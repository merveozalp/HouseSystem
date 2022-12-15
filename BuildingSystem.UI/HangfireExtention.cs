using BuildingSystem.Business.Abstract;
using BuildingSystem.UI.Controllers;
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
            backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

            recurringJobManager.AddOrUpdate("ExpenseMail",
                () => serviceProvider.GetService<IExpenseService>().SendMail(),
              Cron.Monthly);
            return app;
        }
    }
}
