using System;
using Business;
using DataAccess;
using Entities;

class Program
{
    static void Main(string[] args)
    {
        // JSON dosyasının yolu
        string filePath = @"C:\Users\Monster\source\repos\smartPulse\response_1731754862513.json";

        // DataAccess katmanından veri okuma
        var repository = new JsonRepository(filePath);
        Root data = repository.GetData();

        // Business katmanında hesaplama yapma
        var calculator = new ItemCalculator();
        var summaries = calculator.CalculateContractSummaries(data.Items);

        // Sonuçları ekrana yazdırma
        Console.WriteLine("{0,-15} | {1,-20} | {2,-20} | {3,-20} | {4,-20}",
           "Contract Name", "Contract Date", "Total Transaction Amount",
           "Total Transaction Quantity", "Weighted Average Price");
        Console.WriteLine(new string('-', 100));

        // Veriler
        foreach (var summary in summaries)
        {
            Console.WriteLine("{0,-15} | {1,-20} | {2,-20:N2} | {3,-20:N2} | {4,-20:N2}",
                summary.ContractName,
                summary.ContractDate.ToString("dd/MM/yyyy HH:mm"),
                summary.TotalTransactionAmount,
                summary.TotalTransactionQuantity,
                summary.WeightedAveragePrice);
        }
    }
}
