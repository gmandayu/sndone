(function () {
    const cfg = window._aktivitasTabelConfig;
    const NoReferensi = cfg.NoReferensi;
    const IdProses = cfg.IdProses;
    const Produk = cfg.Produk;
    const IdAktivitas = cfg.IdAktivitas;
    const NamaAktivitas = cfg.NamaAktivitas;
    const NamaKapal = cfg.NamaKapal;
    const NamaProduk = cfg.NamaProduk;
    const NamaProses = cfg.NamaProses;
    const LabelProduk = cfg.LabelProduk;
    const IdTemplateAktivitas = cfg.IdTemplateAktivitas;
    const StatusAktivitas = cfg.StatusAktivitas;
    const TableAnak = cfg.TableAnak;
    const isEditable = cfg.isEditable;
    const tangkiList = cfg.tangkiList;
    const produkList = cfg.produkList;
    const parent_url = ew.PATH_BASE;

    let jsonData = cfg.jsonData;
    let formList = cfg.formList;
    let TipeProses = cfg.TipeProses;
    let TipeProsesView = cfg.TipeProses;
    let tempDataAdd = [], tempDataDelete = [], tempDataUpdate = [];
    let formMode = "add", confirmMode = "", tempStatus = "";
    let selectedIdToDelete = null, selectedUpdateId = null;
    let tangkiHasProduk = true;
    let flagLogbookFromPenerimaan = 0;
    let pendingNewData = null; // menyimpan data sementara saat meter mismatch
    let pending388 = null;
    const userLevel = cfg.userLevel;
    let currentStatusAktivitas = "";
    $(document).on('click', '#btn-cancel', function () {
        window.location.href = `${parent_url}AktivitasList?cmd=search&x_IdProses%5B%5D=${IdProses}&search=&searchtype=`;
    });

    let iconProses = "";
    if (TipeProses == "Penerimaan" || TipeProses == "PenerimaanSTSBBM" || TipeProses == "PenerimaanSTSLPG" ||
        TipeProses == "PenerimaanPipa" || TipeProses == "PenerimaanSalesPipa" || TipeProses == "PenerimaanRTW" ||
        TipeProses == "PenerimaanTruck" || TipeProses == "PenerimaanPipaRefinery") {
        TipeProses = "Penerimaan";
        TipeProsesView = "Penerimaan";
        iconProses = "fa-box-open";
    } else if (TipeProses == "Penyaluran" || TipeProses == "PenyaluranTasNgs" || TipeProses == "PenyaluranTruck" ||
        TipeProses == "PenyaluranLPGTASNGS" || TipeProses == "PenyaluranKonsinyasiSTSBBM" ||
        TipeProses == "PenyaluranKonsinyasiSTSLPG" || TipeProses == "PenyaluranPipa" || TipeProses == "PenyaluranSalesPipa" ||
        TipeProses == "PenyaluranPipaLPG" || TipeProses == "PenyaluranKonsinyasiRTW" || TipeProses == "PenyaluranPipaJarakDekat") {
        TipeProses = "Penyaluran";
        TipeProsesView = "Proses Penyaluran";
        iconProses = "fa-truck-fast";
    } else if (TipeProses == "RencanaPenyaluran" || TipeProses == "RencanaPenyaluranLPG" || TipeProses == "RencanaPenyaluranPipa") {
        TipeProses = "RencanaPenyaluran";
        TipeProsesView = "Rencana & Realisasi Penyaluran";
        iconProses = "fa-solid fa-clipboard-list";
    } else if (TipeProses == "SamplingLabTest") {
        TipeProsesView = "Sampling Lab Test";
        iconProses = "fa-flask";
    } else if (TipeProses == "Penimbunan" || TipeProses == "PenyimpananPenerimaanLPG" ||
        TipeProses == "PenyimpananPenerimaanSTSBBM" || TipeProses == "PenyimpananPenerimaanLPGSTS" ||
        TipeProses == "PenyimpananPenerimaanPipa" || TipeProses == "PenyimpananPenerimaanPipaLPG" ||
        TipeProses == "PenyimpananPenerimaanRTW" || TipeProses == "PenyimpananPenerimaanTruck") {
        TipeProses = "Penimbunan";
        TipeProsesView = "Proses Penerimaan";
        iconProses = "fa-oil-can";
    } else if (TipeProses == "PenimbunanPenyaluran" || TipeProses == "PenimbunanPenyaluranLPG" ||
        TipeProses == "PenyimpananPenyaluranSalesSTSBBM" || TipeProses == "PenyimpananPenyaluranKonsinyasiSTSBBM" ||
        TipeProses == "PenyimpananPenyaluranSalesPipa" || TipeProses == "PenyimpananPenyaluranKonsinyasiPipa" ||
        TipeProses == "PenyimpananPenyaluranSalesSTSLPG" || TipeProses == "PenyimpananPenyaluranKonsinyasiSTSLPG" || TipeProses == "PenyimpananPenyaluranSalesRTW") {
        TipeProses = "PenimbunanPenyaluran";
        TipeProsesView = "Proses Penyaluran";
        iconProses = "fa-route";
    } else if (TipeProses == "ClosingStock" || TipeProses == "ClosingStockSTSBBM" || TipeProses == "ClosingStockSTSLPG") {
        TipeProses = "ClosingStock";
        TipeProsesView = "Closing Stock";
        iconProses = "fa-inbox";
    } else if (['PenyimpananPenyaluranKonsinyasiRTW', 'PenyimpananPenyaluranKonsinyasi'].includes(TipeProses)) {
        TipeProses = 'PenimbunanPenyaluran';
        TipeProsesView = 'Proses Penyaluran';
        iconProses = 'fa-route';
    } else if (['PenyaluranKonsinyasiTruck'].includes(TipeProses)) {
        TipeProses = "Penyaluran";
        TipeProsesView = "Proses Penyaluran";
        iconProses = "fa-truck-fast";
    }

    // global helpers
    const $f = name => ($(`#${name}`).length ? $(`#${name}`) : $(`#x_${name}`));

    const bulk388 = (() => {
        let gerbongKetelMap = {};
        let meterAkhirManual = false;

        function initMap() {
            const list = cfg.gerbongKetelList;
            gerbongKetelMap = {};
            (list || []).forEach(x => (gerbongKetelMap[String(x.NoKetel)] = x.Quantity));
        }

        function initSelect2($ctx) {
            $ctx.find('select.select2').select2({
                dropdownParent: $('#modal-popup'),
                width: '100%',
                placeholder: 'Pilih Nomor Gerbong Ketel',
                allowClear: false,
                minimumInputLength: 0
            });
        }

        function toggleAddBtn() {
            $('#btn-add-row-388').prop('disabled', $('#tbl-388 tbody tr').length >= 3);
        }

        function sumQty() {
            let s = 0;
            $('#tbl-388 tbody .Quantity').each(function () {
                s += parseFloat($(this).val()) || 0;
            });
            return s;
        }

        function recalc() {
            const meterAwal = parseFloat($f('MeterAwal').val()) || 0;
            const totalGK = sumQty();

            let meterAkhir = parseFloat($f('MeterAkhir').val()) || 0;
            if (!meterAkhirManual) meterAkhir = meterAwal + totalGK;

            const totalMeter = meterAkhir - meterAwal;
            const selisih = totalMeter - totalGK;

            // tambahkan modal peringatan jika meter akhir tidak sama dengan (meter awal + total GK)

            $f('TotalGK').val(totalGK);
            $f('MeterAkhir').val(meterAkhir);
            $f('Total').val(totalMeter);
            $f('Selisih').val(selisih);
        }

        function addRow(no = '', qty = '', t2 = '') {
            if ($('#tbl-388 tbody tr').length >= 3) return;
            const tpl = document.getElementById('row388Template');
            const $row = $(tpl.content.cloneNode(true)).find('tr');

            $row.find('.NomorGerbongKertel').val(no);
            $row.find('.Quantity').val(qty);
            $row.find('.HasilPengukuranT2').val(t2);

            $('#tbl-388 tbody').append($row);
            initSelect2($row);
            toggleAddBtn();
            recalc();
        }

        function reset(rows = []) {
            $('#tbl-388 tbody').empty();
            (rows.length ? rows : [{ no: '', qty: '', t2: '' }]).forEach(r => addRow(r.no, r.qty, r.t2));
            toggleAddBtn();
            recalc();
        }

        function bindEvents() {
            $(document).off('.bulk388');

            $(document).on('click.bulk388', '#btn-add-row-388', () => addRow());

            $(document).on('click.bulk388', '.btn-del-row-388', function () {
                $(this).closest('tr').remove();
                toggleAddBtn();
                recalc();
            });

            $(document).on('change.bulk388', '#tbl-388 .NomorGerbongKertel', function () {
                const no = String($(this).val() || '');
                const $row = $(this).closest('tr');
                $row.find('.Quantity').val(gerbongKetelMap[no] ?? '').trigger('change');
            });

            $(document).on('input.bulk388 change.bulk388', '#tbl-388 .Quantity, #MeterAwal, #x_MeterAwal', recalc);

            $(document).on('input.bulk388 change.bulk388', '#MeterAkhir, #x_MeterAkhir', function () {
                const v = $(this).val();
                meterAkhirManual = v !== '' && v !== null && !isNaN(parseFloat(v));
                recalc();
            });

            $(document).on('change.bulk388', '#NoMeter, #Produk', function () {
                const noMeter = $('#NoMeter').val();
                const noProduk = $('#Produk').val();
                GetMeterAwalBayNumber('', noMeter);
            });
        }

        function readRowsValidated() {
            const rows = [];
            let ok = true;

            $('#tbl-388 tbody tr').each(function () {
                const $r = $(this);
                const no = ($r.find('.NomorGerbongKertel').val() || '').trim();
                const qty = ($r.find('.Quantity').val() || '').trim();
                const t2 = ($r.find('.HasilPengukuranT2').val() || '').trim();

                if (!no && !qty) return;

                const req = [[$r.find('.NomorGerbongKertel'), no], [$r.find('.Quantity'), qty]];
                req.forEach(([el, v]) => {
                    el.toggleClass('is-invalid', !v);
                    if (!v) ok = false;
                });

                rows.push({ no, qty, t2 });
            });
            return { ok, rows };
        }

        function buildItemForGrid() {
            recalc();
            const { ok, rows } = readRowsValidated();
            if (!ok) return { error: 'Mohon lengkapi semua field wajib pada setiap baris.' };
            if (!rows.length) return { error: 'Tidak ada baris valid untuk ditambahkan.' };

            const meterAwal = parseFloat($f('MeterAwal').val()) || 0;
            const meterAkhir = parseFloat($f('MeterAkhir').val()) || 0;
            const totalGK = rows.reduce((a, r) => a + (parseFloat(r.qty) || 0), 0);
            const totalMeter = parseFloat($f('Total').val()) || meterAkhir - meterAwal;
            const selisih = parseFloat($f('Selisih').val()) || totalMeter - totalGK;

            return {
                item: {
                    id: crypto.randomUUID(),
                    Produk: typeof Produk !== 'undefined' ? Produk : $f('Produk').val() || '',
                    PICPengisian: $f('PICPengisian').val() || '',
                    NoMeter: $f('NoMeter').val() || '',

                    NomorGerbongKertel: rows[0]?.no || '',
                    Quantity: rows[0]?.qty || '',
                    HasilPengukuranT2: rows[0]?.t2 || '',

                    NomorGerbongKertel2: rows[1]?.no || '',
                    Quantity2: rows[1]?.qty || '',
                    HasilPengukuranT2_2: rows[1]?.t2 || '',

                    NomorGerbongKertel3: rows[2]?.no || '',
                    Quantity3: rows[2]?.qty || '',
                    HasilPengukuranT2_3: rows[2]?.t2 || '',

                    MeterAwal: meterAwal,
                    MeterAkhir: meterAkhir,
                    TotalGK: totalGK,
                    Total: totalMeter,
                    Selisih: selisih,
                },
            };
        }
        function openForAdd() {
            initMap();
            meterAkhirManual = false;
            bindEvents();
            reset();
        }

        function openForUpdate(rowData) {
            initMap();
            // treat existing MeterAkhir as "manual" unless user clears it
            meterAkhirManual = true;
            const rows = [];
            if (rowData.NomorGerbongKertel || rowData.Quantity || rowData.HasilPengukuranT2)
                rows.push({ no: rowData.NomorGerbongKertel, qty: rowData.Quantity, t2: rowData.HasilPengukuranT2 });
            if (rowData.NomorGerbongKertel2 || rowData.Quantity2 || rowData.HasilPengukuranT2_2)
                rows.push({ no: rowData.NomorGerbongKertel2, qty: rowData.Quantity2, t2: rowData.HasilPengukuranT2_2 });
            if (rowData.NomorGerbongKertel3 || rowData.Quantity3 || rowData.HasilPengukuranT2_3)
                rows.push({ no: rowData.NomorGerbongKertel3, qty: rowData.Quantity3, t2: rowData.HasilPengukuranT2_3 });

            bindEvents();
            reset(rows.length ? rows : [{ no: '', qty: '', t2: '' }]);

            $f('MeterAwal').val(rowData.MeterAwal || '0');
            $f('MeterAkhir').val(rowData.MeterAkhir || '0');
            recalc();
        }

        function eventBayNumber() {
            const Volume = parseFloat($('#Volume').val()) || 0;
            const Quantity = parseFloat($('#Quantity').val()) || 0;
            const MeterAwal = parseFloat($('#MeterAwal').val()) || 0;

            $('#MeterAkhir').val(Volume + Quantity + MeterAwal);
        }
        function GetMeterAwalBayNumber(BayNumber, NoMeter) {
            $.ajax({
                url: parent_url + `api/LookUpList/GetMeterAwalBayNumber?TableAnak=${TableAnak}&NoReferensi=${NoReferensi}&BayNumber=${BayNumber}&NoMeter=${NoMeter}`,
                type: 'GET',
                beforeSend: function () {
                    showLoading();
                },
                success: function (res) {
                    if (res.success && res.MeterAkhir) $('#MeterAwal').val(res.MeterAkhir);
                    else $('#MeterAwal').val('0');
                    // eventBayNumber();
                    recalc();
                },
                error: function (xhr, status, error) {
                    console.error('API call failed:', status, error);
                },
                complete: function () {
                    hideLoading();
                }
            });
        }

        return { openForAdd, openForUpdate, buildItemForGrid, recalc };
    })();

    function filterByFormList(item) {
        const allowedFields = new Set(
            formList.map(([label, type, name]) => name)
        );
        allowedFields.add("id");

        // console.log("Allowed fields:", allowedFields);
        return Object.fromEntries(
            Object.entries(item).filter(([key]) => allowedFields.has(key))
        );
    }

    // main
    $(document).ready(function () {
        $('#nomor-tipe-proses').text('Nomor ' + TipeProsesView);

        var steps = [
            { number: 1, label: TipeProsesView, url: `${parent_url + TipeProses}List`, icon: iconProses },
            { number: 2, label: "Proses", url: `${parent_url}ProsesList?cmd=search&x_IdReferensi%5B%5D=${NoReferensi}&search=&searchtype=`, icon: "fa-gears" },
            { number: 3, label: "Aktivitas", url: `${parent_url}AktivitasList?cmd=search&x_IdProses%5B%5D=${IdProses}&search=&searchtype=`, icon: "fa-list-check" },
            { number: 4, label: NamaAktivitas, url: '', icon: "fa-file-circle-check" }
        ];
        var currentStep = 4;
        var $stepperWrapper = $('<div class="d-flex border-bottom border-2 pb-2"><div class="stepper"></div></div>');
        var $stepper = $stepperWrapper.find(".stepper");
        steps.forEach(function (step, i) {
            var isActive = step.number === currentStep;
            var isCompleted = step.number < currentStep;
            var stepClass = isActive ? "active" : isCompleted ? "completed" : "";
            var icon, labelContent, html;
            if (isActive) {
                icon = `<div class="step-icon bg-success">${step.number}</div>`;
                labelContent = `<div class="step-label"><p class="text-success mb-1"><i class="fa-solid ${step.icon} me-1 text-success"></i> ${step.label}</p></div>`;
                html = `<div class="step ${stepClass} text-success">${icon}${labelContent}</div>`;
            } else if (isCompleted) {
                icon = `<div class="step-icon" style="background: #3c6dbd;">${step.number}</div>`;
                labelContent = `<div class="step-label"><a href="${step.url}" class="text-primary"><i class="fa-solid ${step.icon} me-1"></i>${step.label}</a></div>`;
                html = `<div class="step ${stepClass}">${icon}${labelContent}</div>`;
            } else {
                icon = `<div class="step-icon">${step.number}</div>`;
                labelContent = `<div class="step-label-not-active"><p style="margin: 0;"><i class="fa-solid ${step.icon} me-1"></i>${step.label}</p></div>`;
                html = `<div class="step ${stepClass} text-secondary">${icon}${labelContent}</div>`;
            }
            $stepper.append(html);
        });
        $(".content-header .container-fluid .row").append($stepperWrapper);

        $(document).on('click', 'button[expand-log]', function () {
            const $btn = $(this);
            const isExpanded = $btn.attr('expand-log') === 'true';
            const $row = $('#log-table-row');
            const $wrapper = $('#log-table-wrapper');
            const $caret = $btn.find('.caret-icon');
            if (!isExpanded) {
                $btn.attr('expand-log', 'true');
                $row.removeClass('d-none');
                setTimeout(() => {
                    $wrapper.css({
                        maxHeight: '500px'
                    });
                }, 10);
                $caret.removeClass('rotate-right').addClass('rotate-down');
            } else {
                $btn.attr('expand-log', 'false');
                $wrapper.css({
                    maxHeight: '0'
                });
                setTimeout(() => {
                    $row.addClass('d-none');
                }, 600);
                $caret.removeClass('rotate-down').addClass('rotate-right');
            }
        });

        function generateColumnDefs(formList) {
            const visibleFields = formList.filter(([label, type, field]) => type !== 'hidden' && field !== 'ProdukAll' && field != "NomorGerbongKertelForUpdate");

            const dynamicCols = visibleFields.map(([label, type, field]) => {
                let colDef = {
                    headerName: label,
                    field: field,
                    minWidth: 300
                };

                if (type === 'datetime-local' || field.includes('Tanggal')) {
                    colDef.valueFormatter = function (params) {
                        if (!params.value) return '';
                        const date = new Date(params.value);
                        const yyyy = date.getFullYear();
                        const mm = String(date.getMonth() + 1).padStart(2, '0');
                        const dd = String(date.getDate()).padStart(2, '0');
                        const hh = String(date.getHours()).padStart(2, '0');
                        const mi = String(date.getMinutes()).padStart(2, '0');
                        const ss = String(date.getSeconds()).padStart(2, '0');
                        return `${yyyy}/${mm}/${dd} ${hh}:${mi}:${ss}`;
                    };
                }

                if (field.includes('Produk') && type.includes('select')) {
                    colDef.valueGetter = (params) =>
                        `${params.data.NoProduk || ''} - ${params.data.NamaProduk || ''}`;
                }

                if (field.includes('Plant') && type.includes('select')) {
                    colDef.valueGetter = (params) =>
                        `${params.data.Plant || ''} - ${params.data.Nama_Terminal || ''}`;
                }

                if (field.includes('IsQualityActive')) {
                    colDef.valueGetter = (params) => {
                        if (params.data.IsQualityActive == '1') {
                            return 'On';
                        } else if (params.data.IsQualityActive == '0') {
                            return 'Off';
                        }
                    }
                }

                if (field.includes('InLineBlending')) {
                    colDef.valueGetter = (params) => {
                        const checked = params.data.InLineBlending || 'No';
                        const value = checked == '1' ? 'Yes' : 'No';

                        return value;
                    };
                    colDef.minWidth = 150;
                    colDef.width = 150;
                }

                if (field.includes('Tangki2') && type.includes('select')) {
                    colDef.valueGetter = (params) => {
                        const sloc = params.data.Sloc2 || '';
                        const seq = params.data.SeqTangki2 || '';
                        const terminal = params.data.NamaTerminal2 || '';
                        const mid = seq ? ` - ${seq}` : '';

                        return `${sloc}${mid} - ${terminal}`;
                    };
                } else if (field.includes('Tangki') && type.includes('select')) {
                    colDef.valueGetter = (params) => {
                        const sloc = params.data.Sloc || '';
                        const seq = params.data.SeqTangki || '';
                        const terminal = params.data.NamaTerminal || '';
                        const mid = seq ? ` - ${seq}` : '';

                        return `${sloc}${mid} - ${terminal}`;
                    };
                } else if (field.includes('Tangki')) {
                    colDef.valueGetter = (params) => {
                        const sloc = params.data.Sloc || '';
                        const seq = params.data.SeqTangki || '';
                        const terminal = params.data.NamaTerminal || '';
                        const mid = seq ? ` - ${seq}` : '';

                        return `${sloc}${mid} - ${terminal}`;
                    };
                }

                return colDef;
            });

            return [
                {
                    headerName: 'No.',
                    valueGetter: 'node.rowIndex + 1',
                    width: 55,
                    filter: false
                },
                {
                    headerName: '',
                    width: 100,
                    filter: false,
                    cellRenderer: function (params) {
                        if (typeof StatusAktivitas !== "undefined" && StatusAktivitas !== "Completed Edit") {
                            return `
                                <button class="btn text-warning btn-update p-0 fs-5 me-2" data-id="${params.data.id}">
                                    <i class="fa-solid fa-pen"></i>
                                </button>
                                <button class="btn text-danger btn-delete p-0 fs-5" data-id="${params.data.id}">
                                    <i class="fa-solid fa-trash"></i>
                                </button>
                            `;
                        }
                        return '';
                    }
                },
                ...dynamicCols
            ];
        }

        let dataGridApi;
        let dataGridOptions;
        const columnDefs = generateColumnDefs(formList);

        // View-only: ganti semua tampilan "Volume" menjadi "Quantity" (hapus satuan)
        function replaceVolumeWithQuantity(text) {
            if (!text) return text;
            return text
                .replace(/\bVolume KL Obs\b/gi, 'Quantity')
                .replace(/\bVolume\b/gi, 'Quantity')
                .replace(/\(KL.*?\)/gi, '') // hilangkan (KL) atau variasinya
                .trim();
        }

        // Ubah header volume menjadi Quantity
        columnDefs.forEach(col => {
            if (col.headerName) {
                col.headerName = replaceVolumeWithQuantity(col.headerName);
            }
        });

        dataGridOptions = {
            rowData: jsonData,
            columnDefs: columnDefs,
            defaultColDef: {
                sortable: false,
                suppressMovable: true,
                filter: true,
                resizable: true,
                cellClassRules: {
                    'bg-success text-white': (params) => {
                        if (params.colDef.field === 'Density') {
                            const produk = params.data.Produk;
                            const densityValue = parseFloat(params.value);

                            const produkInfo = produkList.find(p => p.NoProduk === produk);
                            if (!produkInfo || isNaN(densityValue)) return false;

                            const min = parseFloat(produkInfo.DensityMin);
                            const max = parseFloat(produkInfo.DensityMax);

                            if (isNaN(min) || isNaN(max)) return true;

                            return densityValue >= min && densityValue <= max;
                        }

                        if (params.colDef.field === 'SelisihWaktu') {
                            const val = parseFloat(params.value);
                            if (isNaN(val)) return false;

                            const diff = Math.abs(val);

                            const sop = params.data?.TanggalJamSOP;
                            if (!sop) return false;

                            const sopTime = new Date(sop).getTime();
                            if (!isFinite(sopTime)) return false;

                            const startTime = new Date(cfg.startDate).getTime();
                            if (!isFinite(startTime)) return false;

                            const isFirstRow = params.node?.rowIndex === 0;

                            if (IdTemplateAktivitas === "432" && isFirstRow && val < 0) {
                                return true;
                            }

                            const menitSejakStart = Math.round((sopTime - startTime) / 60000);

                            if (menitSejakStart <= 60) {
                                return diff <= 5;
                            }

                            return diff <= 10;
                        }

                        return false;
                    },
                    'mark-yellow': (params) => {
                        if (params.colDef.field === 'Density') {
                            const produk = params.data.Produk;
                            const densityValue = parseFloat(params.value);

                            const produkInfo = produkList.find(p => p.NoProduk === produk);
                            if (!produkInfo || isNaN(densityValue)) return false;

                            const min = parseFloat(produkInfo.DensityMin);
                            const max = parseFloat(produkInfo.DensityMax);

                            if (isNaN(min) || isNaN(max)) return false;

                            return densityValue < min || densityValue > max;
                        }

                        if (params.colDef.field === 'SelisihWaktu') {
                            const val = parseFloat(params.value);
                            if (isNaN(val)) return false;

                            const diff = Math.abs(val);

                            const sop = params.data?.TanggalJamSOP;
                            if (!sop) return false;

                            const sopTime = new Date(sop).getTime();
                            if (!isFinite(sopTime)) return false;

                            const startTime = new Date(cfg.startDate).getTime();
                            if (!isFinite(startTime)) return false;

                            const isFirstRow = params.node?.rowIndex === 0;

                            if (IdTemplateAktivitas === "432" && isFirstRow && val < 0) {
                                return false;
                            }

                            const menitSejakStart = Math.round((sopTime - startTime) / 60000);

                            if (menitSejakStart <= 60) {
                                return diff > 5 && diff <= 10;
                            }

                            return diff > 10 && diff <= 15;
                        }

                        return false;
                    },
                    'bg-danger text-white': (params) => {
                        if (params.colDef.field === 'SelisihWaktu') {
                            const val = parseFloat(params.value);
                            if (isNaN(val)) return false;

                            const diff = Math.abs(val);

                            const sop = params.data?.TanggalJamSOP;
                            if (!sop) return false;

                            const sopTime = new Date(sop).getTime();
                            if (!isFinite(sopTime)) return false;

                            const startTime = new Date(cfg.startDate).getTime();
                            if (!isFinite(startTime)) return false;

                            const isFirstRow = params.node?.rowIndex === 0;

                            if (IdTemplateAktivitas === "432" && isFirstRow && val < 0) {
                                return false;
                            }

                            const menitSejakStart = Math.round((sopTime - startTime) / 60000);

                            if (menitSejakStart <= 60) {
                                return diff > 10;
                            }

                            return diff > 15;
                        }

                        return false;
                    }
                }
            },
            // rowSelection: 'multiple',
            // suppressRowClickSelection: true,
            pagination: true,
            paginationPageSizeSelector: [10, 20, 50, 100],
            paginationPageSize: 10,
            onGridReady: function (params) {
                dataGridApi = params.api;
            },
            getRowId: (params) => params.data.id,
            getRowClass: (params) => {
                return params.node.rowIndex % 2 === 1 ? 'stripe' : '';
            }
        };

        const dataGridElement = document.querySelector('#dataGrid');
        agGrid.createGrid(dataGridElement, dataGridOptions);

        const gridOptionsLog = {
            rowData: cfg.jsonLog,
            columnDefs: [
                {
                    headerName: 'No.',
                    valueGetter: 'node.rowIndex + 1',
                    width: 80,
                    filter: false
                },
                {
                    headerName: 'Aktivitas',
                    field: 'Aktivitas',
                    flex: 1
                },
                {
                    headerName: 'Username',
                    field: 'Username',
                    flex: 1
                },
                {
                    headerName: 'Status Aktivitas',
                    field: 'StatusAktivitas',
                    flex: 1
                },
                {
                    headerName: 'Tanggal',
                    field: 'Tanggal',
                    flex: 1,
                    valueFormatter: function (params) {
                        if (!params.value) return '';
                        const date = new Date(params.value);
                        const yyyy = date.getFullYear();
                        const mm = String(date.getMonth() + 1).padStart(2, '0');
                        const dd = String(date.getDate()).padStart(2, '0');
                        const hh = String(date.getHours()).padStart(2, '0');
                        const mi = String(date.getMinutes()).padStart(2, '0');
                        const ss = String(date.getSeconds()).padStart(2, '0');
                        return `${yyyy}/${mm}/${dd} ${hh}:${mi}:${ss}`;
                    }
                },
                {
                    headerName: 'Catatan',
                    field: 'Catatan',
                    flex: 1
                }
            ],
            defaultColDef: {
                sortable: false,
                suppressMovable: true,
                filter: true,
                resizable: true
            },
            // rowSelection: 'multiple',
            // suppressRowClickSelection: true,
            pagination: true,
            paginationPageSizeSelector: [10, 20, 50, 100],
            paginationPageSize: 10,
            getRowClass: (params) => {
                return params.node.rowIndex % 2 === 1 ? 'stripe' : '';
            }
        };
        const logGridElement = document.querySelector('#logGrid');
        agGrid.createGrid(logGridElement, gridOptionsLog);

        function showLoading() {
            $('#loading-spinner').css('display', 'flex');
            $('#loading-spinner').fadeIn();
        }

        function handleFormSubmission(newData) {
            // set product fields if available
            const produkInput = $('[name="Produk"]');
            if (produkInput.length) {
                const selectedText = produkInput.find('option:selected').text();
                const selectedValue = produkInput.val();
                const [noProduk, namaProduk] = selectedText.split(' - ');
                newData.NoProduk = noProduk?.trim() || '';
                newData.NamaProduk = namaProduk?.trim() || '';
                newData.Produk = selectedValue;
            }

            // set tank fields if available
            const tangkiInput = $('[name="NomorTangki"], [name="Nomor_Tangki"]');
            if (tangkiInput.length) {
                const selectedText = tangkiInput.find('option:selected').text().trim();
                let parts = selectedText.split(' - ').map(p => p.trim());
                parts = parts.filter(p => p !== '');

                const sloc = parts[0] || '';
                let seq = '';
                let terminal = '';

                if (parts.length === 3) {
                    seq = parts[1] || '';
                    terminal = parts[2] || '';
                } else if (parts.length === 2) {
                    seq = '';
                    terminal = parts[1] || '';
                }

                newData.Sloc = sloc;
                newData.SeqTangki = seq;
                newData.NamaTerminal = terminal;
            }

            const tangkiInput2 = $('[name="NomorTangki2"]');
            if (tangkiInput2.length) {
                const selectedText = tangkiInput2.find('option:selected').text().trim();
                let parts = selectedText.split(' - ').map(p => p.trim());
                parts = parts.filter(p => p !== '');

                const sloc = parts[0] || '';
                let seq = '';
                let terminal = '';

                if (parts.length === 3) {
                    seq = parts[1] || '';
                    terminal = parts[2] || '';
                } else if (parts.length === 2) {
                    seq = '';
                    terminal = parts[1] || '';
                }

                newData.Sloc2 = sloc;
                newData.SeqTangki2 = seq;
                newData.NamaTerminal2 = terminal;
            }

            // insert or update the grid and temp arrays
            if (formMode === 'add') {
                if (dataGridApi) {
                    dataGridApi.applyTransaction({ add: [newData] });
                }
                tempDataAdd.push(newData);
            } else {
                selectedUpdateId = newData.id;
                const rowNode = dataGridApi.getRowNode(newData.id);
                if (rowNode && dataGridApi) {
                    Object.assign(rowNode.data, newData);
                    dataGridApi.applyTransaction({ update: [rowNode.data] });
                }

                const indexInAdd = tempDataAdd.findIndex(item => item.id === newData.id);
                const indexInUpdate = tempDataUpdate.findIndex(item => item.id === newData.id);

                if (indexInAdd !== -1) {
                    tempDataAdd[indexInAdd] = newData;
                } else if (indexInUpdate !== -1) {
                    tempDataUpdate[indexInUpdate] = newData;
                } else {
                    tempDataUpdate.push(newData);
                }
            }

            // reset and close the modal
            $('#form-input-modal')[0].reset();
            $('#modal-popup').modal('hide');
            formMode = 'add';
            selectedUpdateId = null;
        }

        function apply388Transaction(p) {
            if (!p || !p.item) return;
            const cleanItem = p.item;
            if (p.mode === 'update') {
                const id = String(p.id);
                const rowNode = dataGridApi.getRowNode(id);
                if (!rowNode) return ew.alert('Data tidak ditemukan di grid untuk diupdate.');

                const updatedRow = { ...rowNode.data, ...cleanItem, id };
                rowNode.setData(updatedRow);

                const idxAdd = tempDataAdd.findIndex(x => String(x.id) === id);
                if (idxAdd !== -1) tempDataAdd[idxAdd] = updatedRow;
                else {
                    const idxUpd = tempDataUpdate.findIndex(x => String(x.id) === id);
                    if (idxUpd !== -1) tempDataUpdate[idxUpd] = updatedRow;
                    else tempDataUpdate.push(updatedRow);
                }
            } else {
                dataGridApi.applyTransaction({ add: [cleanItem] });
                tempDataAdd.push(cleanItem);
            }

            $('#modal-popup').modal('hide');
            formMode = 'add';
            selectedUpdateId = null;
        }

        function hideLoading() {
            $('#loading-spinner').css('display', 'none');
            $('#loading-spinner').fadeOut();
        }

        $('#modal-popup').on('hidden.bs.modal', function () {
            $('#form-input-modal')[0].reset();
            $('[type="checkbox"]').val('').trigger('change');
        });

        $('#modal-popup').on('shown.bs.modal', function () {
            formList.forEach(([label, type, field]) => {
                if (type.includes('select')) {
                    $(`#${field}`).select2({
                        dropdownParent: $('#modal-popup'),
                        placeholder: `-- ${label} --`,
                        allowClear: true
                    });
                }
            });
            formList.forEach(([label, type, field]) => {
                const $labelEl = $(`#row_${field} .col-2.fw-bold`);
                if ($labelEl.length) {
                    $labelEl.text(replaceVolumeWithQuantity($labelEl.text()));
                }
            });
            if (IdTemplateAktivitas == "180" && formMode === 'add' && NoReferensi) {
                getTimbanganAwal(NoReferensi);
            }
            if (IdTemplateAktivitas == "218" || IdTemplateAktivitas == "259" && formMode === 'add' && NoReferensi) {
                getLastQuantityAkhir(NoReferensi);
                getProdukPenimbunanPenyaluran(NoReferensi);
            }
        });

        $('#btn-add-modal').on('click', function () {
            formMode = 'add';

            if (IdTemplateAktivitas === '388') {
                // console.log('open form 388 for add');
                $('#bulk-388').show();
                $('#row_NomorGerbongKertel, #row_Quantity, #row_HasilPengukuranT2').hide();
                bulk388.openForAdd();
            }

            if (IdTemplateAktivitas === '402') {
                formList.forEach(item => {
                    const [label, type, name] = item;

                    if (type === 'select' && name === "NomorGerbongKertel") {
                        $('select#NomorGerbongKertel').prop('hidden', false);
                        $('select#NomorGerbongKertel').attr('name', 'NomorGerbongKertel');
                        $('select#NomorGerbongKertel').prop('required', true);
                        $('#row_NomorGerbongKertel').show();
                        $('select#NomorGerbongKertelForUpdate').attr('name', 'NomorGerbongKertelForUpdate');
                    } else if (type === 'text' && name === "NomorGerbongKertelForUpdate") {
                        $('input#NomorGerbongKertelForUpdate').prop('hidden', true);
                        $('input#NomorGerbongKertelForUpdate').prop('required', false);
                        $('input#NomorGerbongKertelForUpdate').removeAttr('name');
                        $('#row_NomorGerbongKertelForUpdate').hide();
                    }
                });
            }

            if ((IdTemplateAktivitas == "155" || IdTemplateAktivitas == "114" || IdTemplateAktivitas == "222" || IdTemplateAktivitas == "281" || IdTemplateAktivitas == "340") && flagLogbookFromPenerimaan === 0) {
                if (IdTemplateAktivitas == "155" || IdTemplateAktivitas == "114" || IdTemplateAktivitas == "222" || IdTemplateAktivitas == "281" || IdTemplateAktivitas == "340") {
                    $('#logbook-add-confirm-body').text('Apakah anda ingin mengambil data dari penyaluran atau menambahkan data secara manual ?');
                }
                $('#logbookPenerimaanConfirmation').modal('show');
                return;
            }

            if (NamaAktivitas.includes('Form Input')) {
                $('#modal-popupLabel').text(NamaAktivitas.replace('Form Input', 'Tambah Data'));
            } else {
                $('#modal-popupLabel').text(`Tambah Data ${NamaAktivitas}`);
            }

            $('#form-input-modal button[type="submit"]')
                .html('<i class="fas fa-plus me-1"></i> Add')
                .removeClass('btn-primary').addClass('btn-success');
            $('#modal-popup').modal('show');
        });

        $('#logbookFromPenerimaan').on('click', function () {
            flagLogbookFromPenerimaan = 1;

            $('#logbookFromPenerimaan').text('Proses mengambil data...');
            $('#logbookFromPenerimaan').prop('disabled', true);
            $('#logbookAddManually').prop('disabled', true);

            if (IdTemplateAktivitas == "34" || IdTemplateAktivitas == "148" || IdTemplateAktivitas == "209" || IdTemplateAktivitas == "250" || IdTemplateAktivitas == "325" || IdTemplateAktivitas == "361" || IdTemplateAktivitas == "394") {
                fetchAndAddSubAktivitasLogbookPenerimaanToGrid(IdAktivitas);
            } else if (IdTemplateAktivitas == "114" || IdTemplateAktivitas == "155" || IdTemplateAktivitas == "222" || IdTemplateAktivitas == "281" || IdTemplateAktivitas == "340") {
                fetchAndAddSubAktivitasLogbookPenyimpananToGrid(IdAktivitas);
            }
        });

        $('#logbookAddManually').on('click', function () {
            formMode = 'add';

            $('#logbookPenerimaanConfirmation').modal('hide');
            flagLogbookFromPenerimaan = 1;

            $('#logbookPenerimaanConfirmation').one('hidden.bs.modal', function () {
                if (NamaAktivitas.includes('Form Input')) {
                    $('#modal-popupLabel').text(NamaAktivitas.replace('Form Input', 'Tambah Data'));
                } else {
                    $('#modal-popupLabel').text(`Tambah Data ${NamaAktivitas}`);
                }

                $('#form-input-modal button[type="submit"]')
                    .html('<i class="fas fa-plus me-1"></i> Add')
                    .removeClass('btn-primary').addClass('btn-success');

                $('#modal-popup').modal('show');
            });
        });

        $('#form-input-modal').on('click', 'button[type="submit"]', function (e) {
            e.preventDefault();

            const isQuality = $('#IsQualityActive').val();

            if (isQuality == '0') {
                ew.alert({
                    text: "Apakah anda yakin akan save data dalam keadaan Quality OFF?",
                    showCancelButton: true,
                    confirmButtonText: 'Yes',
                    cancelButtonText: 'Cancel',
                }).then((result) => {
                    if (result.dismiss === 'cancel') {
                        return;
                    }

                    $('#form-input-modal').trigger('submit');
                });

                return;
            }

            $('#form-input-modal').trigger('submit');
        });

        function getExistingRowById(gridApi, id) {
            let row = null;

            gridApi.forEachNode(node => {
                if (node.data?.id === id) {
                    row = node.data;
                }
            });

            return row;
        }

        $('#form-input-modal').on('submit', function (e) {
            e.preventDefault();
            let isValid = true;
            $(this).find('[required]:visible:enabled').each(function () {
                if (!$(this).val()) {
                    isValid = false;
                    $(this).addClass('is-invalid');
                } else {
                    $(this).removeClass('is-invalid');
                }
            });

            if (!isValid) {
                ew.alert('Mohon lengkapi semua field yang wajib diisi.');
                return;
            }
            let newData = {};
            let id = (formMode === 'add') ? crypto.randomUUID() : selectedUpdateId;
            newData.id = id;

            // console.log(id);

            let validDensity = true;
            formList.forEach(([label, type, name]) => {
                const input = $(`[name="${name}"]`);
                if (!input.length) return;

                if (type === 'checkbox') {
                    const checked = input.prop('checked');
                    let value = checked ? 1 : 0;

                    newData[name] = value;
                } else {
                    let value = input.val();
                    if (name.toLowerCase() === 'density' && Number(value) >= 1) {
                        validDensity = false;
                    }

                    newData[name] = value;
                }
            });

            if (!validDensity) {
                ew.alert('Nilai Density tidak boleh ≥ 1.')
                return;
            }

            if (IdTemplateAktivitas === '388') {
                const res = bulk388.buildItemForGrid();
                if (res.error) return ew.alert(res.error);

                if (formMode === 'update') res.item.id = String(selectedUpdateId);
                else res.item.id = String(newData.id || crypto.randomUUID());

                const cleanItem = filterByFormList(res.item);

                const meterAwal = parseFloat(cleanItem.MeterAwal) || 0;
                const totalGK = parseFloat(cleanItem.TotalGK) || 0;
                const meterAkhir = parseFloat(cleanItem.MeterAkhir) || 0;

                const tolerance = 0.0001;
                const mismatch = Math.abs((meterAwal + totalGK) - meterAkhir) > tolerance;
                if (mismatch) {
                    pending388 = {
                        mode: formMode,
                        id: selectedUpdateId,
                        item: cleanItem
                    };
                    confirmMode = 'meterMismatch388';
                    /* opsional
                    $('#confirmModal .modal-header')
                        .removeAttr('style')
                        .removeClass('bg-primary bg-danger bg-success bg-warning')
                        .addClass('bg-warning');
                    */

                    $('#modal-confirm-title').text('Peringatan');
                    $('#confirm-body').html(
                        'Meter Akhir <span style="color:red;font-weight:bold;">tidak sama</span> dengan Meter Awal + Total GK.<br>Apakah Anda yakin ingin menyimpan data ini?'
                    );
                    $('#confirmBtn')
                        .html(formMode === 'update'
                            ? '<i class="fas fa-pen me-1"></i> Update'
                            : '<i class="fas fa-plus me-1"></i> Tambah')
                        .removeClass('btn-danger')
                        .addClass('btn-success');

                    $('#confirmModal').modal('show');
                    return;
                }

                apply388Transaction({ mode: formMode, id: selectedUpdateId, item: cleanItem });
                return;
                /*
                const res = bulk388.buildItemForGrid();
                if (res.error) return ew.alert(res.error);

                if (formMode === 'update') {
                    res.item.id = String(selectedUpdateId);

                    const rowNode = dataGridApi.getRowNode(String(selectedUpdateId));
                    if (!rowNode) return ew.alert('Data tidak ditemukan di grid untuk diupdate.');

                    const cleanItem = filterByFormList(res.item);

                    const updatedRow = { ...rowNode.data, ...cleanItem };
                    rowNode.setData(updatedRow);

                    const idxAdd = tempDataAdd.findIndex(x => String(x.id) === String(selectedUpdateId));
                    if (idxAdd !== -1) tempDataAdd[idxAdd] = updatedRow;
                    else {
                        const idxUpd = tempDataUpdate.findIndex(x => String(x.id) === String(selectedUpdateId));
                        if (idxUpd !== -1) tempDataUpdate[idxUpd] = updatedRow;
                        else tempDataUpdate.push(updatedRow);
                    }
                } else {
                    res.item.id = String(newData.id || crypto.randomUUID());
                    const cleanItem = filterByFormList(res.item);

                    dataGridApi.applyTransaction({ add: [cleanItem] });
                    tempDataAdd.push(cleanItem);
                }

                $('#modal-popup').modal('hide');
                formMode = 'add';
                selectedUpdateId = null;
                return;
                */
            }

            if (IdTemplateAktivitas === "56" || IdTemplateAktivitas === '447') {
                const meterAwal = parseFloat(newData.MeterAwal) || 0;
                const volumeKL = parseFloat(newData.Volume) || 0;
                const meterAkhir = parseFloat(newData.MeterAkhir) || 0;

                // If there is a mismatch, ask for confirmation
                if (Math.abs((meterAwal + volumeKL) - meterAkhir) > 0.0001) {
                    pendingNewData = newData;
                    confirmMode = 'meterMismatch';

                    // customise the confirm modal for this case
                    $('#modal-confirm-title').text('Konfirmasi');
                    $('#confirm-body').html(
                        'Meter Akhir <span style="color:red;font-weight:bold;">tidak sama</span> dengan Quantity + Meter Awal.<br>Apakah Anda yakin ingin menambahkan data ini?'
                    );

                    $('#confirmBtn')
                        .html('<i class="fas fa-plus me-1"></i> Tambah')
                        .removeClass('btn-danger')
                        .addClass('btn-primary');

                    $('#confirmModal').modal('show');
                    return;
                }
            }

            const produkInput = $('[name="Produk"]');
            if (produkInput.length) {
                const selectedText = produkInput.find('option:selected').text();
                const selectedValue = produkInput.val();

                const [noProduk, namaProduk] = selectedText.split(' - ');
                newData.NoProduk = noProduk?.trim() || '';
                newData.NamaProduk = namaProduk?.trim() || '';
                newData.Produk = selectedValue;
            }

            const tangkiInput = $('[name="NomorTangki"], [name="Nomor_Tangki"]');
            if (tangkiInput.length) {
                const selectedText = tangkiInput.find('option:selected').text().trim();
                let parts = selectedText.split(' - ').map(p => p.trim());
                parts = parts.filter(p => p !== '');

                const sloc = parts[0] || '';
                let seq = '';
                let terminal = '';

                if (parts.length === 3) {
                    seq = parts[1] || '';
                    terminal = parts[2] || '';
                } else if (parts.length === 2) {
                    seq = '';
                    terminal = parts[1] || '';
                }

                newData.Sloc = sloc;
                newData.SeqTangki = seq;
                newData.NamaTerminal = terminal;
            }

            const tangkiInput2 = $('[name="NomorTangki2"]');
            if (tangkiInput2.length) {
                const selectedText = tangkiInput2.find('option:selected').text().trim();
                let parts = selectedText.split(' - ').map(p => p.trim());
                parts = parts.filter(p => p !== '');

                const sloc = parts[0] || '';
                let seq = '';
                let terminal = '';

                if (parts.length === 3) {
                    seq = parts[1] || '';
                    terminal = parts[2] || '';
                } else if (parts.length === 2) {
                    seq = '';
                    terminal = parts[1] || '';
                }

                newData.Sloc2 = sloc;
                newData.SeqTangki2 = seq;
                newData.NamaTerminal2 = terminal;
            }

            const isGroup60 =
                IdTemplateAktivitas === "34" ||
                IdTemplateAktivitas === "209" ||
                IdTemplateAktivitas === "250" ||
                IdTemplateAktivitas === "148" ||
                IdTemplateAktivitas === "325" ||
                IdTemplateAktivitas === "361" ||
                IdTemplateAktivitas === "394" ||
                IdTemplateAktivitas === "432";

            const isGroup15_60 =
                IdTemplateAktivitas === "13" ||
                IdTemplateAktivitas === "199" ||
                IdTemplateAktivitas === "273" ||
                IdTemplateAktivitas === "140" ||
                IdTemplateAktivitas === "312" ||
                IdTemplateAktivitas === "465" ||
                IdTemplateAktivitas === "378" ||
                IdTemplateAktivitas === "426";

            if (formMode === 'add' && (isGroup60 || isGroup15_60)) {
                if (isGroup60) {
                    const now = new Date();
                    const formattedNow = formatDateTime(now);

                    const isTanggalOnly =
                        IdTemplateAktivitas === "394" ||
                        IdTemplateAktivitas === "432";

                    if (isTanggalOnly) {
                        newData.Tanggal = formattedNow;
                    } else {
                        newData.TanggalJam = formattedNow;
                    }

                    const actualTime = now.getTime();
                    let lastSopTime = null;

                    dataGridApi.forEachNodeAfterFilterAndSort(node => {
                        const sop = node.data?.TanggalJamSOP;
                        if (!sop) return;

                        const t = new Date(sop).getTime();
                        if (!isFinite(t)) return;

                        if (lastSopTime === null || t > lastSopTime) {
                            lastSopTime = t;
                        }
                    });

                    let sopTime;
                    if (lastSopTime !== null) {
                        sopTime = lastSopTime + (60 * 60000);
                    } else {
                        sopTime = new Date(
                            cfg.startDate
                        ).getTime();
                    }

                    newData.TanggalJamSOP = formatDateTime(new Date(sopTime));
                    newData.SelisihWaktu =
                        Math.round((actualTime - sopTime) / 60000);
                }

                if (isGroup15_60) {
                    const now = new Date();
                    const formattedNow = formatDateTime(now);

                    const isTanggalOnly = IdTemplateAktivitas === "426";

                    if (isTanggalOnly) {
                        newData.Tanggal = formattedNow;
                    } else {
                        newData.TanggalJam = formattedNow;
                    }

                    const actualTime = now.getTime();
                    let lastSopTime = null;

                    dataGridApi.forEachNodeAfterFilterAndSort(node => {
                        const sop = node.data?.TanggalJamSOP;
                        if (!sop) return;

                        const t = new Date(sop).getTime();
                        if (!isFinite(t)) return;

                        if (lastSopTime === null || t > lastSopTime) {
                            lastSopTime = t;
                        }
                    });

                    const startTime = new Date(
                        cfg.startDate
                    ).getTime();

                    const batasSatuJam = startTime + (60 * 60000);
                    let sopTime;

                    if (lastSopTime === null) {
                        sopTime = startTime + (15 * 60000);
                    } else if (lastSopTime < batasSatuJam) {
                        sopTime = lastSopTime + (15 * 60000);
                    } else {
                        sopTime = lastSopTime + (60 * 60000);
                    }

                    newData.TanggalJamSOP = formatDateTime(new Date(sopTime));
                    newData.SelisihWaktu = Number(((actualTime - sopTime) / 60000).toFixed(2))
                }
            }

            if (formMode === 'update' && (isGroup60 || isGroup15_60)) {

                const existingRow = getExistingRowById(dataGridApi, newData.id);
                if (!existingRow || !existingRow.TanggalJamSOP) return;

                const now = new Date();
                const formattedNow = formatDateTime(now);

                const isTanggalOnly =
                    IdTemplateAktivitas === "394" ||
                    IdTemplateAktivitas === "432" ||
                    IdTemplateAktivitas === "426";

                if (isTanggalOnly) {
                    newData.Tanggal = formattedNow;
                } else {
                    newData.TanggalJam = formattedNow;
                }

                const sopTime = new Date(existingRow.TanggalJamSOP).getTime();
                const actualTime = now.getTime();

                newData.TanggalJamSOP = existingRow.TanggalJamSOP;
                newData.SelisihWaktu = Number(((actualTime - sopTime) / 60000).toFixed(2))
            }

            if (formMode === 'add') {
                if (dataGridApi) {
                    dataGridApi.applyTransaction({ add: [newData] });
                }

                tempDataAdd.push(newData);
            } else if (formMode === 'update') {
                selectedUpdateId = newData.id;
                const rowNode = dataGridApi.getRowNode(id);
                if (rowNode && dataGridApi) {
                    Object.assign(rowNode.data, newData);
                    dataGridApi.applyTransaction({ update: [rowNode.data] });
                }

                const indexInAdd = tempDataAdd.findIndex(item => item.id === id);
                if (indexInAdd !== -1) {
                    tempDataAdd[indexInAdd] = newData;
                } else {
                    const indexInUpdate = tempDataUpdate.findIndex(item => item.id === id);
                    if (indexInUpdate !== -1) {
                        tempDataUpdate[indexInUpdate] = newData;
                    } else {
                        tempDataUpdate.push(newData);
                    }
                }
            }

            $('#form-input-modal')[0].reset();
            $('#modal-popup').modal('hide');
            formMode = 'add';
            selectedUpdateId = null;
        });

        function fetchAndAddSubAktivitasLogbookPenerimaanToGrid(idAktivitas) {
            if (!idAktivitas || !dataGridApi) {
                console.warn("IdAktivitas atau dataGridApi tidak tersedia.");
                return;
            }

            let jenisProduk = "BBM";
            if (IdTemplateAktivitas == "148") {
                jenisProduk = "LPG";
            } else if (IdTemplateAktivitas == "209") {
                jenisProduk = "BBM_STS";
            } else if (IdTemplateAktivitas == "250") {
                jenisProduk = "LPG_STS";
            } else if (IdTemplateAktivitas == "325") {
                jenisProduk = "PIPA_BBM";
            } else if (IdTemplateAktivitas == "361") {
                jenisProduk = "PIPA_LPG";
            } else if (IdTemplateAktivitas == "394") {
                jenisProduk = "BBM_RTW";
            }

            $.ajax({
                url: parent_url + `api/LookUpList/subaktivitas-hasil-pemeriksaan/get-by-penimbunan?idAktivitas=${idAktivitas}&jenis=${jenisProduk}`,
                method: 'GET',
                success: function (response) {
                    if (!Array.isArray(response)) {
                        console.error("Format data tidak sesuai:", response);
                        return;
                    }

                    response.forEach(item => {
                        let existingNode = null;

                        dataGridApi.forEachNode(node => {
                            if (node.data?.SubAktivitasHasilPemeriksaanId === item.Id) {
                                existingNode = node;
                            }
                        });

                        const apiData = {
                            TanggalJam: item.TanggalJam ?? null,
                            Density: item.Density ?? '',
                            Keterangan: item.Keterangan ?? '',
                            Temperature: item.Temperature ?? '',
                            SubAktivitasHasilPemeriksaanId: item.Id
                        };

                        if (existingNode) {
                            const updatedData = {
                                ...existingNode.data,
                                ...apiData
                            };

                            existingNode.setData(updatedData);

                            const idx = tempDataUpdate.findIndex(x => x.id === updatedData.id);
                            if (idx !== -1) {
                                tempDataUpdate[idx] = updatedData;
                            } else {
                                tempDataUpdate.push(updatedData);
                            }
                        } else {
                            let newData = {
                                id: crypto.randomUUID(),
                                ...apiData,
                                Produk_disabled: Produk
                            };

                            const produkInput = $('[name="Produk"]');
                            if (produkInput.length) {
                                const selectedText = produkInput.find('option:selected').text();
                                const selectedValue = produkInput.val();

                                const [noProduk, namaProduk] = selectedText.split(' - ');
                                newData.NoProduk = noProduk?.trim() || '';
                                newData.NamaProduk = namaProduk?.trim() || '';
                                newData.Produk = selectedValue;
                            }

                            if (jenisProduk === "PIPA_BBM" || jenisProduk === "PIPA_LPG") {
                                newData.NamaKegiatan = `Logbook Penerimaan Produk ${LabelProduk}`;
                            } else if (jenisProduk === "BBM_RTW") {
                                newData.NamaKegiatan = `Logbook Penerimaan Produk ${item.LabelProduk ?? LabelProduk ?? ''}`;
                                newData.Tanggal = item.TanggalJam ?? '';
                                newData.SubAktivitasFormInputHslPemeriksaanRTWId = item.Id;

                                delete newData.TanggalJam;
                                delete newData.SubAktivitasHasilPemeriksaanId;
                            } else {
                                newData.Nama_Kegiatan = `Logbook Penerimaan ${NamaKapal}, Produk ${LabelProduk}`;
                                newData.Nama_Kapal = NamaKapal;
                            }

                            dataGridApi.applyTransaction({ add: [newData] });
                            tempDataAdd.push(newData);
                        }
                    });

                    dataGridApi.refreshCells();
                },
                error: function (xhr, status, error) {
                    console.error("Gagal mengambil data dari API:", error);
                }
            });

            $('#logbookFromPenerimaan').text('Ambil data dari penerimaan');
            $('#logbookFromPenerimaan').prop('disabled', false);
            $('#logbookAddManually').prop('disabled', false);
            $('#logbookPenerimaanConfirmation').modal('hide');
        }

        function fetchAndAddSubAktivitasLogbookPenyimpananToGrid(idAktivitas) {
            if (!idAktivitas || !dataGridApi) {
                console.warn("IdAktivitas atau dataGridApi tidak tersedia.");
                return;
            }

            let jenisProduk = "BBM"
            if (IdTemplateAktivitas == "155") {
                jenisProduk = "LPG"
            } else if (IdTemplateAktivitas == "222") {
                jenisProduk = "BBM_STS";
            } else if (IdTemplateAktivitas == "281") {
                jenisProduk = "LPG_STS";
            } else if (IdTemplateAktivitas == "340") {
                jenisProduk = "PIPA_BBM";
            } else if (IdTemplateAktivitas == "404") {
                jenisProduk = "RTW";
            }

            $.ajax({
                url: parent_url + `api/LookUpList/subaktivitas-hasil-pemeriksaan/get-by-penyaluran?idAktivitas=${idAktivitas}&jenis=${jenisProduk}`,
                method: 'GET',
                success: function (response) {
                    if (!Array.isArray(response)) {
                        console.error("Format data tidak sesuai:", response);
                        return;
                    }

                    response.forEach(item => {
                        let existingNode = null;

                        dataGridApi.forEachNode(node => {
                            if (node.data?.SubAktivitasHasilPemeriksaanId === item.Id) {
                                existingNode = node;
                            }
                        });

                        const apiData = {
                            Density: item.Density || '',
                            SubAktivitasHasilPemeriksaanId: item.Id
                        };

                        if (jenisProduk === "PIPA_BBM") {
                            apiData.TanggalJam = item.TanggalJam ?? null;
                            apiData.Temperature = item.Temperature || '';
                            apiData.NamaKegiatan = `Logbook Penyaluran Produk ${item.LabelProduk}`;
                            apiData.NamaBatch = item.NomorBatch || '';
                        } else {
                            apiData.Tanggal = item.TanggalJam ?? null;
                            apiData.Temperatur = item.Temperature || '';
                            apiData.Nama_Kegiatan = `Logbook Penyaluran Kapal ${NamaKapal}, Produk ${item.LabelProduk}`;
                            apiData.Nama_Kapal = NamaKapal;
                        }

                        if (existingNode) {
                            const updatedData = {
                                ...existingNode.data,
                                ...apiData
                            };

                            existingNode.setData(updatedData);

                            const idx = tempDataUpdate.findIndex(x => x.id === updatedData.id);
                            if (idx !== -1) {
                                tempDataUpdate[idx] = updatedData;
                            } else {
                                tempDataUpdate.push(updatedData);
                            }
                        } else {
                            let newData = {
                                id: crypto.randomUUID(),
                                ...apiData,
                                Produk_disabled: item.LabelProduk
                            };

                            const produkInput = $('[name="Produk"]');
                            if (produkInput.length) {
                                const selectedText = produkInput.find('option:selected').text();
                                const selectedValue = produkInput.val();

                                const [noProduk, namaProduk] = selectedText.split(' - ');
                                newData.NoProduk = noProduk?.trim() || '';
                                newData.NamaProduk = namaProduk?.trim() || '';
                                newData.Produk = selectedValue;
                            }

                            dataGridApi.applyTransaction({ add: [newData] });
                            tempDataAdd.push(newData);
                        }
                    });

                    dataGridApi.refreshCells();
                },
                error: function (xhr, status, error) {
                    console.error("Gagal mengambil data dari API:", error);
                }
            });

            $('#logbookFromPenerimaan').text('Ambil data dari penyaluran');
            $('#logbookFromPenerimaan').prop('disabled', false);
            $('#logbookAddManually').prop('disabled', false);
            $('#logbookPenerimaanConfirmation').modal('hide');
        }

        function simpanData(status) {
            if (status !== "Completed" && status !== "Completed Edit") {
                if (tempDataAdd.length === 0 && tempDataDelete.length === 0 && tempDataUpdate.length === 0) {
                    ew.alert('Tidak perubahan untuk disimpan.');
                    return;
                }
            }

            let isSuccess = true;
            let errorMsg = [];

            let allData = [];

            if (status === "Completed" || status === "Completed Edit") {
                dataGridApi.forEachNode((node) => {
                    if (node.data) {
                        allData.push(node.data);
                    }
                });
            } else {
                allData = [...tempDataAdd, ...tempDataUpdate];
            }

            const fieldMap = {};

            // console.log(formList);
            formList.forEach(([label, type, name]) => {
                const input = $(`[name="${name}"]`);

                fieldMap[name] = {
                    label,
                    type,
                    isRequired: input.length && input.prop('required') === true
                };
            });

            // console.log(allData);
            allData.forEach(row => {
                const inlineBlending =
                    row.InLineBlending === true ||
                    row.InLineBlending === 1 ||
                    row.InLineBlending === "1" ||
                    String(row.InLineBlending).toLowerCase() === "true" ||
                    String(row.InLineBlending).toLowerCase() === "y" ||
                    String(row.InLineBlending).toLowerCase() === "yes";

                Object.entries(row).forEach(([key, value]) => {
                    const field = fieldMap[key];
                    if (!field) return;

                    if (field.type === 'hidden' || field.type === 'hiddenform') return;

                    if (key === 'NomorTangki2' && !inlineBlending) return;

                    if (!field.isRequired) return;

                    if (value === null || value === undefined || value === '') {
                        isSuccess = false;
                        if (!errorMsg.includes(field.label)) errorMsg.push(field.label);
                    }
                });
            });

            // console.log(isSuccess);
            if (!isSuccess && (status === "Completed" || status === "Completed Edit")) {
                ew.alert(`Seluruh data harus lengkap untuk dapat submit aktivitas. Field berikut harus diisi: ${errorMsg.join(', ')}`);
                return;
            }

            if (!isSuccess) {
                ew.alert(`Field berikut harus diisi: ${errorMsg.join(', ')}`);
                return;
            }

            let cleanedAdd = tempDataAdd.map(({ TotalTerima, ProdukAll, IdPlant_disabled, Nomor_Tangki_disabled, Produk_disabled, NoProduk, NamaProduk, Sloc, Sloc2, SeqTangki, SeqTangki2, NamaTerminal, NamaTerminal2, id, ...rest }) => rest);

            let cleanedUpdate = tempDataUpdate.map(({ TotalTerima, ProdukAll, IdPlant_disabled, Nomor_Tangki_disabled, Produk_disabled, NoProduk, NamaProduk, Sloc, Sloc2, SeqTangki, SeqTangki2, NamaTerminal, NamaTerminal2, ...rest }) => rest);

            // console.log('Cleaned Update: ', cleanedUpdate);

            if (IdTemplateAktivitas === '388') {
                const allowed = new Set(formList.map(([label, type, name]) => name));
                allowed.add('id');
                const filter388 = (obj) => Object.fromEntries(Object.entries(obj).filter(([key]) => allowed.has(key)));

                cleanedAdd = cleanedAdd.map(filter388);
                cleanedUpdate = cleanedUpdate.map(filter388);
            }

            $.ajax({
                url: parent_url + `api/LookUpList/check_valid_status_aktivitas?idAktivitas=${IdAktivitas}&originalStatus=${StatusAktivitas}`,
                type: 'GET',
                beforeSend: function () {
                    showLoading();
                },
                success: function (response) {
                    if (!response.IsValid) {
                        hideLoading();
                        ew.alert(response.Message ?? "Status aktivitas telah diubah oleh pengguna lain");
                        return;
                    } else {
                        $.ajax({
                            url: parent_url + 'api/LookUpList/UpdateAktivitasTabel',
                            method: 'POST',
                            data: JSON.stringify({
                                TableName: TableAnak,
                                IdAktivitas: IdAktivitas,
                                IdProses: IdProses,
                                NoReferensi: NoReferensi,
                                Status: status,
                                ItemsAdd: cleanedAdd,
                                DeletedIds: tempDataDelete,
                                ItemsUpdate: cleanedUpdate
                            }),
                            contentType: 'application/json',
                            success: function (res) {
                                if (IdTemplateAktivitas == "402") {
                                    tempDataAdd.length = 0;
                                    tempDataDelete.length = 0;
                                    tempDataUpdate.length = 0;
                                    $.ajax({
                                        url: parent_url + 'api/LookUpList/insertTotalBDToSubAktivitasNilaiSFBDRTW',
                                        type: 'POST',
                                        data: JSON.stringify({
                                            NoReferensi: NoReferensi,
                                            IdProses: IdProses,
                                            IdAktivitas: IdAktivitas
                                        }),
                                        contentType: 'application/json',
                                        success: function (tes) {
                                            hideLoading();
                                            ew.alert(res.message);
                                            setTimeout(function () {
                                                if (status == "Completed" || status == "Completed Edit") {
                                                    window.location.href = `${parent_url}AktivitasList?cmd=search&x_IdProses%5B%5D=${IdProses}&search=&searchtype=`;
                                                } else {
                                                    location.reload();
                                                }
                                            }, 1000);
                                        },
                                        error: function (xhr, status, error) {
                                            console.error("Update Sub Aktivitas gagal:", error);
                                        },
                                        complete: function () {
                                            hideLoading();
                                        }
                                    });
                                }
                                else {
                                    tempDataAdd.length = 0;
                                    tempDataDelete.length = 0;
                                    tempDataUpdate.length = 0;
                                    ew.alert(res.message);
                                    setTimeout(function () {
                                        if (status == "Completed" || status == "Completed Edit") {
                                            window.location.href = `${parent_url}AktivitasList?cmd=search&x_IdProses%5B%5D=${IdProses}&search=&searchtype=`;
                                        } else {
                                            location.reload();
                                        }
                                    }, 1000);
                                }
                            },
                            error: function (xhr, status, error) {
                                hideLoading();
                                try {
                                    var responseJson = JSON.parse(xhr.responseText);

                                    if (responseJson.message) {
                                        ew.alert("Perubahan gagal disimpan: " + responseJson.message);
                                    } else {
                                        ew.alert("Perubahan gagal disimpan.");
                                    }
                                } catch (e) {
                                    console.error(xhr.responseText);
                                    ew.alert("Perubahan gagal disimpan: " + xhr.responseText);
                                }
                            },
                            complete: function () {
                                hideLoading();
                            }
                        });
                    }
                },
                error: function (xhr, status, error) {
                    hideLoading();
                    ew.alert("Gagal menyimpan data.");
                    console.error("Form submit gagal:", error);
                }
            });
        }

        function reverseStatusSubmit(status, catatan) {
            const cleanedUpdate = tempDataUpdate.map(({ TotalTerima, ProdukAll, IdPlant_disabled, Nomor_Tangki_disabled, Produk_disabled, NoProduk, NamaProduk, Sloc, Sloc2, SeqTangki, SeqTangki2, NamaTerminal, NamaTerminal2, ...rest }) => rest);
            const cleanedAdd = tempDataAdd.map(({ TotalTerima, ProdukAll, IdPlant_disabled, Nomor_Tangki_disabled, Produk_disabled, NoProduk, NamaProduk, Sloc, Sloc2, SeqTangki, SeqTangki2, NamaTerminal, NamaTerminal2, id, ...rest }) => rest);
            $.ajax({
                url: parent_url + `api/LookUpList/check_valid_status_aktivitas?idAktivitas=${IdAktivitas}&originalStatus=${StatusAktivitas}`,
                type: 'GET',
                beforeSend: function () {
                    showLoading();
                },
                success: function (response) {
                    if (!response.IsValid) {
                        hideLoading();
                        ew.alert(response.Message ?? "Status aktivitas telah diubah oleh pengguna lain");
                        return;
                    } else {
                        $.ajax({
                            url: parent_url + 'api/LookUpList/UpdateAktivitasTabel',
                            method: 'POST',
                            data: JSON.stringify({
                                TableName: TableAnak,
                                IdAktivitas: IdAktivitas,
                                IdProses: IdProses,
                                NoReferensi: NoReferensi,
                                Catatan: catatan,
                                Status: status,
                                ItemsAdd: cleanedAdd,
                                DeletedIds: tempDataDelete,
                                ItemsUpdate: cleanedUpdate
                            }),
                            contentType: 'application/json',
                            success: function (res) {
                                if (IdTemplateAktivitas == "402") {
                                    tempDataAdd.length = 0;
                                    tempDataDelete.length = 0;
                                    tempDataUpdate.length = 0;
                                    $.ajax({
                                        url: parent_url + 'api/LookUpList/insertTotalBDToSubAktivitasNilaiSFBDRTW',
                                        type: 'POST',
                                        data: JSON.stringify({
                                            NoReferensi: NoReferensi,
                                            IdProses: IdProses,
                                            IdAktivitas: IdAktivitas
                                        }),
                                        contentType: 'application/json',
                                        success: function (tes) {
                                            hideLoading();
                                            ew.alert(res.message);
                                            setTimeout(function () {
                                                if (status == "Completed" || status == "Completed Edit") {
                                                    window.location.href = `${parent_url}AktivitasList?cmd=search&x_IdProses%5B%5D=${IdProses}&search=&searchtype=`;
                                                } else {
                                                    location.reload();
                                                }
                                            }, 1000);
                                        },
                                        error: function (xhr, status, error) {
                                            console.error("Update Sub Aktivitas gagal:", error);
                                        },
                                        complete: function () {
                                            hideLoading();
                                        }
                                    });
                                }
                                else {
                                    tempDataAdd.length = 0;
                                    tempDataDelete.length = 0;
                                    tempDataUpdate.length = 0;
                                    ew.alert(res.message);
                                    setTimeout(function () {
                                        window.location.href = `${parent_url}AktivitasList?cmd=search&x_IdProses%5B%5D=${IdProses}&search=&searchtype=`;
                                    }, 1000);
                                }
                            },
                            error: function (xhr, status, error) {
                                hideLoading();
                                try {
                                    var responseJson = JSON.parse(xhr.responseText);

                                    if (responseJson.message) {
                                        ew.alert("Perubahan gagal disimpan: " + responseJson.message);
                                    } else {
                                        ew.alert("Perubahan gagal disimpan.");
                                    }
                                } catch (e) {
                                    console.error(xhr.responseText);
                                    ew.alert("Perubahan gagal disimpan: " + xhr.responseText);
                                }
                            },
                            complete: function () {
                                hideLoading();
                            }
                        });
                    }
                },
                error: function (xhr, status, error) {
                    hideLoading();
                    ew.alert("Gagal menyimpan data.");
                    console.error("Form submit gagal:", error);
                }
            });
        }

        $(document).on("submit", "#reverseStatusEditingModalForm", function (e) {
            e.preventDefault();
            let catatanText = $("#catatanReverseStatusEditing").val();
            reverseStatusSubmit("Editing", catatanText);
        });

        $(document).on("click", "#btn-reverse-status", function () {
            $("#confirmReverseStatusEditingModal").modal("show");
        });

        $(document).on('click', '#btn-export', function () {
            let GeneralData = {
                [`Nomor ${TipeProsesView}`]: NoReferensi,
                'Proses': NamaProses,
                'Aktivitas': NamaAktivitas,
                'Status Aktivitas': StatusAktivitas,
                'Dibuat Oleh': cfg.DibuatOleh,
                'Tanggal Dibuat': cfg.TanggalDibuat,
                'DiperbaruiOleh': cfg.DiperbaruiOleh,
                'Tanggal Diperbarui': cfg.TanggalDiperbarui
            };

            if (IdTemplateAktivitas === '13' || IdTemplateAktivitas === '89' || IdTemplateAktivitas === '140' || IdTemplateAktivitas == "170" || IdTemplateAktivitas == "199" || IdTemplateAktivitas == "236" || IdTemplateAktivitas == "273") {
                let newGeneralData = {};
                $.each(GeneralData, function (key, value) {
                    newGeneralData[key] = value;

                    if (key === 'Status Aktivitas') {
                        newGeneralData['Nama Kapal'] = cfg.NamaKapal;
                        newGeneralData['Produk'] = cfg.produkView;
                    }
                });
                GeneralData = newGeneralData;
            } else if (IdTemplateAktivitas === '56' || IdTemplateAktivitas === '447') {
                let newGeneralData = {};
                $.each(GeneralData, function (key, value) {
                    newGeneralData[key] = value;

                    if (key === 'Status Aktivitas') {
                        newGeneralData['Nama Kapal'] = cfg.NamaKapal;
                    }
                });
                GeneralData = newGeneralData;
            } else if (IdTemplateAktivitas === '179' || IdTemplateAktivitas === '180') {
                let newGeneralData = {};
                $.each(GeneralData, function (key, value) {
                    newGeneralData[key] = value;

                    if (key === 'Status Aktivitas') {
                        newGeneralData['Nomor Polisi'] = cfg.NomorPolisi;
                    }
                });
                GeneralData = newGeneralData;
            } else if (IdTemplateAktivitas === "320" || IdTemplateAktivitas === "325" || IdTemplateAktivitas == "348" || IdTemplateAktivitas == "378"
                || IdTemplateAktivitas == "426" || IdTemplateAktivitas == "476") {
                let newGeneralData = {};
                $.each(GeneralData, function (key, value) {
                    newGeneralData[key] = value;

                    if (key === 'Status Aktivitas') {
                        newGeneralData['Produk'] = cfg.produkView;
                    }
                });
                GeneralData = newGeneralData;
            }

            $.ajax({
                url: parent_url + 'api/LookUpList/ExportAktivitasTabel',
                method: 'POST',
                data: JSON.stringify({
                    GeneralData: GeneralData,
                    TableName: TableAnak,
                    IdAktivitas: IdAktivitas,
                    NoReferensi: NoReferensi
                }),
                contentType: 'application/json',
                xhrFields: {
                    responseType: 'blob'
                },
                beforeSend: function () {
                    showLoading();
                },
                success: function (response, status, xhr) {
                    const disposition = xhr.getResponseHeader('Content-Disposition');
                    let fileName = "file_download";
                    if (disposition && disposition.indexOf('filename=') !== -1) {
                        const fileNameMatch = disposition.match(/filename="?([^";]+)"?/);
                        if (fileNameMatch && fileNameMatch[1]) {
                            fileName = fileNameMatch[1];
                        }
                    }
                    const blobUrl = window.URL.createObjectURL(response);
                    const a = document.createElement('a');
                    a.href = blobUrl;
                    a.download = fileName;
                    document.body.appendChild(a);
                    a.click();
                    document.body.removeChild(a);
                    window.URL.revokeObjectURL(blobUrl);
                    ew.alert("Export successful!");
                },
                error: function (xhr, status, error) {
                    hideLoading();
                    try {
                        var responseJson = JSON.parse(xhr.responseText);

                        if (responseJson.message) {
                            ew.alert("Gagal Export Data: " + responseJson.message);
                        } else {
                            ew.alert("Gagal Export Data.");
                        }
                    } catch (e) {
                        console.error(xhr.responseText);
                        ew.alert("Gagal Export Data: " + xhr.responseText);
                    }
                },
                complete: function () {
                    hideLoading();
                }
            });
        });

        $(document).on('click', '#btn-save', function () {
            const status = $(this).data('nextstatus');
            simpanData(status)
        });

        $(document).on('click', '#btn-submit', function () {
            confirmMode = 'submit';

            $('#modal-confirm-title').text('Konfirmasi Submit Data');
            $('#confirm-body').text('Apakah anda yakin ingin submit data?');

            $('#confirmBtn')
                .html('<i class="fas fa-paper-plane me-1"></i> Submit')
                .removeClass('btn-danger').addClass('btn-success');

            tempStatus = $(this).data('nextstatus');

            $('#confirmModal').modal('show');
        });

        $(document).on('click', '#btn-edit', function () {
            const status = $(this).data('nextstatus');
            simpanData(status)
        });

        $(document).on('click', '.btn-delete', function (e) {
            e.stopPropagation();
            selectedIdToDelete = $(this).data('id');
            confirmMode = 'delete';

            $('#modal-confirm-title').text('Konfirmasi Hapus Data');
            $('#confirm-body').text('Apakah anda yakin ingin menghapus data? Data yang dihapus tidak dapat dikembalikan.');
            $('#confirmBtn')
                .html('<i class="fas fa-trash me-1"></i> Delete')
                .removeClass('btn-success').addClass('btn-danger');

            $('#confirmModal').modal('show');
        });

        $('#confirmBtn').on('click', function () {
            if (confirmMode === 'submit') {
                simpanData(tempStatus);
                tempStatus = null;
            } else if (confirmMode === 'delete') {
                if (!selectedIdToDelete) return;

                const indexInAdd = tempDataAdd.findIndex(item => item.id === selectedIdToDelete.toString());

                if (indexInAdd !== -1) {
                    tempDataAdd.splice(indexInAdd, 1);
                } else {
                    tempDataDelete.push(selectedIdToDelete.toString());
                }

                const rowNode = dataGridApi.getRowNode(selectedIdToDelete.toString());

                if (rowNode && dataGridApi) {
                    dataGridApi.applyTransaction({ remove: [rowNode.data] });
                    dataGridApi.refreshCells();
                }

                selectedIdToDelete = null;
            } else if (confirmMode === 'meterMismatch') {
                if (pendingNewData) {
                    handleFormSubmission(pendingNewData);
                    pendingNewData = null;
                }
            } else if (confirmMode === 'meterMismatch388') {
                if (pending388) {
                    apply388Transaction(pending388);
                    pending388 = null;
                }
            }

            $('#confirmModal').modal('hide');
        });

        $(document).on('click', '.btn-update', function () {
            const id = $(this).data('id');
            // console.log(id);
            if (!id) {
                ew.alert('Terjadi kesalahan saat mengambil data.')
                return;
            }

            const rowNode = dataGridApi.getRowNode(id);
            const data = rowNode?.data;
            if (!data) return;

            formMode = 'update';
            selectedUpdateId = id;

            if (NamaAktivitas.includes('Form Input')) {
                $('#modal-popupLabel').text(NamaAktivitas.replace('Form Input', 'Update Data'));
            } else {
                $('#modal-popupLabel').text(`Update Data ${NamaAktivitas}`);
            }

            if (IdTemplateAktivitas === '402') {
                formList.forEach(item => {
                    const [label, type, name] = item;

                    const input = $(`[name="${name}"]`);

                    if (!input.length) return;

                    let value = data[name] ?? "";

                    if (type === 'select' && name === "NomorGerbongKertel") {
                        $('select#NomorGerbongKertel').prop('hidden', true);
                        $('select#NomorGerbongKertel').prop('required', false);
                        $('#row_NomorGerbongKertel').hide();
                        $('input#NomorGerbongKertelForUpdate').val(value);
                        $('input#NomorGerbongKertelForUpdate').attr('name', 'NomorGerbongKertelForUpdate');
                    } else if (type === 'text' && name === "NomorGerbongKertelForUpdate") {
                        $('select#NomorGerbongKertel').removeAttr('name');
                        $('input#NomorGerbongKertelForUpdate').prop('disabled', true);
                        $('input#NomorGerbongKertelForUpdate').prop('hidden', false);
                        $('input#NomorGerbongKertelForUpdate').show();
                        $('input#NomorGerbongKertelForUpdate').attr('name', 'NomorGerbongKertel');
                        $('#row_NomorGerbongKertelForUpdate').show();
                    } else {
                        input.val(value);
                    }
                });
            } else {
                formList.forEach(item => {
                    const [label, type, name] = item;

                    const input = $(`[name="${name}"]`);

                    if (!input.length) return;

                    let value = data[name] ?? "";

                    if (type === 'checkbox') {
                        if (value) {
                            input.prop('checked', true);
                        } else {
                            input.prop('checked', false);
                        }
                    } else if (name == 'IsQualityActive') {
                        if (!value) {
                            input.val('0');
                        } else {
                            input.val('1');
                        }
                    } else {
                        input.val(value);
                    }
                });
            }

            // formList.forEach(([label, type, name]) => {
            //     const input = $(`[name="${name}"]`);

            //     if (!input.length) return;

            //     let value = data[name] ?? "";

            //     if (type === 'checkbox') {
            //         if (value) {
            //             input.prop('checked', true);
            //         } else {
            //             input.prop('checked', false);
            //         }
            //     } else if (name == 'IsQualityActive'){
            //         if (!value) {
            //             input.val('0');
            //         } else {
            //             input.val(value);
            //         }
            //     } else {
            //         input.val(value);
            //     }
            // });

            if (IdTemplateAktivitas == "51" || IdTemplateAktivitas == "247") {
                eventLaporanStockHarian();
            }

            if (IdTemplateAktivitas == "70" || IdTemplateAktivitas == "71" || IdTemplateAktivitas == "335" || IdTemplateAktivitas == "337") {
                eventPenyaluranProduk();
            }

            $('#form-input-modal button[type="submit"]')
                .html('<i class="fas fa-save me-1"></i> Update')
                .removeClass('btn-success')
                .addClass('btn-primary');

            if (IdTemplateAktivitas == '179' || IdTemplateAktivitas == '180') {
                const selectedTangki = tangkiList.find(t => t.id.toString() === $('#NomorTangki').val());
                if (selectedTangki.MatNo && selectedTangki.NamaProduk) {
                    $('#row_Produk_disabled').removeClass('d-none');
                    $('#row_ProdukAll').addClass('d-none');
                    $('#ProdukAll').prop('required', false);
                } else {
                    $('#ProdukAll').val($('#Produk').val()).trigger('change');
                    $('#row_Produk_disabled').addClass('d-none');
                    $('#row_ProdukAll').removeClass('d-none');
                    $('#ProdukAll').prop('required', true);
                }
            }
            if (IdTemplateAktivitas == '56' || IdTemplateAktivitas === '447') {
                const checked = $('#InLineBlending').prop('checked');

                if (checked) {
                    $('#row_NomorTangki2').removeClass('d-none');
                    $('#NomorTangki2').prop('required', true);
                } else {
                    $('#row_NomorTangki2').addClass('d-none');
                    $('#NomorTangki2').prop('required', false);
                }
            }
            if (IdTemplateAktivitas === '388') {
                $('#bulk-388').show();
                $('#row_NomorGerbongKertel, #row_Quantity, #row_HasilPengukuranT2,' +
                    '#row_NomorGerbongKertel2, #row_Quantity2, #row_HasilPengukuranT2_2,' +
                    '#row_NomorGerbongKertel3, #row_Quantity3, #row_HasilPengukuranT2_3')
                    .hide()
                    .find('input,select,textarea')
                    .prop('disabled', true)
                    .prop('required', false);

                $f('PICPengisian').val(data.PICPengisian ?? '');
                $f('NoMeter').val(data.NoMeter ?? '');
                $f('MeterAwal').val(data.MeterAwal ?? '');
                $f('MeterAkhir').val(data.MeterAkhir ?? '');
                $f('TotalGK').val(data.TotalGK ?? '');
                $f('Total').val(data.Total ?? '');
                $f('Selisih').val(data.Selisih ?? '');

                bulk388.openForUpdate(data);
            }

            $('#modal-popup').modal('show');
        });

        $(document).on('change', '#NomorTangki, #NomorTangki2, #NoTangki', function () {
            const selectedId = $(this).val();

            const selectedTangki = tangkiList.find(t => t.id.toString() === selectedId);

            if (IdTemplateAktivitas === '56' || IdTemplateAktivitas === '347' || IdTemplateAktivitas === '412' || IdTemplateAktivitas === '447') {
                if (selectedTangki) {
                    if (selectedTangki.MatNo && selectedTangki.NamaProduk) {
                        $('#Produk').val(selectedTangki.MatNo).trigger('change');
                    }
                }
            } else {
                if (selectedTangki) {
                    if (selectedTangki.MatNo && selectedTangki.NamaProduk) {
                        $('#Produk').val(selectedTangki.MatNo);
                        $('#ProdukAll').val(selectedTangki.MatNo).trigger('change');
                        $('#Produk_disabled').val(selectedTangki.MatNo + ' - ' + selectedTangki.NamaProduk);

                        $('#row_Produk_disabled').removeClass('d-none');
                        $('#row_ProdukAll').addClass('d-none');
                        $('#ProdukAll').prop('required', false);
                    } else {
                        $('#Produk').val('');
                        $('#Produk_disabled').val('');
                        $('#ProdukAll').val('');

                        if (IdTemplateAktivitas == '179' || IdTemplateAktivitas == '180') {
                            $('#row_Produk_disabled').addClass('d-none');
                            $('#row_ProdukAll').removeClass('d-none');
                            $('#ProdukAll').prop('required', true);
                        }
                    }
                } else {
                    $('#Produk').val('');
                    $('#Produk_disabled').val('');
                }
            }
        });

        $(document).on('change', '#ProdukAll', function () {
            const selectedNo = $(this).val();

            const selectedProduk = produkList.find(t => t.NoProduk.toString() === selectedNo);
            if (selectedProduk) {
                $('#Produk').val(selectedProduk.NoProduk);
                $('#Produk_disabled').val(selectedProduk.NoProduk + ' - ' + selectedProduk.NamaProduk);
            } else {
                $('#Produk').val('');
                $('#Produk_disabled').val('');
            }
        });

        function eventPenyaluranProduk() {
            const Shift1 = parseFloat($('#Shift1').val()) || 0;
            const Shift2 = parseFloat($('#Shift2').val()) || 0;
            const Shift3 = parseFloat($('#Shift3').val()) || 0;
            const Shift4 = parseFloat($('#Shift4').val()) || 0;

            $('#Total').val(Shift1 + Shift2 + Shift3 + Shift4);
        }

        function eventLaporanStockHarian() {
            const stockAwal = parseFloat($('#StockAwal').val());
            const stockAkhir = parseFloat($('#StockAkhir').val());
            const penerimaan = parseFloat($('#Penerimaan').val());
            const penyaluran = parseFloat($('#Penyaluran').val());

            if (!isNaN(stockAwal) && !isNaN(stockAkhir) && !isNaN(penerimaan) && !isNaN(penyaluran)) {
                const expectedStockAkhir = stockAwal + penerimaan - penyaluran;
                const workingLoss = stockAkhir - expectedStockAkhir;
                const persentase = workingLoss / penyaluran * 100;
                $('#WorkingLoss').val(workingLoss.toFixed(2));
                $('#Presentase').val(persentase.toFixed(2) + "%");
            } else {
                $('#WorkingLoss').val('');
                $('#Presentase').val('');
            }
        }

        $(document).on('input', '#StockAwal, #StockAkhir, #Penerimaan, #Penyaluran', function () {
            eventLaporanStockHarian();
        });

        $(document).on('input', '#Shift1, #Shift2, #Shift3, #Shift4', function () {
            eventPenyaluranProduk();
        });
        function eventBayNumber() {
            const Volume = parseFloat($('#Volume').val()) || 0;
            const Quantity = parseFloat($('#Quantity').val()) || 0;
            const MeterAwal = parseFloat($('#MeterAwal').val()) || 0;

            $('#MeterAkhir').val(Volume + Quantity + MeterAwal);
        }

        function eventNetWeight(source = 'timbanganAkhir') {
            const TimbanganAwal = parseFloat($('#TimbanganAwal').val()) || 0;

            if (source === 'timbanganAkhir') {
                const TimbanganAkhir = parseFloat($('#TimbanganAkhir').val()) || 0;
                const netWeight = TimbanganAkhir - TimbanganAwal;
                $('#NetWight').val(netWeight);
            } else if (source === 'netWeight') {
                const NetWight = parseFloat($('#NetWight').val()) || 0;
                const timbanganAkhir = TimbanganAwal + NetWight;
                $('#TimbanganAkhir').val(timbanganAkhir);
            }
        }

        function eventFlowrateMonitoringStock() {
            const quantityAwal = parseFloat($('#QuantityAwal').val()) || 0;
            const quantityAkhir = parseFloat($('#QuantityAkhir').val()) || 0;
            const tanggalAwal = $('#TanggalQuantityAwal').val();
            const tanggalAkhir = $('#TanggalQuantityAkhir').val();

            if (tanggalAwal && tanggalAkhir) {
                const dateAwal = new Date(tanggalAwal);
                const dateAkhir = new Date(tanggalAkhir);

                const selisihMs = dateAkhir - dateAwal;

                // Konversi ke jam dalam format desimal
                const selisihJamDesimal = selisihMs / (1000 * 60 * 60);

                if (selisihJamDesimal > 0) {
                    const selisihQuantity = quantityAkhir - quantityAwal;
                    const flowrate = selisihQuantity / selisihJamDesimal;
                    $('#Flowrate').val(flowrate.toFixed(2));
                } else {
                    $('#Flowrate').val('');
                }
            } else {
                $('#Flowrate').val('');
            }
        }
        function GetMeterAwalBayNumber(BayNumber, NoMeter) {
            $.ajax({
                url: parent_url + `api/LookUpList/GetMeterAwalBayNumber?TableAnak=${TableAnak}&NoReferensi=${NoReferensi}&BayNumber=${BayNumber}&NoMeter=${NoMeter}`,
                type: 'GET',
                beforeSend: function () {
                    showLoading();
                },
                success: function (res) {
                    if (res.success && res.MeterAkhir) {
                        $('#MeterAwal').val(res.MeterAkhir);
                    } else {
                        $('#MeterAwal').val('');
                    }
                    eventBayNumber();
                },
                error: function (xhr, status, error) {
                    console.error('API call failed:', status, error);
                },
                complete: function () {
                    hideLoading();
                }
            });
        }

        function getTimbanganAwal(NoReferensi) {
            $.ajax({
                url: parent_url + `api/LookUpList/getTimbangan_Awal?NoReferensi=${NoReferensi}`,
                type: 'GET',
                beforeSend: function () {
                    showLoading();
                },
                success: function (res) {
                    if (res.success && res.Timbangan_awal) {
                        $('#TimbanganAwal').val(res.Timbangan_awal);
                        eventNetWeight();
                    } else {
                        $('#TimbanganAwal').val('');
                    }
                },
                error: function (xhr, status, error) {
                    console.error('API getTimbangan_Awal failed:', status, error);
                    $('#TimbanganAwal').val('');
                },
                complete: function () {
                    hideLoading();
                }
            });
        }

        function getLastQuantityAkhir(NoReferensi) {
            if (!NoReferensi) {
                console.warn('NoReferensi tidak tersedia untuk auto-fill Quantity Awal');
                return;
            }

            $.ajax({
                url: parent_url + `api/LookUpList/get-last-quantity-akhir?noReferensi=${NoReferensi}`,
                type: 'GET',
                beforeSend: function () {
                    showLoading();
                },
                success: function (response) {
                    if (response.success && response.QuantityAkhir) {
                        $('#QuantityAwal').val(response.QuantityAkhir);

                        eventFlowrateMonitoringStock();

                        console.log('Auto-fill Quantity Awal berhasil:', response.QuantityAkhir);
                    } else {
                        $('#QuantityAwal').val('');
                        console.log('Tidak ada data sebelumnya untuk auto-fill Quantity Awal');
                    }
                },
                error: function (xhr, status, error) {
                    console.error('Error saat mengambil Quantity Akhir terakhir:', error);
                    $('#QuantityAwal').val('');
                },
                complete: function () {
                    hideLoading();
                }
            });
        }

        function getProdukPenimbunanPenyaluran(NoReferensi) {
            if (!NoReferensi) {
                console.warn('NoReferensi tidak tersedia untuk auto-fill Produk');
                return;
            }

            $.ajax({
                url: parent_url + `api/LookUpList/get-produk-penimbunan-penyaluran?noReferensi=${NoReferensi}`,
                type: 'GET',
                beforeSend: function () {
                    showLoading();
                },
                success: function (response) {
                    if (response.success && response.JenisProduk) {
                        $('#Produk').val(response.JenisProduk).trigger('change');

                        console.log('Auto-fill Produk berhasil:', response.JenisProduk);
                    } else {
                        console.log('Tidak ada data produk untuk auto-fill');
                    }
                },
                error: function (xhr, status, error) {
                    console.error('Error saat mengambil Produk:', error);
                },
                complete: function () {
                    hideLoading();
                }
            });
        }

        if (IdTemplateAktivitas == "56" || IdTemplateAktivitas === '447') {
            $(document).on('change', '#BayNumber, #NoMeter', function () {
                if (formMode !== 'add') return;

                const BayNumber = $('#BayNumber').val();
                const NoMeter = $('#NoMeter').val();

                if (BayNumber && NoMeter) {
                    GetMeterAwalBayNumber(BayNumber, NoMeter);
                }
            });

            $(document).on('change', '#InLineBlending', function () {
                const checked = $(this).prop('checked');

                if (checked) {
                    $('#row_NomorTangki2').removeClass('d-none');
                    $('#NomorTangki2').prop('required', true);
                } else {
                    $('#row_NomorTangki2').addClass('d-none');
                    $('#NomorTangki2').prop('required', false);
                    $('#NomorTangki2').val('').trigger('change');
                }
            });

            $(document).on('input change', '#MeterAwal, #Volume', function () {
                eventBayNumber();
            });
        }

        if (IdTemplateAktivitas == "179") {
            $(document).on('change', '#BayNumber', function () {
                if (formMode !== 'add') return;

                const BayNumber = $('#BayNumber').val();

                GetMeterAwalBayNumber(BayNumber, '');
            });

            $(document).on('input change', '#MeterAwal, #Quantity', function () {
                eventBayNumber();
            });
        }
        if (IdTemplateAktivitas == "180") {
            // Event untuk Timbangan Awal dan Timbangan Akhir
            $(document).on('input change', '#TimbanganAwal', function () {
                // Ketika Timbangan Awal berubah, recalculate berdasarkan field yang terakhir diinput
                const timbanganAkhir = $('#TimbanganAkhir').val();
                const netWight = $('#NetWight').val();

                if (timbanganAkhir) {
                    eventNetWeight('timbanganAkhir');
                } else if (netWight) {
                    eventNetWeight('netWeight');
                }
            });

            $(document).on('input change', '#TimbanganAkhir', function () {
                eventNetWeight('timbanganAkhir');
            });

            // Event baru untuk Net Weight
            $(document).on('input change', '#NetWight', function () {
                eventNetWeight('netWeight');
            });
        }

        if (IdTemplateAktivitas == "218" || IdTemplateAktivitas == "259") {
            $(document).on('input change', '#QuantityAwal, #QuantityAkhir, #TanggalQuantityAwal, #TanggalQuantityAkhir', function () {
                eventFlowrateMonitoringStock();
            });
        }

        if (isEditable == "False") {
            $("#btn-save").hide();
            $("#btn-edit").hide();
            $("#btn-submit").hide();
            $('.btn-update, .btn-delete, #btn-add-modal').prop('disabled', true);
            $('#catatanReverseStatusEditing').prop('disabled', false);
        }

        $('.text-rasa-number').on('input', function () {
            let val = $(this).val();
            let isNegative = val.startsWith('-');

            val = val.replace(',', '.');
            val = val.replace(/[^0-9.]/g, '');

            const parts = val.split('.');
            if (parts.length > 2) {
                val = parts[0] + '.' + parts.slice(1).join('');
            }

            if (isNegative) {
                val = '-' + val;
            }

            $(this).val(val);
        });

        if (IdTemplateAktivitas == "320" || IdTemplateAktivitas == "356" || IdTemplateAktivitas == "476") {
            $(document).on('input change', '#Tanggal, #VolumeDischarge', function () {
                const volumeDischarge = parseFloat($('#VolumeDischarge').val()) || 0;
                const tanggal = $('#Tanggal').val();
                getFlowrateVal(volumeDischarge, tanggal, selectedUpdateId);
            });
        }

        if (IdTemplateAktivitas === "34" ||
            IdTemplateAktivitas === "209" ||
            IdTemplateAktivitas === "250" ||
            IdTemplateAktivitas === "148" ||
            IdTemplateAktivitas === "325" ||
            IdTemplateAktivitas === "361" ||
            IdTemplateAktivitas === "394" ||
            IdTemplateAktivitas === "432"
        ) {
            $(document).on('input change', '#Volume', function () {
                const volume = parseFloat($('#Volume').val()) || 0;
                const tanggal = $('#TanggalJam').val();
                const now = new Date();

                getFlowrateVal(volume, now, selectedUpdateId);
            });
        }

        function getFlowrateVal(newQuantity, newTanggal, selectedUpdateId) {
            const rows = [];

            dataGridApi.forEachNodeAfterFilterAndSort((node) => {
                rows.push(node.data);
            });

            let baseRow = null;

            if (selectedUpdateId) {
                const idx = rows.findIndex(r => r.id === selectedUpdateId);
                if (idx > 0) {
                    baseRow = rows[idx - 1];
                }
            } else if (rows.length > 0) {
                baseRow = rows[rows.length - 1];
            }

            const newTime = new Date(newTanggal).getTime();
            let flowrate = 0;

            if (baseRow) {
                const lastQuantity = parseFloat(baseRow.VolumeDischarge || baseRow.Volume) || 0;
                const lastTime = new Date(baseRow.Tanggal || baseRow.TanggalJam).getTime();
                const diffHours = (newTime - lastTime) / (1000 * 60 * 60);

                if (diffHours > 0) {
                    flowrate = (newQuantity - lastQuantity) / diffHours;
                } else {
                    return;
                }
            } else {
                const lastTimeRaw = cfg.startDate;
                const lastTime = new Date(lastTimeRaw).getTime();
                const diffHours = (newTime - lastTime) / (1000 * 60 * 60);

                if (diffHours > 0) {
                    flowrate = newQuantity / diffHours;
                } else {
                    return;
                }
            }


            if (isFinite(flowrate)) {
                $('#Flowrate').val(flowrate.toFixed(2));
            }

            // if (selectedUpdateId) {
            //     recalcFlowratesExcept(selectedUpdateId);
            // }
        }

        function recalcFlowratesExcept(excludeId) {
            const nodes = [];

            dataGridApi.forEachNodeAfterFilterAndSort(node => {
                nodes.push(node);
            });

            for (let i = 0; i < nodes.length; i++) {
                const node = nodes[i];
                const data = node.data;

                if (data.id === excludeId) continue;

                const currTime = new Date(data.Tanggal || data.TanggalJam).getTime();
                if (!currTime) continue;

                let flowrate = 0;

                if (i > 0) {
                    const prev = nodes[i - 1].data;
                    const prevTime = new Date(prev.Tanggal || data.TanggalJam).getTime();
                    const diffHrs = (currTime - prevTime) / 3600000;

                    if (diffHrs <= 0) continue;

                    if (IdTemplateAktivitas == '34') {
                        flowrate = (data.Volume - prev.Volume) / diffHrs;
                    } else {
                        flowrate = (data.VolumeDischarge - prev.VolumeDischarge) / diffHrs;
                    }
                } else {
                    const startTime = new Date(cfg.startDate).getTime();
                    const diffHrs = (currTime - startTime) / 3600000;

                    if (diffHrs <= 0) continue;

                    if (IdTemplateAktivitas == '34') {
                        flowrate = data.Volume / diffHrs;
                    } else {
                        flowrate = data.VolumeDischarge / diffHrs;
                    }
                }

                if (!isFinite(flowrate)) continue;

                const newFlowrate = flowrate.toFixed(2);

                if (String(data.Flowrate) === newFlowrate) continue;

                node.setDataValue('Flowrate', newFlowrate);

                const updatedRow = {
                    ...data,
                    Flowrate: newFlowrate
                };

                const idx = tempDataUpdate.findIndex(x => x.id === data.id);
                if (idx !== -1) {
                    tempDataUpdate[idx] = updatedRow;
                } else {
                    tempDataUpdate.push(updatedRow);
                }
            }
        }

        // function recalcTanggalJamSOP() {
        //     const nodes = [];

        //     dataGridApi.forEachNodeAfterFilterAndSort(node => {
        //         nodes.push(node);
        //     });

        //     const startTime = new Date(cfg.startDate).getTime();
        //     if (!startTime || !isFinite(startTime)) return;

        //     const changedNodes = [];

        //     for (let i = 0; i < nodes.length; i++) {
        //         const node = nodes[i];
        //         const data = node.data;

        //         const actualTime = new Date(data.TanggalJam).getTime();
        //         if (!actualTime || !isFinite(actualTime)) continue;

        //         const offsetMinutes = (i < 3) ? (i + 1) * 15 : (i - 2) * 60;

        //         const sopTime = startTime + (offsetMinutes * 60000);
        //         const sopFormatted = formatDateTime(new Date(sopTime));
        //         const selisihMenit = Math.round((actualTime - sopTime) / 60000);

        //         node.setDataValue('TanggalJamSOP', sopFormatted);
        //         node.setDataValue('SelisihWaktu', selisihMenit);

        //         changedNodes.push(node);

        //         const updatedRow = {
        //             ...data,
        //             TanggalJamSOP: sopFormatted,
        //             SelisihWaktu: selisihMenit
        //         };

        //         const idxAdd = tempDataAdd.findIndex(x => x.id === data.id);
        //         if (idxAdd !== -1) {
        //             tempDataAdd[idxAdd] = updatedRow;
        //             continue;
        //         }

        //         const idxUpd = tempDataUpdate.findIndex(x => x.id === data.id);
        //         if (idxUpd !== -1) tempDataUpdate[idxUpd] = updatedRow;
        //         else tempDataUpdate.push(updatedRow);
        //     }

        //     dataGridApi.refreshCells();
        // }

        function formatDateTime(dateObj) {
            const pad = (n) => String(n).padStart(2, '0');
            return (
                dateObj.getFullYear() + "-" +
                pad(dateObj.getMonth() + 1) + "-" +
                pad(dateObj.getDate()) + " " +
                pad(dateObj.getHours()) + ":" +
                pad(dateObj.getMinutes()) + ":" +
                pad(dateObj.getSeconds())
            );
        }
    });
})();