using Paypal.Entities;
using System;

namespace Paypal.Services
{
    class ContractService
    {
        private IOnlineService _onlineService;

        public ContractService(IOnlineService onlineService)
        {
            _onlineService = onlineService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + _onlineService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _onlineService.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
