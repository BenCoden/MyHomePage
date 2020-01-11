using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyHomePage.Shared
{
    public interface IJsonReader<T>
    {
        List<T> GetTypeFromFile(string json);

        Task<List<T>> GetTypeFromFileAsync(string filepath);
    }

    public class JsonReader<T> : IJsonReader<T>
    {
        public async Task<List<T>> GetTypeFromFileAsync(string filepath)
        {
            Debug.Assert(!string.IsNullOrEmpty(filepath));
            Debug.Assert(File.Exists(filepath));

            return GetTypeFromFile(await File.ReadAllTextAsync(filepath));
        }

        public List<T> GetTypeFromFile(string json)
        {
            try
            {
                Debug.Assert(json != null);
                var result = JsonConvert.DeserializeObject<List<T>>(json);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}