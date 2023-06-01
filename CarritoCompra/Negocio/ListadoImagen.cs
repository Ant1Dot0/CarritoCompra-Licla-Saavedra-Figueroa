using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Negocio
{
    public class ListadoImagen
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Imagen> Listar()
        {
            List<Imagen> lista = new List<Imagen>();

            try
            {
                datos.setearConsulta("Select Id, IdArticulo, ImagenUrl from IMAGENES");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();

                    aux.ID = (int)datos.Lector["Id"];
                    aux.IDarticulo = (int)datos.Lector["IdArticulo"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
