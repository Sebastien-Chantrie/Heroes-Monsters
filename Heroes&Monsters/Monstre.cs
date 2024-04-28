namespace Heroes_Monsters
{
    public enum TypeMonstre
    {
        Loup,
        Orc,
        Dragon
    }
    internal class Monstre : Entity
    {
        public TypeMonstre monstre { get; set; }

        public Monstre(TypeMonstre monstre) : base() 
        {
            this.monstre = monstre;
            this.inventaire = GetModificateurInventaire();
        }

        public override Stats GetModificateurDeStats()
        {
            Stats stats = new Stats();
            switch (monstre)
            {
                case TypeMonstre.Orc:
                    stats.force = 1;
                    break;
                case TypeMonstre.Dragon:
                    stats.endurance = 1;
                    break;
            }
            return stats;
        }

        private Inventaire GetModificateurInventaire()
        {
            De de4 = new De(4);
            De de6 = new De(6);
            this.monstre = monstre;
            Inventaire inventaire = new Inventaire();
            switch (monstre)
            {
                case TypeMonstre.Loup:
                    inventaire.cuir = de4.Lancer();
                    inventaire.gold = 0;
                    break;

                case TypeMonstre.Orc:
                    inventaire.gold = de6.Lancer();
                    inventaire.cuir = 0;
                    break;
                case TypeMonstre.Dragon:
                    inventaire.cuir = de4.Lancer();
                    inventaire.gold = de6.Lancer();
                    break;
            }
            return inventaire;
        }
        
        public override void Print()
        {
            Console.WriteLine($"Un monstre de type {monstre} est apparu !");
        }

    }
}
