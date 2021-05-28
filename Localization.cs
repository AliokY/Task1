using System.Collections.Generic;

namespace Task1_probation
{
    class Localization
    {
        private Dictionary<string, string> messages = new Dictionary<string, string>();

        public Dictionary<string, string> Messages
        {
            get
            {
                return messages;
            }
            set
            {
                messages = value;
            }
        }

        public Localization()
        {
            Messages = messages;
        }

        private Dictionary<string, string> ru = new Dictionary<string, string>
        {
            { "gameRules", "Здравствуйте, это игра для двух человек. Правила: необходимо ввести первое слово, а затем \n" +
                    "по очереди ввести слова, состоящие из букв исходного слова. Игрок проигрывает, если не смог придумать новое слово \n" +
                    "или повторил ранее введенное слово."},
            { "inputPlayerName", "Введите имя {0} игрока, пожалуйста:"},
            { "inputMainWord", "Введите главное слово от 8 до 30 букв, пожалуйста:"},
            { "symbolValid", @"^[а-яё]+$"},
            { "incorrectSymbols", "Неправильный язык ввода или недопустимый символ. Попробуйте еще раз:"},
            { "invalidLenth", "Неправильная длина слова. Попробуйте еще раз:"},
            { "inputAnswer", "Игрок {0}, введите ваш ответ, пожалуйста" },
            { "incorrectAnswer", "Ответ не соответствует условию. Игрок {0} проиграл"},
            { "repeatingWord", "Это повторяющееся слово. Игрок {0} проиграл" }
        };

        private Dictionary<string, string> en = new Dictionary<string, string>
        {
        { "gameRules", "Hello.This is a game for two people. Rules: you must enter the first word, and then,\n" +
                "in turn, enter words consisting of the letters of the original word. The player loses if he could not \n" +
                "come up with a new word or repeated the previously entered word. Enter the main word from 8 to 30 letters, please:" },
        { "inputPlayerName", "Enter the player's {0} name , please:"},
        { "inputMainWord", "Enter the main word from 8 to 30 letters, please:"},
        { "symbolValid", "^[a-z]+$" },
        { "incorrectSymbols", "Incorrect input language or invalid symbol. Try again:" },
        { "invalidLenth", "Incorrect word length. Try again:" },
        { "inputAnswer", "player {0}, enter your answer, please" },
        { "incorrectAnswer", "Answer doesn't appropriate to condition. Player {0} lose" },
        { "repeatingWord", "This is a repeating word. Player {0} lose" }
        };
        /// <summary>
        /// sets the game language
        /// </summary>
        /// <param name="programLanguage"></param>
        internal void Localize(Language programLanguage)
        {
            messages = programLanguage == Language.en ? en : ru;
        }
        /// <summary>
        /// setting values for choosing the game language
        /// </summary>
        internal enum Language
        {
            en = 1,
            ru = 2
        }
    }
}
