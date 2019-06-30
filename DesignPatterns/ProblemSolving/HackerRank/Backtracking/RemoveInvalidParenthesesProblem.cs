using System.Collections.Generic;

namespace ProblemSolving.HackerRank.Backtracking
{
    //https://www.geeksforgeeks.org/remove-invalid-parentheses/
    public class RemoveInvalidParenthesesProblem
    {
        private bool IsParanthesis(char c)
        {
            return c == '(' || c == ')';
        }

        public bool IsBalancedString(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char current = str[i];
                if (current == '(')
                {
                    count++;
                }
                else if (current == ')')
                {
                    count--;
                }
                if (count < 0)
                {
                    return false;
                }
            }
            return count == 0;
        }

        public List<string> RemoveInvalidParantheses(string str)
        {
            int maxLen = 0;
            if (string.IsNullOrEmpty(str))
            {
                return new List<string>();
            }

            List<string> results = new List<string>();
            List<string> visited = new List<string>();
            Queue<string> processingNodes = new Queue<string>();

            processingNodes.Enqueue(str);
            visited.Add(str);

            while (processingNodes.Count != 0)
            {
                bool isFound = false;
                string stringToProcess = processingNodes.Dequeue();
                if (IsBalancedString(stringToProcess))
                {
                    isFound = true;
                    if (!results.Contains(stringToProcess) && stringToProcess.Length >= maxLen)
                    {
                        maxLen = stringToProcess.Length;
                        results.Add(stringToProcess);
                    }
                }

                if (isFound)
                {
                    continue;
                }

                for (int i = 0; i < stringToProcess.Length; i++)
                {
                    char current = stringToProcess[i];
                    // If not paranthesis.
                    if (!IsParanthesis(current))
                    {
                        continue;
                    }

                    string subString = stringToProcess.Substring(0, i) + stringToProcess.Substring(i + 1);
                    if (!visited.Contains(subString) && !string.IsNullOrEmpty(subString))
                    {
                        processingNodes.Enqueue(subString);
                        visited.Add(subString);
                    }
                }
            }

            return results;
        }
    }
}
