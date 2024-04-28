using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppZoo.Models;
namespace WebAppZoo.Services
{
    public class ZooApiService: ApiService
    {
        private static string _baseurl;
        public ZooApiService()
        {
            var builder=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseurl").Value;
        }

        public async Task<List<Animal>> All()
        {
            List<Animal> list = new List<Animal>();
            var client=new HttpClient();
            client.BaseAddress=new Uri(_baseurl);
            var response = await client.GetAsync("Animal");
            if (response.IsSuccessStatusCode)
            {
                var response_json= await response.Content.ReadAsStringAsync();
                Console.WriteLine(response_json);
                list=JsonConvert.DeserializeObject<List<Animal>>(response_json);    
            }
            return list;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Animal entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Animal entity)
        {
            throw new NotImplementedException();
        }
    }
}
