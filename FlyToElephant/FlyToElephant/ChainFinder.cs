using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyToElephant
{
    /// <summary>
    /// Класс, который ищет цепочку слов.
    /// </summary>
    public class ChainFinder
    {
        /// <summary>
        /// Все слова.
        /// </summary>
        IEnumerable<WordItem> items = Dictionary.Words.Distinct().Select(s => new WordItem() { word = s }).ToArray();
        /// <summary>
        /// Начальное слово цепочки.
        /// </summary>
        public WordItem firstWord;
        /// <summary>
        /// Конечное слово цепочки.
        /// </summary>
        public WordItem secondWord;

        /// <summary>
        /// Создать поисковик цепочки.
        /// </summary>
        public ChainFinder()
        {
            // Найдем слово-начало и слово-конец
            firstWord = items.Where(f => f.word.Equals(Config.FirstWord)).FirstOrDefault();
            secondWord = items.Where(f => f.word.Equals(Config.SecondWord)).FirstOrDefault();
            firstWord.parent = firstWord; // Чтобы считалось, что у этого слова есть родители
            if (firstWord == null || secondWord == null) throw new ArgumentException("Одно из слов не найдено в словаре.");
        }

        /// <summary>
        /// Класс, получающий следующее поколение слов, соседних с данным.
        /// </summary>
        /// <param name="word">Слово.</param>
        /// <returns>Соседи слова.</returns>
        public IEnumerable<WordItem> Step(WordItem item)
        {
            var neighbours = items.Where(s => (s - item) == 1 // На расстоянии 1
                && s.parent == null).ToArray(); //И еще не посчитаны
            foreach (var n in neighbours) n.parent = item; // Установим родителя
            return neighbours;
        }

        /// <summary>
        /// Запустить поиск.
        /// </summary>
        public void FindAllWords()
        {
            IEnumerable<WordItem> generation = new WordItem[] { firstWord }; // Первое поколение
            while (true)
            {
                generation = generation.SelectMany(m => Step(m)).ToArray(); // Получим следующее поколение
                //Console.WriteLine(generation.Count());
                if (generation.Count() == 0) throw new Exception("Цепочка не найдена.");
                var endWord = generation.Where(w => w == secondWord).FirstOrDefault(); // Поищем, нет ли финального слова
                if (endWord != null) // Нашли последнее слово
                {
                    int i = 0; // Итератор длинны цепочки
                    while (true) // Выведем цепочку
                    {
                        WordItem parent = endWord.parent;
                        Console.WriteLine(endWord.word);
                        i++;
                        if (parent == endWord) // дошли до первого слова
                        {
                            Console.WriteLine("Длинна цепочки: {0}",i);
                            break; 
                        }
                        endWord = parent;
                    }
                    break;
                }
            }
        }
    }
   
}
