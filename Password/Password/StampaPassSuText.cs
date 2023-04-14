using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multifunzione
{
    internal class StampaPassSuText
    {
        string pass;

        public StampaPassSuText(string password)
        {
            pass = password;
        }

        public void Scrivi(string testo)
        {
            File.AppendAllText(pass, testo + "\n");
        }

        public void Cancella()
        {
            File.Delete(pass);
        }
    }
}
