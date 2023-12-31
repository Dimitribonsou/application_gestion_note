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
using System.Data.SqlClient;
using System.Configuration;

namespace NoteGest
{
    public partial class Filiere : Form
    {
       

        public Filiere()
        {
            InitializeComponent();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                 

            // recuparation des valeurs saisie par l'utilisateur
            FiliereBLL fl = new FiliereBLL();
            FiliereDAL fla = new FiliereDAL();
            fl.nom = txtNom.Text;
            fl.libelle = txtLibelle.Text;
            fl.description = txtDesc.Text;

            // insertion des donnees dans la base de donnee
            try
            {
                fla.AddFiliere(fl);
                MessageBox.Show("Filiere Ajouter avec success !! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erreur : "+ex.Message); 
            }
           

        }

        private void Filiere_Load(object sender, EventArgs e)
        {

        }
    }
}
