namespace SkillCheck.Tests.Intern
{
    public class ArrayTests
    {
        /*
         * Тест на поиск максимального числа в массиве:
         */

        //[Fact]
        public void Find_max_number_in_array_and_returns_max_value()
        {
            int result = ArrayHelper.Max(new int[] { 1, 5, 3, 9, 2 });
            Assert.Equal(9, result); // Ожидается 9 как максимальное число
        }

        /*
         * Тест на сортировку массива
         */

        //[Fact]
        public void Sort_array_and_returns_sorted_array()
        {
            int[] result = ArrayHelper.Sort(new int[] { 3, 1, 4, 2 });
            Assert.Equal(new int[] { 1, 2, 3, 4 }, result); // Ожидается отсортированный массив
        }
    }
}
namespace SkillCheck
{
public class ArrayHelper
{
    public static int Max(int[] array)
    {
        if (array == null) throw new ArgumentNullException("Массив не должен быть равен null");

        int max = array[0];
        for(int i =0;  i < max; i++)
        {
            if (max < array[i])
            {
                max = array[i];
            }
        }
        return max;
    }
    public static int[] Sort(int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("Массив не должен быть равен null");

            int[] sortedArray = (int[])array.Clone();
            int n = sortedArray.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = sortedArray[i];
                    int j;
                    for (j = i; j >=  gap && sortedArray[j - gap] > temp; j -= gap)
                    {
                        sortedArray[j] = sortedArray[j - gap];
                    }
                    sortedArray[j] = temp;
                }
                gap /= 2;
            }
            return sortedArray; // Возвращаем отсортированный массив
        }
    }
}
