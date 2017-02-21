using ExcercisesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcercisesLib
{
	public class MathResult<T> where T : struct
	{
		public T? Result
		{
			get
			{
				return Operations.LastOrDefault()?.Result;
			}
		}

		public List<Operation<T>> Operations { get; private set; } = new List<Operation<T>>();


		public MathResult()
		{ 
		}

		public void AddOperation(T X, Operators o, T Y)
		{
			Operations.Add(Operation<T>.Create(X, o, Y));
		}

		public void AddOperation(T X, string o, T Y)
		{
			Operations.Add(Operation<T>.Create(X, o, Y));
		}

		public override string ToString()
		{
			return $"{string.Join("", Operations.Select(o => $"{o.Y} {Operation<T>.OperatorToString(o.Operator)} ")).TrimEnd(' ', '+')} = {Result}";
		}
	}
}
