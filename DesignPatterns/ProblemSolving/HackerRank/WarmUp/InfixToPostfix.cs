using System.Collections.Generic;

namespace ProblemSolving.HackerRank.WarmUp
{
    public class InfixToPostfix
    {
        public static string GetPostfix(string infix)
        {
            Stack<char> operatorStack = new Stack<char>();
            string postFix = string.Empty;
            if (string.IsNullOrEmpty(infix))
            {
                return string.Empty;
            }

            int totalChars = infix.Length;
            for (int i = 0; i < totalChars; i++)
            {
                char currentChar = infix[i];
                if (IsOperator(currentChar))
                {
                    if (currentChar == ')')
                    {
                        if (operatorStack.Count == 0)
                        {
                            return "Invalid Infix Pattern.";
                        }
                        // pop till we find (
                        while (operatorStack.Count > 0)
                        {
                            char lastOperator = operatorStack.Pop();
                            if (lastOperator == '(')
                            {
                                break;
                            }
                            postFix += lastOperator;
                        }
                    }
                    else
                    {
                        operatorStack.Push(currentChar);
                    }
                }
                else
                {
                    postFix += currentChar;
                }
            }
            while (operatorStack.Count > 0)
            {
                postFix += operatorStack.Pop();
            }
            return postFix;
        }

        public static bool IsOperator(char c)
        {
            string chars = "()*^/+-";
            return chars.Contains(c.ToString());
        }
    }
}