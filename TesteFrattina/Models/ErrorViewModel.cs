namespace TesteFrattina.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ValidationResult
    {
        public string MensagemErro { get; set; }
        public bool IsValid { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class PasswordRequest
    {
        public string password { get; set; }
        public string[]errors { get; set; }

        public string SuccessMessage { get; set; }

    }
}