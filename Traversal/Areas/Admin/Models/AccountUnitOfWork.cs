namespace PresentationLayer.Areas.Admin.Models
{
    public class AccountUnitOfWork
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public decimal Amount { get; set; }
    }
}
