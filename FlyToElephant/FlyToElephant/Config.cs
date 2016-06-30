using System;
using System.Linq;
using System.Text;
using System.IO;

namespace FlyToElephant
{
    /// <summary>
    /// Конфигурация поиска пути между словами.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Первое слово цепочки.
        /// </summary>
        public const string FirstWord = "слон";
        /// <summary>
        /// Второе слово цепочки.
        /// </summary>
        public const string SecondWord = "муха";

        /// <summary>
        /// Длина слов цепочки.
        /// </summary>
        public static int WordLength
        {
            get
            {
                if (FirstWord.Length != SecondWord.Length) throw new ArgumentException("Слова имеют разную длину, цепочка невозможна.");
                if (FirstWord == SecondWord) throw new ArgumentException("Слова одинаковы.");
                else return FirstWord.Length;
            }
        }
    }
}
