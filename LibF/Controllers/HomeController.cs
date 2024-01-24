using LibF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace LibF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

   
      public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)

        {

            Configuration = configuration;

        }

        [HttpGet]

        public IActionResult Index()

        {

            return View();

        }

        [HttpPost]

        public IActionResult Index(login_details inventory)

        {


            string connectionString = Configuration["ConnectionStrings:Conn"];

            using (var con = new SqlConnection(connectionString))

            {


                using (var cmd = new SqlCommand("select dbo.userlogincheck(@username,@pwd)", con))

                {

                    cmd.Parameters.AddWithValue("@username", inventory.username);

                    cmd.Parameters.AddWithValue("@pwd", inventory.pwd);


                    con.Open();

                    int c = Convert.ToInt32(cmd.ExecuteScalar());

                    if (c == 1)

                    {

                        Console.WriteLine("welcome User");

                        con.Close();

                        string id = inventory.username;

                        return RedirectToAction("Index", "BookDetails");

                    }

                    else

                    {


                        Console.WriteLine("Account No or Password is wrong!!!");

                        return RedirectToAction("Index","Home");
                    }

                }

            }

        }


        public IActionResult Privacy()
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