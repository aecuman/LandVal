using System;
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class DataGrid : System.Web.UI.Page
    {
        OdbcConnection cn = new OdbcConnection("Dsn=land;uid=root;server=localhost;database=land;port=3306");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da;
        DataSet ds = new DataSet();
        public void bind_ddltenure()
        {
            cn.Open();
            using (cmd = new OdbcCommand("select * from tenure ", cn))
            {
                using (OdbcDataReader rd = cmd.ExecuteReader())
                {
                    Tenure.DataSource = rd;
                    Tenure.Items.Clear();
                    Tenure.Items.Add("..... Please Select Tenure.....");
                    Tenure.DataTextField = ("ten");
                    Tenure.DataValueField = ("tenID");
                    Tenure.DataBind();

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
                    districtddl.DataSource = ty;
                    districtddl.Items.Clear();
                    districtddl.Items.Add("..... Please Select type.....");
                    districtddl.DataTextField = ("typ");
                    districtddl.DataValueField = ("typID");
                    districtddl.DataBind();

                }
            }
            cn.Close();


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_ddltenure();
                bind_ddltype();
               
            }

        }



        protected void search_Click(object sender, EventArgs e)
        {
            cn.Open();
            String cnString = System.Configuration.ConfigurationManager.ConnectionStrings["LandConString"].ToString();
            cmd = new OdbcCommand("SELECT DISTINCT lnd.lndID, lnd.tenID, lnd.typID, district.dstrct, village.villa, block.blck, lnd_details.`size`, lnd_details.`user`, sale.price, sale.`date`, sale.remarks FROM lnd, location, district, village, block, lnd_details, sale WHERE lnd.lcnID = location.locID AND location.districtID = district.districtID AND location.villageID = village.villageID AND location.blockID = block.blockID AND lnd.lnd_detID = lnd_details.lnd_deID AND lnd.saleid = sale.saleid AND (lnd.tenID ='" + Tenure.SelectedValue + "' ) AND (lnd.typID = '" + districtddl.SelectedValue + "') AND (village.villa = '" + TextBox8.Text + "') ;");
            cmd.Connection = cn;
            da = new OdbcDataAdapter(cmd);
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            Grid.DataSource = ds;
            Grid.DataBind();
            cn.Close();
        }
    }
}
