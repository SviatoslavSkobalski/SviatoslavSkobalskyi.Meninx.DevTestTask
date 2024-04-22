using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Presentation
{
    public partial class DeleteConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            RemoveBook(Convert.ToInt32(Session["BookToDeleteId"]));
            Session["BookToDeleteId"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private void RemoveBook(int bookId)
        {
            string constr = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [Books] WHERE [Id] = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", bookId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}