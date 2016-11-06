using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJackGame.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlackJackGameMVC.Controllers
{
    public class HomeController : Controller
    {
        [JsonProperty]
        private BlackJack _blackJack;

        public IActionResult Index()
        {
            _blackJack = new BlackJack();
            SetSession();
            return View(_blackJack);
        }
        public IActionResult NextCard()
        {
            _blackJack = LoadSession();
            _blackJack.GivePlayerAnotherCard();
            SetSession();
            return View("Index", _blackJack);
        }
        public IActionResult Pass()
        {
            _blackJack = LoadSession();
            _blackJack.PassToDealer();
            SetSession();
            return View("Index", _blackJack);
        }

        private BlackJack LoadSession()
        {
            return JsonConvert.DeserializeObject<BlackJack>(HttpContext.Session.GetString("BlackJack"));
        }

        private void SetSession()
        {
            HttpContext.Session.SetString("BlackJack", JsonConvert.SerializeObject(_blackJack));
        }
    }
}
