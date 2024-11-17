using System;
using Business;
using DataAccess;
using Entities;

class Program
{
    static void Main(string[] args)
    {
        // JSON dosyasının yolu
        string filePath = "response_1731754862513.json";

        // DataAccess katmanından veri oku
        var repository = new JsonRepository(filePath);
        Root data = repository.GetData();

        // Business katmanında hesaplama yap
        var calculator = new ItemCalculator();
        var summaries = calculator.CalculateContractSummaries(data.Items);

        // Sonuçları ekrana yazdır
        Console.WriteLine("ContractName\tToplam İşlem Tutarı\tToplam İşlem Miktarı\tAğırlıklı Ortalama Fiyat");
        foreach (var summary in summaries)
        {
            Console.WriteLine($"{summary.ContractName}\t{summary.TotalTransactionAmount:F2}\t\t{summary.TotalTransactionQuantity:F2}\t\t{summary.WeightedAveragePrice:F2}");
        }
    }
}