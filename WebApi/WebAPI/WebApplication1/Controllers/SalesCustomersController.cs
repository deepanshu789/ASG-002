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
    public class SalesCustomersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select customer_id, first_name,last_name,phone,email,street,city,state,zip_code from sales.customers";
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

        public string Post(SalesCustomers sale)
        {
            try
            {
                string query = @"insert into sales.customers values(
                                '" + sale.first_name + @"',
                                '" + sale.last_name + @"',
                                '" + sale.phone + @"',
                                '" + sale.email + @"',
                                '" + sale.street + @"',
                                '" + sale.city + @"',
                                '" + sale.state + @"',
                                '" + sale.zip_code + @"'                                
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
                return "Failed to add";
            }
        }

        public string Put(SalesCustomers sale)
        {
            try
            {
                string query = @"
                update sales.customers set
                first_name='" + sale.first_name + @"',              
                last_name='" + sale.last_name + @"',
                phone='" + sale.phone + @"',
                email='" + sale.email + @"',
                street='" + sale.street + @"',
                city='" + sale.city + @"',
                state='" + sale.state + @"',
                zip_code='" + sale.zip_code + @"',
                where customer_id = " + sale.customer_id + @"";
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
                string query = @"delete from sales.customers where customer_id=" + id + @"";
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
