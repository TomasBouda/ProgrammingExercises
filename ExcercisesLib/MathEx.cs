using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcercisesLib
{
    public class MathEx
    {
		public static MathResult<int> NaturalNumbersSum(int count)
		{
			if (count <= 0) throw new Exception();

			var result = new MathResult<int>();
	
			for (int i = 1; i <= count; i++)
			{
				result.AddOperation(result.Result ?? 0, Operators.addition, i);
			}

			return result;
		}
	}
}
