using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
//using AccesoDatos;
using Acceso = AccesoDatos.Acceso;
namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            Acceso datos = new Acceso();
            try
            {
                datos.setearConsulta("Select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
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

        public int agregarMarca(Marca nueva)
        {

            Acceso conectar = new Acceso();
            try
            {
                if(nueva == null || string.IsNullOrWhiteSpace(nueva.Descripcion))
                {
                    throw new ArgumentException("La descripción de la marca no puede estar vacía.");
                }
                int numero;
                if(int.TryParse(nueva.Descripcion, out numero))
                {
                    throw new ArgumentException("La descripción de la marca no puede ser un número.");
                }

                string consulta = "INSERT INTO MARCAS (Descripcion) OUTPUT INSERTED.Id VALUES (@descripcion)";
                conectar.setearConsulta(consulta);

                conectar.setAtributo("@descripcion", nueva.Descripcion);

                int nuevoID = (int)conectar.ejecutarEscalar();
                return nuevoID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                conectar.cerrarConexion();
            }
        }

        public void eliminarMarcaPorID(int id)
        {
            Acceso conectar = new Acceso();
            try
            {
                // La consulta ahora es un DELETE directo sobre la tabla.
                string consulta = "DELETE FROM MARCAS WHERE Id = @id";
                conectar.setearConsulta(consulta);
                conectar.setAtributo("@id", id);
                conectar.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conectar.cerrarConexion();
            }
        }

        public void eliminarMarcaPorNombre(string nombreMarca)
        {
            Acceso conectar = new Acceso();
            try
            {

                string consulta = "DELETE FROM MARCAS WHERE UPPER(Descripcion) = @nombre";
                conectar.setearConsulta(consulta);


                conectar.setAtributo("@nombre", nombreMarca.ToUpper());
                conectar.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conectar.cerrarConexion();
            }
        }

        public void modificarMarca(Marca marca)
        {
            Acceso conectar = new Acceso();
            try
            {
                if (marca == null || string.IsNullOrWhiteSpace(marca.Descripcion))
                {
                    throw new ArgumentException("La descripción de la marca no puede estar vacía.");
                }
                int numero;
                if (int.TryParse(marca.Descripcion, out numero))
                {
                    throw new ArgumentException("La descripción de la marca no puede ser un número.");
                }

                string consulta = "UPDATE MARCAS SET Descripcion = @descripcion WHERE Id = @id";
                conectar.setearConsulta(consulta);
                conectar.setAtributo("@descripcion", marca.Descripcion);
                conectar.setAtributo("@id", marca.Id);
                conectar.ejecutarAccion();
            }
            finally
            {
                conectar.cerrarConexion();
            }
        }

    }
}
