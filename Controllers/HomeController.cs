using Microsoft.AspNetCore.Mvc;
using MyTamagotchi.Models;
using System.Collections.Generic;

namespace MyTamagotchi.Controllers
{
  public class HomeController : Controller
  {


    [HttpGet("/")]
        public ActionResult Index()
        {
          return View();
        }

        // [HttpGet("/tamagotchis")]
        // public ActionResult Tamagotchis()
        // {
        //     List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        //     return View(allTamagotchis);
        // }

        [HttpGet("/tamagotchi/new")]
        public ActionResult TamagotchiForm()
        {
            return View();
            //might need to edit this
        }

        [HttpPost("/tamagotchi")]
        public ActionResult AddTamagotchi()
        {
            Tamagotchi newTamagotchi = new Tamagotchi(Request.Form["petname"],
                                                      int.Parse(Request.Form["food"]),
                                                      int.Parse(Request.Form["attention"]),
                                                      int.Parse(Request.Form["rest"]));
            newTamagotchi.Save();
            Tamagotchi myTama = Tamagotchi.GetTama();
            //might need to edit this
            return View("TamagotchiDetails", myTama);
        }

        [HttpGet("/tamagotchi")]
        public ActionResult TamagotchiDetails(int id)
        {
            Tamagotchi tamagotchi = Tamagotchi.GetTama();
            return View(tamagotchi);
        }

        [HttpPost("/feed")]
        public ActionResult FeedTama()
        {
          Tamagotchi.GetTama().Feed();
          return  View("TamagotchiDetails", Tamagotchi.GetTama());
        }

        [HttpPost("/play")]
        public ActionResult PlayTama()
        {
          Tamagotchi.GetTama().Play();
          return  View("TamagotchiDetails", Tamagotchi.GetTama());
        }
        [HttpPost("/sleep")]
        public ActionResult SleepTama()
        {
          Tamagotchi.GetTama().Sleep();
          return  View("TamagotchiDetails", Tamagotchi.GetTama());
        }
        [HttpPost("/timepass")]
        public ActionResult TimepassTama()
        {

          Tamagotchi.GetTama().Timepass();
          if(Tamagotchi.GetTama().GetFood() <= 0 || Tamagotchi.GetTama().GetAttention() <= 0 || Tamagotchi.GetTama().GetRest() <= 0){
          return  View("Dead", Tamagotchi.GetTama());
          } else {
            return  View("TamagotchiDetails", Tamagotchi.GetTama());

          }
        }

        [HttpPost("/tamagotchi/list/clear")]
         public ActionResult TamagotchiListClear()
         {
             Tamagotchi.ClearTama();
             return View();
         }

  }
}
