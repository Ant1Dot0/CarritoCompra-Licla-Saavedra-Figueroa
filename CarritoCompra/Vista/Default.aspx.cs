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
    public partial class _Default : Page
    {
        public List<Articulo> listaA { get; set; }

        public List<Articulo> Carrito { get; set; }

        public Articulo Aux { get; set; }

        public int CantidadCarrito;

        public List<Imagen> imagenes { get; set;}

        protected void Page_Load(object sender, EventArgs e)
        {
            listaA = new ArticuloNegocio().Listar();
            imagenes = new ListadoImagen().Listar();

            Session.Add("ListaA", listaA);

            if (Session["CantidadCarrito"] != null)
            {
                CantidadCarrito = (int)Session["CantidadCarrito"];
            }
            else
            {
                CantidadCarrito = 0;
            }

            Session.Add("Imagenes", imagenes);

            Carrito = (List<Articulo>)Session["CCompra"];

            if(Carrito == null)
            {
                Carrito = new List<Articulo>();

            }

            foreach(Articulo x in listaA)
            {
                foreach(Imagen y in imagenes)
                {
                    if (x.ID == y.IDarticulo)
                        x.ImagenURL = y.ImagenUrl;
                }
            }
           

            BtnAddClick();

        }

        private void BtnAddClick()
        {
            if(Request.QueryString["ID"] != null)  
            {
                int ID = int.Parse(Request.QueryString["ID"]);

                Carrito.Add(listaA[ID-1]);
                CantidadCarrito++;
                Session.Add("CCompra", Carrito);
                Session.Add("CantidadCarrito", CantidadCarrito);
                Response.Redirect("Default.aspx");

            }
        }
    }
}