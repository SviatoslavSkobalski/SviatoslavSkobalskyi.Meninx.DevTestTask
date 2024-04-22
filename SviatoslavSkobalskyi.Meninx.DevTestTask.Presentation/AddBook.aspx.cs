using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Presentation
{
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Apply_Click(object sender, EventArgs e)
        {
            AddBookFromTextBoxValues();
            Response.Redirect("Default.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private void AddBookFromTextBoxValues()
        {
            string constr = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("insert into Books (Title ,Author,ISBN,CategoryId, PublicationYear, Quantity) VALUES (@Title, @Author, @ISBN, @CategoryId, @PublicationYear, @Quantity)", con))
                {
                    cmd.Parameters.AddWithValue("@Title", TB_Title.Text);
                    cmd.Parameters.AddWithValue("@Author", TB_Author.Text);
                    cmd.Parameters.AddWithValue("@ISBN", TB_ISBN.Text);
                    cmd.Parameters.AddWithValue("@CategoryId", Convert.ToInt32(TB_CategoryId.Text));
                    cmd.Parameters.AddWithValue("@PublicationYear", Convert.ToInt32(TB_PublicationYear.Text));
                    cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(TB_Quantity.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}