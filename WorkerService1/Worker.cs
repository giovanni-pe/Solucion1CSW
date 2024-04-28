using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using WorkerService1.Models;
using WorkerService1.Services;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEmailService _emailService;

        public Worker(ILogger<Worker> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                   
                    GetAnimals();
                }

                await Task.Delay(20000, stoppingToken);
            }
        }

        private async void GetAnimals()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7132/Animal");
                if (response.IsSuccessStatusCode)
                {
                    List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(await response.Content.ReadAsStringAsync());
     
                    await _emailService.SendEmailAsync("gkpe24u@gmail.com", "Cantidad de animales registrados", "Buenos dias señor administrador del ZooUnas, se le informa que hasta el momento hay " + animals.Count.ToString() + " animales registrados.");
                }
                else
                {
                    _logger.LogInformation($"error al consumir Api.{response.StatusCode}");
                }
            }
        }
       
    }
}
