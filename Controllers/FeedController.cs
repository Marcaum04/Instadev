using System.Collections.Generic;
using Instadev.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instadev.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}