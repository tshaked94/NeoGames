using System;

namespace NeoGames.Models
{
    /// <summary>
    /// This is a class for a single purchase item
    /// </summary>
    public class Purchase
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string PurchaseDate { get; set; }
        private bool IsSeen;

        public bool GetIsSeen()
        {
            return IsSeen;
        }

        public void SetIsSeen(bool isSeen)
        {
            IsSeen = isSeen;
        }

        public Purchase(int id, double amount, string purchaseDate)
        {
            this.Id = id;
            this.Amount = amount;
            this.PurchaseDate = purchaseDate;
            this.IsSeen = false;
        }
    }

}
