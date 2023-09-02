namespace TraversalProject.Areas.Admin.Models
{
    public class AccountViewModel
    {
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public decimal Amount { get; set; } // gönderilen/alınan para miktarı
    }
}
