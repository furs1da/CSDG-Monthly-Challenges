 public List<List<int>> CSDGFebruary(int[] inputArray, int targetSum) // Dmytrii Furs, #8703133
        {
            Array.Sort(inputArray); // sorting array 
            List<List<int>> result = new List<List<int>>(); // creating List<List<int>> to store valid quadruples
            if (inputArray.Length < 4) // if length of inputArray is less than 4 (min possible input) then return empty result
                return result;
            int left = 0, right = 0; // two pointers which are used to navigate through inoutArray
            int currentSum = 0; // variable which is used to store temp value of selected 4 elements in inputArray
            for (int i = 0; i < inputArray.Length - 3; i++) // inputArray.Length - 3 to iterate through at least 4 elements each time
            {
                if (i != 0 && inputArray[i-1] == inputArray[i]) // this if (and next ifs) is used to avoid having same quadruples (because of duplicates)
                { // i!=0 to avoid null reference error at first iteration, inputArray[i-1] == inputArray[i] to check if last element was identical with the current one
                    continue; // just starting next iteration
                }
                for (int j = i + 1; j < inputArray.Length - 2; j++) // same approach 
                {
                    if (j != i + 1 && inputArray[j] == inputArray[j - 1]) // same approach, to avoid having duplicates in result list
                        continue; // just skipping current iteration
                    left = j + 1; // one of two pointers is starting from the next element after j index
                    right = inputArray.Length - 1; // one of two  pointers is starting from the end of array
                    while (left < right) 
                    {
                        if (left != j + 1 && inputArray[left] == inputArray[left - 1]) // same approach, this if clause is used to avoid having duplicates in the final result list  
                        {  
                            left++; // just increasing left pointer by 1 and moving to next iteration
                            continue;
                        }
                        currentSum = inputArray[i] + inputArray[j] + inputArray[left] + inputArray[right]; // calculating sum of selected 4 elements
                        if (currentSum > targetSum) // if sum is bigger than targetSum, then we are moving pointer to the left (to decrease possible sum) (array is sorted at the moment)
                        {
                            --right;
                        }
                        else if (currentSum < targetSum) // else, we are moving left pointer (to increase possible sum)
                        {
                            ++left;
                        }
                        else // else currentSum and targetSum are equal 
                        { // as we avoided any situation where we could add duplicate result, we are just adding quadruple to the final list
                            result.Add(new List<int>() { inputArray[i], inputArray[j], inputArray[left], inputArray[right] }); // adding quadruple to the final result
                            ++left; // moving left pointer
                        }
                    }
                }
              
            }

            return result; // returning result list of quadruples
        }