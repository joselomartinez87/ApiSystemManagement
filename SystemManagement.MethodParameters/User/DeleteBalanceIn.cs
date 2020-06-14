namespace SystemManagement.MethodParameters.User
{
    public class DeleteBalanceIn : SystemManagement.MethodParameters.Common.BaseIn
    {
        public string usr_userNameDestiny { get; set; }

        public decimal valueTransfer { get; set; }

    }
}
