using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsesoriasADMIN
{
    /// <summary>
    /// Lógica de interacción para Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            int res;
            Usuario u;
            u = new Usuario(Int32.Parse(txtCU.Text), txtNombre.Text, txtCorreo.Text, txtTel.Text, txtPassword.Text);
            res = u.alta(u);
            if (res > 0)
                lblMensaje.Content = "Se dio de alta";
            else
                lblMensaje.Content = "ERROR: No se dio de alta";
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Admin w = new Admin();
            w.Show();
            this.Close();
        }


    }
}
