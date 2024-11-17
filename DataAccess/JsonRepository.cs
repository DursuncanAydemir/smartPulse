using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public class JsonRepository
{
    private readonly string _filePath;

    public JsonRepository(string filePath)
    {
        _filePath = filePath;
    }

    public Root GetData()
    {
        // JSON dosyasını okuma
        string jsonData = File.ReadAllText(_filePath);

        // JSON'u deserialize etme
        return JsonConvert.DeserializeObject<Root>(jsonData);
    }
}
