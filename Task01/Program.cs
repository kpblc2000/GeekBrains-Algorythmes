using System;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы. Урок 6, задача 1
/// Реализовать простейшую хэш-функцию. На вход функции подается строка, на выходе сумма кодов символов
/// </summary>

namespace Task01
{
	class Program
	{
		static void Main()
		{
			Console.Write("\nВведите строку для обработки : ");
			string userString = Console.ReadLine();
			int res = 0;
			for (int i = 0; i < userString.Length; i++)
			{
				res += (int)userString[i];
			}

			Console.WriteLine($"Общая сумма кодов символов {res}");
			Console.WriteLine("Нажмите любую клавишу");
			Console.ReadKey();
		}
	}
}
