using AutoMapper.Configuration;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using V8Hangfire.Application.Enums;
using V8Hangfire.Application.Interfaces;
using V8Hangfire.Domain.Interfaces.V8Hangfire;
using V8Hangfire.Domain.Models.V8Hangfire;

namespace V8Hangfire.Application.Services
{
    public class ScheduleService : IScheduleServices
    {
        #region Prop & ctor
        private readonly IV8HangfireRepositoryWrapper _v8HangFire;
        private readonly IConfiguration _configuration;
        private readonly IV8ClientServices _v8Client;


        public ScheduleService(IV8HangfireRepositoryWrapper v8Hangfire, IConfiguration configuration, IV8ClientServices v8ClientServices)
        {
            _v8HangFire = v8Hangfire;
            _configuration = configuration;
            _v8Client = v8ClientServices;
        }

        public async Task<bool> AddEnqueueJob(string service, string apiUrl, int IdRequest)
        {
            await _v8Client.EnqueueJobAsync(service, apiUrl, IdRequest);
            BackgroundJob.Enqueue(() => _v8Client.EnqueueJobAsync(service, apiUrl, IdRequest));
            return true;
        }

        public async Task<bool> UpdateOrAddJob(string jobCode, string service, string apiUrl, string cronString)
        {
            //Chèn và chạy job

            var curJob = await _v8HangFire.JobSchedule.GetAll().Where(x => x.JobName == jobCode).FirstOrDefaultAsync();
            if (curJob == null)
            {
                var obj = new JobSchedule
                {
                    JobTypeID = (int)EnumJobType.Type.Enqueue,
                    JobName = jobCode,
                    Service = service,
                    ApiUrl = apiUrl,
                    CronString = cronString,
                    Status = 1
                };
                await _v8HangFire.JobSchedule.InsertAsync(obj);
                await _v8HangFire.SaveAsync();
                RecurringJob.AddOrUpdate(jobCode, () => _v8Client.RecurringJobAsync(service, apiUrl), cronString);
            }
            else
            {
                curJob.JobTypeID = (int)EnumJobType.Type.Enqueue;
                curJob.JobName = jobCode;
                curJob.Service = service;
                curJob.ApiUrl = apiUrl;
                curJob.CronString = cronString;
                if (curJob.Status == 1)
                {
                    curJob.Status = 0;
                    await _v8HangFire.JobSchedule.UpdateAsync(curJob);
                    await _v8HangFire.SaveAsync();
                    RecurringJob.RemoveIfExists(curJob.JobName);
                }
                else
                {
                    curJob.Status = 1;
                    await _v8HangFire.JobSchedule.UpdateAsync(curJob);
                    await _v8HangFire.SaveAsync();
                    RecurringJob.AddOrUpdate(jobCode, () => _v8Client.RecurringJobAsync(service, apiUrl), cronString);
                }
            }
            return true;
        }
        #endregion
    }
}
