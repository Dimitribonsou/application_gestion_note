using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BLL;
using System.Data;
using System.Threading.Tasks;

namespace DAL
{
   public  class MatiereDAL
    {
       // methode permettant d'enregistrer une nouvelle matiere le champ credit 
       //est a ajoutter dans la table  matiere de type int pour prendre en compte les credit des matieres
       //
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Csharp avance\Multicouche TI-PAM2\NoteGest\DAL\NoteGest.mdf;Integrated Security=True");
        public void AddMatiere(MatiereBLL mt)
        {
            //ouverture de la base de donnee
            cn.Open();
            string query = "insert into [Matiere] (nom,credit,description) values (@nom,@credit,@description)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@nom", mt.nom);
            cmd.Parameters.AddWithValue("@credit", mt.credit);
            cmd.Parameters.AddWithValue("@description", mt.description);
            cmd.ExecuteNonQuery();

            // fermeture de la connection
            cn.Close();
        }

   

    }
}
