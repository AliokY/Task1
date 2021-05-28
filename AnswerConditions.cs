namespace Task1_probation
{
    class AnswerConditions
    {
        /// <summary>
        /// checking the answer for compliance to condition
        /// </summary>
        /// <param name="motherWord">the main first word</param>
        /// <param name="answerWord">player response</param>
        /// <returns>checking result</returns>
        internal bool CheckAnswerToConditions(string motherWord, string answerWord)
        {
            // result of symbols matching
            bool _answerIsValid = true;

            // checking for the presence of characters in the response with the main word. Given the quantity
            for (int i = 0; i < answerWord.Length; i++)
            {
                var symbol = answerWord[i].ToString();

                // returns the index of the first occurrence of the character in the main word, if it does not exist - returns -1
                var index = motherWord.IndexOf(symbol);

                if (index == -1)
                {
                    _answerIsValid = false;

                    break;
                }
                else
                {
                    // removes a character from the base word if it matches
                    motherWord = motherWord.Remove(index, 1);
                }
            }
            return _answerIsValid;
        }
    }
}
