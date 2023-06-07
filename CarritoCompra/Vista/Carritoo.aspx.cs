using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Modelo;

namespace Vista
{
    public partial class Ca : System.Web.UI.Page
    {
        List<Articulo> Carrito = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["CCompra"] != null)
            {
                Carrito = (List<Articulo>)Session["CCompra"];
                GridViewCarrito.DataSource = Carrito;
                DataBind();
            }
                
            
        }

    }
}