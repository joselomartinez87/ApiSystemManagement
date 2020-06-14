namespace SystemManagement.MethodParameters.Authentication
{
    public class ValidateSessionIn : MethodParameters.Common.BaseIn
    {
        public string sessionId { get; set; }

        public decimal userId { get; set; }

    }
}
