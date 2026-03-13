namespace AppGestionCahierDeTexte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Classes", "IdAnneeAcademique", "AnneeAcademiques");
            DropIndex("Classes", new[] { "IdAnneeAcademique" });
        }
        
        public override void Down()
        {
            CreateIndex("Classes", "IdAnneeAcademique");
            AddForeignKey("Classes", "IdAnneeAcademique", "AnneeAcademiques", "IdAnneeAcademique", cascadeDelete: true);
        }
    }
}
