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
        public List<Articulo> Carrito = new List<Articulo>();
        public decimal total;
        public int CantidadCarrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            int cont = 0;
            if (Session["CantidadCarrito"] != null)
            {
                CantidadCarrito = (int)Session["CantidadCarrito"];
            }
            else
            {
                CantidadCarrito = 0;
            }

            if (Session["CCompra"] != null)
            {
                Carrito = (List<Articulo>)Session["CCompra"];
                foreach (Articulo art in Carrito)
                {
                    total += art.Precio;
                    art.ID = cont;
                    cont++;
                }
                GridViewCarrito.DataSource = Carrito;
                DataBind();
            }
            total = 0;
            foreach (Articulo art in Carrito)
            {
                total += art.Precio;
                art.ID = cont;
                cont++;
            }

        }

        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            Carrito.Clear();
            Session.Add("CCompra", Carrito);
            CantidadCarrito = 0;
            Session.Add("CantidadCarrito", CantidadCarrito);
            Response.Redirect("Carritoo.aspx");
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Carrito.Clear();
            Session.Add("CCompra", Carrito);
            CantidadCarrito = 0;
            Session.Add("CantidadCarrito", CantidadCarrito);
            Response.Redirect("Carritoo.aspx");
        }

        protected void GridViewCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carrito.RemoveAt((int)GridViewCarrito.SelectedDataKey.Value);
            CantidadCarrito--;
            Session.Add("CantidadCarrito", CantidadCarrito);
            Response.Redirect("Carritoo.aspx");
        }
    }
}