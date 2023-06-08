using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Negocio;

namespace Vista
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public List<Imagen> ListaImagenes { get; set; }
        public Articulo articulo { get; set; }

        public int CantidadCarrito;
        public List<Articulo> Carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)


        {
            int id_articulo = int.Parse(Request.QueryString["id_articulo"]);
            List<Articulo> lista = (List<Articulo>)Session["ListaA"];
            foreach (Articulo art in lista)
            {
                if (art.ID == id_articulo)
                {
                    articulo = art;
                }
            }
            ListaImagenes = new List<Imagen>();
            List<Imagen> aux = new ListadoImagen().Listar();

            foreach (Imagen x in aux)
            {
                if (x.IDarticulo == articulo.ID)
                    ListaImagenes.Add(x);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Carrito.Add(articulo);
            CantidadCarrito++;
            Session.Add("CCompra", Carrito);
            Session.Add("CantidadCarrito", CantidadCarrito);
            Response.Redirect("Default.aspx");
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Carrito.Add(articulo);
            CantidadCarrito++;
            Session.Add("CCompra", Carrito);
            Session.Add("CantidadCarrito", CantidadCarrito);
            Response.Redirect("Carritoo.aspx");
        }
    }
}