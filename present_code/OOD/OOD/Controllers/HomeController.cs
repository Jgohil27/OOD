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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}