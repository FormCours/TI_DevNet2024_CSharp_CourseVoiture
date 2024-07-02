using Exo_CourseVoiture.Models;


// Création du circuit
Circuit parkingTechni = new Circuit()
{
    Nom = "Parking de Technifutur",
    Longueur = 0.866
};


// Création d'un course
Course course = new Course();
course.Initialiser("La course de \"Kart\" des .Net", parkingTechni, 10);

// Ajout des participant
Pilote p1 = new Pilote() { Nom = "Bowser", Categorie = PiloteCategorie.Lourd };
Voiture v1 = new Voiture() { Marque = "Lada", Modele = "42", VitesseMin = 35, VitesseMax = 60 };
course.AjouterParticipant("1", p1, v1);

Pilote p2 = new Pilote() { Nom = "Luigi", Categorie = PiloteCategorie.Moyen };
Voiture v2 = new Voiture() { Marque = "Lada", Modele = "42", VitesseMin = 35, VitesseMax = 60 };
course.AjouterParticipant("3", p2, v2);

Pilote p3 = new Pilote() { Nom = "Bébé Peach", Categorie = PiloteCategorie.Leger };
Voiture v3 = new Voiture() { Marque = "Porche", Modele = "911", VitesseMin = 40, VitesseMax = 70 };
course.AjouterParticipant("9", p3, v3);


// Simulation de la course...
Console.WriteLine("Début de la course !!!");
Console.ReadLine();
while (course.NbTourActuel < course.NbTourTotal)
{
    course.SimulerUnTour();

    Console.Clear();
    Console.WriteLine($"Tour {course.NbTourActuel}");
    foreach(Participant p in course.Participants)
    {
        Console.WriteLine($" - {p.Pilote.Nom} : {p.TempsTotal}s ");
    }
    Console.ReadLine();
}


// Fin de la course et remise des trophés 🏆
Participant gagnant = course.ObtenirGagnant();

Console.Clear();
Console.WriteLine($"Le gagnant de la course est... {gagnant.Pilote.Nom} avec un temps total de {gagnant.TempsTotal}");