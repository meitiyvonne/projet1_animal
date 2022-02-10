using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Projet_1_Shell
{
    class Program
    {
        List<Animal> animaux = new List<Animal>();
        private const string V = "8";
        static int id = 0;

        private void afficherMenu()
        {
            string choix = "";
            do
            {                
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("\t\t\t\t Animal pension");
                Console.WriteLine("=======================================================================================");
                Console.WriteLine("\t1 - Ajouter un animal (ID, type d’animal, son nom, son âge,\n\t\t son poids, la couleur(rouge, bleu, violet), le nom du propriétaire)");
                Console.WriteLine("\t2 - Voir la liste de tous les animaux en pension");
                Console.WriteLine("\t3 - Voir la liste de tous les propriétaires");
                Console.WriteLine("\t4 - Voir le nombre total d’animaux en pension");
                Console.WriteLine("\t5 - Voir le poids total de tous les animaux en pension");
                Console.WriteLine("\t6 - Voir la liste des animaux d’une couleur(rouge, bleu ou violet)");
                Console.WriteLine("\t7 - Retirer un animal de la liste");
                Console.WriteLine("\t8 - Quitter");
                Console.WriteLine("=======================================================================================");


                Console.Write("\tSaisir le choix (1~7, 8 pour quitter) : ");
                choix = Console.ReadLine();

                selectChoice(choix);

                switch (choix)
                {
                    case "1":
                        ajouterUnAnimal();
                        break;
                    case "2":
                        voirListeAnimauxPension();
                        break;
                    case "3":
                        voirListePropriétaire();
                        break;
                    case "4":
                        voirNombreTotalAnimaux();
                        break;
                    case "5":
                        voirPoidsTotalAnimaux();
                        break;
                    case "6":
                        extraireAnimauxSelonCouleurs();
                        break;
                    case "7":
                        retirerUnAnimalDeListe();
                        break;
                    case V:
                        Console.WriteLine("\n*** Merci d'utiliser notre servie. Au revoir. ***\n");

                        break;
                }

            } while (!(choix == V));
        }

        private void startTheMachine()
        {
            afficherMenu();
        }

        private void selectChoice(string choice)
        {

            bool b = true;
            Regex strPattern = new Regex("^[1-8]$", RegexOptions.IgnoreCase);
            b = strPattern.IsMatch(choice);
            if (!b)
            {
                afficherMessageErreur();
            }
            
        }

        private void afficherMessageErreur()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tLe choix n'est pas valide...\n");
            pageRefresh();
            afficherMenu();
        }

        /// <summary>
        /// 1- Ajouter un animal 
        /// ID, type d’animal, son nom, son âge, son poids, la couleur(rouge, bleu, violet), 
        ///     le nom du propriétaire)");
        ///     <example>
        ///         <code>
        ///             Animal animal = new Animal(type, nom, age, poids, couleur, proprietaire);
        ///         </code>
        ///     </example>
        /// </summary>
        private void ajouterUnAnimal()
        {
            int vacant = 10 - (animaux.Count);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Il a {vacant} places(s) idsponibles.\n");
            Animal animal = new Animal();
            //Console.ResetColor();
            pageRefresh();
            if ((animaux.Count) < 10)
            {
                Console.WriteLine("Veuillez saisir le type de l'animal(chien, chat...):");
                string type = Console.ReadLine();
                while (string.IsNullOrEmpty(type))
                {
                    Console.WriteLine("Veuillez saisir le type de l'animal:");
                    type = Console.ReadLine();
                }
                while ((regexString(type) == false))
                {
                    Console.WriteLine("Veuillez saisir le type de l'animal(chien, chat...):");
                    type = Console.ReadLine();
                }

                Console.WriteLine("Veuillez saisir le nom de l'animal:");
                string nom = Console.ReadLine();
                while (string.IsNullOrEmpty(nom))
                {
                    Console.WriteLine("Veuillez saisir le nom de l'animal:");
                    nom = Console.ReadLine();
                }
                while ((regexString(nom) == false))
                {
                    Console.WriteLine("Veuillez saisir le nom de l'animal:");
                    nom = Console.ReadLine();
                }
                Console.WriteLine($"\n\tReussi d'ajouter {(animaux.Count)+1}\n");

                Console.WriteLine("Veuillez saisir l'age de l'animal:");
                string age = Console.ReadLine();
                while (string.IsNullOrEmpty(age))
                {
                    Console.WriteLine("Veuillez saisir l'age de l'animal:");
                    age = Console.ReadLine();
                }
                while ((regexNoZero(age)) == false)
                {
                    Console.WriteLine("Veuillez saisir l'age de l'animal:");
                    age = Console.ReadLine();
                }
                int iAge = int.Parse(age);


                Console.WriteLine("Veuillez saisir le poids de l'animal:");
                string poids = Console.ReadLine();
                while ((string.IsNullOrEmpty(poids)))
                {
                    Console.WriteLine("Veuillez saisir le poids de l'animal:");
                    poids = Console.ReadLine();
                }
                while ((regexNoZero(poids)) == false)
                {
                    Console.WriteLine("Veuillez saisir le poids de l'animal:");
                    poids = Console.ReadLine();
                }
                int iPoids = int.Parse(poids);

                Console.WriteLine("Veuillez saisir les couleurs rouge, bleu, violet");
                string couleur = Console.ReadLine();
                while (string.IsNullOrEmpty(couleur))
                {
                    Console.WriteLine("Veuillez saisir la couleur de l'animal:");
                    couleur = Console.ReadLine();
                }
                
                while ((regexCouleur(couleur) == false))
                {
                    Console.WriteLine("Veuillez saisir les couleurs rouge, bleu, violet");
                    couleur = Console.ReadLine();
                }


                Console.WriteLine("Veuillez saisir le nom du proprietaire de l'animal:");
                string proprietaire = Console.ReadLine();
                while (string.IsNullOrEmpty(proprietaire))
                {
                    Console.WriteLine("Veuillez saisir le nom du proprietaire:");
                    proprietaire = Console.ReadLine();
                }
                while ((regexString(proprietaire) == false))
                {
                    Console.WriteLine("Veuillez saisir le nom du proprietaire:");
                    proprietaire = Console.ReadLine();
                }

                animal = new Animal(type, nom, iAge, iPoids, couleur, proprietaire);
                animal.ID = id++;
                animaux.Add(animal);

                Console.WriteLine($"\tReussi d'ajouter {animaux.Count} animal.\n");

                pageRefresh();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tDésolé, c'est complet\n");

                pageRefresh();

                afficherMenu();
            }
        }


        /// <summary>
        /// 2 - Voir la liste de tous les animaux en pension
        /// </summary>
        private void voirListeAnimauxPension()
        {

            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,-4} {1,-10} {2,15} {3,6} {4,6} {5,6} {6,15}", "ID ", "|TYPE", "|NOM ", "|AGE ", "|POIDS ", "|COULEUR ", "|PROPRIETAIRE"));
            Console.WriteLine("----------------------------------------------------------------------------");

            
            foreach (Animal a in animaux)
            {
                Console.WriteLine(a.Display());
            }
            pageRefresh();
        }

        /// <summary>
        /// 3 - Voir la liste de tous les propriétaires
        /// </summary>
        private void voirListePropriétaire()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,15}", "| PROPRIETAIRE |"));
            Console.WriteLine("----------------------------------------------------------------------------");

            foreach (Animal a in animaux)
            {
                Console.WriteLine("  "+a.Proprietaire);
            }
            pageRefresh();
        }

        /// <summary>
        /// 4 - Voir le nombre total d’animaux en pension
        /// </summary>
        private void voirNombreTotalAnimaux()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,15}", "| NOMBRE ANIMAUX |"));
            Console.WriteLine("----------------------------------------------------------------------------");

            Console.WriteLine("  "+animaux.Count);
            pageRefresh();

        }

        /// <summary>
        /// 5 - Voir le poids total de tous les animaux en pension
        /// </summary>
        private void voirPoidsTotalAnimaux()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,15}", "| POIDS TOTAL |"));
            Console.WriteLine("----------------------------------------------------------------------------");

            int som = 0;
            for (int i = 0; i < animaux.Count; i++)
            {
                som += animaux[i].Poids;
            }
            Console.WriteLine("  "+som);
            pageRefresh();
        }

        /// <summary>
        /// 6 - Voir la liste des animaux d’une couleur(rouge, bleu ou violet)");
        /// </summary>
        private void extraireAnimauxSelonCouleurs()
        {
            Console.WriteLine("VEUILLEZ SAISIR LA COULEUR DE RECHERCHE: ");
            string tempCouleur = Console.ReadLine();
            List<Animal> extraireCouleur = new List<Animal>();

            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,-4} {1,-10} {2,20} {3,8}", "ID |", "  TYPE  |", "   NOM   |", " COULEUR |"));
            Console.WriteLine("----------------------------------------------------------------------------");

            IEnumerable<Animal> queryCouleur = from animal in animaux where animal.Couleur == tempCouleur select animal;
            
            foreach (Animal an in queryCouleur)
            {
                Console.WriteLine(an.DisplayCouleur() + "\n");
                
            }
            if (queryCouleur.Count() == 0)
            {
                Console.WriteLine("Il n'y a pas cette couleur d'animal");
                pageRefresh();
            }
            pageRefresh();

        }

        /// <summary>
        /// 7 - Retirer un animal de la liste
        /// </summary>
        private void retirerUnAnimalDeListe()
        {
            Console.WriteLine("VEUILLEZ SAISIR LE ID DE L'ANIMAL:");
            string animalId = Console.ReadLine();
            int id = 0;
            id = int.Parse(animalId);
            //bool b = regexString(animalId).Equals(animalId) ? true : false;
            //Console.WriteLine($"b: {b}");
            //bool b=true;
            //if (!b)
            //{ 
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0,-4} {1,-10} {2,20} {3,5} {4,5} {5,8} {6,20}"
                , "ID ", "|TYPE", "|NOM ", "|AGE ", "|POIDS ", "|COULEUR ", "|PROPRIETAIRE"));
                Console.WriteLine("----------------------------------------------------------------------------");

                for (int i = 0; i < animaux.Count; i++)
                {
                    if (animaux[i].ID == id)
                    {
                        Console.WriteLine(String.Format("{0,-4} {1,-10} {2,20} {3,5} {4,5} {5,8} {6,20}", animalId, animaux[i].Type, animaux[i].Nom, animaux[i].Age, animaux[i].Poids, animaux[i].Couleur, animaux[i].Proprietaire));
                        traiterAjoutAnimal(i);
                    }
                }
            //}
                        
        }

        private void traiterAjoutAnimal(int i)
        {

            if (animaux.Contains(animaux[i]))
            {
                //Console.WriteLine("\tça va faire le soin\t\n" + animaux[i].Display() + "\n");
                //Console.WriteLine(animaux[i].Display() + "\n");

                animaux.RemoveAt(i);
                pageRefresh();
            }
            else
            {
                Console.WriteLine("\tIl/Elle est guéri(e).\n");
                pageRefresh();
            }

        }

        /// <summary>
        /// -- Réinitialiser la couleur de la police
        /// -- Rafraîchir la page et entrer dans le menu principal
        /// </summary>
        private void pageRefresh()
        {
            Console.ResetColor();

            Console.WriteLine("(Entrez pour aller au menu principal)");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// verifier le string entrée
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool regexString(string str)
        {
            bool b;
            Regex strPattern = new Regex("^[A-Za-z]+$", RegexOptions.IgnoreCase);
            b = strPattern.IsMatch(str);
            if (!b)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("saisir le string, SVP");
                Console.ResetColor();
                //b = false;
                //return b;
            }

            return b;
        }

        /// <summary>
        /// L'âge et le poids, il ne faut pas être Zero
        /// </summary>
        /// <param name="nombre"></param>
        private bool regexNoZero(string nombre)
        {
            bool b;
            Regex zeroRegex = new Regex("^[1-9]$|(^[1-9][0-9])$|(^[1-9][0-9][0-9])$", RegexOptions.IgnoreCase);
            b = zeroRegex.IsMatch(nombre);
            if (!b)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Il est compris entre 1 et 999, SVP");
                Console.ResetColor();
                //nombre = Console.ReadLine();
                //b = false;
                //return b;

            }
            return b;
        }


        /// <summary>
        /// vérifier la couleur entrée 
        /// </summary>
        private bool regexCouleur(string color)
        {
            bool b;
            Regex pattern = new Regex("rouge|bleu|violet$", RegexOptions.IgnoreCase);
            
            b = pattern.IsMatch(color);
            if (!b)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Est-ce que ces informations sont valides? [O ou N]");
                Console.ResetColor();
                //color = Console.ReadLine();
                string yorn = Console.ReadLine();
                if(yorn.Equals("o")|| yorn.Equals("O"))
                {
                    b = false;
                    return b;
                }
                
            }
            return b;
        }


        //string[,] tableau = new string[10, 7];
        static void Main(string[] args)
        {
            Program program = new Program();
            program.startTheMachine();
        }
    }
}
