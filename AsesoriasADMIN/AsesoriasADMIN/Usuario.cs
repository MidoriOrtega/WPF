using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsesoriasADMIN
{
    class Usuario
    {
        public Int32 claveUnica { get; set; }
        public String nombre { get; set; }
        public String correo { get; set; }
        public String telefono { get; set; }
        public String password { get; set; }

        public Usuario()
        {
        }

        public Usuario(int claveUnica)
        {
            this.claveUnica = claveUnica;
        }

        public Usuario(string nombre)
        {
            this.nombre = nombre;
        }

        public Usuario(int claveUnica, string nombre, string correo, string telefono, string password) : this(claveUnica)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.telefono = telefono;
            this.password = password;
        }

        public int alta(Usuario u)
        {
            int res = 0;
            try
            {                
                SqlConnection con;
                con = Conexion.conectarUsuario();
                SqlCommand cmd = new SqlCommand(String.Format("insert into usuario values({0}, '{1}', '{2}', '{3}', '{4}')", u.claveUnica, u.nombre, u.correo, u.telefono, u.password), con);
                res = cmd.ExecuteNonQuery();
                con.Close();                
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public int baja(Usuario u)
        {
            int res = 0;
            try
            {
                SqlConnection con;
                con = Conexion.conectarUsuario();
                SqlCommand cmd = new SqlCommand(String.Format("delete from usuario where cu = {0}", u.claveUnica), con);
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
            }
            return res;
        }

        public List<Usuario> busca(Usuario u)
        {
            SqlDataReader drd;
            List<Usuario> lis = new List<Usuario>();
            Usuario aux;
            try
            {
                SqlConnection con;
                con = Conexion.conectarUsuario();
                SqlCommand cmd = new SqlCommand(String.Format("select * from usuario where nombre like '%{0}%'", u.nombre), con);
                drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    aux = new Usuario();
                    aux.claveUnica = drd.GetInt32(0);
                    aux.nombre = drd.GetString(1);
                    aux.correo = drd.GetString(2);
                    aux.telefono = drd.GetString(3);
                    aux.password = drd.GetString(4);
                    lis.Add(aux);
                }
                drd.Close();
                con.Close();
            }
            catch(Exception ex)
            {
            }
            return lis;
        }


    }
}
