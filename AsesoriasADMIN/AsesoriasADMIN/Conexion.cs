using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsesoriasADMIN
{
    class Conexion
    {
        public static SqlConnection conectarAdmin()
        {
            SqlConnection cnn = null;
            try
            {
            cnn = new SqlConnection("Data Source=DESKTOP-285NFBG\\SQLEXPRESS;Initial Catalog=administracion;Persist Security Info=True;User ID=sa;Password=sqladmin");
          //cnn = new SqlConnection("Data Source=localhost;Initial Catalog=administracion;Integrated Security=True");
                cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar y el error es: " + ex);
            }
            return cnn;
        }

        public static SqlConnection conectarUsuario()
        {
            SqlConnection cnn = null;
            try
            {
            cnn = new SqlConnection("Data Source=DESKTOP-285NFBG\\SQLEXPRESS;Initial Catalog=usuariosAsesorias;Persist Security Info=True;User ID=sa;Password=sqladmin");
            //cnn = new SqlConnection("Data Source=localhost;Initial Catalog=usuariosAsesorias;Integrated Security=True");
                cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar y el error es: " + ex);
            }
            return cnn;
        }   


        public static String comprobarPwd(String usuario, String contra)
        {
            String resp = "";
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader drd;
            try
            {
                con = Conexion.conectarAdmin();
                cmd = new SqlCommand(String.Format("select contra from administrador where usuario = '{0}'", usuario), con);
                drd = cmd.ExecuteReader();
                if (drd.Read())
                {
                    if (drd.GetString(0).Equals(contra))
                        resp = "Contraseña correcta";
                    else
                        resp = "Contraseña incorrecta";
                }
                else
                    resp = "Usuario incorrecto";
                con.Close();
                drd.Close();
            }
            catch (Exception e)
            {
                resp = "ERROR: " + e;
            }
            return resp;
        }

    }
}
