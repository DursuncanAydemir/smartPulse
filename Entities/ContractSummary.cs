using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class ContractSummary
{
    public string ContractName { get; set; }
    public DateTime ContractDate { get; set; }
    public decimal TotalTransactionAmount { get; set; }
    public decimal TotalTransactionQuantity { get; set; }
    public decimal WeightedAveragePrice { get; set; }
}
