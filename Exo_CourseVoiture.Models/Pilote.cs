
namespace Exo_CourseVoiture.Models
{
    public enum PiloteCategorie
    {
        Leger,
        Moyen,
        Lourd
    }

    public class Pilote
    {
        public string Nom { get; set; }
        public PiloteCategorie Categorie { get; set; }
    }
}
