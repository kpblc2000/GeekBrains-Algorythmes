using System;

namespace Lesson02
{
	/// <summary>
	/// Перевод числа из десятичной системы в двоичную
	/// </summary>
	static class CDecimalToBinary
	{
		/// <summary>
		/// Функция перевода целого числа в двоичную систему
		/// </summary>
		/// <param name="value">обрабатываемое число</param>
		/// <returns>Строка бинарного представления числа</returns>
		static string DecToBin(int value)
		{
			string res = "";
			if (value < 2)
			{
				res = value.ToString();
			}
			else
			{
				res = DecToBin(value / 2) + (value % 2).ToString() + res;
			}
			return res;
		}

		/// <summary>
		/// Модуль, используемый для иллюстрации работы основного алгоритма
		/// </summary>
		public static void Run()
		{
			int value;
			Console.WriteLine("\nПреобразование целого из десятичной в двоичную систему");
			Console.Write("\nВведите преобразовываемое число (целое, неотрицательное) : ");
			int.TryParse(Console.ReadLine(), out value);
			Console.WriteLine("\n");
			if (value >= 0)
				Console.WriteLine("Результат : {0}",DecToBin(value));
			else
				Console.WriteLine("Недопустимое значение");
			
		}
	}
}
