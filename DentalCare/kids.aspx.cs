using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalCare
{
    public partial class kids : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      
        }


        protected void btn_appointment_Click(object sender, EventArgs e)
        {
            // Get the ID of the clicked button
            string buttonID = ((Button)sender).ID;

            // Extract the last character of the button ID to determine the card index
            int cardIndex;
            if (int.TryParse(buttonID.Substring(buttonID.Length - 1), out cardIndex))
            {
                // Find the corresponding label control
                Label label = FindControl("Label" + cardIndex) as Label;

                // Check if the label control is found
                if (label != null)
                {
                    // Get the text of the label
                    string labelText = label.Text;

                    // Define the SQL query to fetch product details based on the label text
                    string query = "SELECT * FROM tbl_product WHERE Name = @Name";

                    // Establish connection to the database
                    string projectConnection = ConfigurationManager.ConnectionStrings["MegalaConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(projectConnection))
                    {
                        // Open the database connection
                        con.Open();

                        // Execute the SQL query
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Name", labelText);
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Check if there are any rows returned from the query
                        if (reader.HasRows)
                        {
                            // Read the first row (assuming only one row is returned)
                            reader.Read();

                            // Retrieve product details from the database
                            string name = reader["Name"].ToString();
                            string details = reader["Details"].ToString();
                            string imagePath = reader["ImagePath"].ToString();
                            int price = Convert.ToInt32(reader["Price"]); // Retrieve price from the database

                            // Close the data reader
                            reader.Close();

                            // Insert the fetched product details into tbl_cart
                            string insertQuery = "INSERT INTO tbl_cart (Name, Details, ImagePath, Price) VALUES (@Name, @Details, @ImagePath, @Price)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                            insertCmd.Parameters.AddWithValue("@Name", name);
                            insertCmd.Parameters.AddWithValue("@Details", details);
                            insertCmd.Parameters.AddWithValue("@ImagePath", imagePath);
                            insertCmd.Parameters.AddWithValue("@Price", price); // Add price parameter
                            insertCmd.ExecuteNonQuery();

                            Response.Redirect("cart.aspx");
                        }
                        else
                        {
                            // If no matching product found, display a message
                            Response.Write("No product found with the given name.");
                        }
                    }
                }
                else
                {
                    // If the label control is not found, display an error message
                    Response.Write("Label control not found.");
                }
            }
        }




    }
}

      

