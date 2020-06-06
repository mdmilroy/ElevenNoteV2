using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
	public Class1()
	{
        string fName = "Michael";
        string lName = "Milroy";

		bool GreaterThanFive(int value)
        {
            bool answer = value > 5;
            return answer;
        }



        void EvenNumbersTo10()
        {
            List<int> Ten = range(1, 10);
            foreach (int even in Ten)
            {
                if (even % 2 == 0)
                {
                    Console.WriteLine(even);
                }
            }
        }




	}
}
