namespace SystemManagement.MethodParameters.User
{
    public class TransferBalanceIn : SystemManagement.MethodParameters.Common.BaseIn
    {

        public string usr_userNameOrigin { get; set; }
        public string usr_userNameDestiny { get; set; }

        public decimal valueTransfer { get; set; }

    }
}
