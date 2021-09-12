using Microsoft.Win32;
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

namespace Progetto
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Cliente> lista;
        CGestione gestione;
        Cliente c;

        public MainWindow()
        {
            InitializeComponent();
            lista = new List<Cliente>();
            gestione = new CGestione(AppDomain.CurrentDomain.BaseDirectory + "Clienti.txt");
            lista = gestione.leggi();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            lista = gestione.leggi();
            if (Id.Text == "Admin" && Password.Text == "Password")
            {
                AdminPage a = new AdminPage();
                this.Hide();
                a.Show();
            }
            else
            {
                for(int i = 0; i < lista.Count(); i++)
                {
                    if (Id.Text == lista[i].Nomeutente && Password.Text== lista[i].Password)
                    {
                        PaginaCliente nuova = new PaginaCliente(Id.Text,Password.Text);
                        this.Hide();
                        nuova.Show();
                    }
                }
            }
            
        }

        private void reg(object sender, RoutedEventArgs e)
        {
            c = new Cliente();     
            lista = gestione.leggi();
            bool trovato = false;
            for(int i = 0; i < lista.Count&&trovato==false; i++)
            {
                if (IDREG.Text == lista[i].Nomeutente)
                {
                    MessageBox.Show("Nome Utente Non Disponibile");
                    trovato = true;
                }
            }
            if (trovato == false)
            {
                lista = new List<Cliente>();
                c.Nomeutente = IDREG.Text;
                c.Password = passreg.Text;
                lista.Add(c);
                gestione.salva(lista, AppDomain.CurrentDomain.BaseDirectory + "Clienti.txt");
                MessageBox.Show("Registrato");

            }
        }
    }
}
