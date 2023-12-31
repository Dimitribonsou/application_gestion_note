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
    public partial class Matiere : Form
    {
        public Matiere()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            // recuparation des valeurs saisie par l'utilisateur
            MatiereBLL mt = new MatiereBLL();
            MatiereDAL mta = new MatiereDAL();
            mt.nom = txtNom.Text;
            mt.credit =Convert.ToInt32(txtCredit.Text);
            mt.description = txtDesc.Text;

            // insertion des donnees dans la base de donnee
            try
            {
                mta.AddMatiere(mt);
                MessageBox.Show("Matiere Ajouter avec success !! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erreur : " + ex.Message);
            }
           

        }

        private void Matiere_Load(object sender, EventArgs e)
        {

        }
    }
}
