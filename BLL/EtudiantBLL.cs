using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class EtudiantBLL
    {
       public int id_etudiant { get; set; }
       public string nom { get; set; }
       public string prenom { get; set; }
       public DateTime date_nais { get; set; }
       public int id_classe { get; set; }
    }
}
