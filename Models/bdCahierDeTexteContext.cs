using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierDeTexte.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class bdCahierDeTexteContext : DbContext
    {
        public bdCahierDeTexteContext() : base("connCahierDeTexte")
        {
        }
        public DbSet<Matiere> Matiere { get; set; }
        public DbSet<AnneeAcademique> AnneeAcademiques { get; set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Syllabus> Syllabus { get; set; }
        public DbSet<DetailsSyllabus> DetailsSyllabus { get; set; }
        public DbSet<Professeur> Professeurs { get;set; }
        public DbSet<ResponsableClasse> ResponsableClasses { get; set; }
        public DbSet<CahierTexte> CahierTextes { get; set; }
    }
}
