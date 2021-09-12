using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
using static QRCoder.Base64QRCode;
using Encoder = System.Drawing.Imaging.Encoder;



namespace Progetto
{
    /// <summary>
    /// Logica di interazione per PaginaCliente.xaml
    /// </summary>
    public partial class PaginaCliente : Window
    {
        Moto moto = new Moto();
        List<Moto> lista;
        List<Cliente> listac;
        List<Cliente> listac2 = new List<Cliente>();
        CGestione gestione=new CGestione(AppDomain.CurrentDomain.BaseDirectory + "Clienti.txt");
        CGestioneMoto gestionemoto = new CGestioneMoto(AppDomain.CurrentDomain.BaseDirectory + "Garage.txt");
        int indice = 0;
        string nome, password;
        Cliente c = new Cliente();

        Bitmap qrCodeImage;
        QRCodeGenerator qrGenerator;
        QRCodeData qrCodeData;
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        public PaginaCliente()
        {
            InitializeComponent();
            
        }

        public PaginaCliente(string s1,string s2)
        {
            InitializeComponent();
            lista = new List<Moto>();
            gestionemoto = new CGestioneMoto(AppDomain.CurrentDomain.BaseDirectory + "Garage.txt");
            lista = gestionemoto.leggi();
            listac = new List<Cliente>();
            gestione = new CGestione(AppDomain.CurrentDomain.BaseDirectory + "Clienti.txt");
            listac = gestione.leggi();
            nome = s1;
            password = s2;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            moto = lista[0];
            if (moto.Modello != "")
            {
                modello.Content = moto.Modello;
                marca.Content = moto.Marca;
                targa.Content = moto.Targa;
                immagine.Source = new BitmapImage(new Uri(moto.Immagine));
            }
            else
            {
                MessageBox.Show("Nessuna Moto Presente");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            c = new Cliente();
            moto = lista[indice];
            c.Codiceunivoco = moto.Codiceunivoco;
            string s = nome +";"+ password +";"+ c.Codiceunivoco+";";
            qrGenerator = new QRCodeGenerator();
            qrCodeData = qrGenerator.CreateQrCode(s, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            qrCodeImage = qrCode.GetGraphic(20);
            listac2 = new List<Cliente>();            
            qrCodeImage.Save("D:\\MATTIA\\scuola\\Informatica\\github\\Progetto.github.io\\Progetto\\bin\\Debug\\Qr\\" + "ciaooo" + ".jpeg", ImageFormat.Jpeg);
            img1.Source = BitmapToImageSource(qrCodeImage);
            for(int i = 0; i < listac.Count; i++)
            {
                if (listac[i].Nomeutente == nome && listac[i].Password==password)
                {
                    c.Nomeutente = nome;
                    c.Password = password;
                    c.Qr = s;
                    listac2.Add(c);
                }
                else
                {
                    listac2.Add(listac[i]);
                }
            }
            gestione.sostituisci(listac2, AppDomain.CurrentDomain.BaseDirectory + "Clienti.txt");

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//precedente
        {
            if (indice >= 1)
            {
                indice--;
                moto = lista[indice];
                if (moto.Modello != "")
                {
                    marca.Content = moto.Modello;
                    modello.Content = moto.Marca;
                    targa.Content = moto.Targa;
                    immagine.Source = new BitmapImage(new Uri(moto.Immagine));
                }
            }

            else
            {
                MessageBox.Show("Nessuna Moto Presente");
            }
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)//successivo
        {
            if (indice < lista.Count - 1)
            {
                indice++;
                moto = lista[indice];
                if (moto.Modello != "")
                {
                    marca.Content = moto.Modello;
                    modello.Content = moto.Marca;
                    targa.Content = moto.Targa;
                    immagine.Source = new BitmapImage(new Uri(moto.Immagine));
                }
            }
            else
            {
                MessageBox.Show("Nessuna Moto Presente");
            }
        }

        private void QrWebCamControl_QrDecoded(object sender, string e)
        {           
            c.fromCSV2(e);
            bool a = false;
            for(int i = 0; i < lista.Count&&a==false; i++)
            {
                if (lista[i].Codiceunivoco == c.Codiceunivoco)
                {
                    marcaautoinpossesso.Content = lista[i].Marca;
                    modelloautoinpossesso.Content = lista[i].Modello;
                    targaautoinpossesso.Content = lista[i].Targa;
                    immagine1.Source = new BitmapImage(new Uri(moto.Immagine));
                    a = true;
                }
            }
         
        }

        private void camSelect_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            webCam.CameraIndex = camSelect.SelectedIndex;
        }

        private void ritorna(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            camSelect.ItemsSource = webCam.CameraNames;
        }

    }
}
