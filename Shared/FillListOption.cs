using AppGestionCahierDeTexte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierDeTexte.Shared
{
    public static class FillListOption
    {
        static bdCahierDeTexteContext db = new bdCahierDeTexteContext();
        public static List<ListeItem> fillAnneeAcademique()
        {
            List<ListeItem> laListe = new List<ListeItem>();
            var liste = db.AnneeAcademiques.ToList();
            laListe.Add(new ListeItem
            {
                value = null,
                Text = "Selectionner"
            });
            foreach (var t in liste)
            {
                var item = new ListeItem
                {
                    value = t.ValueAnneeAcademique.ToString(),
                    Text = t.LibelleAnneeAcademique.ToString()
                };
                laListe.Add(item);
            }
            return laListe;
        }
    }
}
