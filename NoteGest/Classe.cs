using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BLL;
using DAL;

namespace NoteGest
{
    public partial class Classe : Form
    {
        public Classe()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        // extenssiation d'un objet de la classe ClasseDAL
        ClasseDAL ClDaL = new ClasseDAL();
        // extenssiation d'un objet de la classe ClasseBLL
        ClasseBLL clBLL = new ClasseBLL();
    
        private void Classe_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            // appel de la methode getFiliere pour charger les filieres existantes dans le comboxFiliere
            dt = ClDaL.getFiliere();
            // afficher les informationdans le combox filiere
            foreach (DataRow data in dt.Rows)
            {
                cmbFiliere.Items.Add(data[1]+":"+data[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLibelle.Text) || string.IsNullOrEmpty(txtNom.Text) )
            {
                MessageBox.Show(" erreur veuillez remplir tout les champs");
            }
            else
            {
                clBLL.nom = txtNom.Text;
                clBLL.niveau = Convert.ToInt32(cmbNiveau.SelectedItem);
                string val = cmbFiliere.SelectedItem.ToString();
                // separer la ligne selectionner dans le combobox sous forme de tableau a partir du caractere ":"
                string[] tab = val.Split(':');
                int id = Convert.ToInt32(tab[0]);
                clBLL.id_filiere = id;
                clBLL.libelle = txtLibelle.Text;
                try
                {
                    ClDaL.Addclasse(clBLL);
                    MessageBox.Show("Classe Ajouter avec succes");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : "+ex.Message); 
                }
                 
            }
        }
        

    }
}
