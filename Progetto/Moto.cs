using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto
{
    class Moto
    {
        private string marca;
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private string modello;
        public string Modello
        {
            get { return modello; }
            set { modello = value; }
        }

        private string targa;
        public string Targa
        {
            get { return targa; }
            set { targa = value; }
        }

        private string immagine;
        public string Immagine
        {
            get { return immagine; }
            set { immagine = value; }
        }

        private string disponibile;
        public string Disponibile 
        {
            get { return disponibile; }
            set { disponibile = value; }
        }
        private string codiceunivoco;
        public string Codiceunivoco
        {
            get { return codiceunivoco; }
            set { codiceunivoco = value; }
        }

        public Moto()
        {
            Marca = "";
            Modello = "";
            Targa = "";
            Immagine = "";
            disponibile = "si";
            codiceunivoco = "";
        }
        public string toCSV()
        {
            string stringa = marca + ";" + modello + ";"+targa+";"+immagine+";"+ disponibile+";"+ codiceunivoco+";";
            return stringa;
        }
        public void fromCSV(string stringa)
        {
            string[] temp = stringa.Split(';');
            this.marca = temp[0];
            this.modello = temp[1];
            this.targa = temp[2];
            this.immagine = temp[3];
            this.disponibile = temp[4];
            this.codiceunivoco = temp[5];
        }
    }
}
