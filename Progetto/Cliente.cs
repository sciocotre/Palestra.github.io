using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto
{
    class Cliente
    {
        private string nomeutente;
        public string Nomeutente
        {
            get { return nomeutente; }
            set { nomeutente = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string codiceunivoco;
        public string Codiceunivoco
        {
            get { return codiceunivoco; }
            set { codiceunivoco = value; }
        }

        private string qr;
        public string Qr
        {
            get { return qr; }
            set { qr = value; }
        }
        public void fromCSV(string stringa)
        {
            string[] temp = stringa.Split(';');
            this.nomeutente = temp[0];
            this.password = temp[1];
            this.codiceunivoco = temp[2];
            this.qr = temp[3];
        }
        public void fromCSV2(string stringa)
        {
            string[] temp = stringa.Split(';');
            this.nomeutente = temp[0];
            this.password = temp[1];
            this.codiceunivoco = temp[2];           
        }

        public string toCSV()
        {
            string stringa = nomeutente + ";" + password + ";"+codiceunivoco+";";
            return stringa;
        }
    }
}
