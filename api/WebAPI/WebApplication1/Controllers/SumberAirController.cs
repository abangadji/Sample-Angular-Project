using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace WebApplication1.Controllers
{
    public class SumberAirController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query =@"select id, nama, created_by, created_date, deleted_date from dbo.ms_sumber_air";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["RenlingApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post (SumberAir sung)
        {
            try
            {
                string query = @"
                    insert into dbo.Employee values
                    (
                    '" + sung.nama + @"'
                    ,'" + sung.created_by + @"'
                    ,'" + sung.created_date + @"'
                    ,'" + sung.deleted_date + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["RenlingApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }

        public string Put(SumberAir sung)
        {
            try
            {
                string query = @"
                    update dbo.ms_sumber_air set 
                    nama='" + sung.nama + @"'
                    ,created_by='" + sung.created_by + @"'
                    ,created_date='" + sung.created_date + @"'
                    ,deleted_date='" + sung.deleted_date + @"'
                    where id=" + sung.id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["RenlingApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.ms_sumber_air 
                    where id=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["RenlingApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }




    }
}