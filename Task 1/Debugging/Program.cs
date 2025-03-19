const int NumsCount = 10;
int[] nums = new int[NumsCount];
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

bool CheckSortResults(int[] nums)
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

void Output(int[] nums)
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
}

void SelectionSort(int[] nums)
{
  for (var i = nums.Length - 1; i >= 0; i--)
  {
    var maxIndex = i;
    int j;
    for (j = i - 1; j >= 0; --j)
    {
      if (nums[j] > nums[maxIndex])
      {
        maxIndex = j;
      }
    }

    if (i != maxIndex)
    {
      Swap(ref nums[i], ref nums[maxIndex]);
    }
  }
}

void Swap(ref int x, ref int y)
{
  var t = x;
  x = y;
  y = t;
}