namespace SkillCheck.Tests.Intern
{
    public class MathHelper
    {
        public static bool IsEven(int x)
        {
            return x % 2 == 0;
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Factorial(int x)
        {
            if (x < 0)
                throw new ArgumentException("Факториала отрицательного числа не существует");

            int result = 1;
            for (int i = 1;  i <= x; i++)
            {
                result *= i;
            }
            return result;
        }

        // Метод деления двух чисел
        public static double Divide(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("Делить на ноль нельзя");

            return num1 / num2;
        }
    }
}
namespace SkillCheck.Tests.Intern
{
    public class MathTests
    {
        /*
         * Тест на сложение двух чисел:
         */

        //[Fact]
        public void Add_two_numbers_and_returns_sum()
        {
            int result = MathHelper.Add(2, 3);
            Assert.That(result, Is.EqualTo(5)); // Ожидаемая сумма 2 + 3 = 5
        }

        /*
         * Тест на проверку четного числа
         */

        //[Fact]
        public void Check_if_number_is_even_and_returns_true()
        {
           bool result = MathHelper.IsEven(4);
           Assert.True(result); // Ожидается true для четного числа
        }

        //[Fact]
        public void Check_if_number_is_odd_and_returns_false()
        {
            bool result = MathHelper.IsEven(5);
           Assert.False(result); // Ожидается false для нечетного числа
        }

        /*
         * Тест на факториал числа:
         */

        //[Fact]
        public void Calculate_factorial_of_number_and_returns_factorial()
        {
            int result = MathHelper.Factorial(5);
            Assert.Equal(120, result); // 5! = 120
        }

        /*
         * Тест на деление чисел:
         */

        //[Fact]
        public void Divide_two_numbers_and_returns_quotient()
        {
            double result = MathHelper.Divide(10, 2);
            Assert.Equal(5, result); // Ожидается результат 10 / 2 = 5
        }

        //[Fact]
        public void Divide_by_zero_and_throws_exception()
        {
            Assert.Throws<DivideByZeroException>(() => MathHelper.Divide(10, 0)); // Проверка на деление на ноль
        }
    }
}

