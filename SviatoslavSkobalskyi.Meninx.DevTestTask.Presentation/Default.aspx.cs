using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Presentation
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.BindGrid();
        }

        protected void BooksGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int primaryKey = Convert.ToInt32(BooksGridView.DataKeys[e.NewEditIndex].Value);
            Response.Redirect("EditBook.aspx?Id=" + primaryKey);
        }

        protected void BooksGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["BookToDeleteId"] = Convert.ToInt32(BooksGridView.DataKeys[e.RowIndex].Value);
            Response.Redirect("DeleteConfirmation.aspx");
        }

        protected void addBookButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBook.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Books]", con))
                {
                    if (txtSearch.Text != "")
                    {
                        cmd.CommandText = $"exec GetAllBooksFilteredSortedPaged @SEARCH_TEXT = {txtSearch.Text}";
                    }
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    BooksGridView.DataSource = dt;
                    BooksGridView.DataBind();
                }
            }
        }

        protected void BooksGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("", con))
                {
                    if (ViewState["SortColumn"] == null)
                    {
                        ViewState["SortColumn"] = e.SortExpression;
                    }
                    if (ViewState["SortDirection"] == null)
                    {
                        ViewState["SortDirection"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
                    }

                    if (ViewState["SortColumn"].ToString() != e.SortExpression)
                    {
                        ViewState["SortDirection"] = "ASC";
                    }

                    string currentDirection = ViewState["SortDirection"].ToString() == "ASC" ? "ASC" : "DESC";

                    if (txtSearch.Text != "")
                    {
                        cmd.CommandText = $"exec GetAllBooksFilteredSortedPaged @SEARCH_TEXT= {txtSearch.Text}, @SORT_COLUMN_NAME={e.SortExpression}, @SORT_COLUMN_DIRECTION='{currentDirection}'";
                    }
                    else
                    {
                        cmd.CommandText = $"exec GetAllBooksFilteredSortedPaged @SORT_COLUMN_NAME={e.SortExpression}, @SORT_COLUMN_DIRECTION='{currentDirection}'";
                    }

                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    BooksGridView.DataSource = dt;
                    BooksGridView.DataBind();

                    ViewState["SortColumn"] = e.SortExpression;
                    ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
                }
            }
        }
    }
}