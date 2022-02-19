using ProductsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsWebApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DotNetWebApp; Integrated Security = True";
            conn.Open();

            SqlCommand dtentry = new SqlCommand();
            dtentry.Connection = conn;
            dtentry.CommandType = System.Data.CommandType.Text;
            dtentry.CommandText = "select * from Products";
            List<Products> ListPd = new List<Products>();
            try
            {
                SqlDataReader sqdrd = dtentry.ExecuteReader();
                while(sqdrd.Read())
                {
                    ListPd.Add(new Products { ProductId = (int)sqdrd["ProductId"], ProductName = sqdrd["ProductName"].ToString(), Rate = (decimal)sqdrd["Rate"], Description = sqdrd["Description"].ToString(), CategoryName = sqdrd["CategoryName"].ToString() });

                }
                sqdrd.Close();
            }
            catch(Exception excp)
            {
                ViewBag.Error = (excp.Message);
            }
            conn.Close();
 
            return View(ListPd);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Products prd = null;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DotNetWebApp; Integrated Security = True";
            conn.Open();

            SqlCommand dtentry = new SqlCommand();
            dtentry.Connection = conn;
            dtentry.CommandType = System.Data.CommandType.Text;
            dtentry.CommandText = "select * from Products where ProductId=@ProductId";

            dtentry.Parameters.AddWithValue("@ProductId", id);
            SqlDataReader sqdrd = dtentry.ExecuteReader();
            if(sqdrd.Read())
            {
               prd = new Products { ProductId = (int)sqdrd["ProductId"], ProductName = sqdrd["ProductName"].ToString(), Rate = (decimal)sqdrd["Rate"], Description = sqdrd["Description"].ToString(), CategoryName = sqdrd["CategoryName"].ToString() };

            }
            else
            {
                ViewBag.ErrorMessage = "No Data Found";
            }
            sqdrd.Close();
            conn.Close();

            return View(prd);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products obj)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DotNetWebApp; Integrated Security = True";
            conn.Open();

            SqlCommand dtentry = new SqlCommand();
            dtentry.Connection = conn;
            dtentry.CommandType = System.Data.CommandType.Text;
            dtentry.CommandText = "update Products set ProductName=@ProductName, Rate=@Rate, Description=@Description, CategoryName=@CategoryName where ProductId=@ProductId";

            dtentry.Parameters.AddWithValue("@ProductId", obj.ProductId);
            dtentry.Parameters.AddWithValue("@ProductName", obj.ProductName);
            dtentry.Parameters.AddWithValue("@Rate", obj.Rate);
            dtentry.Parameters.AddWithValue("@Description", obj.Description);
            dtentry.Parameters.AddWithValue("@CategoryName", obj.CategoryName);


            try
            {
                dtentry.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch(Exception excp)
            {
                ViewBag.Error = (excp.Message);
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PView()
        {
            return View();
        }
    }
}
