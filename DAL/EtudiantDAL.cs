using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL;


namespace DAL
{
    public class EtudiantDAL
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Csharp avance\Multicouche TI-PAM2\NoteGest\DAL\NoteGest.mdf;Integrated Security=True");
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
        // methode permettant d'ajouter un nouveau  etudiant

        public void AddEtudiant(EtudiantBLL etd)
        {
            string query = "insert into Etudiant (nom,prenom,id_classe,date_nais) values(@nom,@prenom,@id_classe,@date_nais)";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@nom", etd.nom);
            cmd.Parameters.AddWithValue("@prenom", etd.prenom);
            cmd.Parameters.AddWithValue("@id_classe", etd.id_classe);
            cmd.Parameters.AddWithValue("@date_nais", etd.date_nais);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        // methode permettant de supprimer  un  etudiant

        public void deleteEtudiant(int id)
        {
            string query = "delete from Etudiant where id_etudiant=@id";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        // methode permettant de mettre a jour un etudiant etudiant

        public void UpdateEtudiant(EtudiantBLL etd)
        {
            string query = "update Etudiant set  nom=@nom,prenom=@prenom,id_classe=@id_classe,date_nais=@date_nais where id_etudiant=@id_etudiant";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@nom", etd.nom);
            cmd.Parameters.AddWithValue("@prenom", etd.prenom);
            cmd.Parameters.AddWithValue("@id_classe", etd.id_classe);
            cmd.Parameters.AddWithValue("@date_nais", etd.date_nais);
            cmd.Parameters.AddWithValue("@id_etudiant", etd.id_etudiant);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        // methode permettant de charger les informations dans le datgridView
        public DataTable getEtudiant()
        {
            DataTable dt = new DataTable();
            string query = " select id_etudiant, etd.nom,prenom, date_nais, cl.nom as nomClasse from Etudiant etd inner join classe cl on cl.id_classe=etd.id_Classe order by etd.nom asc";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            data.Fill(dt);
            cn.Close();
            return dt;
        }
        // methode permettant de donner le nom de la classe d'un etudiant
        public DataTable getClasseById(int id_classe)
        {
            DataTable dt = new DataTable();
            string query = " select cl.nom as nomClasse from Classe cl where id_classe=@id_classe";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@id_classe", id_classe);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            data.Fill(dt);
            cn.Close();
            return dt;
        }

        // methode permettant de selection tout les matieres deja enregistrer
        public DataTable getMatiere()
        {
            DataTable dt = new DataTable();
            string query = " select nom ,credit,description from Matiere order by id_mat asc";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            data.Fill(dt);
            cn.Close();
            return dt;
        }
    }
}
