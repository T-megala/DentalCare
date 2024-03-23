using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DentalCare
{
    public partial class appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_appointment_Click(object sender, EventArgs e)
        {
           

            string projectConnection = ConfigurationManager.ConnectionStrings["MegalaConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(projectConnection);
            con.Open();

            using (SqlCommand cmd = new SqlCommand("sp_appointments", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@service", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = ddlDoctors.Text;

                SqlParameter param2 = new SqlParameter("@doctor", SqlDbType.VarChar);
                cmd.Parameters.Add(param2).Value = txt_email.Text;

                SqlParameter param3 = new SqlParameter("@uname", SqlDbType.VarChar);
                cmd.Parameters.Add(param3).Value = txt_uname.Text;

                SqlParameter param4 = new SqlParameter("@email", SqlDbType.VarChar);
                cmd.Parameters.Add(param4).Value = txt_email.Text;

                SqlParameter param5 = new SqlParameter("@appointment_date", SqlDbType.VarChar);
                cmd.Parameters.Add(param5).Value = txt_date.Text;

                SqlParameter param6 = new SqlParameter("@appointment_time", SqlDbType.VarChar);
                cmd.Parameters.Add(param6).Value = ddlTime.Text;

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    Response.Redirect("Login.aspx");


            }
        }

      

        protected void datepicker_TextChanged(object sender, EventArgs e)
        {



        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}