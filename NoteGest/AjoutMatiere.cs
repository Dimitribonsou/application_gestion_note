using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace NoteGest
{
    public partial class AjoutMatiere : Form
    {
        // creation des objets de la classe Classe_matiereDAL pour acceder 
        // aux methodes getClasse et getMatiere pour charger  le combobox des matieres
        Classe_matiereDAL cl_mat = new Classe_matiereDAL();

        public AjoutMatiere()
        {
            InitializeComponent();
        }

        private void AjoutMatiere_Load(object sender, EventArgs e)
        {
            // code permettant de charger toute les classes enregistrer dans le combobox classe lors 
            //du chagement du formulaire

            DataTable dt = new DataTable();
            // appel de la methode getFiliere pour charger les filieres existantes dans le comboxFiliere
            dt = cl_mat.getClasse();
            // afficher les informationdans le combox filiere
            foreach (DataRow data in dt.Rows)
            {
                cmbClasse.Items.Add(data[1] + ":" + data[0]);
            }

            // code permettant de charger toute les matieres enregistrer dans le combobox classe lors 
            //du chagement du formulaire


            DataTable dt1 = new DataTable();
            // appel de la methode getFiliere pour charger les filieres existantes dans le comboxFiliere
            dt1 = cl_mat.getMatiere();
            // afficher les informationdans le combox filiere
            foreach (DataRow data in dt1.Rows)
            {
                cmbMatiere.Items.Add(data[1] + ":" + data[0]);
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbClasse.SelectedItem.ToString()) || string.IsNullOrEmpty(cmbMatiere.SelectedItem.ToString()))
            {
                MessageBox.Show(" erreur veuillez remplir tout les champs");
            }
            else
            {
               // creation d'un objet de la Couche BLL
                classe_matBLL clm = new classe_matBLL();

                // separer la ligne selectionner dans le combobox sous forme de tableau a partir du caractere ":"
                //on recupere l'identifiant de la classe choisie par l'utilisateur

                string val1 = cmbClasse.SelectedItem.ToString();
                string[] tab = val1.Split(':');
                int id_cl = Convert.ToInt32(tab[0]);
                clm.id_classe = id_cl;

                // on recupere l'identifiant de la matiere choisie parl'utlisateur
                string val2 = cmbMatiere.SelectedItem.ToString();
                string[] tab1 = val2.Split(':');
                int id_matiere = Convert.ToInt32(tab1[0]);
                clm.id_mat= id_matiere;
                 
                try
                {
                    cl_mat.AddMatiereToClasse(clm);
                    MessageBox.Show("Ajout de la matiere a la classe effectuer avec succes");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }

            }
        }

      
    }
}
