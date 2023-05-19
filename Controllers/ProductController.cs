using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication11.Controllers;
using WebApplication11.Models;
namespace WebApplication11.Controllers
{
    public class ProductController : Controller
    {
        string connectString = @"Data Source=NOZIPHO_SITHEBE\SQLEXPRESS;Initial Catalog=farmcentralSchema;Integrated Security=True";
        [HttpGet]
        // GET: ProductController
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sql = new SqlConnection(connectString))
            {
                sql.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select * from Product", sql);
                sd.Fill(dt);
            }

            return View(dt);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            using (SqlConnection sql = new SqlConnection(connectString))
            {
                sql.Open();
                string query = "INSERT INTO Product VALUES(@ProductName,@IncomingorOutgoing,@Type,@Dateacquired)";
                SqlCommand sqlCmd = new SqlCommand(query, sql);
                sqlCmd.Parameters.AddWithValue("@ProductName", product.productName);
                sqlCmd.Parameters.AddWithValue("@IncomingorOutgoing", product.incomingout);
                sqlCmd.Parameters.AddWithValue("@Type", product.type);
                sqlCmd.Parameters.AddWithValue("@Dateacquired", product.dateAcquired);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product pM = new Product();
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Product Where ProductCode = @ProductCode";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ProductCode", id);
                sqlDa.Fill(dtblProduct);
            }
            if (dtblProduct.Rows.Count == 1)
            {
                pM.productCode = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
                pM.productName = dtblProduct.Rows[0][1].ToString();
                pM.incomingout = dtblProduct.Rows[0][2].ToString();
                pM.type = dtblProduct.Rows[0][3].ToString();
                pM.dateAcquired = dtblProduct.Rows[0][4].ToString();
                return View(pM);
            }
            else
                return RedirectToAction("Index");
        }


        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product productModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectString))
            {
                sqlCon.Open();
                string query = "UPDATE Product SET ProductName = @ProductName , IncomingorOutgoing=@IncomingorOutgoing , Type = @Type , DateAcquired=@dateAcquired WHere ProductCode = @ProductCode";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProductCode", productModel.productCode);
                sqlCmd.Parameters.AddWithValue("@ProductName", productModel.productName);
                sqlCmd.Parameters.AddWithValue("@IncomingorOutgoing", productModel.incomingout);
                sqlCmd.Parameters.AddWithValue("@Type", productModel.type);
                sqlCmd.Parameters.AddWithValue("@Dateacquired", productModel.dateAcquired);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Product WHere ProductID = @ProductID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProductID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index"); ;

        }
    }
}


