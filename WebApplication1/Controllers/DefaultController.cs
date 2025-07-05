using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        //binding id to root variable name sould matching , order don't matter
        //https://localhost:7092/default/index/123?a=100&b=200&c=300
        //using query string
        public IActionResult Index(int? id,int c=3, int a=1, int b=2)
        {
            //if (id == null)
            //    return NotFound();


            //to pass something controller -> view
            //use ViewBag
            //uses dynamic coding -> uses Expando coding ->create properties at runtime
            ViewBag.id=id; 
            ViewBag.c=c;
            ViewBag.a=a;
            ViewBag.b=b;

            
            return View();
        }
    }
}
