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
    public partial class Etudiant : Form
    {
        EtudiantBLL etd = new EtudiantBLL();
        EtudiantDAL etda = new EtudiantDAL();
        public Etudiant()
        {
            InitializeComponent();
        }

        private void Etudiant_Load(object sender, EventArgs e)
        {
            // code permettant de charger toute les classes enregistrer dans le combobox classe lors 
            //du chagement du formulaire

            DataTable dt = new DataTable();
            // appel de la methode getFiliere pour charger les filieres existantes dans le comboxFiliere
            dt = etda.getClasse();
            // afficher les informationdans le combox filiere
            foreach (DataRow data in dt.Rows)
            {
                cmbClasse.Items.Add(data[1] + ":" + data[0]);
            }
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text) || string.IsNullOrEmpty(cmbClasse.SelectedItem.ToString()))
            {
                MessageBox.Show(" erreur veuillez remplir tout les champs");
            }
            else
            {
                etd.nom = txtNom.Text;
                string val = cmbClasse.SelectedItem.ToString();
                // separer la ligne selectionner dans le combobox sous forme de tableau a partir du caractere ":"
                string[] tab = val.Split(':');
                int id = Convert.ToInt32(tab[0]);

                etd.id_classe= id;
                etd.prenom = txtPrenom.Text;
                etd.date_nais = dtpDate.Value;
                try
                {
                    etda.AddEtudiant(etd);
                    MessageBox.Show("Etudiant Ajouter avec succes");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
                loadData();
                ClearFrom();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text) )
            {
                MessageBox.Show(" veuillez selectionner la ligne a modifier");
            }
            else
            {
                try
                {
                    // on recupere l'identifant de l'etudiant selectionner dans le datagridView
                    etd.id_etudiant = Convert.ToInt32(dgvEtudiant.SelectedRows[0].Cells[0].Value);
                    etd.nom = txtNom.Text;
                    string val = cmbClasse.SelectedItem.ToString();
                    // separer la ligne selectionner dans le combobox sous forme de tableau a partir du caractere ":"
                    string[] tab = val.Split(':');
                    int id = Convert.ToInt32(tab[0]);

                    etd.id_classe = id;
                    etd.prenom = txtPrenom.Text;
                    etd.date_nais = dtpDate.Value;
                    try
                    {
                        etda.UpdateEtudiant(etd);
                        MessageBox.Show("Etudiant Modifier avec succes");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                    loadData();
                    ClearFrom();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message); ;
                }

            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text) )
            {
                MessageBox.Show(" veuillez selectionner la ligne a supprimer");
            }
            else
            {
                // on recupere l'identifant de l'etudiant selectionner dans le datagridView
                int id_etudiant = Convert.ToInt32(dgvEtudiant.SelectedRows[0].Cells[0].Value);
                try
                {
                    etda.deleteEtudiant(id_etudiant );
                    MessageBox.Show("Etudiant Supprimer avec succes");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
                loadData();
                ClearFrom();
            }
        }

        //methode permettant de remplir le datagridView lors du chargement de la page
        private void loadData()
        {
            DataTable dt = new DataTable();
            dt = etda.getEtudiant();
            dgvEtudiant.DataSource = dt;
        }
        //methode permettant d'effacer tout les champs apres avoir effectuer une action
        private void ClearFrom()
        {
            txtPrenom.Text = string.Empty;
            txtNom.Text = string.Empty;
            cmbClasse.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
        }

        private void dgvEtudiant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNom.Text = dgvEtudiant.CurrentRow.Cells[1].Value.ToString();
            txtPrenom.Text = dgvEtudiant.CurrentRow.Cells[2].Value.ToString();
            dtpDate.Value = Convert.ToDateTime(dgvEtudiant.CurrentRow.Cells[3].Value);
            cmbClasse.SelectedItem = dgvEtudiant.CurrentRow.Cells[4].Value;
            
        }

        
    }
}
