using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL
{
   public  class NoteDAL
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
       // methode permettant de recuperer tout les classes deja enregistrer 
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
       //methode permettant de recuperer les etudiants par classe
        public DataTable getEtudiant(int id)
        {
            DataTable dt = new DataTable();
            string query = " select nom ,id_etudiant,prenom from Etudiant  where id_classe=@id_classe order by id_etudiant desc";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id_classe", id);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            data.Fill(dt);
            cn.Close();
            return dt;
        }

       //methode permettant d'inserer une note dans la bd
        public void AddNote(NoteBLL note)
        {
            //ouverture de la base de donnee
            cn.Open();
            string query = "insert into [Note] (id_mat,valeur,id_etudiant) values (@id_mat,@note,@id_etudiant)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id_mat",note.id_mat);
            cmd.Parameters.AddWithValue("@note",note.valeur);
            cmd.Parameters.AddWithValue("@id_etudiant", note.id_Etudiant);
            cmd.ExecuteNonQuery();

            // fermeture de la connection
            cn.Close();
        }
    }
}
