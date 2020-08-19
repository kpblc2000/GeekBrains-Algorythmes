using System;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы, урок 4
/// Задача 2, поиск наибольшей общей последовательности через матрицу
/// </summary>

namespace Lesson04
{
	class Program
	{

		/// <summary>
		/// Возвращает максимальное из 2 значений
		/// </summary>
		/// <param name="Value1"></param>
		/// <param name="Value2"></param>
		/// <returns></returns>
		static int MaxValue(int Value1, int Value2)
		{
			return Value1 > Value2 ? Value1 : Value2;
		}

		/// <summary>
		/// Фактически повтор кода из методички + вебинар. Находит длину наибольшей общей подпоследовательности
		/// </summary>
		/// <param name="String1">Обрабатываемая строка</param>
		/// <param name="String2">Обрабатываемая строка</param>
		/// <param name="Index1">Индекс начала поиска в <paramref name="String1"/></param>
		/// <param name="Index2">Индекс начала поиска в <paramref name="String2"/></param>
		/// <returns></returns>
		static int GetMaxSubQueryLen(string String1, string String2, int Index1 = 0, int Index2 = 0)
		{
			if (String1.Length == 0 || String2.Length == 0 || String1.Length == Index1 + 1 || String2.Length == Index2 + 1)
			{
				return 0;
			}
			else if (String1[Index1] == String2[Index2])
			{
				return GetMaxSubQueryLen(String1, String2, Index1 + 1, Index2 + 1) + 1;
			}
			else
			{
				return MaxValue(GetMaxSubQueryLen(String1, String2, Index1 + 1, Index2), GetMaxSubQueryLen(String1, String2, Index1, Index2 + 1));
			}
		}

		/// <summary>
		/// Заполнение матрицы для определения наибольшей общей последовательности.
		/// </summary>
		/// <param name="String1">Обрабатываемая строка</param>
		/// <param name="String2">Обрабатываемая строка</param>
		/// <param name="Matrix">Матрица размером длина строки <paramref name="String1"/> x длина строки <paramref name="String2"/></param>
		/// <param name="Index1">Индекс начала поиска в <paramref name="String1"/></param>
		/// <param name="Index2">Индекс начала поиска в <paramref name="String2"/></param>
		/// <returns></returns>
		static int GetLCS(string String1, string String2, int[,] Matrix, int Index1 = 0, int Index2 = 0)
		{
			if (String1.Length == 0 || String2.Length == 0 || String1.Length == Index1 + 1 || String2.Length == Index2 + 1)
			{
				return 0;
			}
			else if (String1[Index1] == String2[Index2])
			{
				if (Matrix[Index1 == 0 ? 0 : Index1 - 1, Index2] == Matrix[Index1, Index2] ||
					Matrix[Index1, Index2 == 0 ? 0 : Index2 - 1] == Matrix[Index1, Index2]
					)
				{
					int temp = Matrix[Index1, Index2] + 1;
					Matrix[Index1, Index2] = temp;
					for (int i = Index1; i <= Matrix.GetUpperBound(0); i++)
					{
						for (int j = Index2; j <= Matrix.GetUpperBound(1); j++)
						{
							Matrix[i, j] = MaxValue(temp, Matrix[i, j]);
						}
					}
					//MatrixToConsole(Matrix);
					//Console.WriteLine("\n***\n");
				}
				return GetLCS(String1, String2, Matrix, Index1 + 1, Index2 + 1) + 1;
			}
			else
			{
				return MaxValue(GetLCS(String1, String2, Matrix, Index1 + 1, Index2), GetLCS(String1, String2, Matrix, Index1, Index2 + 1));
			}
		}

		/// <summary>
		/// Вывод матрицы чисел в консоль. Используется только для отладочных целей
		/// </summary>
		/// <param name="mt">Выводимая матрица</param>
		private static void MatrixToConsole(int[,] mt)
		{
			for (int j = 0; j <= mt.GetUpperBound(1); j++)
			{
				for (int i = 0; i <= mt.GetUpperBound(0); i++)
				{
					Console.Write($"{mt[i, j],8}\t");
				}
				Console.WriteLine();
			}
		}

		static void Main()
		{
			string strA;// = "37276785892267";
			string strB;// = "2955179738";

			strA = "356467";
			strB = "2368";
			Console.WriteLine($"Начальные значения строк:\n{strA}\n{strB}\n");
			int[,] mt = new int[strA.Length, strB.Length];
			for (int i = 0; i <= mt.GetUpperBound(0); i++)
			{
				for (int j = 0; j <= mt.GetUpperBound(1); j++)
				{
					mt[i, j] = 0;
				}
			}

			int l1 = GetLCS(strA, strB, mt);
			Console.WriteLine("Полученная матрица ходов:");
			MatrixToConsole(mt);

			Console.WriteLine($"Максимальная длина общей последовательности = {l1}");

			//int len = GetMaxSubQueryLen(strB, strA);

			//Console.WriteLine(len);

			Console.WriteLine("Нажмите любую клавишу");
			Console.ReadKey();

		}

	}
}
