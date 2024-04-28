using WorkerService1;
using WorkerService1.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
