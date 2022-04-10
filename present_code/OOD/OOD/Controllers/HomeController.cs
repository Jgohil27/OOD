using Microsoft.AspNetCore.Mvc;
using OOD.Models;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using OOD.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using OOD.Areas.Identity.Pages.Account;

namespace OOD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string DBConnection = "Server=KALYAN\\sqlexpress;Database=CovidDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        string? LastName, FirstName, EmailId;
        int? PhoneNumber ; 
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private SqlConnection con;

        private void Connection()
        {
            string Connection = "Server=KALYAN\\sqlexpress;Database=CovidDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            //string test = System.Configuration.ConfigurationManager.ConnectionStrings["Test2"].ToString();
            //string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CovidConnection"].ConnectionString;
            con = new SqlConnection(Connection);
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Dashboard(ProfileViewModel CS)
        {
            if (ModelState.IsValid)
            {
                if (FetchProfile(CS))
                {
                    ViewBag.Message = "Profile loaded successfully";
                }
            }
            ViewBag.FirstName = CS.FirstName;
            ViewBag.LastName = CS.LastName;
            ViewBag.PhoneNumber = CS.PhoneNumber;
            ViewBag.EmailAddress = CS.EmailAddress;
            // ViewBag.DOB = "08/"
            ViewBag.State = "Virgina";
            return View(CS);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUs CS)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (AddContactUs(CS))
                    {
                        ViewBag.Message = "Contact details added successfully";
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public bool AddContactUs(ContactUs CS)
        {

            Connection();
            SqlCommand com = new SqlCommand("AddContactUsDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@FirstName", CS.FirstName);
            com.Parameters.AddWithValue("@LastName", CS.LastName);
            com.Parameters.AddWithValue("@EmailAddress", CS.EmailAddress);
            com.Parameters.AddWithValue("@Message", CS.Message);
            com.Parameters.AddWithValue("@PhoneNumber", CS.PhoneNumber);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CovidHighRisk()
        {
            return View();
        }

        public IActionResult CovidMediumRisk()
        {
            return View();
        }

        public IActionResult CovidLowRisk()
        {
            return View();
        }

        [Authorize]
        //[HttpGet]
        public IActionResult Profile(ProfileViewModel CS)
        {
            if(ModelState.IsValid)
            {
                if (FetchProfile(CS))
                {
                    LastName = CS.LastName;
                    FirstName = CS.FirstName;
                    EmailId = CS.EmailAddress;
                    PhoneNumber = CS.PhoneNumber;
                    ViewBag.Message = "Profile loaded successfully";
                }
            }
            return View(CS);
        }

        [HttpPost]
        [ActionName("Profile")]
        public IActionResult UpdateProfile(ProfileViewModel CS)
        {
            //CS.LastName = LastName;
            //CS.FirstName = FirstName ;
            //CS.EmailAddress = EmailId ;
            //CS.PhoneNumber = PhoneNumber;
            if (ModelState.IsValid)
            {
                if (AddUpdatedProfile(CS))
                {
                    ViewBag.Message = "Profile Updated successfully";
                }
            }
            return RedirectToAction("Dashboard", "Home");
        }

        public bool AddUpdatedProfile(ProfileViewModel CS)
        {
            Connection();
            SqlCommand com = new SqlCommand("AddUpdatedProfile", con)
            {
                CommandType = CommandType.StoredProcedure
            };            
            com.Parameters.AddWithValue("@EmailId", CS.EmailAddress);
            com.Parameters.AddWithValue("@FirstName", CS.FirstName);
            com.Parameters.AddWithValue("@LastName", CS.LastName);            
            com.Parameters.AddWithValue("@PhoneNumber", CS.PhoneNumber);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        public bool FetchProfile(ProfileViewModel CS)
        {
            Connection();
            SqlCommand com = new SqlCommand("FetchProfile", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@EmailId", "kalyanking12@gmail.com");
            //com.Parameters.AddWithValue("@EmailId", ApplicationUser.);
            com.Parameters.Add("@FirstName",SqlDbType.VarChar, 50);
            com.Parameters.Add("@LastName", SqlDbType.VarChar, 50);
            com.Parameters.Add("@Email", SqlDbType.VarChar, 50);
            com.Parameters.Add("@PhoneNumber", SqlDbType.Int);
            com.Parameters["@FirstName"].Direction = ParameterDirection.Output;
            com.Parameters["@LastName"].Direction = ParameterDirection.Output;
            com.Parameters["@Email"].Direction = ParameterDirection.Output;
            com.Parameters["@PhoneNumber"].Direction = ParameterDirection.Output;
            con.Open();         
            int i = com.ExecuteNonQuery();
            CS.FirstName = com.Parameters["@FirstName"].Value.ToString();
            CS.LastName = com.Parameters["@LastName"].Value.ToString();
            CS.EmailAddress = com.Parameters["@Email"].Value.ToString();
            CS.PhoneNumber = Convert.IsDBNull(com.Parameters["@PhoneNumber"].Value)? null:(int ?)com.Parameters["@PhoneNumber"].Value;
          //  Convert.IsDBNull(reader["AcceptanceActID"]) ? null : (int?)reader["AcceptanceActID"],
            ViewBag.FirstName = CS.FirstName;
            // var o = com.();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
           

        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Authorize]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(FormViewModel CS)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CS.RiskScore = CS.HaveMedicalSymptoms ? CS.RiskScore + 30 : CS.RiskScore;
                    CS.RiskScore = CS.Temperature > 100 ? CS.RiskScore + 10 : CS.RiskScore;
                    CS.RiskScore = CS.DoctorVisit ? CS.RiskScore + 5 : CS.RiskScore;
                    CS.RiskScore = CS.HadInteraction ? CS.RiskScore + 5 : CS.RiskScore;
                    CS.RiskScore = CS.HadInteractioCS ? CS.RiskScore + 10 : CS.RiskScore;
                    CS.RiskScore = CS.isIPersonPostive ? CS.RiskScore + 30 : CS.RiskScore;
                    CS.RiskScore = CS.HadOutings ? CS.RiskScore + 5 : CS.RiskScore;
                    CS.RiskScore = CS.Outforfood ? CS.RiskScore + 5 : CS.RiskScore;

                    CS.RiskResult = CS.RiskScore <= 20 ? "Low" : CS.RiskScore >= 50 ? "High" : "Medium";

                    if (AddSymptoms(CS))
                    {
                        ViewBag.Message = "Symptoms details added successfully";
                    }
                }

                if(CS.RiskScore <= 20)
                {
                    return RedirectToAction("CovidLowRisk", "Home");
                }
                else if (CS.RiskScore >= 50)
                {
                    return RedirectToAction("CovidHighRisk", "Home");
                }
                else if (CS.RiskScore >=21 && CS.RiskScore <= 49)
                {
                    return RedirectToAction("CovidMediumRisk", "Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public bool AddSymptoms(FormViewModel CS)
        {

            Connection();
            SqlCommand com = new SqlCommand("AddFormSymptoms", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            if(CS.DateNoted == DateTime.MinValue || CS.DateNoted == null)
            {
                CS.DateNoted = DateTime.Now;
            }
            if (CS.CovidDatetime == DateTime.MinValue || CS.CovidDatetime == null)
            {
                CS.CovidDatetime = DateTime.Now;
            }

            com.Parameters.AddWithValue("@HaveMedicalSymptoms", CS.HaveMedicalSymptoms);
            com.Parameters.AddWithValue("@MedicalCovidSymptoms", CS.MedicalCovidSymptoms == null ? "-" : CS.MedicalCovidSymptoms);
            com.Parameters.AddWithValue("@DateNoted",CS.DateNoted);
            com.Parameters.AddWithValue("@Temperature", CS.Temperature);
            com.Parameters.AddWithValue("@TakeAnyMedicine", CS.TakeAnyMedicine);
            com.Parameters.AddWithValue("@MedicineName", CS.MedicineName == null ? "-" : CS.MedicineName);
            com.Parameters.AddWithValue("@DoctorVisit", CS.DoctorVisit);
            com.Parameters.AddWithValue("@DoctorProfession", CS.DoctorProfession == null ? "-" : CS.DoctorProfession);
            com.Parameters.AddWithValue("@HadInteraction", CS.HadInteraction);
            com.Parameters.AddWithValue("@HadInteractioCS", CS.HadInteractioCS);
            com.Parameters.AddWithValue("@InteractionCS", CS.InteractionCS == null ? "-" : CS.InteractionCS);
            com.Parameters.AddWithValue("@isIPersonPostive", CS.isIPersonPostive);
            com.Parameters.AddWithValue("@CovidDatetime", CS.CovidDatetime);
            com.Parameters.AddWithValue("@HadOutings", CS.HadOutings);
            com.Parameters.AddWithValue("@OutingCS", CS.OutingCS == null ? "-" : CS.OutingCS);
            com.Parameters.AddWithValue("@Outforfood", CS.Outforfood);
            com.Parameters.AddWithValue("@RiskResult", CS.RiskResult);
            com.Parameters.AddWithValue("@RiskScore", CS.RiskScore);
            com.Parameters.AddWithValue("@RiskCalculatedDate", DateTime.Now);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}