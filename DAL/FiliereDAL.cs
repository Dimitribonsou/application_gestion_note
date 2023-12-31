using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class FiliereDAL
    {

        //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        //SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\NoteGest.mdf;Integrated Security=True");
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Csharp avance\Multicouche TI-PAM2\NoteGest\DAL\NoteGest.mdf;Integrated Security=True");
        public void AddFiliere(FiliereBLL fl)
        {
            //ouverture de la base de donnee
            cn.Open();
            string query = "insert into [Filiere] (nom,libelle,description) values (@nom,@libelle,@description)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@nom", fl.nom);
            cmd.Parameters.AddWithValue("@libelle", fl.libelle);
            cmd.Parameters.AddWithValue("@description",fl.description);
            cmd.ExecuteNonQuery();

            // fermeture de la connection
            cn.Close();
        }

    }
}
