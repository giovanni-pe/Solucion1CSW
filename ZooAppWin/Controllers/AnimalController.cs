using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZooAppWin.Models;

namespace ZooAppWin.Controllers
{
    internal class AnimalController

    {
        private HttpClient client;
        public AnimalController()
        {
            client = new HttpClient();
        }
        public async Task<List<Animal>> All()
        {
            try
            {
               List<Animal> animals = new List<Animal>();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7132/Animal");
                response.EnsureSuccessStatusCode(); 
                string responseJson=await response.Content.ReadAsStringAsync();
                animals=JsonConvert.DeserializeObject<List<Animal>>(responseJson);
                return animals;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
