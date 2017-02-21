using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil;

namespace ExcercisesLib
{
	public enum Operators
	{
		none,
		addition,
		subtraction,
		multiplication,
		division
	}


	public class Operation<T> where T : struct
	{
		public T X { get; set; }
		public Operators Operator { get; set; }
		public T Y { get; set; }
		public T? Result { get; set; }

		public Operation(T x, Operators o, T y)
		{
			X = x;
			Operator = o;
			Y = y;

			Result = Calculate(X, Operator, Y);
		}

		public static Operation<T> Create(T x, Operators o, T y)
		{
			return new Operation<T>(x, o, y);
		}

		public static Operation<T> Create(T x, string o, T y)
		{
			return Create(x, StringToOperator(o), y);
		}

		public override string ToString()
		{
			return $"{X} {OperatorToString(Operator)} {Y} = {Result}";
		}

		public static string OperatorToString(Operators o)
		{
			switch (o)
			{
				case Operators.addition: return "+";
				case Operators.subtraction: return "-";
				case Operators.multiplication: return "*";
				case Operators.division: return "/";
				default: return "";
			}
		}

		public static Operators StringToOperator(string o)
		{
			switch (o)
			{
				case "+": return Operators.addition;
				case "-": return Operators.subtraction;
				case "*": return Operators.multiplication;
				case "/": return Operators.division;
				default: return Operators.none;
			}
		}

		public T? Calculate(T x, Operators o, T y)
		{
			switch (o)
			{
				case Operators.addition: return MiscUtil.Operator.Add(x, y);
				case Operators.subtraction: return MiscUtil.Operator.Subtract(x, y);
				case Operators.multiplication: return MiscUtil.Operator.Multiply(x, y);
				case Operators.division: return MiscUtil.Operator.Divide(x, y);
				default: return null;
			}
		}
	}
}
