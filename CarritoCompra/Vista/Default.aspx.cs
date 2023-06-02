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

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Imagen> imagenes = new List<Imagen>();
            listaA = new ArticuloNegocio().Listar();
            imagenes = new ListadoImagen().Listar();

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
            if(Request.QueryString["Cont"] != null)  
            {
                int ID = int.Parse(Request.QueryString["ID"]);

                Carrito.Add(listaA[ID]);

                
            }
        }
    }
}