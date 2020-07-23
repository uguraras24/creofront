using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AccountInfo : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Individual()
        {
            MySqlDatabase msDB = new MySqlDatabase();

            List<DropDown> countryList = new List<DropDown>();
            List<DropDown> stateList = new List<DropDown>();
            List<DropDown> cityList = new List<DropDown>();

            var dropDownTuple = msDB.dropDownListReturn();
            List<string> countryL = dropDownTuple.Item1;
            List<string> stateL = dropDownTuple.Item2;
            List<string> cityL = dropDownTuple.Item3;

            foreach (var countryVal in countryL)
                countryList.Add(new DropDown { value = countryVal, content = countryVal });
            foreach (var stateVal in stateL)
                stateList.Add(new DropDown { value = stateVal, content = stateVal });
            foreach (var cityVal in cityL)
                cityList.Add(new DropDown { value = cityVal, content = cityVal });

            ViewBag.countryList = new SelectList(countryList, "value", "content");
            ViewBag.stateList = new SelectList(stateList, "value", "content");
            ViewBag.cityList = new SelectList(cityList, "value", "content");

            return View();
        }


        public IActionResult Institutional()
        {
            MySqlDatabase msDB = new MySqlDatabase();

            List<DropDown> countryList = new List<DropDown>();
            List<DropDown> stateList = new List<DropDown>();
            List<DropDown> cityList = new List<DropDown>();

            var dropDownTuple = msDB.dropDownListReturn();
            List<string> countryL = dropDownTuple.Item1;
            List<string> stateL = dropDownTuple.Item2;
            List<string> cityL = dropDownTuple.Item3;

            foreach (var countryVal in countryL)
                countryList.Add(new DropDown { value = countryVal, content = countryVal });
            foreach (var stateVal in stateL)
                stateList.Add(new DropDown { value = stateVal, content = stateVal });
            foreach (var cityVal in cityL)
                cityList.Add(new DropDown { value = cityVal, content = cityVal });

            ViewBag.countryList = new SelectList(countryList, "value", "content");
            ViewBag.stateList = new SelectList(stateList, "value", "content");
            ViewBag.cityList = new SelectList(cityList, "value", "content");

            return View();
        }


        public IActionResult InstitutionalCreate(Models.Institutional institutionalForm)
        {
            ClaimsPrincipal cp = this.User;
            MySqlDatabase msDB = new MySqlDatabase();

            String userId = cp.FindFirst(ClaimTypes.NameIdentifier).Value;
            String displayName = "";
            Boolean institutionalControl = false;

            var institutionalJsonData = new Institutional
            {
                displayname = institutionalForm.firstname + " " + institutionalForm.lastname,
                firstname = institutionalForm.firstname,
                lastname = institutionalForm.lastname,
                birthday = institutionalForm.birthday,
                taxidein = institutionalForm.taxidein,
                email = institutionalForm.email,
                alternativeemail = institutionalForm.alternativeemail,
                phone = institutionalForm.phone,
                alternativephone = institutionalForm.alternativephone,
                address = institutionalForm.address,
                country = institutionalForm.country,
                state = institutionalForm.state,
                city = institutionalForm.city,
                zipcode = institutionalForm.zipcode,
                companycorporationname = institutionalForm.companycorporationname,
                companytaxid_ein = institutionalForm.companytaxid_ein,
                companysectors = institutionalForm.companysectors,
                companyabout = institutionalForm.companyabout,
                companyemail = institutionalForm.companyemail,
                companyphone = institutionalForm.phone,
                companywebsite = institutionalForm.companywebsite,
                companyaddress = institutionalForm.companyaddress,
                companycountry = institutionalForm.companycountry,
                companystate = institutionalForm.companystate,
                companycity = institutionalForm.companycity,
                companyzipcode = institutionalForm.companyzipcode,

            };

            string jsonData;
            jsonData = JsonConvert.SerializeObject(institutionalJsonData);
            institutionalControl = msDB.accountInstitutionalJsonCreate(userId, "Create Profile", jsonData);

            if (institutionalControl)
            {
                displayName = institutionalForm.firstname + " " + institutionalForm.lastname;
                ClaimsIdentity displayNameIdentity = new ClaimsIdentity();
                displayNameIdentity.AddClaim(new Claim(ClaimTypes.Name, displayName));
                cp.AddIdentity(displayNameIdentity);
                HttpContext.SignInAsync(cp);

                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index", "Login");




        }
        public IActionResult IndividualCreate(Models.Individual individualForm)
        {
            ClaimsPrincipal cp = this.User;
            MySqlDatabase msDB = new MySqlDatabase();

            String userId = cp.FindFirst(ClaimTypes.NameIdentifier).Value;
            String displayName = "";
            Boolean individualControl = false;            

            var individualJsonData = new Individual
            {
                displayname = individualForm.firstname + " " + individualForm.lastname,
                firstname = individualForm.firstname,
                lastname = individualForm.lastname,
                birthday = individualForm.birthday,
                taxidein = individualForm.taxidein,
                email = individualForm.email,
                alternativeemail = individualForm.alternativeemail,
                phone = individualForm.phone,
                alternativephone = individualForm.alternativephone,
                address = individualForm.address,
                country = individualForm.country,
                state = individualForm.state,
                city = individualForm.city,
                zipcode = individualForm.zipcode,
                bankname = individualForm.bankname,
                accountnumber = individualForm.accountnumber,
                rintaba = individualForm.rintaba,
                swiftbc = individualForm.swiftbc
            };

            string jsonData;
            jsonData = JsonConvert.SerializeObject(individualJsonData);
            individualControl = msDB.accountIndividualJsonCreate(userId,"Create Profile",jsonData);

            if (individualControl)
            {
                displayName = individualForm.firstname + " " + individualForm.lastname;
                ClaimsIdentity displayNameIdentity = new ClaimsIdentity();
                displayNameIdentity.AddClaim(new Claim(ClaimTypes.Name, displayName));
                cp.AddIdentity(displayNameIdentity);
                HttpContext.SignInAsync(cp);
               
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index", "Login");

        }
    }
}
