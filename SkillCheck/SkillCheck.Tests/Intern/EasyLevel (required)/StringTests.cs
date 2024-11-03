namespace SkillCheck
{
    public static class StringHelper
    {

        public static string  Reverse(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            char[] reversedArray = new char[input.Length];
            int j = 0;


            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversedArray[j] = input[i];
                j++;
            }

            return new string(reversedArray);
        }

        
        public static bool IsPalindrome(string input)
        {
            if (input ==  null) throw new ArgumentNullException(nameof(input));

            int left = 0;
            int right = input.Length - 1;

            while (left < right)
            {
                if (char.ToLower(input[left]) != char.ToLower(input[right]))
                {
                    return false; 
                }
                left++;
                right--;
            }

            return true; 
        }

        // Метод для конкатенации двух строк
        public static string Concatenate(string str1, string str2)
        {
            if (str1 == null || str2 == null) throw new ArgumentNullException("Строки не могут быть null");
            return str1 + str2;
        }
    }
}

namespace SkillCheck.Tests.Intern
{
    public class StringTests
    {
        /*
         * Тест на обратную строку:
         */

        //[Fact]
        public void Reverse_string_and_retuns_reversed_string()
        {
            string result = StringHelper.Reverse("hello");
            Assert.Equal("olleh", result); // Ожидается "olleh" для строки "hello"
        }

        /*
         * Тест на проверку палиндрома:
         */

        //[Fact]
        public void Check_if_string_is_palindrome_and_returns_true()
        {
            bool result = StringHelper.IsPalindrome("madam");
            Assert.True(result); // "madam" является палиндромом
        }

        //[Fact]
        public void Check_if_string_is_not_palindrome_and_returns_false()
        {
            bool result = StringHelper.IsPalindrome("hello");
            Assert.False(result); // "hello" не является палиндромом
        }

        /*
         * Тест на конкатенацию строк:
         */

        //[Fact]
        public void Concatenate_two_strings_and_returns_concatenated_string()
        {
            string result = StringHelper.Concatenate("Hello", "World");
            Assert.Equal("HelloWorld", result); // Ожидается "HelloWorld" без пробела
        }
    }
}
