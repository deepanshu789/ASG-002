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
    public class SalesOrdersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select order_id, customer_id,order_status,order_date,required_date,shipped_date,store_id,staff_id from sales.orders";
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

        public string Post(SalesOrders sale)
        {
            try
            {
                string query = @"insert into sales.orders values(
                                '" + sale.customer_id + @"',
                                '" + sale.order_status + @"',
                                '" + sale.order_date + @"',
                                '" + sale.required_date + @"',
                                '" + sale.shipped_date + @"',
                                '" + sale.store_id + @"'  ,
                                '" + sale.staff_id + @"'  
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

        public string Put(SalesOrders sale)
        {
            try
            {
                string query = @"
                update sales.orders set             
                customer_id='" + sale.customer_id + @"',
                order_status='" + sale.order_status + @"',
                order_date='" + sale.order_date + @"',
                required_date='" + sale.required_date + @"',
                shipped_date='" + sale.shipped_date + @"',
                store_id='" + sale.store_id + @"',
                staff_id='" + sale.staff_id + @"'
                where order_id = " + sale.order_id + @"";
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
                string query = @"delete from sales.orders where order_id=" + id + @"";
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
