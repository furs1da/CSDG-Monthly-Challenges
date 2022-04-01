using System;
using System.Collections.Generic;
using System.Linq;

    public List<List<int>> GetFactors(int n) // Dmytrii Furs, #8703133
        {
            if (n < 4) // if entered number is lower than 0, then return null, because 0-3 do not have divisors
                return null;

            List<List<int>> resultList = new List<List<int>>(); // else, we are using DFS to find all results
            for (int i = 2; i <= Math.Sqrt(n); i++) //  i = 2, because 2 is the lowest possible divisors and Math.Sqrt(n) for each number is the highest possible divisor
            {
                if (n % i == 0) // if we can divide number without any remainder, then we are going to find all possible solutions in that "Leaf"
                {
                    List<List<int>> tmp = DFS(n / i); 
                    foreach (List<int> item in tmp)
                    {
                        item.Add(i); // we are adding i number, because algorithm finds all numbers in the sublist except first one (for example, for 12 it is 6 (i = 2) and (2, 3) (i = 2) (watch DFS function))
                        item.Sort(); // sorting is done for formating and next comparison
                        // checking if these set of values is already in the final set
                        if(!resultList.Any(resItem => Enumerable.SequenceEqual(resItem, item))) // first time I finally found on stackoverflow how to compare 2 lists by their values (using LINQ library)
                        resultList.Add(item); // resultList.Any(resItem => Enumerable.SequenceEqual(resItem, item)) -> Explanation: resultList.Any - any item in the list, resItem => Enumerable.SequenceEqual(resItem, item) - if given list and one in the array are equal
                    }
                }
            }
            return resultList; // returning the final result
        }

    public List<List<int>> DFS(int n) // usual DFS algorithm to find all possible values down the "tree"
        {
            List<List<int>> result = new List<List<int>>();

            List<int> temp = new List<int>(); // explaining for number 12
            temp.Add(n); // Care, here we have number number 6 in the first iteration, because we are sending i/n (12/2 = 6)
            result.Add(temp); // adding 

            for (int i = 2; i <= Math.Sqrt(n); i++) //  i = 2, because 2 is the lowest possible divisors and Math.Sqrt(n) for each number is the highest possible divisor
            {
                if (n % i == 0)
                {
                    List<List<int>> tmp = DFS(n / i); // same recursive approach, luckily it works 0_0 (every time I am programming recursive algos with my intuition) 
                    foreach (List<int> item in tmp)
                    {
                        item.Add(i); // to find all additional numbers when we have more than 2 numbers in the list (2,2,3)
                        result.Add(item); // adding list to subresult
                    }
                }
            }
            return result; // subresult for certain divisor (in case with number 12, there are 2 subresults for number 2 and 3)
        }