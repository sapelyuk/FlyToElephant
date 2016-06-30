using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FlyToElephant
{
    /// <summary>
    /// Набор слов
    /// </summary>
    public static class Dictionary
    {
        /// <summary>
        /// Все слова словаря.
        /// </summary>
        public static IEnumerable<string> Words
        {
            get
            {
                int length = Config.WordLength;
                string path = @"C:\Users\yaroslav\Documents\GitHub\FlyToElephant\FlyToElephant\FlyToElephant\dictionary.txt";
                using (TextReader file = new StreamReader(path, Encoding.GetEncoding(1251)))
                {
                    while (true)
                    {
                        var word = file.ReadLine();
                        if (word == null) break; // конец файла
                        word = word.Split(' ')[0].ToLower().Trim().Replace('ё', 'е');
                        if (word.Length == length
                        && !WrongWords.Contains(word)) yield return word; // нашли слово нужной длины
                    }
                }
            }
        }

        /// <summary>
        /// Список слов, которые не считаются существительными.
        /// </summary>
        static string[] WrongWords = new string[] {
        "плат",
        "трот",
        "арат",
        "мара",
        "саек",
        "парс",
        "кафр",
        "рака",
        "ради",
        "кущи",
        "кали",
        "кади",
        "каик",
        "каин",
        "дать",
        "дуть",
        "буки",
        "баки",
        "паки",
        "пали",
        "паль",
        "кадь",
        "корн",
        "терн",
        "теин",
        "твин",
        "сван",
        "вено",
        "веди",
        "веды",
        "пера",
        "поят",
        "коем",
        "тает",
        "трет",
        "фаут",
        "слов",
        "клот",
        "дара",
        "паск",
        "плав",
        };
    }
}
