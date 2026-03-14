(function() {
    const parent_url = ew.PATH_BASE;
    const cfg = window._welcomePageConfig;
    let fpStartDate, fpEndDate;
    let dashboardData = cfg.dashboardData ?? [];
    let penyaluranProcessSales = cfg.penyaluranProcessSales ?? [];
    let penyaluranProcessKonsinyasi = cfg.penyaluranProcessKonsinyasi ?? [];
    let regionListRaw = cfg.regionListRaw ?? [];
    let plantListRaw = cfg.plantListRaw ?? [];
    var currentUserLevel = cfg.currentUserLevel;
    const tomSelectSettings = {
        create: false,
        sortField: { field: "text", direction: "asc" },
        plugins: ['clear_button']
    };

    const specialCardData = {
            title: 'Distribusi Produk',
            sales: [
                { Name: 'Pertalite', Value: 50 },
                { Name: 'Pertamax', Value: 50 }
            ],
            konsinyasi: []
    };

    function exportData() {
        const btn = $('#exportBtn'); 
        const originalHtml = btn.html(); 

        try {
            const startDateInput = fpStartDate.selectedDates[0];
            const endDateInput = fpEndDate.selectedDates[0];
            const regionSelect = $('#regionFilter').val();
            const plantSelect = $('#plantFilter').val();

            const startDateParam = startDateInput ? formatStringDate(startDateInput) : getTodayString();
            const endDateParam = endDateInput ? formatStringDate(endDateInput) : getTodayString();

            const urlParams = new URLSearchParams();
            urlParams.set('startDate', startDateParam);
            urlParams.set('endDate', endDateParam);
            urlParams.set('region', regionSelect);
            urlParams.set('plant', plantSelect);
            
            const url = `${parent_url}api/LookUpList/ExportDashboard?${urlParams.toString()}`;

            $.ajax({
                url: url,
                type: 'GET',
                xhrFields: {
                    responseType: 'blob'
                },
                beforeSend: function() {
                    btn.prop('disabled', true);
                    btn.html('<i class="bi bi-hourglass-split"></i> Exporting...');
                },
                complete: function() {
                    btn.prop('disabled', false);
                    btn.html(originalHtml);
                },
                success: function(blob, textStatus, jqXHR) {
                    const disposition = jqXHR.getResponseHeader('Content-Disposition');
                    let baseFilename = `SND_Dashboard_Export`; 
                    
                    if (disposition) {
                        const parts = disposition.split(';');
                        const filenamePart = parts.find(part => part.trim().startsWith('filename='));
                        
                        if (filenamePart) {
                            baseFilename = filenamePart.split('=')[1].replace(/"/g, '').trim().replace(/\.xlsx$/i, ''); 
                        }
                    }

                    const now = new Date();
                    const timestamp = `${now.getHours().toString().padStart(2, '0')}${now.getMinutes().toString().padStart(2, '0')}`;
                    
                    const finalFilename = `${baseFilename}_${timestamp}.xlsx`;
                    
                    const a = document.createElement('a');
                    a.style.display = 'none';
                    document.body.appendChild(a);

                    const downloadUrl = window.URL.createObjectURL(blob);
                    a.href = downloadUrl;
                    a.download = finalFilename; 
                    a.click();

                    window.URL.revokeObjectURL(downloadUrl);
                    a.remove();
                },
                error: function(jqXHR, textStatus, errorThrown) {
                    let errorMsg = `Export failed with status: ${jqXHR.status} (${errorThrown})`;

                    if (jqXHR.status === 401) {
                        errorMsg = "Your session may have expired. Please refresh the page and log in again.";
                    }

                    console.error('Export failed:', errorThrown);
                    ew.alert({
                        title: 'Export Failed',
                        text: errorMsg,
                        icon: 'error',
                        confirmButtonColor: '#ba313b'
                    });
                }
            });

        } catch (err) {
            console.error('Export failed:', err);
            ew.alert({
                title: 'Export Failed',
                text: err.message,
                icon: 'error',
                confirmButtonColor: '#ba313b'
            });
            btn.prop('disabled', false);
            btn.html(originalHtml);
        }
    }

    function populateFilterPlants(regionId, defaultPlantId = '') {
        plantSelect.clearOptions();

        const plants = (!regionId || regionId === 'All') 
            ? plantListRaw 
            : plantListRaw.filter(p => p.Region === regionId);

        const plantOptions = [
            { value: 'All', text: 'All' },
            ...plants.map(p => ({ value: p.IdPlant, text: p.Terminal }))
        ];

        plantSelect.addOption(plantOptions);
        plantSelect.refreshOptions(false);
        plantSelect.setValue(defaultPlantId || 'All');
    }

    function populateFilters() {
        const urlParams = new URLSearchParams(window.location.search);
        const regionParam = urlParams.get('region') || 'All';
        const plantParam = urlParams.get('plant') || 'All';

        const regions = [
            { value: 'All', text: 'All' },
            ...(regionListRaw?.map(r => ({ value: r.IdRegion, text: r.Region })) || [])
        ];

        regionSelect = new TomSelect("#regionFilter", {
            ...tomSelectSettings,
            options: regions,
        });

        plantSelect = new TomSelect("#plantFilter", {
            ...tomSelectSettings,
            options: [{ value: 'All', text: 'All' }]
        });

        regionSelect.setValue(regionParam);
        populateFilterPlants(regionParam, plantParam);
    }

    document.getElementById('regionFilter').addEventListener('change', (evt) => {
        const selectedRegion = evt.target.value;
        populateFilterPlants(selectedRegion);
    });

    function getTodayString() {
        const today = new Date();
        return formatStringDate(today);
    }

    function renderCards(data) {
        const container = document.querySelector('.row.g-4');
        const template = document.getElementById('card-template').innerHTML;
        const fragment = document.createDocumentFragment();
        const tempDiv = document.createElement('div');
        let allCardsHtml = '';

        data.forEach(d => {
            let cardHtml = template
                .replace('{{name}}', d.PlanName)
                .replace('{{total}}', d.Total)
                .replace('{{waiting}}', d.Waiting)
                .replace('{{processing}}', d.InProgress)
                .replace('{{complete}}', d.Complete);
            
            switch (d.PlanName) {
                case 'Good House Keeping':
                    cardHtml = cardHtml
                        .replace('<span class="status-label"><i class="bi bi-hourglass-split icon-waiting"></i> Waiting</span>', 
                                 '<span class="status-label"><i class="bi bi-pencil-square icon-complete"></i> Input GHK</span>')
                        .replace('badge-waiting', 'badge-complete')
                        .replace(/<div class="status-item">\s*<span class="status-label"><i class="bi bi-gear-fill[\s\S]*?<\/div>/, '')
                        .replace(/<div class="status-item">\s*<span class="status-label"><i class="bi bi-check-circle-fill[\s\S]*?<\/div>/, '');
                    break;
                case 'Buku Tamu':
                    cardHtml = cardHtml
                        .replace('<span class="status-label"><i class="bi bi-hourglass-split icon-waiting"></i> Waiting</span>', 
                                 '<span class="status-label"><i class="bi bi-door-open-fill icon-PintuUtama"></i> Pintu Utama</span>')
                        .replace('<span class="status-label"><i class="bi bi-gear-fill icon-processing"></i> In Progress</span>', 
                                 '<span class="status-label"><i class="bi bi-building-fill icon-LobbyUtama"></i> Lobby Utama</span>')
                        .replace('<span class="status-label"><i class="bi bi-check-circle-fill icon-complete"></i> Complete</span>', 
                                 '<span class="status-label"><i class="bi bi-slash-circle-fill icon-AreaTerlarang"></i> Area Terlarang</span>')
                        .replace('badge-waiting', 'badge-PintuUtama')
                    break;
                case 'MWT Online':
                    cardHtml = template
                        .replace('{{name}}', d.PlanName)
                        .replace('{{total}}', d.Total)
                        .replace(
                            `<span class="status-label"><i class="bi bi-hourglass-split icon-waiting"></i> Waiting</span>`,
                            `<span class="status-label"><i class="bi bi-gear-fill icon-waiting"></i> On Progress</span>`
                        )
                        .replace(
                            `<span class="status-label"><i class="bi bi-gear-fill icon-processing"></i> In Progress</span>`,
                            `<span class="status-label"><i class="bi bi-clock-fill icon-AreaTerlarang"></i> Back Log</span>`
                        )
                        .replace(
                            `badge-processing`,
                            `badge-AreaTerlarang`
                        )
                        .replace('{{waiting}}', d.Waiting)
                        .replace('{{processing}}', d.InProgress)
                        .replace('{{complete}}', d.Complete);
                    break;
                default:
                    cardHtml = template
                        .replace('{{name}}', d.PlanName)
                        .replace('{{total}}', d.Total)
                        .replace('{{waiting}}', d.Waiting)
                        .replace('{{processing}}', d.InProgress)
                        .replace('{{complete}}', d.Complete);
                    break;
            }

            allCardsHtml += cardHtml;
        });

    container.innerHTML = allCardsHtml;
}

    function renderProductDistribution(penyaluranSalesData, penyaluranKonsinyasiData) {

            const container = document.getElementById('special-card-container');
            const template = document.getElementById('special-card-template').innerHTML;
            
            let cardHtml = template.replace('{{title}}', "Distribusi Produk");
            container.innerHTML = cardHtml;

            const salesColumn = container.querySelector('#sales-column');
            const konsinyasiColumn = container.querySelector('#konsinyasi-column');

            penyaluranSalesData.forEach(item => {
                salesColumn.innerHTML += `<div class="product-item"><span class="product-name">${item.Name}</span><span class="product-value">${item.Value}</span></div>`;
            });

            penyaluranKonsinyasiData.forEach(item => {
                konsinyasiColumn.innerHTML += `<div class="product-item"><span class="product-name">${item.Name}</span><span class="product-value">${item.Value}</span></div>`;
            });
        }

    function formatStringDate(date) {
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const day = String(date.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
    }

    function filterData() {
        const startDateInput = fpStartDate.selectedDates[0];
        const endDateInput = fpEndDate.selectedDates[0];
        const regionSelect = document.getElementById('regionFilter').value;
        const plantSelect = document.getElementById('plantFilter').value;

        const startDateParam = startDateInput ? formatStringDate(startDateInput) : '';
        const endDateParam = endDateInput ? formatStringDate(endDateInput) : '';

        // Reload halaman dengan query string supaya data di server ikut terfilter
        const urlParams = new URLSearchParams(window.location.search);
        urlParams.set('startDate', startDateParam);
        urlParams.set('endDate', endDateParam);
        urlParams.set('region', regionSelect);
        urlParams.set('plant', plantSelect);
        window.location.search = urlParams.toString();
    }

    function resetData() {
        fpStartDate.clear();
        fpEndDate.setDate(getTodayString());
        fpStartDate.set('maxDate', null);
        fpEndDate.set('minDate', null);

        // Reset query string dan reload
        window.location.search = '';
    }

    document.addEventListener('DOMContentLoaded', () => {
        populateFilters();

        const commonConfig = {
            altInput: true,
            altFormat: "M j, Y",
            dateFormat: "Y-m-d",
        };

        fpStartDate = flatpickr("#startDate", {
            ...commonConfig,
            onChange: (dates) => {
                if (dates[0]) fpEndDate.set('minDate', dates[0]);
            },
        });

        fpEndDate = flatpickr("#endDate", {
            ...commonConfig,
            onChange: (dates) => {
                if (dates[0]) fpStartDate.set('maxDate', dates[0]);
            },
        });

        // Set default date end = today
        const urlParams = new URLSearchParams(window.location.search);
        const startDateParam = urlParams.get('startDate') || getTodayString();
        const endDateParam = urlParams.get('endDate') || getTodayString();

        fpStartDate.setDate(startDateParam);
        fpEndDate.setDate(endDateParam);

        renderCards(dashboardData);
        relabelProofOfVisitCard();
        renderProductDistribution(penyaluranProcessSales, penyaluranProcessKonsinyasi);
    });
    
    function relabelProofOfVisitCard() {
        const cards = document.querySelectorAll('.card.status-card');
        cards.forEach(card => {
            const title = card.querySelector('.card-header')?.textContent?.trim();
            if (title === 'Proof of Visit') {
            const items  = card.querySelectorAll('.status-item');
            const labels = card.querySelectorAll('.status-item .status-label');
            const badges = card.querySelectorAll('.status-item .badge');

            if (labels[0]) labels[0].innerHTML =
                '<i class="bi bi-database-fill icon-total" aria-hidden="true"></i> Total Data';
            if (labels[1]) labels[1].innerHTML =
                '<i class="bi bi-exclamation-octagon-fill icon-notok" aria-hidden="true"></i> Tidak Sesuai';
            if (labels[2]) labels[2].innerHTML =
                '<i class="bi bi-patch-check-fill icon-complete" aria-hidden="true"></i> Sesuai';

            if (badges[0]) { badges[0].classList.remove('badge-waiting');    badges[0].classList.add('badge-total'); }
            if (badges[1]) { badges[1].classList.remove('badge-processing'); badges[1].classList.add('badge-notok'); }
            }
        });
    }

    document.getElementById('filterBtn').addEventListener('click', filterData);
    document.getElementById('exportBtn').addEventListener('click', exportData);
    document.getElementById('resetBtn').addEventListener('click', resetData);

    setTimeout(() => {
        $.ajax({
            url: parent_url + "api/LookUpList/CheckIdPositionIsMapped",
            method: "GET",
            success: function(res) {
                if (res.isNotMapped) {
                    ew.alert({
                        title: '',
                        html: 'Anda berhasil login, namun posisi Anda belum memiliki hak akses pada Plant/Region manapun.<br><br><strong>Silakan hubungi admin</strong> melalui email berikut ini <strong>sndone.support@pertamina.com</strong> untuk memperbarui hak akses anda.',
                        icon: 'info',
                        confirmButtonText: 'OK',
                        confirmButtonColor: '#3C6DBD'
                    });
                }
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    }, 400);
})();