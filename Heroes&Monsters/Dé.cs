namespace Heroes_Monsters
{
    public class De
    {
        private int minimum = 1;
        private int maximum;

        public De(int face)
        {
            maximum = face;
        }

        public int Lancer()
        {
            Random random = new Random();
            return random.Next(minimum, maximum + 1);
        }

        public int StackStats()
        {
            int stackStats = 0;
            int[] stacks = new int[4];
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = Lancer();
            }
            Array.Sort(stacks);
            for (int i = 1; i < stacks.Length ; i++)
            {
                stackStats += stacks[i];
            }
            return stackStats;
        }
    }
}
