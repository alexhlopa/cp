using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryLab5;
using CrossPlatformLab5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossPlatformLab5.Controllers
{
    [Authorize]
    public class LabsController : Controller
    {
        public IActionResult PR1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PR1(FirstLabModel firstLabModel)
        {
            try
            {
                firstLabModel.Response = new Lab1()
                    .GetResult(firstLabModel.N, firstLabModel.K)
                    .ToString();
                firstLabModel.Calculated = true;
            }
            catch (Exception exception)
            {
                firstLabModel.ErrorValue = exception.Message;
            }
            return View(firstLabModel);
        }

        public IActionResult PR2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PR2(SecondLabModel secondLabModel)
        {
            try
            {
                secondLabModel.Response = new Lab2()
                    .GetResult(secondLabModel.N)
                    .ToString();
                secondLabModel.Calculated = true;
            }
            catch (Exception exception)
            {
                secondLabModel.ErrorValue = exception.Message;
            }
            return View(secondLabModel);
        }
    }
}

        
       
    

