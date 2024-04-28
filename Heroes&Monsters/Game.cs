using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Heroes_Monsters
{
    internal class Game
    {
        public void run()
        {
            Heros hero = CreationPerso();
            Monstre monstre = CreationMonstre();
            while (hero.pointDeVieActuel > 0)
            {
                Combat(monstre, hero);
                if (monstre.pointDeVieActuel <= 0)
                {
                    monstre = CreationMonstre();
                }
            }
        }
        public Race ChoixRace()
        {
            int race = -5;
            bool tryconvert = false;
            while (!tryconvert)
            {
                Console.WriteLine("Bonjour, bienvenue dans l'aventure, choisisez votre race :");
                Console.WriteLine("1.Humain");
                Console.WriteLine("2.Nain");
                string? choice = Console.ReadLine();
                tryconvert = int.TryParse(choice, out race);
                if (race != 1 && race != 2) 
                {
                    tryconvert = false;
                }
            }
            race -= 1;
            return (Race)race;
        }

        public Heros CreationPerso()
        {
            Heros hero = new Heros(ChoixRace());
            hero.Print();
            return hero;
        }

        public Monstre CreationMonstre()
        {
            De de3 = new De(3);
            Monstre monstre = new Monstre((TypeMonstre)de3.Lancer() - 1);
            monstre.Print();
            return monstre;
        }

        public void Combat(Monstre cible, Heros hero)
        {
            bool _switch = true;
            while (hero.pointDeVieActuel > 0 && cible.pointDeVieActuel > 0)
            {
                if (_switch)
                {
                    hero.Attaque(cible);
                    Console.WriteLine($"Le heros attaque le monstre ! PV DU MONSTRE : {cible.pointDeVieActuel} / {cible.pointDeVieMaximum}");
                }
                else
                {
                    cible.Attaque(hero);
                    Console.WriteLine($"Le monstre attaque le heros ! PV DU HEROS : {hero.pointDeVieActuel} / {hero.pointDeVieMaximum}");
                }
                _switch = !_switch;
            }
            if (hero.pointDeVieActuel > 0)
            {
                Console.WriteLine("Le monstre a été vaincu");
                hero.RecupererInventaire(cible);
                Console.WriteLine($"Le heros dispose maintenant de {hero.inventaire.cuir} cuir et de {hero.inventaire.gold} pieces d'or");
                hero.Regen();
            }
            else
            {
                Console.WriteLine("GAME OVER NOOB");
            }
        }
    }
}
