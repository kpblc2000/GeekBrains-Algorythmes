using System;
using System.Runtime.Remoting.Channels;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы. Урок 2
/// </summary>

namespace Lesson02
{
	class Program
	{
		static void Main()
		{
			int userAnswer;
			Console.WriteLine(@"Выберите выполняемое действие:
1 : Преобразование числа в двоичную систему
2 : Возведение числа в степень

Ваш выбор: ");
			int.TryParse(Console.ReadLine(), out userAnswer);
			switch (userAnswer)
			{
				case 1:
					CDecimalToBinary.Run();
					break;
				case 2:
					CExplPower.Run();
					break;
				default:
					break;
			}

			Console.WriteLine("\n\n***\nРабота окончена. Нажмите любую клавишу");
			Console.ReadKey();
		}

	}

}
