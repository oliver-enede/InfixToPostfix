using System;
using System.Collections.Generic;

public class InfixToPostfix
{
    public static string ConvertInfixToPostfix(string infix)
    {
        Stack<char> stack = new Stack<char>();
        string postfix = "";

        foreach (char c in infix)
        {
            if (char.IsLetterOrDigit(c))
            {
                postfix += c;
            }
            else if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                while (stack.Peek() != '(')
                {
                    postfix += stack.Pop();
                }
                stack.Pop(); // remove the '('
            }
            else
            {
                while (stack.Count > 0 && !IsLeftAssociative(stack.Peek().ToString(), c.ToString()) && !IsRightAssociative(stack.Peek().ToString(), c.ToString()))
                {
                    postfix += stack.Pop();
                }
                stack.Push(c);
            }
        }

        while (stack.Count > 0)
        {
            postfix += stack.Pop();
        }

        return postfix;
    }

    private static bool IsLeftAssociative(string op1, string op2)
    {
        if (op1 == "+" || op1 == "-" || op1 == "*" || op1 == "/" || op1 == "^")
        {
            if (op2 == "+" || op2 == "-" || op2 == "*" || op2 == "/")
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsRightAssociative(string op1, string op2)
    {
        if (op1 == "^" && op2 == "^")
        {
            return true;
        }
        return false;
    }

    public static void Main(string[] args)
    {
        string infix = "A + B * C";
        Console.WriteLine("Infix: " + infix);
        Console.WriteLine("Postfix: " + ConvertInfixToPostfix(infix));
    }
}