using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class SiteMaster : MasterPage
    {
        public int CantidadCarrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CantidadCarrito"] != null)
            {
                CantidadCarrito = (int)Session["CantidadCarrito"];
            }
            else
            {
                CantidadCarrito = 0;
            }
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}