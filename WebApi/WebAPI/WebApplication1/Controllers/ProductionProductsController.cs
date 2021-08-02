using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductionProductsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select product_id, product_name,brand_id,category_id,model_year,list_price from production.products";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikeDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(ProductionProducts sale)
        {
            try
            {
                string query = @"insert into production.products values(
                                '" + sale.product_name + @"',
                                '" + sale.brand_id + @"',
                                '" + sale.category_id + @"',
                                '" + sale.model_year + @"',
                                '" + sale.list_price + @"'                                
                                )";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikeDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Failed to add";
            }
        }

        public string Put(ProductionProducts sale)
        {
            try
            {
                string query = @"
                update production.products set             
                product_name='" + sale.product_name + @"',
                brand_id='" + sale.brand_id + @"',
                category_id='" + sale.category_id + @"',
                model_year='" + sale.model_year + @"',
                list_price='" + sale.list_price + @"'
                where product_id = " + sale.product_id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikeDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Failed to update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from production.products where product_id=" + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikeDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully";

            }
            catch (Exception e)
            {
                return "Failed to delete";
            }
        }
    }
}
