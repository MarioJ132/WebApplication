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
            //var command
            //SqlCommand
            /**SqlCommand cmd = new SqlCommand("SELECT [IdentificationCardID],[Name],[OrgStructure]," +
                "[PhoneNumber],[EmailAddress],[HireDate],[CardExpireDate],[TerminationDate]," +
                "[WorkerTypeID],[Company],[CourtAccessRequired],[IDCardNumber],[DepatAbrev]," +
                "[Department]" +
                "FROM[dbo].[IdentificationCards]" +
                "Where [IDCardNumber] = 99994");**/
           
            /**SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[AccessLogs]" +
                "(AccessLocationID), (StationID), (AccessDate), (OperatorLogin)" +
                "Values [WorkerTypeID], [Department], [HireDate], [PhoneNumber]" +
                "FROM [dbo].[IdentificationCards]" +
                "Where [IdentificationCardID] = 1");**/
            SqlCommand cmd = new SqlCommand("INSERT INTO [AccessLogs]" + "([AccessLocationID],[StationID],[AccessDate],[IDCardNumber],[DeclineReason],[OperatorLogin])" +
                             "Select [WorkerTypeID], [Department], [CardExpireDate], [IDCardNumber], [Name], [OrgStructure]" +
                             "FROM [IdentificationCards]" +
                             "Where [IdentificationCardID] = 1");
    
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
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
            //conn.Open();
            //SqlCommand cmd2 = new SqlCommand ("INSERT INTO )
            //SqlCommand cmd2 = new SqlCommand("INSERT INTO [dbo].[AccessLogs]([AccessLogID])" +
            //    "Values('ID')");
            //cmd2.CommandType = System.Data.CommandType.Text;
            //cmd2.Connection = conn;
            //cmd2.ExecuteNonQuery();

            //conn.Close();
            
        }

    }
}