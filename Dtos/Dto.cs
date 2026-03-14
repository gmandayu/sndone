public class GetStartupSubAktivitasResponse
{
    public bool IsEditable { get; set; }
    public string StatusAktivitas { get; set; } = string.Empty;
    public List<LogAktivitasResponse> LogAktivitas { get; set; } = [];
    public class LogAktivitasResponse
    {
        public string Aktivitas { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string StatusAktivitas { get; set; } = string.Empty;
        public string Tanggal { get; set; } = string.Empty;
        public string Catatan { get; set; } = string.Empty;
    }
}

public class MWTOnlineRequest
{
    public List<IFormFile>? Files { get; set; }
    public IFormFile? File { get; set; }
    public string? Plant { get; set; } = "";
    public string? Deskripsi { get; set; } = "";
    public string? DeskripsiFile { get; set; } = "";
    public string? Id { get; set; } = "";
}

public class BukuTamuRequest
{
    public IFormFile? TandaTangan { get; set; }

    public IFormFile? File { get; set; }

    public DateTime? Tanggal { get; set; }

    public string? Plant { get; set; } = "";

    public string? Nama { get; set; } = "";

    public string? AsalPerusahaan { get; set; } = "";

    public string? Jabatan { get; set; } = "";

    public string? FungsiYgDikunjungi { get; set; } = "";

    public string? MaksudKunjungan { get; set; } = "";

    public string? TandaPengenal { get; set; } = "";

    public string? Keterangan { get; set; } = "";

    public string? Pintu { get; set; } = "";

    public string? PintuId { get; set; } = "";

    public DateTime PintuUtamaInTanggal { get; set; }

    public string? Id { get; set; }
}

public class UploadAktivitasDokumenRequest
{
    public string? IdAktivitasDokumen { get; set; }

    public string? IdAktivitas { get; set; }

    public string? NoReferensi { get; set; }

    public List<IFormFile>? files { get; set; }

    public List<string>? DeletedIds { get; set; }
}

public class UploadDocumentGHKandPOVRequest
{
    public string? idRef { get; set; }

    public string? NoReferensi { get; set; }

    public DateTime? Tanggal { get; set; }

    public IFormFile? VerifikasiMOD { get; set; }

    public List<IFormFile>? files { get; set; }

    public string? Lokasi { get; set; }

    public string? Keterangan { get; set; }

    public string? Ketidaksesuaiaan { get; set; }

    public string? Menu { get; set; }

    public string? NamaSecurity { get; set; }
}

public class UpdateDocumentGHKandPOVRequest : UploadDocumentGHKandPOVRequest
{
    public List<string>? DeletedIds { get; set; }
}

public class UpdateStatusAktivitasByDocumentRequest
{
    public required string IdAktivitas { get; set; }
    public string? Keterangan { get; set; }
    public required string StatusAktivitas { get; set; }
    public string? Catatan { get; set; }
    public bool IsNominationTankReceivingLineOpen { get; set; } = false;
    public bool IsNonNominationReceivingLineClosedAndSealed { get; set; } = false;
    public bool IsTankEmptyAndDry { get; set; } = false;
    public bool IsDocumentationComplete { get; set; } = false;
}

public class SendEmailRequest
{
    public string? Email { get; set; }
}

public class ResetPasswordRequest
{
    public string? Action { get; set; }

    public string? User { get; set; }

    public string? Code { get; set; }

    public string? NewPassword { get; set; }

    public string? NewPasswordConfirm { get; set; }
}

public class ValidateResetPasswordRequest
{
    public string? Action { get; set; }

    public string? User { get; set; }

    public string? Code { get; set; }
}

public class DeleteReferensiRequest
{
    public string? Referensi { get; set; }

    public List<string>? IdReferensi { get; set; }
}

public class CheckDuplicateReferensiRequest
{
    public string? Referensi { get; set; }

    public Dictionary<string, object>? Data { get; set; }
}

public class UpdateAktivitasTabelRequest
{
    public string? TableName { get; set; }

    public string? IdAktivitas { get; set; }

    public string? IdProses { get; set; }

    public string? NoReferensi { get; set; }

    public string? Status { get; set; }

    public string? Catatan {get; set;}

    public List<Dictionary<string, object>> ItemsAdd { get; set; } = [];

    public List<Dictionary<string, object>> ItemsUpdate { get; set; } = [];

    public List<string> DeletedIds { get; set; } = [];
}

public class UpdateDokumenMandatory
{
    public string? NoReferensi { get; set; }

    public string? IdProses { get; set; }

    public string? IdAktivitas { get; set; }

    public string Jenis {get; set;} = "BBM";
}

public class UpdateAMTRequest
{
    public string? NoReferensi { get; set; }

    public string? IdAktivitas { get; set; }

    public string? AMT { get; set; }
}

public class SubAktivitasHasilPemeriksaanResponse
{
    public int? Id {get; set;}

    public DateTime? TanggalJam {get; set;}

    public string? Density {get; set;}

    public string? Temperature {get; set;}

    public string? Keterangan {get; set;}

    public string? LabelProduk { get; set; }
    public string? NomorBatch { get; set; } = "";
    // khusus BBM_RTW
    public string? NamaKegiatan { get; set; }
    public string? Level { get; set; }
    public decimal? Quantity { get; set; }
    public decimal? Flowrate { get; set; }
}

public class UpdateByNoReferensi
{
    public string? NoReferensi { get; set; }
    public string? IdAktivitas { get; set; }
    public string? Jenis { get; set; } = "BBM";
}

public class ExportAktivitasTabelRequest
{
    public Dictionary<string, object>? GeneralData { get; set; }

    public string? TableName { get; set; }

    public string? NoReferensi { get; set; }

    public string? IdAktivitas { get; set; }
}

public class UpdateStatusAktivitasRequest
{
    public int IdAktivitas { get; set; }

    public string? StatusAktivitas {get; set;}

    public string? Catatan {get; set;}
}

public class FaceEnrollmentRequest
{
    public string? IdUser { get; set; }

    public string? Username { get; set; }

    public IFormFile? Face { get; set; }

    public DateTime? Tanggal {get; set;}
}

public class DropdownResponse
{
    public int Value { get; set; }

    public string Label { get; set; } = string.Empty;
}

public class FaceEnrollmentDelete
{
    public string? IdUser { get; set; }

    public string? Username { get; set; }

    public DateTime? Tanggal {get; set;}

    public string? AzurePersonId { get; set; }
}

public class IdamanPositionsResponse
{
    public string? next { get; set; }

    public int page { get; set; }

    public int total { get; set; }

    public List<IdamanPositionItem>? value { get; set; }
}

public class IdamanPositionItem
{
    public string? id { get; set; }

    public IdamanCompany? company { get; set; }

    public IdamanPosition? position { get; set; }

    public string? email { get; set; }
}

public class IdamanCompany
{
    public string? code { get; set; }

    public string? name { get; set; }
}

public class IdamanPosition
{
    public string? id { get; set; }

    public string? parentId { get; set; }

    public string? name { get; set; }

    public string? kbo { get; set; }

    public IdamanOrganization? organization { get; set; }
}

public class IdamanOrganization
{
    public string? id { get; set; }

    public string? name { get; set; }

    public string? companyCode { get; set; }
}

public class IdamanUserMini
{
    public string? id { get; set; }

    public string? displayName { get; set; }

    public string? email { get; set; }

    public string? certificateNumber { get; set; }

    public string? employeeType { get; set; }
}

public class TokenResponse
{
    public string? access_token { get; set; }

    public string? token_type { get; set; }

    public int expires_in { get; set; }
}

public class MasterUserDto
{
    public int IdUser { get; set; }
    public string? IdIdaman { get; set; }
    public string? Email { get; set; }
    public int? IdPosition { get; set; }
}

public class TujuanKonsinyasiItem
{
    public string? Value { get; set; }
    public string? Label { get; set; }
    public decimal? Qty { get; set; }
}

public class AddNewPjsDto
{
    public string OrganizationLevel { get; set; }
    public int PosisiAwal { get; set; }
    public int PosisiPJS { get; set; }
    public DateTime TanggalMulai { get; set; }
    public DateTime TanggalSelesai { get; set; }
    public IFormFile SuratTugas { get; set; }
    public string? Keterangan { get; set; } = "";
    public int? IdRegion { get; set; } = 0;
    public int? IdPlant { get; set; } = 0;
}

public class UpdatePjsDto
{
    public int Id { get; set; }
    public int PosisiPJS { get; set; }
    public IFormFile? SuratTugas { get; set; }
    public DateTime TanggalMulai { get; set; }
    public DateTime TanggalSelesai { get; set; }
    public string? Keterangan { get; set; } = "";
}

public class ApprovalPjsDto
{
    public int Id { get; set; }
    public int PosisiPJS { get; set; }
    public string ApprovalStatus { get; set; }
    public string? Remarks { get; set; } = "";
}

public class CheckIdamanPositionRequest
{
    public string Email { get; set; } = "";
}

public class IdamanUserSearchResponse
{
    public string? next { get; set; }
    public int page { get; set; }
    public int total { get; set; }
    public List<IdamanUserSearchItem>? value { get; set; }
}

public class IdamanUserSearchItem
{
    public string? id { get; set; }
    public IdamanUserSearchPosition? position { get; set; }
    public string? email { get; set; }
    public string? displayName { get; set; }
    public string? username { get; set; }
}

public class IdamanUserSearchPosition
{
    public string? id { get; set; }
    public string? name { get; set; }
}
public class IdamanResolvedUserDto
{
    public int IdPosition { get; set; } = 11111111; 
    public string IdPositionIdaman { get; set; } = string.Empty;
    public string PositionName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string IdIdaman { get; set; } = string.Empty;
}
