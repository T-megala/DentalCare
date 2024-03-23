using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace YourNamespace
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartItems();
            }
        }

        private void BindCartItems()
        {
            // Define the SQL query to fetch items from tbl_cart
            string query = "SELECT * FROM tbl_cart";

            // Establish connection to the database
            string projectConnection = ConfigurationManager.ConnectionStrings["MegalaConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(projectConnection))
            {
                // Open the database connection
                con.Open();

                // Execute the SQL query
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind the fetched data to the repeater control
                CartRepeater.DataSource = dt;
                CartRepeater.DataBind();
            }
        }
    }
}
