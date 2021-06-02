using System.Collections.Generic;

namespace Task1probation
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
                    "или повторил ранее введенное слово. Введите /info после начала игры для вывода меню."},
            { "inputPlayerName", "Введите имена игроков через Enter, пожалуйста:"},
            { "inputMainWord", "Введите главное слово от 8 до 30 букв, пожалуйста:"},
            { "symbolValid", @"^[а-яё]+$"},
            { "incorrectSymbols", "Неправильный язык ввода или недопустимый символ. Попробуйте еще раз:"},
            { "invalidLenth", "Неправильная длина слова. Попробуйте еще раз:"},
            { "info", "Введите /show-words – показать все введенные обоими пользователями слова в текущей игре, /score – показать общий счет по играм \n" +
                "для текущих игроков (извлечь из файла), /total-score – показать общий счет для всех игроков."},
            {"continue", "Нажмите любую кнопку чтобы продолжить." },
            {"currentPlayerNoGames", "У текущих игроков пока нет игр. Нажмите любую кнопку чтобы продолжить."},
            {"noCompletedGames", "Пока нет завершённых игр. Нажмите любую кнопку чтобы продолжить."},
            {"playerInfo", "У игрока {0}: {1} побед, {2} поражений."},
            { "inputAnswer", "Игрок {0}, введите ваш ответ, пожалуйста." },
            { "incorrectAnswer", "Ответ не соответствует условию. Игрок {0} проиграл."},
            { "repeatingWord", "Это повторяющееся слово. Игрок {0} проиграл."}
        };

        private Dictionary<string, string> en = new Dictionary<string, string>
        {
        { "gameRules", "Hello.This is a game for two people. Rules: you must enter the first word, and then,\n" +
                "in turn, enter words consisting of the letters of the original word. The player loses if he could not \n" +
                "come up with a new word or repeated the previously entered word. Enter /info after starting the game to display the menu."},
        { "inputPlayerName", "Enter the player names from new line , please:"},
        { "inputMainWord", "Enter the main word from 8 to 30 letters, please:"},
        { "symbolValid", "^[a-z]+$" },
        { "incorrectSymbols", "Incorrect input language or invalid symbol. Try again:" },
        { "invalidLenth", "Incorrect word length. Try again:" },
        { "info", "Enter /show-words - show all words entered by both users in the current game, /score - show the total score for games \n "+
                 "for current players (extract from file), /total-score - show the total score for all players."},
        {"continue", "Press any key to continue." },
        {"currentPlayerNoGames", "The current players haven't games yet. Press any key to continue."},
        {"noCompletedGames", "No games completed yet. Press any key to continue."},
        {"playerInfo", "Player {0} has: {1} wins, {2} defeats."},
        { "inputAnswer", "player {0}, enter your answer, please." },
        { "incorrectAnswer", "Answer doesn't appropriate to condition. Player {0} lose." },
        { "repeatingWord", "This is a repeating word. Player {0} lose." }
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
