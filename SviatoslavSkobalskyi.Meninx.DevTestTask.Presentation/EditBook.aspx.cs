using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Presentation
{
    public partial class EditBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var bookId = Request.QueryString["Id"];
                if (bookId != null)
                {
                    GetBookInfo(Convert.ToInt32(bookId));
                }
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Apply_Click(object sender, EventArgs e)
        {
            UpdateBookFromTextBoxValues();

            Response.Redirect("Default.aspx");
        }

        private void GetBookInfo(int id)
        {
            string constr = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Books WHERE ID = {id}", con))
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        TB_ID.Text = reader.GetInt32(0).ToString();
                        TB_Title.Text = reader.GetString(1);
                        TB_Author.Text = reader.GetString(2);
                        TB_ISBN.Text = reader.GetString(3);
                        TB_CategoryId.Text = reader.GetInt32(4).ToString();
                        TB_PublicationYear.Text = reader.GetInt32(5).ToString();
                        TB_Quantity.Text = reader.GetInt32(6).ToString();
                    }
                }
            }
        }
        private void UpdateBookFromTextBoxValues()
        {
            string constr = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("update Books set Title=@Title,Author=@Author,ISBN=@ISBN,CategoryId=@CategoryId, PublicationYear=@PublicationYear, Quantity=@Quantity where Id=@Id", con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(TB_ID.Text));
                    cmd.Parameters.AddWithValue("@Title", TB_Title.Text);
                    cmd.Parameters.AddWithValue("@Author", TB_Author.Text);
                    cmd.Parameters.AddWithValue("@ISBN", TB_ISBN.Text);
                    cmd.Parameters.AddWithValue("@CategoryId", Convert.ToInt32(TB_CategoryId.Text));
                    cmd.Parameters.AddWithValue("@PublicationYear", Convert.ToInt32(TB_PublicationYear.Text));
                    cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(TB_Quantity.Text));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}