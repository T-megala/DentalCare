using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalCare
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void btn_login_Click1(object sender, EventArgs e)
        {
            Response.Write("Login Button clicked");


            if (string.IsNullOrEmpty(txt_Name.Text) || string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_UserName.Text) || string.IsNullOrEmpty(txt_pwd.Text))
            {
                Response.Write("Please fill in all the fields.");
            }
            else
            {
                string projectConnection = ConfigurationManager.ConnectionStrings["MegalaConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(projectConnection))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_adduserdata", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter param1 = new SqlParameter("@name", SqlDbType.VarChar);
                        cmd.Parameters.Add(param1).Value = txt_Name.Text;

                        SqlParameter param2 = new SqlParameter("@email", SqlDbType.VarChar);
                        cmd.Parameters.Add(param2).Value = txt_email.Text;

                        SqlParameter param3 = new SqlParameter("@uname", SqlDbType.VarChar);
                        cmd.Parameters.Add(param3).Value = txt_UserName.Text;

                        SqlParameter param4 = new SqlParameter("@pwd", SqlDbType.VarChar);
                        cmd.Parameters.Add(param4).Value = txt_pwd.Text;

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            Response.Redirect("index.aspx");
                    }
                }
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {

        }
    }
}