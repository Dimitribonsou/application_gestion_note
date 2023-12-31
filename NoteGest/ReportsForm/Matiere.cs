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
using CrystalDecisions.CrystalReports.Engine;


namespace NoteGest.ReportsForm
{
    public partial class Matiere : Form
    {
        ReportDocument rpt = new ReportDocument();
        EtudiantDAL etd = new EtudiantDAL();
        public Matiere()
        {
            InitializeComponent();
        }

        private void Matiere_Load(object sender, EventArgs e)
        {
            rpt.Load(@"D:\Csharp avance\Multicouche TI-PAM2\NoteGest\NoteGest\Reports\Matiere.rpt");
            //DataTable dt = etd.getEtudiant();
            DataTable dt = etd.getMatiere();
            rpt.SetDataSource(dt);
            //string Classe =
            // afficher les classe en fonction de l'id
            //rpt.SetParameterValue("@classe", );

            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
