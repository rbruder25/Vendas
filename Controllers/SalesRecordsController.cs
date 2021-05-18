
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using System;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public  SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxdate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year,1, 1);
            }
            if(!maxdate.HasValue)
            {
                maxdate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxdate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindBynameAsync(minDate, maxdate);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
