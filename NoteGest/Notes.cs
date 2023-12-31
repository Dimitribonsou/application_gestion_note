using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace NoteGest
{
    public partial class Notes : Form
    {
        NoteBLL nt = new NoteBLL();
        NoteDAL nta = new NoteDAL();
        public Notes()
        {
            InitializeComponent();
        }

        private void Notes_Load(object sender, EventArgs e)
        {
            // charger le combobox des matiere
            DataTable dt = new DataTable();
            // appel de la methode getFiliere pour charger les filieres existantes dans le comboxFiliere
            dt = nta.getMatiere();
            // afficher les informationdans le combox filiere
            foreach (DataRow data in dt.Rows)
            {
                cmbMatiere.Items.Add(data[1] + ":" + data[0]);
            }

            // charger le combobox des classes
            DataTable dt1 = new DataTable();
            // appel de la methode getFiliere pour charger les filieres existantes dans le comboxFiliere
            dt1 = nta.getClasse();
            // afficher les informationdans le combox filiere
            foreach (DataRow data in dt1.Rows)
            {
                cmbClasse.Items.Add(data[1] + ":" + data[0]);
            }
        }

        private void cmbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEtudiant.Items.Clear();
            // charger le combobox des Etudiants
            DataTable dt2 = new DataTable();
            // appel de la methode getFiliere pour charger les filieres existantes dans le comboxFiliere
            string val = cmbClasse.SelectedItem.ToString();
            //la methode split permet de diviser la chaine de caractere en deux partie a partir du caractere : 
            string [] tab = val.Split(':');
            int id_classe = Convert.ToInt32(tab[0]);
            dt2 = nta.getEtudiant(id_classe);
            // afficher les informationdans le combox filiere
            foreach (DataRow data in dt2.Rows)
            {
                cmbEtudiant.Items.Add(data[1] + ":" + data[0] + " " + data[2]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbClasse.SelectedItem.ToString()) || string.IsNullOrEmpty(cmbMatiere.SelectedItem.ToString()) || string.IsNullOrEmpty(cmbEtudiant.SelectedItem.ToString()))
            {
                MessageBox.Show(" erreur veuillez remplir tout les champs");
            }
            else
            {

                // separer la ligne selectionner dans le combobox sous forme de tableau a partir du caractere ":"
                //on recupere l'identifiant de la matiere choisie par l'utilisateur

                string val1 = cmbMatiere.SelectedItem.ToString();
                string[] tab = val1.Split(':');
                int id_matiere = Convert.ToInt32(tab[0]);
                nt.id_mat = id_matiere;

                // on recupere l'identifiant de l'etudiant choisie par l'utlisateur
                string val2 = cmbEtudiant.SelectedItem.ToString();
                string[] tab1 = val2.Split(':');
                int id_etudiant= Convert.ToInt32(tab1[0]);
                nt.id_Etudiant = id_etudiant;

                //on recupere la valeur de la note
                nt.valeur = float.Parse(txtNote.Text);
                try
                {
                    //insertion de la note dans la bd
                    nta.AddNote(nt);
                    MessageBox.Show("Note enregistrer avec succes");

                    clearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }
        private void clearForm()
        {
            txtNote.Text = string.Empty;
            cmbClasse.SelectedIndex = -1;
            cmbEtudiant.SelectedIndex = -1;
            cmbMatiere.SelectedIndex = -1;
        }
    }
}
