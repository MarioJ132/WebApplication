using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Connect to the DB
            //string connStr = "Server=;Database=BuildingAccess;Integrated Security = True;";
            SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Database=BuildingAccess;Integrated Security = True;");
            
            conn.Open();

            //Create a command
            SqlCommand cmd = new SqlCommand("SELECT [IdentificationCardID],[Name],[OrgStructure],"+
                "[PhoneNumber],[EmailAddress],[HireDate],[CardExpireDate],[TerminationDate]," +
                "[WorkerTypeID],[Company],[CourtAccessRequired],[IDCardNumber],[DepatAbrev]," +
                "[Department]" +
                "FROM[dbo].[IdentificationCards]");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            string temp = "";
            //Read from DB
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                temp += reader["IdentificationCardID"].ToString();
                temp += reader["name"].ToString();
                temp += reader["PhoneNumber"].ToString();
                temp += reader["EmailAddress"].ToString();
                temp += reader["CardExpireDate"].ToString();
                temp += "<br/>";
            }

            conn.Close();

            lbl_test.Text = temp;
        }
    }
}