using Microsoft.AspNetCore.Mvc;
using Library;
using System;
using IdentityServer4;

namespace WebApp.Controllers
{
    public class LabsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Lab1()
        {
            return View();
        }

        public IActionResult Lab2()
        {
            return View();
        }

        public IActionResult Lab3()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RunLab(int labNumber, string inputFilePath, string outputFilePath)
        {
            try
            {
                switch (labNumber)
                {
                    case 1:
                        Library.Lab1.Run(inputFilePath, outputFilePath);
                        break;
                    case 2:
                        Library.Lab2.Run(inputFilePath, outputFilePath); 
                        break;
                    case 3:
                        Library.Lab3.Run(inputFilePath, outputFilePath);
                        break;
                    default:
                        throw new Exception("Invalid lab number.");
                }

                ViewBag.Message = $"Lab {labNumber} executed successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }

            return View("Index");
        }
        
    }
}
