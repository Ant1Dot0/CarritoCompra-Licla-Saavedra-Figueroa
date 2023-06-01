using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Negocio
{
    public class ListadoCat
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                datos.setearConsulta("Select Id, Descripcion as 'Categoria' from CATEGORIAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();

                    aux.ID = (int)datos.Lector["Id"];
                    aux.categoria = (string)datos.Lector["Categoria"];

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
