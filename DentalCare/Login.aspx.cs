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
    public partial class Login : System.Web.UI.Page
    {
        private object cmd;

        public object MessageBox { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click1(object sender, EventArgs e)
        {
            string projectConnection = ConfigurationManager.ConnectionStrings["MegalaConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(projectConnection);

            con.Open();

            SqlCommand cmd = new SqlCommand("sp_loginuser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@uname", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = txt_UserName.Text;
            SqlParameter param2 = new SqlParameter("@pwd", SqlDbType.VarChar);
            cmd.Parameters.Add(param2).Value = txt_pwd.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            try
            {
                string a = ds.Tables[0].Rows[0][0].ToString();
                Session["loggedinUser"] = a;
                if (a != "")
                {
                    Response.Redirect("FetchhData.aspx");
                }
            }
            catch(Exception ex) 
            {
                Response.Write("InValid User");
            }
            con.Close();

        }
    }
}