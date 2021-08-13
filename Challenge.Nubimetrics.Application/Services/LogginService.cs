using Challenge.Nubimetrics.Domain.DataModels;
using Challenge.Nubimetrics.Domain.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Services
{
    public interface ILogginService
    {
        Task WriteDisk(IEnumerable<CurrencyConversionDataModel> currencies);
    }

    public class LogginService : ILogginService
    {
        private readonly string JsonFileName;
        private readonly string CsvFileName;
        private readonly string FolderName;

        public LogginService(IOptions<LoggingDiskOptions> options)
        {
            JsonFileName = options.Value.FileJSON;
            CsvFileName = options.Value.FileCSV;
            FolderName = options.Value.FolderName;
        }

        public async Task WriteDisk(IEnumerable<CurrencyConversionDataModel> currencies)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FolderName);

            await WriteJson(currencies, path);

            await WriteCsv(currencies, path);
        }

        private async Task WriteJson(IEnumerable<CurrencyConversionDataModel> currencies, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string pathJson = Path.Combine(path, JsonFileName);

            await File.WriteAllTextAsync(pathJson, JsonConvert.SerializeObject(currencies));
        }

        private async Task WriteCsv(IEnumerable<CurrencyConversionDataModel> currencies, string path)
        {
            string pathCsv = Path.Combine(path, CsvFileName);

            var ratioList = new List<string>();

            currencies.ToList().ForEach(q => ratioList.Add(q.ToDolar?.Ratio));

            if (!ratioList.Any())
                return;

            await File.WriteAllTextAsync(pathCsv, JsonConvert.SerializeObject(ratioList));
        }
    }
}
