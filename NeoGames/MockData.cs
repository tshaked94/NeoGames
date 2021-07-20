using System;
using System.Collections.Generic;

namespace NeoGames.Models
{
    /// <summary>
    /// creates mock data (instead of getting data from DB)
    /// </summary>
    public sealed class MockData
    {
        private static readonly MockData instance = new MockData();
        private static Purchase[] purchases;

        static MockData()
        {
        }
        private MockData()
        {
            purchases = new Purchase[10];
            Purchase purchase = new Purchase(1, 1, "2019-11-26 16:09:31");
            purchases[0] = purchase;

            purchase = new Purchase(2, 5, "2019-11-26 16:09:31");
            purchases[1] = purchase;

            purchase = new Purchase(3, 56, "2019-11-26 16:09:32");
            purchases[2] = purchase;

            purchase = new Purchase(4, 22, "2019-11-26 16:09:32");
            purchases[3] = purchase;

            purchase = new Purchase(5, 154.5, "2019-11-26 16:09:32");
            purchases[4] = purchase;

            purchase = new Purchase(6, 35.56, "2019-11-26 16:09:32");
            purchases[5] = purchase;

            purchase = new Purchase(7, 12.01, "2019-11-26 16:12:31");
            purchases[6] = purchase;

            purchase = new Purchase(8, 13, "2019-11-26 16:13:31");
            purchases[7] = purchase;

            purchase = new Purchase(9, 0.58, "2019-11-26 16:14:31");
            purchases[8] = purchase;

            purchase = new Purchase(10, 155, "2019-11-27 16:09:31");
            purchases[9] = purchase;
        }

        public static MockData Instance
        {
            get
            {
                return instance;
            }
        }
        public Purchase[] getPurchases(int bulkSize = 5)
        {
            // in an app with DB - there would be an authentication layer.
            // I would create a table for each user of this api, and the last purchase id that he saw.
            // Then, I could get this data when I get a request, and get the correct data according to the data in this table.

            if (bulkSize == 0)
            {
                return purchases;
            }

            List<Purchase> currentPurchases = new List<Purchase>();

            foreach (Purchase purchase in purchases)
            {
                if (bulkSize == 0)
                {
                    break;
                }
                if (!purchase.GetIsSeen())
                {
                    currentPurchases.Add(purchase);
                    purchase.SetIsSeen(true);
                    bulkSize--;
                }
            }

            return currentPurchases.ToArray();
        }
    }

}