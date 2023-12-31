using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BLL;
using System.Threading.Tasks;

namespace DAL
{
  public   class Classe_matiereDAL
    {
      SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Csharp avance\Multicouche TI-PAM2\NoteGest\DAL\NoteGest.mdf;Integrated Security=True");
        // methode permettant de selection tout les matieres deja enregistrer
        public DataTable getMatiere()
        {
            DataTable dt = new DataTable();
            string query = " select nom ,id_mat from Matiere order by id_mat desc";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            data.Fill(dt);
            cn.Close();
            return dt;
        }
        //  methode permettant de selection tout les classes deja enregistrer
        public DataTable getClasse()
        {
            DataTable dt = new DataTable();
            string query = " select nom ,id_classe from classe order by id_classe desc";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            data.Fill(dt);
            cn.Close();
            return dt;
        }
      // methode d'enregistrement des operations effectuer par l'utilisateur
        public void AddMatiereToClasse(classe_matBLL mt)
        {
            //ouverture de la base de donnee
            cn.Open();
            string query = "insert into [classe_mat] (id_classe,id_mat) values (@id_classe,@id_mat)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id_classe", mt.id_classe);
            cmd.Parameters.AddWithValue("@id_mat", mt.id_mat);
            cmd.ExecuteNonQuery();
            // fermeture de la connection
            cn.Close();
        }

    }
}
