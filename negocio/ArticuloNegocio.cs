using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
//using AccesoDatos;
using Acceso = AccesoDatos.Acceso;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();

            // INSTANCIA DE CLASE DE ACCESO A DATOS
            Acceso conectar = new Acceso();
            // SE MIGRO ESTA LOGICA A CLASE ACCESODATOS
            //SqlConnection conexion = new SqlConnection();
            //SqlCommand comando = new SqlCommand();
            //SqlDataReader lector;

            try
            {
                // ESTA LOGICA SE MIGRA A CLASE ACCESODATOS
                ///lo primero es la el servidor donde se conecta, lo segundo es la base de datos y lo tercero es la seguridad
                //conexion.ConnectionString = "Server=TOMAS; Database=CATALOGO_P3_DB; Integrated Security=True; TrustServerCertificate=True;";
                //comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "SELECT A.Id,A.Codigo,A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio FROM ARTICULOS A, MARCAS M, CATEGORIAS C Where M.Id = A.Id And C.Id = M.Id";
                //comando.Connection = conexion;

                // GENERO LA CONSULTA PARA PASARLE AL CONECTOR
                conectar.setearConsulta(@"
                SELECT  a.Id,
                        a.Codigo,
                        a.Nombre,
                        a.Descripcion,
                        a.IdMarca,
                        m.Descripcion AS MarcaDescripcion,
                        a.IdCategoria,
                        c.Descripcion AS CategoriaDescripcion,
                        a.Precio,
                        i.Id        AS IdImagen,
                        i.ImagenUrl AS UrlImagen
                FROM ARTICULOS a
                LEFT JOIN MARCAS m     ON m.Id = a.IdMarca
                LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria
                LEFT JOIN IMAGENES i   ON i.IdArticulo = a.Id
                ORDER BY a.Id, i.Id;");


                conectar.ejecutarLectura();

                Articulo actual = null;// El articulo actual que estoy leyendo
                int ultimoId = -1; // El id del último artículo que leí

                // SE MIGRO ESTA LOGICA A CLASE ACCESODATOS
                //conexion.Open();
                //lector = comando.ExecuteReader();

                // SE CAMBIO LA LOGICA PARA PASAR LA CONECCION MEDIANTE LA CLASE ACCESODATOS
                while (conectar.Lector.Read())
                {
                    int idActual = (int)conectar.Lector["Id"]; //el id del artículo que estoy leyendo

                    // si cambió el artículo, creo uno nuevo y lo agrego a la lista
                    if (idActual != ultimoId)
                    {
                        actual = new Articulo //creamos un nuevo articulo
                        {
                            Id = idActual,
                            Codigo = (string)conectar.Lector["Codigo"],
                            Nombre = (string)conectar.Lector["Nombre"],
                            Descripcion = Convert.ToString(conectar.Lector["Descripcion"]),
                            IdMarca = (int)conectar.Lector["IdMarca"],
                            IdCategoria = (int)conectar.Lector["IdCategoria"],
                            Marca = new Marca()
                            {
                                Id = (int)conectar.Lector["IdMarca"],
                                Descripcion = Convert.ToString(conectar.Lector["MarcaDescripcion"])
                            },
                            Categoria = new Categoria()
                            {
                                Id = (int)conectar.Lector["IdCategoria"],
                                Descripcion = Convert.ToString(conectar.Lector["CategoriaDescripcion"])
                            },

                            Precio = (decimal)conectar.Lector["Precio"],
                            Imagenes = new List<Imagen>()
                        };

                        lista.Add(actual);
                        ultimoId = idActual;// actualizo el id del último artículo leído
                    }

                    // si esta fila trae imagen, la agrego al artículo actual
                    if (!(conectar.Lector["IdImagen"] is DBNull))
                    {
                        actual.Imagenes.Add(new Imagen //agregamos la imagen a la lista de imagenes del articulo actual
                        {
                            Id = (int)conectar.Lector["IdImagen"],
                            IdArticulo = idActual,
                            ImagenUrl = (string)conectar.Lector["UrlImagen"]
                        });
                    }
                }

                return lista;
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

        public int agregar(Articulo nuevo)

        {
            validarArticuloNegocio(nuevo, false); // Validamos el articulo antes de agregarlo

            Acceso conectar = new Acceso();
            var urls = nuevo.Imagenes.Select(img => img.ImagenUrl).ToList(); // Extrae las URLs de las imágenes
            int idInsertado = 0;
            try
            {

                // pruebas de logica agnosticas a las ventanas
                conectar.setearConsulta(@"
            INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)
            OUTPUT INSERTED.Id
            VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio);");
                // prueba de seteo
                conectar.setAtributo("@codigo", nuevo.Codigo);
                conectar.setAtributo("@nombre", nuevo.Nombre);
                conectar.setAtributo("@descripcion", (object)nuevo.Descripcion?? DBNull.Value);
                conectar.setAtributo("@idMarca", nuevo.IdMarca);
                conectar.setAtributo("@idCategoria", nuevo.IdCategoria);
                conectar.setAtributo("@precio", nuevo.Precio);


                idInsertado = (int)conectar.ejecutarEscalar();
                nuevo.Id = idInsertado; // asigna el ID generado al objeto Articulo
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conectar.cerrarConexion();

            }

            if (urls.Count > 0)
            {
                AgregarImagenes(idInsertado, urls);
            }
            return idInsertado;
        }

        public void AgregarImagenes(int articuloId, List<string> imagenUrls) //Metodo para agregar las imagenes
        {
        
            Acceso conectar = new Acceso();
            try
            {
                foreach (var url in imagenUrls) // Recorremos cada url de la lista y la insertamos en la bd
                {
                    conectar.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                    conectar.setAtributo("@IdArticulo", articuloId);
                    conectar.setAtributo("@ImagenUrl", url);
                    conectar.ejecutarAccion();
                }
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
        // Elimina el dato de forma fisica en la DDBB (usar con cuidaod se pierde el registro)
        public void eliminar(int id)
        {
            Acceso conectar = new Acceso();
            try
            {
                string consulta = "DELETE FROM ARTICULOS WHERE Id = @Id";
                conectar.setearConsulta(consulta);
                conectar.setAtributo("@Id", id);
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

        public List<Articulo> Buscar(string nombre, int? idMarca, int? idCategoria, decimal? precioMax)
        {
            var lista = new List<Articulo>();
            var conectar = new Acceso();

            try
            {
                var consulta = @"
            SELECT  a.Id,
                    a.Codigo,
                    a.Nombre,
                    a.Descripcion,
                    a.IdMarca,
                    m.Descripcion AS MarcaDescripcion,
                    a.IdCategoria,
                    c.Descripcion AS CategoriaDescripcion,
                    a.Precio
            FROM ARTICULOS a
            LEFT JOIN MARCAS m     ON m.Id = a.IdMarca
            LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria
            WHERE 1=1";

                if (!string.IsNullOrEmpty(nombre)) consulta += " AND a.Nombre LIKE @Nombre";
                if (idMarca.HasValue) consulta += " AND a.IdMarca = @IdMarca";
                if (idCategoria.HasValue) consulta += " AND a.IdCategoria = @IdCategoria";
                if (precioMax.HasValue) consulta += " AND a.Precio <= @PrecioMax";

                conectar.setearConsulta(consulta);
                if (!string.IsNullOrEmpty(nombre)) conectar.setAtributo("@Nombre", "%" + nombre + "%");
                if (idMarca.HasValue) conectar.setAtributo("@IdMarca", idMarca.Value);
                if (idCategoria.HasValue) conectar.setAtributo("@IdCategoria", idCategoria.Value);
                if (precioMax.HasValue) conectar.setAtributo("@PrecioMax", precioMax.Value);

                conectar.ejecutarLectura();

                while (conectar.Lector.Read())
                {
                    var aux = new Articulo
                    {
                        Id = (int)conectar.Lector["Id"],
                        Codigo = Convert.ToString(conectar.Lector["Codigo"]), 
                        Nombre = Convert.ToString(conectar.Lector["Nombre"]),
                        Descripcion = Convert.ToString(conectar.Lector["Descripcion"]),
                        IdMarca = conectar.Lector["IdMarca"] is DBNull ? 0 : (int)conectar.Lector["IdMarca"],
                        IdCategoria = conectar.Lector["IdCategoria"] is DBNull ? 0 : (int)conectar.Lector["IdCategoria"],
                        Precio = (decimal)conectar.Lector["Precio"],
                        Marca = new Marca
                        {
                            Id = conectar.Lector["IdMarca"] is DBNull ? 0 : (int)conectar.Lector["IdMarca"],
                            Descripcion = conectar.Lector["MarcaDescripcion"] is DBNull ? "" : Convert.ToString(conectar.Lector["MarcaDescripcion"])
                        },
                        Categoria = new Categoria
                        {
                            Id = conectar.Lector["IdCategoria"] is DBNull ? 0 : (int)conectar.Lector["IdCategoria"],
                            Descripcion = conectar.Lector["CategoriaDescripcion"] is DBNull ? "" : Convert.ToString(conectar.Lector["CategoriaDescripcion"])
                        },
                        
                    };

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                conectar.cerrarConexion();
            }
        }


        public List<Articulo> filtrarMarca(int idMarca)
        {
            List<Articulo> lista = new List<Articulo>();
            Acceso conectar = new Acceso();
            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio FROM ARTICULOS A WHERE A.IdMarca = @IdMarca";
                conectar.setearConsulta(consulta);
                conectar.setAtributo("@IdMarca", idMarca);
                conectar.ejecutarLectura();
                while (conectar.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = conectar.Lector.GetInt32(0);
                    aux.Codigo = (string)conectar.Lector["Codigo"];
                    aux.Nombre = (string)conectar.Lector["Nombre"];
                    aux.Descripcion = Convert.ToString(conectar.Lector["Descripcion"]);
                    aux.IdMarca = (int)conectar.Lector["IdMarca"];
                    aux.IdCategoria = (int)conectar.Lector["IdCategoria"];
                    aux.Precio = (decimal)conectar.Lector["Precio"];
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
                conectar.cerrarConexion();
            }
        }


        public void modificar(Articulo articulo)
        {
            if (articulo.Id <= 0) throw new Exception("El ID del artículo no es válido para la modificación.");
            validarArticuloNegocio(articulo, true); // Validamos el articulo antes de modificarlo
            Acceso conectar = new Acceso();
            try
            {
                conectar.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                conectar.setAtributo("@Codigo", articulo.Codigo);
                conectar.setAtributo("@Nombre", articulo.Nombre);
                conectar.setAtributo("@Descripcion", (object)articulo.Descripcion?? DBNull.Value);
                conectar.setAtributo("@IdMarca", articulo.IdMarca);
                conectar.setAtributo("@IdCategoria", articulo.IdCategoria);
                conectar.setAtributo("@Precio", articulo.Precio);
                conectar.setAtributo("@Id", articulo.Id);

                int filasAfectadas = conectar.ejecutarAccion();
                if (filasAfectadas == 0) // Verifica si alguna fila fue afectada
                {
                    throw new Exception("No se encontró el artículo para modificar.");
                }

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

        public void modificarImagenes(Articulo articulo)
        {
            if(articulo.Id <= 0) throw new Exception("El ID del artículo no es válido para la modificación.");
            validarArticuloNegocio(articulo, true); // Validamos el articulo antes de modificarlo
            modificar(articulo); //Modificamos los datos del articulo primero
            var urls = (articulo.Imagenes ?? new List<Imagen>()) // Aca nos aseguramos que la lista no sea nula
                    .Select(i => i.ImagenUrl)
                    .Where(u => !string.IsNullOrWhiteSpace(u))
                    .Select(u => u.Trim())
                    .ToList();
            Acceso conectar = new Acceso();

            try
            {
                // Luego eliminamos las imágenes existentes
                conectar.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                conectar.setAtributo("@IdArticulo", articulo.Id);
                conectar.ejecutarAccion();
                // Luego, agregamos las nuevas imágenes
                foreach (var imagen in articulo.Imagenes)
                {
                    conectar.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                    conectar.setAtributo("@IdArticulo", articulo.Id);
                    conectar.setAtributo("@ImagenUrl", imagen.ImagenUrl);
                    conectar.ejecutarAccion();
                }
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
        public void validarArticuloNegocio(Articulo articulo, bool esModificacion)
        {
            if (articulo == null) throw new Exception("El artículo no puede ser nulo.");

            // Trim para eliminar espacios en blanco al inicio y al final
            articulo.Codigo = articulo.Codigo?.Trim();
            articulo.Nombre = articulo.Nombre?.Trim();
            articulo.Descripcion = articulo.Descripcion?.Trim();

            // Validaciones
            if (string.IsNullOrWhiteSpace(articulo.Codigo)) throw new Exception("El código del artículo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(articulo.Nombre)) throw new Exception("El nombre del artículo no puede estar vacío.");
            if (articulo.IdMarca <= 0) throw new Exception("Debe seleccionar una marca válida.");
            if (articulo.IdCategoria <= 0) throw new Exception("Debe seleccionar una categoría válida.");
            if (articulo.Precio < 0) throw new Exception("El precio no puede ser negativo.");

            if(ExisteCodigo(articulo.Codigo, esModificacion ? articulo.Id : (int?)null))
                throw new Exception("El código del artículo ya existe.");

           List <Imagen> imagenes = new List<Imagen>();
           HashSet<string> urlsUnicas = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // Comparación sin distinguir mayúsculas/minúsculas
            List <string> urlsInvalidas = new List<string>();
            List <string> urlsLargas = new List<string>();
            if(articulo.Imagenes != null)
            {
                foreach (var img in articulo.Imagenes)
                {
                    if (string.IsNullOrWhiteSpace(img.ImagenUrl))
                        continue; // Ignorar URLs vacías o nulas
                    string urlTrimmed = img.ImagenUrl.Trim();
                    if (!EsUrlValida(urlTrimmed))
                    {
                        urlsInvalidas.Add(urlTrimmed);
                        continue;
                    }
                    if (urlTrimmed.Length > 1000)
                    {
                        urlsLargas.Add(urlTrimmed);
                        continue;
                    }
                    if (urlsUnicas.Add(urlTrimmed)) // Solo agrega si es única
                    {
                        imagenes.Add(new Imagen { ImagenUrl = urlTrimmed });
                    }
                }
            }
               if(urlsInvalidas.Count > 0)
                   throw new Exception("Una o más URLs no son válidas (deben ser http/https).");
                if(urlsLargas.Count > 0)
                throw new Exception("Una o mas URLs de imagenes exceden el limite de 1000 caracteres");
                articulo.Imagenes = imagenes; // Asigna la lista filtrada de imágenes al artículo
        }

        private bool EsUrlValida(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private bool ExisteCodigo(string codigo, int? idExcluido)
        {
            Acceso conectar = new Acceso();
            try
            {
                conectar.setearConsulta(@"SELECT COUNT(1) FROM ARTICULOS WHERE Codigo=@Codigo AND (@Id IS NULL OR Id<>@Id)");
                conectar.setAtributo("@Codigo", codigo);
                conectar.setAtributo("@Id", (object)idExcluido ?? DBNull.Value);
                return Convert.ToInt32(conectar.ejecutarEscalar()) > 0;
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

        
    }

    }
