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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsesoriasADMIN
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String resp = Conexion.comprobarPwd(txtUsuario.Text, txtPassword.Password);
            if (resp.Equals("Contraseña correcta"))
            {
                Admin vAdmin = new Admin();
                vAdmin.Show();
                this.Close();
            }
            else
            {
                lblMensaje.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                lblMensaje.Content = resp;
            }
        }

        private void btnEntrar_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button btnEntrar = sender as Button;
            btnEntrar.Background = new SolidColorBrush(Colors.Green);
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = "cdelga";
            txtPassword.Password = "1234";
        }
    }
}
