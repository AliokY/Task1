using System;

namespace Task1_probation
{
    class AnswersReceiver
    {
        internal string InputAnswer()
        {
            //_inputTimer.Start();

            string answer = Console.ReadLine().ToLower();

            //_inputTimer.Stop();

            return answer;
        }
    }
}
