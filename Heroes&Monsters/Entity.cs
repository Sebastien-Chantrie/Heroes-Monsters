using System.Threading.Channels;

namespace Heroes_Monsters
{
    internal struct Stats
    {
        public int endurance;
        public int force;
    }

    internal struct Inventaire
    {
        public int cuir;
        public int gold;
    }

    internal abstract class Entity
    {
        public Inventaire inventaire;
        private readonly Stats baseStats;
        private readonly Stats bonusStats;
        private readonly int pointDeVieMax;
        public int pointDeVieActuel;
        public int pointDeVieMaximum { get { return pointDeVieMax; } }

        public Entity()
        {
            De de6 = new De(6);

            inventaire = new Inventaire()
            {
                cuir = 0,
                gold = 0,
            };

            baseStats = new Stats()
            {
                endurance = de6.StackStats(),
                force = de6.StackStats()
            };

            bonusStats = GetModificateurDeStats();
            pointDeVieMax = CalculerPointDeVie();
            pointDeVieActuel = pointDeVieMax;
        }

        public abstract Stats GetModificateurDeStats();
        public virtual int CalculerPointDeVie()
        {
            return Modificator(baseStats.endurance + bonusStats.endurance);
        }
        public virtual int Modificator(int stats)
        {
            if (stats < 5) { return stats - 1; }
            else if (stats < 10) { return stats; }
            else if (stats < 15) { return stats + 1; }
            else { return stats + 2; }
        }
        public void Attaque(Entity cible)
        {
            De de4 = new De(4);
            int power = de4.Lancer() + Modificator(baseStats.force + bonusStats.force);
            cible.pointDeVieActuel -= power;
        }

        public int GetForce()
        {
            return baseStats.force + bonusStats.force;
        }
        public int GetEndurance()
        {
            return baseStats.endurance + bonusStats.endurance;
        }
        public int GetPointDeVie()
        {
            return pointDeVieMax;
        }
        public void PrintInventaire()
        {
            Console.WriteLine($"Kouir :{inventaire.cuir}, Gold{inventaire.gold}");
        }

        public virtual void PrintClassInfo()
        {

        }
        public virtual void Print()
        {
            PrintClassInfo();
            Console.WriteLine($" Endurance :{baseStats.endurance} + bonus racial: {bonusStats.endurance} ");
            Console.WriteLine($" Force :{baseStats.force} + bonus racial : {bonusStats.force} ");
            Console.WriteLine($" Vie :{pointDeVieMax} ");
        }
    }
}
