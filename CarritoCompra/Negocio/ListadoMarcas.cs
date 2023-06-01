using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Negocio
{
    public class ListadoMarcas
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                datos.setearConsulta("Select Id, Descripcion as 'Marca' from MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();

                    aux.ID = (int)datos.Lector["Id"];
                    aux.marca = (string)datos.Lector["Marca"];

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

