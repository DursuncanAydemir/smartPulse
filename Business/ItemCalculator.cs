using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Business;

public class ItemCalculator
{
    public List<ContractSummary> CalculateContractSummaries(List<Item> items)
    {
        var grouped = items.GroupBy(i => i.ContractName);

        List<ContractSummary> summaries = new List<ContractSummary>();

        foreach (var group in grouped)
        {
            string contractName = group.Key;
            DateTime contractDate = ContractNameParser.ParseContractDate(contractName);

            decimal totalTransactionAmount = group.Sum(i => (i.Price * i.Quantity) / 10);
            decimal totalTransactionQuantity = group.Sum(i => i.Quantity / 10);
            decimal weightedAveragePrice = totalTransactionQuantity > 0
                ? totalTransactionAmount / totalTransactionQuantity
                : 0;

            summaries.Add(new ContractSummary
            {
                ContractName = contractName,
                ContractDate = contractDate,
                TotalTransactionAmount = totalTransactionAmount,
                TotalTransactionQuantity = totalTransactionQuantity,
                WeightedAveragePrice = weightedAveragePrice
            });
        }

        return summaries;
    }
}
