namespace RapidApi.WebUI.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Hata mesajýný tutacak yeni özellik
        public string? Message { get; set; }

        // Ýsteðe baðlý: Exception detaylarýný tutacak özellik
        public string? ExceptionDetails { get; set; }
    }
}