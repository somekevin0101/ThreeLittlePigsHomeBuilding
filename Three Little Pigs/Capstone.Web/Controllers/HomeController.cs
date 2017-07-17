using ThreeLittlePigs.Web.DAL;
using ThreeLittlePigs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThreeLittlePigs.Web.Controllers
{
    public class HomeController : Controller
    {
        private IHouseDAL houseDAL;
        private ISurveyDAL surveyDAL;

        public HomeController(IHouseDAL houseDAL, ISurveyDAL surveyDAL)
        {
            this.houseDAL = houseDAL;
            this.surveyDAL = surveyDAL;
        }
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            List<House> houses = houseDAL.GetAllHouses();
            return View("Index", houses);
        }

        [HttpGet]
        public ActionResult Detail(string houseCode)
        {
            House h = houseDAL.GetHouse(houseCode);

            return View("Detail", h);
        }
        [HttpGet]
        public ActionResult About()
        {
            return View("About");
        }

        [HttpGet]
        public ActionResult Services()
        {
            return View("Services");
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View("Contact");
        }


        [HttpGet]
        public ActionResult Survey()
        {
            List<House> houses = houseDAL.GetAllHouses();
            Survey s = new Survey()
            {
                Houses = ConvertListToSelectList(houses)
            };

            return View("Survey", s);
        }

        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            List<House> parks = houseDAL.GetAllHouses();
            survey.Houses = ConvertListToSelectList(parks);

            if (!ModelState.IsValid)
            {
                TempData["Incomplete"] = "Some required fields were not entered correctly. Please fix the fields marked with *.";
                return View ("Survey", survey);
            }

            surveyDAL.SaveSurvey(survey);

            TempData["StatusMessage"] = "Success! Your survey has been submitted!";

            return RedirectToAction("FavoriteHouses");
        }

        [HttpGet]
        public ActionResult FavoriteHouses()
        {
            Dictionary<House, int> houseVotes = new Dictionary<House, int>();

            List<House> houses = houseDAL.GetAllHouses();
            
            foreach(House h in houses)
            {
                int vote = surveyDAL.GetVotes(h.HouseCode);

                if(vote > 0)
                {
                    houseVotes.Add(h, vote);
                }
            }

            return View("FavoriteHouses", houseVotes);
        }


        // private helper methods

        private List<SelectListItem> ConvertListToSelectList(List<House> HouseList)
        {
            List<SelectListItem> dropdownlist = new List<SelectListItem>();

            foreach (House house in HouseList)
            {
                SelectListItem choice = new SelectListItem() { Text = house.HouseName, Value = house.HouseCode };
                dropdownlist.Add(choice);
            }

            return dropdownlist;
        }
    }
}