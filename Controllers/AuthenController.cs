using learn.core.Data;
using learn.core.DTO;
using learn.core.service;
using learn.infra.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Apimonth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenticationservice authenticationservice;
        private readonly IEmalservice emailservice;
        private readonly IUsersservice usersservvice;

        public AuthenController(IAuthenticationservice authenticationservice, IEmalservice emailservice, IUsersservice usersservvice)
        {
            this.authenticationservice = authenticationservice;
            this.emailservice = emailservice;
            this.usersservvice = usersservvice;
        }

        [HttpPost]
        public IActionResult authen([FromBody] login_api login)
        {
            var RESULT = authenticationservice.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {
                return Ok(RESULT); //200
            }
        }
        [HttpPost("Blocker")]
        public IActionResult BlockAuthen([FromBody] BlockF_dto BlockF_)
        {
            string emailservice1 = emailservice.BlockEmail(BlockF_);
            if (emailservice1 == "True")
            {
                return Ok("Sent");
            }
            else
            {
                return BadRequest("Not sent");
            }
        }
        [HttpPost("Email")]
        public IActionResult Send([FromBody]Employee_newDto e)
        {
            string emailservice1 = emailservice.GetEmail(e);
            if (emailservice1 == "True")
            {
                return Ok("Sent");
            }
            else
            {
                return BadRequest("Not sent");
            }
        }
        [HttpPost("Weatherany")]
        public string Weatherany([FromBody] Users_Task users_)
        {
            List<Users_Task> u = usersservvice.getallUsers();

            //Assign API KEY which received from OPENWEATHERMAP.ORG  
            string appId = "0352fcbf8abd66539e9ab0be12f3cebb";
                
                    //API path with CITY parameter and other parameters.
                    string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", users_.Address, appId);

                    using (WebClient client = new WebClient())
                    {
                        string json = client.DownloadString(url);

                        //********************//  
                        //     JSON RECIVED   
                        //********************//  
                        //{"coord":{ "lon":72.85,"lat":19.01},  
                        //"weather":[{"id":711,"main":"Smoke","description":"smoke","icon":"50d"}],  
                        //"base":"stations",  
                        //"main":{"temp":31.75,"feels_like":31.51,"temp_min":31,"temp_max":32.22,"pressure":1014,"humidity":43},  
                        //"visibility":2500,  
                        //"wind":{"speed":4.1,"deg":140},  
                        //"clouds":{"all":0},  
                        //"dt":1578730750,  
                        //"sys":{"type":1,"id":9052,"country":"IN","sunrise":1578707041,"sunset":1578746875},  
                        //"timezone":19800,  
                        //"id":1275339,  
                        //"name":"Mumbai",  
                        //"cod":200}  

                        //Converting to OBJECT from JSON string.  
                        var weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherS.RootObject>(json);

                        //Special VIEWMODEL design to send only required fields not all fields which received from   
                        //www.openweathermap.org api  
                        WeatherS.ResultViewModel rslt = new WeatherS.ResultViewModel();

                        rslt.City = weatherInfo.name;
                        rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                        rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);

                        //Converting OBJECT to JSON String   
                        var jsonstring = new JavaScriptSerializer().Serialize(rslt);


                        //Return JSON string.  
                        return jsonstring;
                    }
        }
        [HttpPost("Weather")]
        public string Weatherbyname([FromBody] Users_Task users_)
        {
            List<Users_Task> u = usersservvice.getallUsers();

            //Assign API KEY which received from OPENWEATHERMAP.ORG  
            string appId = "0352fcbf8abd66539e9ab0be12f3cebb";
            for (int k = 0; k < u.Count; k++)
            {
                if (u[k].fullname == users_.fullname)
                {
                    //API path with CITY parameter and other parameters.
                    string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", u[k].Address, appId);

                    using (WebClient client = new WebClient())
                    {
                        string json = client.DownloadString(url);

                        //********************//  
                        //     JSON RECIVED   
                        //********************//  
                        //{"coord":{ "lon":72.85,"lat":19.01},  
                        //"weather":[{"id":711,"main":"Smoke","description":"smoke","icon":"50d"}],  
                        //"base":"stations",  
                        //"main":{"temp":31.75,"feels_like":31.51,"temp_min":31,"temp_max":32.22,"pressure":1014,"humidity":43},  
                        //"visibility":2500,  
                        //"wind":{"speed":4.1,"deg":140},  
                        //"clouds":{"all":0},  
                        //"dt":1578730750,  
                        //"sys":{"type":1,"id":9052,"country":"IN","sunrise":1578707041,"sunset":1578746875},  
                        //"timezone":19800,  
                        //"id":1275339,  
                        //"name":"Mumbai",  
                        //"cod":200}  

                        //Converting to OBJECT from JSON string.  
                        var weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherS.RootObject>(json);

                        //Special VIEWMODEL design to send only required fields not all fields which received from   
                        //www.openweathermap.org api  
                        WeatherS.ResultViewModel rslt = new WeatherS.ResultViewModel();

                        rslt.City = weatherInfo.name;
                        rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                        rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);

                        //Converting OBJECT to JSON String   
                        var jsonstring = new JavaScriptSerializer().Serialize(rslt);

                        //Return JSON string.  
                        return jsonstring;
                    }

                }

            }
            return "Not acces";
        }
    }
}
