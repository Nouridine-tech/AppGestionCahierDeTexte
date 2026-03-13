using AppGestionCahierDeTexte.Models;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionCahierDeTexte.View.Parametre
{
    public partial class frmClasse : Form
    {
        bdCahierDeTexteContext db = new bdCahierDeTexteContext();
        private void Effacer()
        {
            txtLibelle.Text = string.Empty;
            //cbbAnneeAcademique.Text = string.Empty;
            cbbAnneeAcademique.DataSource = Shared.FillListOption.fillAnneeAcademique();
            cbbAnneeAcademique.DisplayMember = "Text";
            cbbAnneeAcademique.ValueMember = "value";
            DgClasse.DataSource = db.Classe.ToList();
            txtLibelle.Focus();
        }
        public frmClasse()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Classe c = new Classe();
            c.LibelleClasse = txtLibelle.Text;
            c.IdAnneeAcademique = int.Parse(cbbAnneeAcademique.SelectedValue.ToString());
            db.Classe.Add(c);
            db.SaveChanges();
            Effacer();
        }

        private void frmClasse_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(DgClasse.CurrentRow.Cells[0].Value.ToString());
            var c = db.Classe.Find(Id);
            c.LibelleClasse = txtLibelle.Text;
            c.IdAnneeAcademique = int.Parse(cbbAnneeAcademique.SelectedValue.ToString());
            db.SaveChanges();
            Effacer();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(DgClasse.CurrentRow.Cells[0].Value.ToString());
            var c = db.Classe.Find(Id);
            db.Classe.Remove(c);
            db.SaveChanges();
            Effacer();
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            txtLibelle.Text = DgClasse.CurrentRow.Cells[1].Value.ToString();
            cbbAnneeAcademique.SelectedValue = DgClasse.CurrentRow.Cells[2].Value;
        }

        private void btnrecherche_Click(object sender, EventArgs e)
        {
            var liste = db.Classe.ToList();
            if (!String.IsNullOrEmpty(txtRAnee.Text)) 
            {
                int? annee = int.Parse(txtRAnee.Text);
                liste = liste.Where(c => c.IdAnneeAcademique==annee).ToList();
            }
            if (!String.IsNullOrEmpty(txtRClasse.Text))
            {
                liste = liste.Where(f => f.LibelleClasse.ToUpper().Contains(txtRClasse.Text.ToUpper())).ToList();
            }
            DgClasse.DataSource = liste.Take(100);
        }
    }
}