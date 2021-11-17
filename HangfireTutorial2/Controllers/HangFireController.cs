using Hangfire;
using HangfireDemo.Demo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireTutorial2.Controllers
{
    [Route("/Api/HangFire")]
    public class HangFireController : Controller
    {
        private IDemoService demoService;

        public HangFireController(IDemoService demoService)
        {
            this.demoService = demoService;
        }

        [HttpGet]
        [Route("recurringTask")]
        public IActionResult Index()
        {
            RecurringJob.AddOrUpdate(recurringJobId:"demo-job", methodCall: () => this.demoService.RunDemoTask(), Cron.Minutely);

            return Ok();
        }

        [HttpGet]
        [Route("backgroundTask/{fibParam}")]
        public IActionResult Fibonnaci(int fibParam)
        {
            BackgroundJob.Enqueue(() => this.demoService.RunFibDemo(fibParam));

            return Ok();
        }
    }


}
