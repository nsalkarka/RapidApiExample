namespace RapidApi.WebUI.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Hata mesaj�n� tutacak yeni �zellik
        public string? Message { get; set; }

        // �ste�e ba�l�: Exception detaylar�n� tutacak �zellik
        public string? ExceptionDetails { get; set; }
    }
}