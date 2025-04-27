using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using DomainService.Adds;
using DomainService.Objects;

namespace DomainService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class CentralBankService : ICentralBankService
    {
        private string _apiUrl = "https://www.cbr-xml-daily.ru/daily_json.js";
        public ConverterObject ConvertValue(double value, string currencyName)
        {
            ConverterObject converterRes = new ConverterObject();
            using (HttpClient _httpClient = new HttpClient())
            {
                HttpResponseMessage response = _httpClient.GetAsync(_apiUrl).Result;
                Logger.WriteInfo("Trying to fetch CB data");
                if (response.IsSuccessStatusCode)
                {
                    converterRes.requestRes = response.StatusCode.ToString();
                    var rawRes = response.Content.ReadAsStringAsync().Result;
                    var desResult = JsonConvert.DeserializeObject<ResultRoot>(rawRes);
                    switch (currencyName)
                    {
                        case "EUR":
                            converterRes.currencyValue = value / desResult.Valute["EUR"].Value;
                            converterRes.currencyName = "EUR";
                            break;
                        case "USD":
                            converterRes.currencyValue = value / desResult.Valute["USD"].Value;
                            converterRes.currencyName = "USD";
                            break;
                        case "KZT":
                            converterRes.currencyValue = value / desResult.Valute["KZT"].Value;
                            converterRes.currencyName = "KZT";
                            break;
                        case "CNY":
                            converterRes.currencyValue = value / desResult.Valute["CNY"].Value;
                            converterRes.currencyName = "CNY";
                            break;
                        default:
                            converterRes.currencyValue = value;
                            converterRes.currencyName = "RUB";
                            break;
                    }
                    Logger.WriteStatus("Successfuly fetched");
                    return converterRes;
                }
                else
                {
                    converterRes.currencyValue = value;
                    converterRes.currencyName = "RUB";
                    converterRes.requestRes = response.StatusCode.ToString();
                }
            }
            return converterRes;
        }
    }
}
