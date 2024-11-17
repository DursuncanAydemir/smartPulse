using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities;

public static class ContractNameParser
{
    public static DateTime ParseContractDate(string contractName)
    {
        if (string.IsNullOrEmpty(contractName) || contractName.Length < 10)
            throw new ArgumentException("Geçersiz contractName formatı");

        string datePart = contractName.Substring(2, 8); // YYAAGGSS

        int year = 2000 + int.Parse(datePart.Substring(0, 2)); // YY
        int month = int.Parse(datePart.Substring(2, 2));       // AA
        int day = int.Parse(datePart.Substring(4, 2));         // GG
        int hour = int.Parse(datePart.Substring(6, 2));        // SS

        return new DateTime(year, month, day, hour, 0, 0);
    }
}
