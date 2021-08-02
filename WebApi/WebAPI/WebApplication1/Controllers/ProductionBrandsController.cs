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
    public class ProductionBrandsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select brand_id, brand_name from production.brands";
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

        public string Post(ProductionBrands pro)
        {
            try
            {
                string query = @"insert into production.brands values('" + pro.brand_name + @"')";
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
                return "Failed to add";
            }
        }

        public string Put(ProductionBrands pro)
        {
            try
            {
                string query = @"update production.brands set brand_name='" + pro.brand_name + @"'where brand_id = " + pro.brand_id + @"";
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
                return "Failed to update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from production.brands where brand_id=" + id + @"";
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
