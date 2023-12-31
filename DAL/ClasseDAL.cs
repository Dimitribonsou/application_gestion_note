using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class ClasseDAL
    {
        //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Csharp avance\Multicouche TI-PAM2\NoteGest\DAL\NoteGest.mdf;Integrated Security=True");
        //SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\NoteGest.mdf;Integrated Security=True");
        

        public void Addclasse(ClasseBLL cl)
        {
            string query = "insert into classe (nom,libelle,id_filiere,niveau) values(@nom,@libelle,@id_filiere,@niveau)";
            cn.Open();
            SqlCommand cmd=new SqlCommand(query,cn);
            cmd.Parameters.AddWithValue("@nom", cl.nom);
            cmd.Parameters.AddWithValue("@libelle", cl.libelle);
            cmd.Parameters.AddWithValue("@id_filiere", cl.id_filiere);
            cmd.Parameters.AddWithValue("@niveau", cl.niveau);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public DataTable  getFiliere()
        {
            DataTable dt = new DataTable();
            string query = " select nom ,id_filiere from filiere order by id_filiere desc";
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter data =new SqlDataAdapter(cmd);
            data.Fill(dt);
            cn.Close();
            return dt;
        }
 
    }
}
