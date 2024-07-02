using System.Collections.ObjectModel;

namespace Exo_CourseVoiture.Models
{
    public class Course
    {
        private List<Participant> _Participants = new List<Participant>();

        public string Nom { get; set; }
        public Circuit Circuit { get; set; }
        public int NbTourTotal { get; set; }
        public int NbTourActuel { get; private set; }
        public ReadOnlyCollection<Participant> Participants
        {
            get { return _Participants.AsReadOnly(); }
        }

        public void Initialiser(string nom, Circuit circuit, int nbTour)
        {
            Nom = nom;
            Circuit = circuit;
            NbTourTotal = nbTour;
        }

        public void AjouterParticipant(string numero, Pilote pilote, Voiture voiture)
        {
            // foreach (Participant p in Participants) { }

            if (_Participants.Any(p => p.Numero == numero))
            {
                throw new Exception("Numéro déjà pris :o");
            }

            Participant participant = new Participant
            {
                Numero = numero,
                Pilote = pilote,
                Voiture = voiture
            };

            _Participants.Add(participant);
        }

        public void SimulerUnTour()
        {
            if(NbTourActuel >= NbTourTotal)
            {
                throw new Exception("La course est fini...");
            }

            NbTourActuel++;

            foreach (var participant in _Participants)
            {
                participant.FaireUnTour(Circuit, NbTourActuel);
            }
        }

        public Participant ObtenirGagnant()
        {
            if(NbTourActuel < NbTourTotal)
            {
                throw new Exception("La course est po fini ! (╯°□°）╯︵ ┻━┻");
            }

            Participant gagnant = _Participants[0];
            for (int i = 1; i < _Participants.Count; i++)
            {
                if(gagnant.TempsTotal > _Participants[i].TempsTotal)
                {
                    gagnant = _Participants[i];
                }
            }
            return gagnant;
        }
    }
}
