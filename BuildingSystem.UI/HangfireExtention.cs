using BuildingSystem.Business.Abstract;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BuildingSystem.UI
{
    public static class HangfireExtention
    {
        public static IApplicationBuilder UseApplicationModule(this IApplicationBuilder app,
            IBackgroundJobClient backgroundJobs, IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider)
        {
            backgroundJobs.Enqueue(() => Console.WriteLine("Hello Hangfire"));
            recurringJobManager.AddOrUpdate("ExpenseMail",
                () => serviceProvider.GetService<IExpenseService>().SendMail(),
              Cron.Daily);
            return app;
        }
    }
}
