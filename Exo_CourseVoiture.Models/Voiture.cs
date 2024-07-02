using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_CourseVoiture.Models
{
    public class Voiture
    {
        public string Marque { get; set; }
        public string Modele { get; set; }

        public double VitesseMin { get; set; }
        public double VitesseMax { get; set; }

        private double ObtenirVitesseMin(Pilote pilote)
        {
            switch (pilote.Categorie)
            {
                case PiloteCategorie.Leger:
                    return VitesseMin * 1.2;
                case PiloteCategorie.Lourd:
                    return VitesseMin * 0.8;
                default:
                    return VitesseMin;
            }
        }
        private double ObtenirVitesseMax(Pilote pilote)
        {
            switch (pilote.Categorie)
            {
                case PiloteCategorie.Leger:
                    return Math.Max(VitesseMax * 0.7, ObtenirVitesseMin(pilote));
                case PiloteCategorie.Lourd:
                    return VitesseMax * 1.5;
                default:
                    return VitesseMax;
            }
        }


        public double ObtenirVitesse(Pilote pilote)
        {
            double vitesseMin = ObtenirVitesseMin(pilote);
            double vitesseMax = ObtenirVitesseMax(pilote);
            double rng = Random.Shared.NextDouble();

            return (rng * (vitesseMax - vitesseMin)) + vitesseMin; 
        }
    }
}
