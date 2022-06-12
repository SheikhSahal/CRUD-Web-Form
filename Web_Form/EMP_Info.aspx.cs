using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Web_Form
{
    public partial class EMP_Info : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=MSAHALQASIM;Initial Catalog=Demo;User ID=sa;Password=Optiplex@242244";
            con.Open();
            if (!Page.IsPostBack)
            {
                Data_show();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Insert into EMP(Name , Email) values ('" + txtName.Text.ToString() + "','" + txtPhone.Text.ToString() + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Data_show();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Update emp set Name = '" + txtName.Text.ToString() + "', Email ='" + txtPhone.Text.ToString() + "' where Name='" + txtName.Text.ToString() + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Data_show();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText= "delete from emp where Name ='"+ txtName.Text.ToString() + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Data_show();
        }

       public void Data_show()
        {
            ds = new DataSet();
            cmd.CommandText = "select * from emp";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        
    }
}