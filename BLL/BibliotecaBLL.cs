using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTIDADES;

namespace BLL
{
    public class BibliotecaBLL
    {
        public List<Libros> obtenerLibros()
        {
            BibliotecaDAL libros = new BibliotecaDAL();
            return libros.obtenerLibros();
        }

        public List<Autor> obtenerAutores()
        {
            BibliotecaDAL autores = new BibliotecaDAL();
            return autores.obtenerAutores();
        }

        public List<Libros> obtenerAutor(string autor)
        {
            BibliotecaDAL autores = new BibliotecaDAL();
            return autores.obtenerLibroAutor(autor);
        }

    }
}
