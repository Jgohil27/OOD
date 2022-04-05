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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //private SqlConnection con;

        //private void connection()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
        //    con = new SqlConnection(constr);

        //}

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

                    //if (AddContactUs(CS))
                    //{
                    //    ViewBag.Message = "Employee details added successfully";
                    //}
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

    //    public bool AddContactUs(ContactUs CS)
    //    {

    //        connection();
    //        SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
    //        com.CommandType = CommandType.StoredProcedure;
    //        com.Parameters.AddWithValue("@FirstName", obj.FirstName);
    //        com.Parameters.AddWithValue("@LastName", obj.LastName);
    //        com.Parameters.AddWithValue("@EmailAddress", obj.EmailAddress);
    //        com.Parameters.AddWithValue("@Message", obj.Message);
    //        com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
    //        con.Open();
    //        int i = com.ExecuteNonQuery();
    //        con.Close();
    //        if (i >= 1)
    //        {

    //            return true;

    //        }
    //        else
    //        {

    //            return false;
    //        }
    //}
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