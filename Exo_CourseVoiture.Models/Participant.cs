using System.Collections.ObjectModel;

namespace Exo_CourseVoiture.Models
{
    public class Participant
    {
        private Dictionary<int, double> _TempsTours = new Dictionary<int, double>();

        public string Numero { get; set; }
        public Voiture Voiture { get; set; }
        public Pilote Pilote { get; set; }
        public ReadOnlyDictionary<int, double> TempsTours
        {
            // La méthode « AsReadOnly » renvoi le dico en lecteur seul
            // Sans cela, il serait possible d'utiliser les méthodes "Add", "Clear", ...
            get { return _TempsTours.AsReadOnly(); }
        }
        public double TempsTotal { get; private set; }

        public void FaireUnTour(Circuit circuit, int nbTour)
        {
            double vitesse = Voiture.ObtenirVitesse(Pilote);

            // Longeur: km, vitesse: km/h => Longeur/vitesse: h  => h * 3600 : s
            double temps = Math.Round((circuit.Longueur / vitesse) * 3600, 2);

            _TempsTours.Add(nbTour, temps);
            TempsTotal = Math.Round(TempsTotal + temps, 2);
        }
    }
}
