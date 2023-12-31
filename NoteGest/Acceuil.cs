using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteGest
{
    public partial class Acceuil : Form
    {
        public Acceuil()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void etudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Etudiant etd = new Etudiant();
            etd.MdiParent = this;
            etd.FormBorderStyle = FormBorderStyle.None;
            etd.Dock = DockStyle.Fill;
            etd.Show();
            
        }

        private void classeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classe cl = new Classe();
            cl.MdiParent = this;
            cl.FormBorderStyle = FormBorderStyle.None;
            cl.Dock = DockStyle.Fill;
            cl.Show();
        }

        private void matiereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matiere mat= new Matiere();
            mat.MdiParent = this;
            mat.FormBorderStyle = FormBorderStyle.None;
            mat.Dock = DockStyle.Fill;
            mat.Show();
        }

        private void filiereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filiere fil = new Filiere();
            fil.MdiParent = this;
            fil.FormBorderStyle = FormBorderStyle.None;
            fil.Dock = DockStyle.Fill;
            fil.Show();
        }

        private void noteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notes nt = new Notes();
            nt.MdiParent = this;
            nt.FormBorderStyle = FormBorderStyle.None;
            nt.Dock = DockStyle.Fill;
            nt.Show();
        }

        private void rapportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjoutMatiere nt = new AjoutMatiere();
            nt.MdiParent = this;
            nt.FormBorderStyle = FormBorderStyle.None;
            nt.Dock = DockStyle.Fill;
            nt.Show();
        }

        private void listesDesEtudiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsForm.EtudiantRPT etdForm = new ReportsForm.EtudiantRPT();
            etdForm.MdiParent = this;
            etdForm.FormBorderStyle = FormBorderStyle.None;
            etdForm.Dock = DockStyle.Fill;
            etdForm.Show();
        }

        private void listesDesNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsForm.Matiere etdForm = new ReportsForm.Matiere();
            etdForm.MdiParent = this;
            etdForm.FormBorderStyle = FormBorderStyle.None;
            etdForm.Dock = DockStyle.Fill;
            etdForm.Show();
        }
    }
}
