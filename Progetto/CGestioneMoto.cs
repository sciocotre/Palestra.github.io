using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto
{
    class CGestioneMoto
    {
        private string nomeFile;
        public CGestioneMoto(string nomeFile)
        {
            this.nomeFile = nomeFile;
        }

        public void scriviTutto(string stringa)
        {
            File.WriteAllText(nomeFile, stringa);
        }
        public string leggiTutto()
        {
            return File.ReadAllText(nomeFile);
        }
        public bool salva(List<Moto> lista, string nomeFile)
        {
            bool esito = false;
            this.nomeFile = nomeFile;
            string temp = "";
            for (int i = 0; i < lista.Count; i++)
            {
                temp += lista[i].toCSV() + "\n";
            }
            File.AppendAllText(nomeFile, temp);
            esito = true;
            return esito;
        }
        public List<Moto> leggi()
        {
            List<Moto> lista = new List<Moto>();
            using (StreamReader sr = File.OpenText(nomeFile))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Moto temp = new Moto();
                    temp.fromCSV(s);
                    lista.Add(temp);
                }
            }
            return lista;
        }
        

    }
}
