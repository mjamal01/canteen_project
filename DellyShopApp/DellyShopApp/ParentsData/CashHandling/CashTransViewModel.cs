using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace DellyShopApp.ParentsData.CashHandling
{
    public class CashTransViewModel
    {
        public ObservableCollection<cant_parent_cash_trans> transactions { get; set; }
        public decimal totalDebit { get; set; }
        public decimal totalCredit { get; set; }

        public CashTransViewModel()
        {
            transactions = new ObservableCollection<cant_parent_cash_trans>();
            totalDebit = 0;
            totalCredit = 0;
            UpdateTransactions();
        }
        public void UpdateTransactions()
        {
            transactions.Clear();
            try
            {
                transactions = JsonConvert.DeserializeObject<ObservableCollection<cant_parent_cash_trans>>(Global.CashTransDetail);
                foreach (var trans in transactions)
                {

                    totalDebit += trans.Debit;
                    totalCredit += trans.Credit;

                }
            }
            catch (Exception ex)
            {

            }
        }
    }

}
