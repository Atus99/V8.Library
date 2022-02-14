using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using V8Hangfire.Application.Interfaces;

namespace V8.HangFire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        #region Prop & Ctor
        private readonly IScheduleServices _schedule;
        private readonly IConfiguration _configuration;

        public ScheduleController(IScheduleServices scheduleServices, IConfiguration configuration)
        {
            _schedule = scheduleServices;
            _configuration = configuration;
        }

        #endregion

        [HttpPost("add-or-update")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> UpdateOrAddJob(ScheduleInput input)
        {
            var rs = await _schedule.UpdateOrAddJob(input.JobCode, input.Service, input.ApiUrl, input.CronString);
            return new ObjectResult(rs);
        }

        [HttpPost("fire-and-forget")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Squence(ScheduleInput input)
        {
            var rs = await _schedule.AddEnqueueJob(input.Service, input.ApiUrl, input.IdRequest);
            return new ObjectResult("");
        }

        public class ScheduleInput
        {
            public string JobCode { get; set; }
            public string Service { get; set; }
            public string ApiUrl { get; set; }
            public string CronString { get; set; }
            public int IdRequest { get; set; }
        }
    }
}
