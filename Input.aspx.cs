using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Input : System.Web.UI.Page
    {
        OdbcConnection cn = new OdbcConnection("Dsn=land;uid=root;server=localhost;database=land;port=3306");
        OdbcCommand cmd = new OdbcCommand();
        String did = null;
        String vid = null;
        String bid = null;
        String lid = null;
        String lnd = null;
        String sid = null;
        public void bind_ddltenure()
        {
            cn.Open();
            using (cmd = new OdbcCommand("select * from tenure ", cn))
            {
                using (OdbcDataReader rd = cmd.ExecuteReader())
                {
                    tenure.DataSource = rd;
                    tenure.Items.Clear();
                    tenure.Items.Add("..... Please Select Tenure.....");
                    tenure.DataTextField = ("ten");
                    tenure.DataValueField = ("tenID");
                    tenure.DataBind();

                }
            }
            cn.Close();


        }
        public void bind_ddltype()
        {
            cn.Open();
            using (cmd = new OdbcCommand("select * from type", cn))
            {
                using (OdbcDataReader ty = cmd.ExecuteReader())
                {
                    type.DataSource = ty;
                    type.Items.Clear();
                    type.Items.Add("..... Please Select type.....");
                    type.DataTextField = ("typ");
                    type.DataValueField = ("typID");
                    type.DataBind();

                }
            }
            cn.Close();


        }
        public void bind_ddldistrict()
        {
            cn.Open();
            using (cmd = new OdbcCommand("select * from district", cn))
            {
                using (OdbcDataReader ds = cmd.ExecuteReader())
                {
                    districtddl.DataSource = ds;
                    districtddl.Items.Clear();
                    districtddl.Items.Add("..... Please Select district.....");
                    districtddl.DataTextField = ("dstrct");
                    districtddl.DataValueField = ("districtID");
                    districtddl.DataBind();

                }
            }
            cn.Close();
        }
        string message = "hello World";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_ddltenure();
                bind_ddltype();
                bind_ddldistrict();
            }
        }

        protected void Insertbtn_Click(object sender, EventArgs e)
        {

            insertUser();
        }

        private void insertUser()
        {

            Insertbtn.Attributes.Add("onclick", "alert('" + message + "'); return false;");
            String cnString = System.Configuration.ConfigurationManager.ConnectionStrings["LandConString"].ToString();
            {
                {
                    cn.Open();

                    using (cmd = new OdbcCommand("INSERT INTO land.sale(price, date, remarks) VALUES ('" + priceTextbox.Text + "','" + date.Text + "','" + remarksTextBox.Text + "');", cn))
                        cmd.ExecuteNonQuery();
                    cn.Close();
                }
                cn.Open();
                using (cmd = new OdbcCommand("INSERT INTO land.lnd_details(size, user, buildng) VALUES ('" + sizeTextBox.Text + "','" + userTextBox.Text + "','null');", cn))
                    cmd.ExecuteNonQuery();
                cn.Close();
                {
                    cn.Open();
                    using (cmd = new OdbcCommand("SELECT districtID, dstrct FROM land.district where (dstrct='" + districtddl.SelectedItem + "');", cn))
                    {
                        using (OdbcDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                did = reader.GetString(0);
                            }
                            reader.Close();
                        }

                        using (cmd = new OdbcCommand("INSERT INTO land.village(districtID, villa) VALUES ('" + did + "','" + villageTextbox.Text + "');", cn))
                            cmd.ExecuteNonQuery();


                    }
                    cn.Close();
                }
                cn.Open();
                using (cmd = new OdbcCommand("SELECT villageID FROM land.village where (villa='" + villageTextbox.Text + "');", cn))
                {
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vid = reader.GetString(0);
                        }
                        reader.Close();
                    }

                    using (cmd = new OdbcCommand("INSERT INTO land.block(districtID, vilID, blck) VALUES ('" + did + "','" + vid + "','" + blockTextbox.Text + "');", cn))
                        cmd.ExecuteNonQuery();


                }
                cn.Close();
            }
            cn.Open();
            using (cmd = new OdbcCommand("SELECT blockID FROM land.block where (blck='" + blockTextbox.Text + "');", cn))
            {
                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bid = reader.GetString(0);
                    }
                    reader.Close();
                }

                using (cmd = new OdbcCommand("INSERT INTO land.location(districtID, villageID, blockID) VALUES ('" + did + "','" + vid + "','" + bid + "');", cn))
                    cmd.ExecuteNonQuery();
            }
            cn.Close();
            {
                cn.Open();
                using (cmd = new OdbcCommand("SELECT locID FROM land.location;", cn))
                {
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lid = reader.GetString(0);
                        }
                        reader.Close();
                    }
                    using (cmd = new OdbcCommand("SELECT lnd_deID FROM land.lnd_details;", cn))
                    {
                        using (OdbcDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lnd = reader.GetString(0);
                            }
                            reader.Close();
                        }
                        using (cmd = new OdbcCommand("SELECT saleID FROM land.sale;", cn))
                        {
                            using (OdbcDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    sid = reader.GetString(0);
                                }
                                reader.Close();
                            }

                            using (cmd = new OdbcCommand("INSERT INTO land.lnd(tenID, typID, lcnID, lnd_detID, saleid) VALUES ('" + tenure.SelectedValue + "','" + type.SelectedValue + "','" + lid + "','" + lnd + "','" + sid + "');", cn))
                                cmd.ExecuteNonQuery();
                            cn.Close();
                        }

                    }
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);

        }


        protected void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type.SelectedValue.ToString().Equals("2"))
            {
                stru.Style.Value = "display:in-line block";
            }
            else
            { stru.Style.Value = "display:none"; }
        }




    }
}