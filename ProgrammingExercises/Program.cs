using ExcercisesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercises
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Write("Insert natural nubmer: ");
				Proceed(Console.ReadLine());
			}
		}

		private static void Proceed(string input)
		{
			int n;
			if (int.TryParse(input, out n) && n > 0)
			{
				var res = MathEx.NaturalNumbersSum(n);
				foreach (Operation<int> o in res.Operations)
				{
					if(res.Operations.IndexOf(o) != 0)
						Console.WriteLine(o);
				}

				Console.WriteLine(res);
			}
			else
				Console.WriteLine("Invalid input");
		}
	}
}
