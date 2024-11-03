public class Calculator
{
    public int Calculate(string infix)
    {
        string postfix = InfixToPostfix(infix);
        return EvaluatePostfix(postfix);
    }

    private bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
    }

    private int Precedence(char c)
    {
        if (c == '^') return 3;
        else if (c == '*' || c == '/') return 2;
        else if (c == '+' || c == '-') return 1;
        else return -1;
    }

    private string InfixToPostfix(string infix)
    {
        Stack<char> stack = new Stack<char>();
        string postfix = "";
        infix = infix.Replace(" ", ""); 

        for (int i = 0; i < infix.Length; i++)
        {
            char current = infix[i];

            if (char.IsDigit(current))
            {
                
                while (i < infix.Length && char.IsDigit(infix[i]))
                {
                    postfix += infix[i];
                    i++;
                }
                i--; 
                postfix += ' '; 
            }
            else if (current == '(')
            {
                stack.Push(current);
            }
            else if (current == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    postfix += stack.Pop() + " ";
                }
                stack.Pop(); 
            }
            else if (IsOperator(current))
            {
                while (stack.Count > 0 && Precedence(current) <= Precedence(stack.Peek()))
                {
                    if (current == '^' && Precedence(current) == Precedence(stack.Peek()))
                        break; 
                    postfix += stack.Pop() + " ";
                }
                stack.Push(current);
            }
        }

        while (stack.Count > 0)
        {
            postfix += stack.Pop() + " ";
        }

        return postfix.Trim(); 
    }

    private int EvaluatePostfix(string postfix)
    {
        Stack<int> stack = new Stack<int>();
        string[] tokens = postfix.Split(' '); 

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            else if (IsOperator(token[0]))
            {
                int right = stack.Pop();
                int left = stack.Pop();
                switch (token[0])
                {
                    case '+':
                        stack.Push(left + right);
                        break;
                    case '-':
                        stack.Push(left - right);
                        break;
                    case '*':
                        stack.Push(left * right);
                        break;
                    case '/':
                        stack.Push(left / right);
                        break;
                    case '^':
                        stack.Push((int)Math.Pow(left, right));
                        break;
                }
            }
        }

        return stack.Pop();
    }
}

namespace SkillCheck.Tests.Intern.HardLevel__required_
{
    public class CalculatorTests
    {
        /*
         * Здесь тест необходимо только раскомментировать
         */

        private readonly Calculator _calculator = new Calculator();

        [Theory]
        [InlineData("1+1", 2)]
        [InlineData("2-1", 1)]
        [InlineData("3*2", 6)]
        [InlineData("6/3", 2)]
        [InlineData("2+3*4", 14)]
        [InlineData("(2+3)*4", 20)]
        [InlineData("10/2+5", 10)]
        [InlineData("5-3*2+8/4", 1)]
        [InlineData("10*(2+3)-4/2", 48)]
        [InlineData("15-3*(2*5)/6+6", 16)]
        public void Calculate_equation_of_string_and_return_result_of_calculate(string equation, int expectedResult)
        {
            var actualResult = _calculator.Calculate(equation);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
