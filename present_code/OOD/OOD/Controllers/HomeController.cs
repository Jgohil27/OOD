using Microsoft.AspNetCore.Mvc;
using OOD.Models;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace OOD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string DBConnection = "Server=KALYAN\\sqlexpress;Database=CovidDB;Trusted_Connection=True;MultipleActiveResultSets=true";
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

        public IActionResult Dashboard()
        {
            return View();
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
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
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

        public IActionResult Profile()
        {
            return View();
        }

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