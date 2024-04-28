namespace Heroes_Monsters
{
    public enum Race
    {
        Humain,
        Nain
    }
    internal class Heros : Entity
    {
        public Race race { get; set; }
        public Heros(Race race) : base() {  this.race = race; }



        public override Stats GetModificateurDeStats()
        {
            this.race = race;
            Stats stats = new Stats();
            switch (race)
            {
                case Race.Humain:
                    stats.force = 1;
                    stats.endurance = 1;
                    break;
                    
                case Race.Nain:
                    stats.force = 0;
                    stats.endurance = 2;
                    break;
                    
            }
            return stats;
        }
        public void RecupererInventaire(Monstre cible)
        {
            inventaire.cuir += cible.inventaire.cuir;
            inventaire.gold += cible.inventaire.gold;
        }

        public override void PrintClassInfo()
        {
            Console.WriteLine($"Votre personnage de race {race}");
        }

        public void Regen()
        {
            pointDeVieActuel = pointDeVieMaximum;
        }
    }
}