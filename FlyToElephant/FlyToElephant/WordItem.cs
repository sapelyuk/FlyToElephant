namespace FlyToElephant
{
    /// <summary>
    /// Единицы цепочки слов.
    /// </summary>
    public class WordItem
    {
        /// <summary>
        /// Слово.
        /// </summary>
        public string word;
        /// <summary>
        /// Слово-родитель.
        /// </summary>
        public WordItem parent;

        public static int operator -(WordItem item1, WordItem item2)
        {
            int res = 0;
            for (int i = 0; i < item1.word.Length; i++)
            {
                if (item1.word[i] != item2.word[i]) res++;
            }
            return res;
        }
    }
}
