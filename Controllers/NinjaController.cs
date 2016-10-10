using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Ninjaspace.Controllers
{
 public class NinjaController : Controller
 {
  [HttpGet]
  [Route("index")]
  public IActionResult Ninja()
  { 
      if(HttpContext.Session.GetString("display") == null)
      {
            HttpContext.Session.SetInt32("activities", 0);
            HttpContext.Session.SetString("display", "");
      }
      ViewBag.activities = HttpContext.Session.GetInt32("activities");
      ViewBag.display = HttpContext.Session.GetString("display");
      return View("Ninja");
  }

  // Post Method::: To take Survey Details
  [HttpPost]
  [Route("process_money")]
  public IActionResult create(string building)
  { 
      DateTime date = DateTime.Now;
      Random rnd = new Random();
      string Currentdisplay = HttpContext.Session.GetString("display");
                if(building == "farm")
                {
                  int Farm = (int)rnd.Next(10,21);
                  HttpContext.Session.SetInt32("activities", (int) HttpContext.Session.GetInt32("activities") + Farm);
                  Currentdisplay += $"Earned {Farm} golds from the farm! {date}";
                  HttpContext.Session.SetString("display", Currentdisplay);
                }

                else if(building == "cave")
                {
                  int Cave = (int)rnd.Next(5,11);
                  HttpContext.Session.SetInt32("activities", (int) HttpContext.Session.GetInt32("activities") + Cave);
                  Currentdisplay += $"Earned {Cave} golds from the cave! {date}";
                  HttpContext.Session.SetString("display", Currentdisplay);
                }

                else if(building == "house")
                {
                  int House = (int)rnd.Next(2,6);
                  HttpContext.Session.SetInt32("activities", (int) HttpContext.Session.GetInt32("activities") + House);
                  Currentdisplay += $"Earned {House} golds from the house! {date}";
                  HttpContext.Session.SetString("display", Currentdisplay);
                    
                }
                else if (building == "casino")
                {
                    int Casino = (int)rnd.Next(-50,51);
                    HttpContext.Session.SetInt32("activities", (int) HttpContext.Session.GetInt32("activities") + Casino);
                    if (Casino >= 0)
                    {
                        Currentdisplay += $"Entered a casino and earned {Casino} ...Yay!...({date})";
                        HttpContext.Session.SetString("display", Currentdisplay);                                      
                    }
                    else
                    {
                        Currentdisplay +=  $"Entered a casino and lost {Casino}...Ouch!...({date}) ";
                        HttpContext.Session.SetString("display", Currentdisplay);                                        
                    }
                }
                else
                {
                    Currentdisplay +=  $"<p>something went wrong</p>";
                    HttpContext.Session.SetString("display", Currentdisplay);
                }
               return RedirectToAction("Ninja"); 
  }
 }
}

