using LibF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace LibF.Controllers
{
    public class BookDetailsController : Controller
    {
        public IConfiguration Configuration { get; }

        public BookDetailsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public ActionResult Index()

        {
            List<BookDetail> BookList = new List<BookDetail>();
            string connectionString = Configuration["ConnectionStrings:Conn"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select * from BookDetails";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        string format = "yyyy-MM-dd";
                       BookDetail details = new BookDetail();
                        details.BookID = Convert.ToInt32(sdr["BookID"]);
                        details.Title = Convert.ToString(sdr["Title"]);
                        details.Author = Convert.ToString(sdr["Author"]);
                        details.BookType = Convert.ToString(sdr["BookType"]);
                        details.Publisheddate = Convert.ToDateTime(sdr["Publisheddate"]);
                        details.Price = Convert.ToInt32(sdr["Price"]);
                        BookList.Add(details);
                    }
                    connection.Close();
                }

            }
            return View(BookList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    
        public ActionResult Create(BookDetail detail)
        {
            try
            {
                string connectionString = Configuration["ConnectionStrings:Conn"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string format = "yyyy-MM-dd";
                    string sql = $"Insert Into BookDetails (BookID,Title,Author,BookType,Publisheddate,Price)" +
                        $" Values ('{detail.BookID}', '{detail.Title}','{detail.Author}','{detail.BookType}','{detail.Publisheddate}'" +
                        $",'{detail.Price}')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                ViewBag.Result = "Success";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

        [HttpGet("Read/{id}")]
        public IActionResult ReadbyId(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReadById(int id)
        {
            BookDetail details = new BookDetail();
            string connectionString = Configuration["ConnectionStrings:Conn"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from BookDetails where BookID='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        details.BookID = Convert.ToInt32(sdr["BookID"]);
                        details.Title = Convert.ToString(sdr["Title"]);
                        details.Author = Convert.ToString(sdr["Author"]);
                        details.BookType = Convert.ToString(sdr["BookType"]);
                        details.Publisheddate = Convert.ToDateTime(sdr["Publisheddate"]);
                        details.Price = Convert.ToInt32(sdr["Price"]);
                        

                    }
                    connection.Close();
                }

            }
            return View(details);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            BookDetail details = new BookDetail();
            string connectionString = Configuration["ConnectionStrings:Conn"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from BookDetails where BookID='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        details.BookID = Convert.ToInt32(sdr["BookID"]);
                        details.Title = Convert.ToString(sdr["Title"]);
                        details.Author = Convert.ToString(sdr["Author"]);
                        details.BookType = Convert.ToString(sdr["BookType"]);
                        details.Publisheddate = Convert.ToDateTime(sdr["Publisheddate"]);
                        details.Price = Convert.ToInt32(sdr["Price"]);


                    }
                    connection.Close();
                }

            }
            return View(details);
        }

        [HttpPost]
        public IActionResult Update(BookDetail details, int id)
        {
            string connectionString = Configuration["ConnectionStrings:Conn"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update BookDetails SET Title='{details.Title}',Author='{details.Author}',BookType='{details.BookType}',Publisheddate='{details.Publisheddate}',Price='{details.Price}' where BookID='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            BookDetail details = new BookDetail();
            string connectionString = Configuration["ConnectionStrings:Conn"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from BookDetails where BookID='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        details.BookID = Convert.ToInt32(sdr["BookID"]);
                        details.Title = Convert.ToString(sdr["Title"]);
                        details.Author = Convert.ToString(sdr["Author"]);
                        details.BookType = Convert.ToString(sdr["BookType"]);
                        details.Publisheddate = Convert.ToDateTime(sdr["Publisheddate"]);
                        details.Price = Convert.ToInt32(sdr["Price"]);


                    }
                    connection.Close();
                }

            }
            return View(details);
        }

        [HttpPost]
        public IActionResult Delete(BookDetail book, int id)
        {
            string connectionString = Configuration["ConnectionStrings:Conn"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete from BookDetails where BookID='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            BookDetail details = new BookDetail();
            string connectionString = Configuration["ConnectionStrings:Conn"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from BookDetails where BookID='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        details.BookID = Convert.ToInt32(sdr["BookID"]);
                        details.Title = Convert.ToString(sdr["Title"]);
                        details.Author = Convert.ToString(sdr["Author"]);
                        details.BookType = Convert.ToString(sdr["BookType"]);
                        details.Publisheddate = Convert.ToDateTime(sdr["Publisheddate"]);
                        details.Price = Convert.ToInt32(sdr["Price"]);


                    }
                    connection.Close();
                }

            }
            return View(details);
        }
    }
}

