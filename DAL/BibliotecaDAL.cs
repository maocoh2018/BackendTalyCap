using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DAL
{
    public class BibliotecaDAL
    {
        SqlConnection Conn = new SqlConnection();
        /// <summary>
        /// Metodo par listar los clientes existentes
        /// </summary>
        /// <returns></returns>
        public List<Libros> obtenerLibros()
        {

            try
            {
                Conn = ConectionDAL.Singleton.ConnetionFactory;
                Conn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[ObtenerLibros]", Conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                List<Libros> listaLibros = new List<Libros>();
                listaLibros = (from DataRow dr in dt.Rows
                                 select new Libros
                                 {
                                     idBook = Convert.ToInt32(dr["idBook"]),
                                     title = dr["title"].ToString(),
                                     description = dr["description"].ToString(),
                                     pageCount = dr["pageCount"].ToString(),
                                     excerpt = dr["excerpt"].ToString(),
                                     publishDate = Convert.ToDateTime(dr["publishDate"]),
                                     autor = dr["autor"].ToString()

                                 }).ToList();


          
                return listaLibros;
            }
            catch (Exception ex)
            {
                throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            }
            finally
            {
                Conn.Close();
            }
        }


        public List<Autor> obtenerAutores()
        {

            try
            {
                Conn = ConectionDAL.Singleton.ConnetionFactory;
                Conn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[ObtenerAutores]", Conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                List<Autor> listaAutores = new List<Autor>();
                listaAutores = (from DataRow dr in dt.Rows
                               select new Autor
                               {
                                   idAutor = Convert.ToInt32(dr["idAutor"]),
                                   idBook = Convert.ToInt32(dr["idBook"]),
                                   firstName = dr["firstName"].ToString(),
                                   lastName = dr["lastName"].ToString()
                               }).ToList();

                return listaAutores;
            }
            catch (Exception ex)
            {
                throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            }
            finally
            {
                Conn.Close();
            }
        }

        public List<Libros> obtenerLibroAutor(string autor)
        {

            try
            {
                Conn = ConectionDAL.Singleton.ConnetionFactory;
                Conn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[ObtenerAutor]", Conn);
                cmd.Parameters.AddWithValue("@id", autor);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);                
                List<Libros> listaLibros = new List<Libros>();
                listaLibros = (from DataRow dr in dt.Rows
                               select new Libros
                               {
                                   idBook = Convert.ToInt32(dr["idBook"]),
                                   title = dr["title"].ToString(),
                                   description = dr["description"].ToString(),
                                   pageCount = dr["pageCount"].ToString(),
                                   excerpt = dr["excerpt"].ToString(),
                                   publishDate = Convert.ToDateTime(dr["publishDate"]),
                                   autor = dr["autor"].ToString()

                               }).ToList();

                return listaLibros;
            }
            catch (Exception ex)
            {
                throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            }
            finally
            {
                Conn.Close();
            }
        }




    }
        
}
