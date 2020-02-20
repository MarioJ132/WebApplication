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
            SqlConnection conn = new SqlConnection("Data Source=localhost;Database=BuildingAccess;Integrated Security = True;");

            conn.Open();
            int IDScanned = 99991;
            string PorF = PassOrFail(IDScanned);
            DateTime date = DateTime.Now;
            SqlCommand cmd = new SqlCommand("INSERT INTO [AccessLogs]" + "([AccessLocationID],[StationID],[AccessDate],[IDCardNumber],[DeclineReason],[OperatorLogin])" +
                            "Values ((Select [AccessLocationID] FROM [AccessLocations] Where [AccessLocationID] = 1)," +
                            "(Select [OrgStructure] FROM [IdentificationCards] Where [IdentificationCardID] = 1)," +
                            "(@date)," +
                            "(Select [IDCardNumber] FROM [IdentificationCards] Where [IdentificationCardID] = 1)," + 
                            "(@passorFail)," +
                            "(Select [firstName] From [OperatorLogin] Where [firstName] = 'Billy'))");
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@passorFail", PorF);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private string PassOrFail(int IDScanned)
        {
            if ()
            {
                return "Pass";
            }
            
        }

    }
}