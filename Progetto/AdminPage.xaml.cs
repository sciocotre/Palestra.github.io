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
using System.Windows.Shapes;

namespace Progetto
{
    /// <summary>
    /// Logica di interazione per AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        CGestione gestione;
        CGestioneMoto gestionemoto = new CGestioneMoto(AppDomain.CurrentDomain.BaseDirectory + "Garage.txt");
        Moto moto = new Moto();
        int indice = 0;
        string filePatch = "";
        List<Moto> lista;
        List<Moto> lista2 = new List<Moto>();

        public AdminPage()
        {
            InitializeComponent();
            lista = new List<Moto>();

            gestionemoto = new CGestioneMoto(AppDomain.CurrentDomain.BaseDirectory + "Garage.txt");
            lista = gestionemoto.leggi();
            Moto m = new Moto();
            
            

        }

        private void Successiva(object sender, RoutedEventArgs e)
        {
            if (indice < lista.Count-1)
            {
                
                indice++;
                moto = lista[indice];
                if (moto.Modello != "")
                {
                    m1.Content = moto.Modello;
                    m2.Content = moto.Marca;
                    t.Content = moto.Targa;
                    immagine.Source = new BitmapImage(new Uri(moto.Immagine));
                }
            }
            else
            {
                MessageBox.Show("Nessuna Moto Presente");
            }
        }

        private void Precedente(object sender, RoutedEventArgs e)
        {
            if (indice >= 1)
            {
                indice--;


                moto = lista[indice];
                if (moto.Modello != "")
                {
                    m1.Content = moto.Modello;
                    m2.Content = moto.Marca;
                    t.Content = moto.Targa;
                    immagine.Source = new BitmapImage(new Uri(moto.Immagine));
                }
            }

            else
            {
                MessageBox.Show("Nessuna Moto Presente");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open1 = new OpenFileDialog();
            open1.InitialDirectory = "D:\\MATTIA";
            if (open1.ShowDialog() == true)
            {
                filePatch = open1.FileName;
                img.Source = new BitmapImage(new Uri(filePatch));
            }
        }

        private void AggiornaDatabase(object sender, RoutedEventArgs e)
        {

            if (filePatch != "" && modello.Text != "" && marca.Text != "" && targa.Text != "" && codiceunivoco.Text != "")
            {
                lista = new List<Moto>();
                moto = new Moto();
                moto.Modello = modello.Text;
                moto.Marca = marca.Text;
                moto.Targa = targa.Text;
                moto.Immagine = filePatch;
                moto.Codiceunivoco = codiceunivoco.Text;
                lista.Add(moto);
                gestionemoto.salva(lista, AppDomain.CurrentDomain.BaseDirectory + "Garage.txt");
                MessageBox.Show("AGGIUNTA");
                modello.Text="";
                marca.Text="";
                targa.Text="";
                img.Source = null;
                codiceunivoco.Text="";

            }
            else
            {
                MessageBox.Show("Compilare tutti i campi!");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            moto = lista[0];
            if (moto.Modello != "")
            {
                m1.Content = moto.Modello;
                m2.Content = moto.Marca;
                t.Content = moto.Targa;
                immagine.Source = new BitmapImage(new Uri(moto.Immagine));
            }
            else
            {
                MessageBox.Show("Nessuna Moto Presente");
            }
            lista = gestionemoto.leggi();

        }

        private void ritorna(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Hide();
        }
    }
}
