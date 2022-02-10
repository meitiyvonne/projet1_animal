using System;

namespace Projet_1_Shell
{
    class Animal
    {


        public Animal()
        { }

        public Animal(string type, string nom, int age, int poids, string couleur, string proprietaire)
        {
            
            this.Type = type;
            this.Nom = nom;
            this.Age = age;
            this.Poids = poids;
            this.Couleur = couleur;
            this.Proprietaire = proprietaire;
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
        public int Poids { get; set; }
        public string Couleur { get; set; }
        public string Proprietaire { get; set; }


        public string Display()
        {

            return string.Format("{0,4} {1,-10} {2,20} {3,5} {4,5} {5,8} {6,20}", this.ID, this.Type, this.Nom, this.Age, this.Poids, this.Couleur, this.Proprietaire);
        }

        public string DisplayCouleur()
        {

            return string.Format("{0,4} {1,-10} {2,20} {3,8}", this.ID, this.Type, this.Nom, this.Couleur);
        }

    }
}
