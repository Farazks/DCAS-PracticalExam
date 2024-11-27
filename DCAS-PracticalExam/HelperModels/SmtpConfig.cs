namespace DCAS_PracticalExam.HelperModels
{
    public class SmtpConfig
    {
        public string senderAddress { get; set; }
        public string senderDisplayName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string host { get; set; }
        public int port { get; set; }
        public bool enableSsl { get; set; }
        public bool useDefaultCredentials { get; set; }
        public bool isBodyHtml { get; set; }
    }
}
