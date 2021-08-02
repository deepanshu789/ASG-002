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
    public class SalesStaffsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select staff_id, first_name,last_name,phone,email,active,store_id,manager_id from sales.staffs";
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

        public string Post(SalesStaffs sale)
        {
            try
            {
                string query = @"insert into sales.staffs values(
                                '" + sale.first_name + @"',
                                '" + sale.last_name + @"',
                                '" + sale.phone + @"',
                                '" + sale.email + @"',
                                '" + sale.active + @"',
                                '" + sale.store_id + @"'  ,
                                '" + sale.manager_id + @"'  
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

        public string Put(SalesStaffs sale)
        {
            try
            {
                string query = @"
                update sales.staffs set             
                first_name='" + sale.first_name + @"',
                last_name='" + sale.last_name + @"',
                phone='" + sale.phone + @"',
                email='" + sale.email + @"',
                active='" + sale.active + @"',
                store_id='" + sale.store_id + @"',
                manager_id='" + sale.manager_id + @"'
                where staff_id = " + sale.staff_id + @"";
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
                string query = @"delete from sales.staffs where staff_id=" + id + @"";
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
