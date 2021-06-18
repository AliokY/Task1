using System.Collections.Generic;

namespace Task1probation
{
    class AnswerUniqueness
    {
        // result of checking uniqueness of response
        private bool _answerExists = false;

        /// <summary>
        /// checking the answer for uniqueness
        /// </summary>
        /// <param name="answerWord"></param>
        /// <param name="allAnswers">a list containing all the answers</param>
        /// <returns></returns>
        internal bool CheckUniquenessOfAnswer(string answerWord, List<string> allAnswers)
        {
            // checking the answer for uniqueness
            if (allAnswers.Contains(answerWord))
            {
                _answerExists = true;
            }
            else
            {
                // add a unique word to the dictionary
                allAnswers.Add(answerWord);
            }
            return _answerExists;
        }
    }
}
