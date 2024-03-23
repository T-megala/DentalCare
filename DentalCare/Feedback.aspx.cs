using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalCare
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string projectConnection = ConfigurationManager.ConnectionStrings["MegalaConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();

            using (SqlCommand cmd = new SqlCommand("sp_feedback", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@name", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = Txt_name.Text;

                SqlParameter param2 = new SqlParameter("@feedback", SqlDbType.VarChar);
                cmd.Parameters.Add(param2).Value = Txt_feedback.Text;

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    FeedbackMessage.Text = "Thank you for your feedback!";

            }
        }
    }
}