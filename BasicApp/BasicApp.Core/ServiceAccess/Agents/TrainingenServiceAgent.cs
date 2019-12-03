using BasicApp.Core.Business.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BasicApp.Core.ServiceAccess.Agents
{
    public interface ITrainingenServiceAgent
    {
        Task<List<Training>> GetTrainingen();

        Task PostTraining(Training training);
    }

    public class TrainingenServiceAgent :  ITrainingenServiceAgent
    {
        public async Task<List<Training>> GetTrainingen()
        {
            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://192.168.178.18:4999/api/trainingen");
                var responseContent = await response.Content.ReadAsStringAsync();
                var trainingenList = JsonConvert.DeserializeObject<List<Training>>(responseContent);
                return trainingenList;
            }
        }

        public async Task PostTraining(Training training)
        {
            using(var httpClient = new HttpClient())
            {
                var trainingDto = JsonConvert.SerializeObject(training);
                var requestContent = new StringContent(trainingDto, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://192.168.178.18:4999/api/trainingen", requestContent);
            }
        }
    }
}
