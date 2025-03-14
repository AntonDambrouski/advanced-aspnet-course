  /*
   * 
   * Ошибка в строке 57 и 61
   * 1 элемент под индексом 0 не участвует в сравнении элементов
   * 
   */

const int NumsCount = 10;
int[] nums = new int[NumsCount]; // Создали массив размера 10
// rand initializations
Input(nums);

//sort
SelectionSort(nums);

if (!CheckSortResults(nums))
{
  Console.WriteLine("Array is unsorted!");
}

// output
Console.WriteLine("Array:");
Output(nums);

bool CheckSortResults(int[] nums) //Проверка работает верно
{
  for (int i = 1; i < nums.Length; i++)
  {
    if (nums[i - 1] > nums[i])
    {
      return false;
    }
  }

  return true;
}

void Output(int[] nums) //вывод массива работает верно
{
  for (int i = 0; i < nums.Length; i++)
  {
    Console.WriteLine(nums[i]);
  }
}

void Input(int[] nums)
{
  Random random = new Random();
  for (int i = 0; i < nums.Length; i++)
  {
    nums[i] = random.Next(0, 100);
  }
} //Верно

void SelectionSort(int[] nums)
{
  for (var i = nums.Length - 1; i >= 0; i--) 
  {
    var maxIndex = i; 
    int j;
    for (j = i - 1; j >= 0; --j) //Ищем индекс самого большого числа и помещаем его в конец массива
    {
      if (nums[j] > nums[maxIndex])
      {
        maxIndex = j;
      }
    }

    if (i != maxIndex) //Если последний индекс массива не совпадает с индексом наибольшего числа то перезаписываем элементы, меняем их местами
    {
      Swap(ref nums[i], ref nums[maxIndex]);
    }
  }
}

void Swap(ref int x, ref int y) // Хорошо работает, ссылочный тип работает напрямую с переданными ему переменными, тоесть перезаписывает напрямуюю элементы массива
{
  var t = x;
  x = y;
  y = t;
}