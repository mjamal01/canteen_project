using System;
namespace DellyShopApp.ParentsData.CashHandling
{
    public class cant_parent_cash_trans
    {
        public cant_parent_cash_trans()
        {
        }
        public DateTime DTG { get; set; }
        public int id { get; set; }
        public int parent_id { get; set; }
        public int Ref { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal Balance { get; set; }
        public string image { get; set; }//This is just for showing Debit and Credit differenciation
        public string AmountDescription { get; set; }
        public string BalanceAmount { get; set; }
    }
}
