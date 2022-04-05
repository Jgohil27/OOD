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

                    if (AddSymptoms(CS))
                    {
                        ViewBag.Message = "Symptoms details added successfully";
                    }
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

            if(CS.DateNoted == DateTime.MinValue)
            {
                CS.DateNoted = DateTime.Now;
            }
            if (CS.CovidDatetime == DateTime.MinValue)
            {
                CS.CovidDatetime = DateTime.Now;
            }

            com.Parameters.AddWithValue("@HaveMedicalSymptoms", CS.HaveMedicalSymptoms);
            com.Parameters.AddWithValue("@MedicalCovidSymptoms", CS.MedicalCovidSymptoms);
            com.Parameters.AddWithValue("@DateNoted",CS.DateNoted);
            com.Parameters.AddWithValue("@Temperature", CS.Temperature);
            com.Parameters.AddWithValue("@TakeAnyMedicine", CS.TakeAnyMedicine);
            com.Parameters.AddWithValue("@MedicineName", CS.MedicineName);
            com.Parameters.AddWithValue("@DoctorVisit", CS.DoctorVisit);
            com.Parameters.AddWithValue("@DoctorProfession", CS.DoctorProfession);
            com.Parameters.AddWithValue("@HadInteraction", CS.HadInteraction);
            com.Parameters.AddWithValue("@HadInteractioCS", CS.HadInteractioCS);
            com.Parameters.AddWithValue("@InteractionCS", CS.InteractionCS);
            com.Parameters.AddWithValue("@isIPersonPostive", CS.isIPersonPostive);
            com.Parameters.AddWithValue("@CovidDatetime", CS.CovidDatetime);
            com.Parameters.AddWithValue("@HadOutings", CS.HadOutings);
            com.Parameters.AddWithValue("@OutingCS", CS.OutingCS);

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