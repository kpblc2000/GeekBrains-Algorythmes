using System;

namespace Lesson02
{
	/// <summary>
	/// Возведение числа в степень различными способами
	/// </summary>
	public static class CExplPower
	{
		private static int counter;

		/// <summary>
		/// Возведение в степень простой итерацией
		/// </summary>
		/// <param name="Value">Возводимое в <paramref name="Power"/> число</param>
		/// <param name="Power">Значение степени</param>
		/// <returns>Результат <paramref name="Value"/>^<paramref name="Power"/></returns>
		public static long ExplPowerIteraction(long Value, int Power)
		{
			long res = 1;
			for (int i = 1; i <= Power; i++)
			{
				counter++;
				res *= Value;
			}
			return res;
		}

		/// <summary>
		/// Возведение в степень с использованием рекурсии		
		/// </summary>
		/// <param name="Value">Возводимое в <paramref name="Power"/> число</param>
		/// <param name="Power">Значение степени</param>
		/// <returns>Результат <paramref name="Value"/>^<paramref name="Power"/></returns>
		public static long ExplPowerRecusive(long Value, int Power)
		{
			counter++;
			if (Power == 0)
				return 1;
			else
			{
				return ExplPowerRecusive(Value, --Power) * Value;
			}
		}

		/// <summary>
		/// Возведение в степень с учетом четности степени
		/// </summary>
		/// <param name="Value">Возводимое в <paramref name="Power"/> число</param>
		/// <param name="Power">Значение степени</param>
		/// <returns>Результат <paramref name="Value"/>^<paramref name="Power"/></returns>
		public static long ExplPowerRecursiveEven(long Value, int Power)
		{
			counter++;
			if (Power == 0)
			{
				return 1;
			}
			else if (Power % 2 == 0)
			{
				return ExplPowerRecursiveEven(Value * Value, Power / 2);
			}
			else
			{
				return ExplPowerRecursiveEven(Value, --Power) * Value;
			}
		}


		public static void Run()
		{
			int value, power;
			Console.WriteLine("\nВозведение числа в степень");
			Console.Write("\nВведите обрабатываемое число (целое) : ");
			int.TryParse(Console.ReadLine(), out value);
			Console.Write("\nВведите степень (целое) : ");
			int.TryParse(Console.ReadLine(), out power);
			counter = 0;
			Console.WriteLine("\nИтерация : {0}, заняло {1} шагов", ExplPowerIteraction(value, power), counter);
			counter = 0;
			Console.WriteLine("\nРекурсия : {0}, заняло {1} шагов", ExplPowerRecusive(value, power), counter);
			counter = 0;
			Console.WriteLine("\nРекурсия с учетом четности : {0}, заняло {1} шагов", ExplPowerRecursiveEven(value, power), counter);
			return;
		}
	}
}