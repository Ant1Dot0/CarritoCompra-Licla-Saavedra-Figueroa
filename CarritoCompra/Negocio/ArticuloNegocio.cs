using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Negocio
{
    public class ArticuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setearConsulta("SELECT A.id as ART, CODIGO, NOMBRE, A.Descripcion as DESCRIP, M.ID as MAR, M.Descripcion as MARDE, C.Id as CATE, C.Descripcion as CATEDE, PRECIO FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE A.IdMarca = M.id and A.idCategoria = C.id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)datos.Lector["ART"];
                    aux.Codigo = (string)datos.Lector["CODIGO"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Descripcion = (string)datos.Lector["DESCRIP"];
                    aux.Marca = new Marca();
                    aux.Marca.marca = (string)datos.Lector["MARDE"];
                    aux.Marca.ID = (int)datos.Lector["MAR"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.categoria = (string)datos.Lector["CATEDE"];
                    aux.Categoria.ID = (int)datos.Lector["CATE"];
                    aux.Precio = (decimal)datos.Lector["PRECIO"];
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
        public void Insertar(Articulo Agregar)
        {


            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) Values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @PP)");
                datos.SetearPARAMETROS("@Codigo", Agregar.Codigo);
                datos.SetearPARAMETROS("@Nombre", Agregar.Nombre);
                datos.SetearPARAMETROS("@Descripcion", Agregar.Descripcion);
                datos.SetearPARAMETROS("@IdMarca", Agregar.Marca.ID);
                datos.SetearPARAMETROS("IdCategoria", Agregar.Categoria.ID);
                datos.SetearPARAMETROS("@PP", Agregar.Precio);

                datos.ejecutarEscritura();

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Articulo BuscarArticuloid(Articulo articulo)
        {
            try
            {
                datos.setearConsulta("SELECT Id, CODIGO, NOMBRE, Descripcion, IdMarca, IdCategoria, PRECIO FROM ARTICULOS WHERE CODIGO = " + articulo.Codigo);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    articulo.ID = (int)datos.Lector["ART"];
                    articulo.Codigo = (string)datos.Lector["CODIGO"];
                    articulo.Nombre = (string)datos.Lector["NOMBRE"];
                    articulo.Descripcion = (string)datos.Lector["DESCRIP"];
                    articulo.Marca = new Marca();
                    articulo.Marca.marca = (string)datos.Lector["MARDE"];
                    articulo.Marca.ID = (int)datos.Lector["MAR"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.categoria = (string)datos.Lector["CATEDE"];
                    articulo.Categoria.ID = (int)datos.Lector["CATE"];
                    articulo.Precio = (decimal)datos.Lector["PRECIO"];
                }
                else
                {
                    articulo.ID = 0;
                }
                return articulo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo articulo)
        {
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, Precio = @precio where Id " + articulo.ID);
                datos.SetearPARAMETROS("@codigo", articulo.Codigo);
                datos.SetearPARAMETROS("@nombre", articulo.Nombre);
                datos.SetearPARAMETROS("@descripcion", articulo.Descripcion);
                datos.SetearPARAMETROS("@idmarca", articulo.Marca);
                datos.SetearPARAMETROS("@idcategoria", articulo.Categoria);
                datos.SetearPARAMETROS("@precio", articulo.Precio);

                datos.ejecutarEscritura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int ID)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where ID = @id");
                datos.SetearPARAMETROS("@id", ID);
                datos.ejecutarEscritura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
