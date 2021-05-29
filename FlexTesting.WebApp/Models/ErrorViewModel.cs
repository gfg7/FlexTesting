using System;

namespace FlexTesting.WebApp.Models
{
    public record ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string ErrorMessage { get; set; }
        public static ErrorViewModel WithError(string error) => new ErrorViewModel() {ErrorMessage = error};
    }
}