 public List<List<int>> CSDGFebruary(int[] inputArray, int targetSum)
        {
           Array.Sort(inputArray);
            List<List<int>> result = new List<List<int>>();
            if (inputArray.Length < 4)
                return result;
            int left = 0, right = 0;
            int currentSum = 0;
            for (int i = 0; i < inputArray.Length - 3; i++)
            {
                if (i != 0 && inputArray[i-1] == inputArray[i])
                {
                    continue;
                }
                for (int j = i + 1; j < inputArray.Length - 2; j++)
                {
                    if (j != i + 1 && inputArray[j] == inputArray[j - 1])
                        continue;
                    left = j + 1;
                    right = inputArray.Length - 1;
                    while (left < right)
                    {
                        if (left != j + 1 && inputArray[left] == inputArray[left - 1])
                        {
                            left++;
                            continue;
                        }
                        currentSum = inputArray[i] + inputArray[j] + inputArray[left] + inputArray[right];
                        if (currentSum > targetSum)
                        {
                            --right;
                        }
                        else if (currentSum < targetSum)
                        {
                            ++left;
                        }
                        else
                        {
                            result.Add(new List<int>() { inputArray[i], inputArray[j], inputArray[left], inputArray[right] });
                            ++left;
                        }
                    }
                }
              
            }

            return result;
        }