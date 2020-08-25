using System;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы. Урок 6, задача 2
/// Переписать программу, реализующее двоичное дерево поиска
/// </summary>

namespace Task02
{

	/// <summary>
	/// Бинарное дерево реализовано через массив
	/// </summary>

	class Program
	{

		/// <summary>
		/// Обход построенного дерева и вывод его в консоль
		/// </summary>
		/// <param name="TreeToPrint">Обрабатываемое дерево</param>
		/// <param name="Idx">Начальный индекс</param>
		static void PrintRootLeftRight(int[] TreeToPrint, int Idx)
		{
			Idx = Idx <= 0 ? 1 : Idx;
			if (Idx < TreeToPrint.Length && TreeToPrint[Idx] != 0)
			{
				Console.Write(TreeToPrint[Idx]);
				if ((Idx * 2 < TreeToPrint.Length) && (TreeToPrint[2 * Idx] != 0) ||
					((Idx * 2 + 1) < TreeToPrint.Length && (TreeToPrint[Idx * 2 + 1] != 0))
					)
				{
					Console.Write("(");
					if ((Idx * 2 < TreeToPrint.Length) && (TreeToPrint[2 * Idx] != 0))
						PrintRootLeftRight(TreeToPrint, 2 * Idx);
					else
						Console.Write("NULL");
					Console.Write(", ");
					if ((Idx * 2 + 1) < TreeToPrint.Length && (TreeToPrint[Idx * 2 + 1] != 0))
						PrintRootLeftRight(TreeToPrint, 2 * Idx + 1);
					else
						Console.Write("NULL");

					Console.Write(")");
				}
			}
		}

		/// <summary>
		/// Проход по дереву по принципу "Корень-Налево-Направо"
		/// </summary>
		/// <param name="TreeToPrint">Обрабатываемое дерево</param>
		/// <param name="Idx">Начальный индекс обхода</param>
		static void TravelRootLeftRight(int[] TreeToPrint, int Idx)
		{
			if (Idx < TreeToPrint.Length && TreeToPrint[Idx] != 0)
			{
				Console.Write($"{TreeToPrint[Idx]}, ");

				if ((Idx * 2 < TreeToPrint.Length) && (TreeToPrint[2 * Idx] != 0))
					TravelRootLeftRight(TreeToPrint, 2 * Idx);

				Console.Write(", ");
				if ((Idx * 2 + 1) < TreeToPrint.Length && (TreeToPrint[Idx * 2 + 1] != 0))
					TravelRootLeftRight(TreeToPrint, 2 * Idx + 1);

			}
		}

		/// <summary>
		/// Проход по дереву по принципу "Направо-Корень-Налево"
		/// </summary>
		/// <param name="TreeToPrint">Обрабатываемое дерево</param>
		/// <param name="Idx">Начальный индекс обхода</param>
		static void TravelRightRootLeft(int[] TreeToPrint, int Idx)
		{
			if (Idx < TreeToPrint.Length && TreeToPrint[Idx] != 0)
			{

				Console.Write(", ");
				if ((Idx * 2 + 1) < TreeToPrint.Length && (TreeToPrint[Idx * 2 + 1] != 0))
					TravelRightRootLeft(TreeToPrint, 2 * Idx + 1);

				Console.Write($"{TreeToPrint[Idx]}, ");

				if ((Idx * 2 < TreeToPrint.Length) && (TreeToPrint[2 * Idx] != 0))
					TravelRightRootLeft(TreeToPrint, 2 * Idx);

			}
		}

		/// <summary>
		/// Вставка значения в дерево. Если корня нет, вставляется на место корня. Меньшие элементы вставляются налево, бОльшие - направо
		/// </summary>
		/// <param name="Tree">Обрабатываемое дерево</param>
		/// <param name="Value">Вставляемое значение</param>
		static void InsertInTree(int[] Tree, int Value)
		{
			if (Tree[1] == 0)
			{
				Tree[1] = Value;
			}
			else
			{
				int iCounter = 1;
				while ((iCounter * 2 + 1) <= Tree.Length && Tree[iCounter] != 0)
				{
					if (Value < Tree[iCounter])
					{
						iCounter *= 2;
					}
					else
					{
						iCounter = iCounter * 2 + 1;
					}
				}
				Tree[iCounter] = Value;
			}
		}

		/// <summary>
		/// Поиск значения в дереве
		/// </summary>
		/// <param name="Tree">Обрабатываемое дерево</param>
		/// <param name="valueSearch">Искомое значение</param>
		/// <returns>true, если значение найдено</returns>
		static bool FindValueInTree(int[] Tree, int valueSearch)
		{
			int iCounter = 1;
			bool res = false;

			while ((iCounter * 2 + 1) <= Tree.Length && Tree[iCounter] != 0)
			{
				if (valueSearch == Tree[iCounter])
				{
					res = true;
					break;
				}
				else if (valueSearch > Tree[iCounter])
					iCounter = iCounter * 2 + 1;
				else
					iCounter *= 2;
			}
			return res;
		}

		static void Main()
		{
			int[] IntTree;

			IntTree = new int[500];
			int counter = 0;
			InsertInTree(IntTree, 48);
			foreach (int item in new int[] { 60, 35, 30, 56, 7, 35, 8 })
			{
				InsertInTree(IntTree, item);
				counter++;
			}
			// Обход дерева
			PrintRootLeftRight(IntTree, 1);

			// Поиск значения в дереве
			int valueSearch;
			Console.Write("\nВведите искомое число : ");
			int.TryParse(Console.ReadLine(), out valueSearch);

			bool found = FindValueInTree(IntTree, valueSearch);

			Console.WriteLine("Значение {0} в дереве {1} найден", valueSearch, found ? "не" : "");

			Console.WriteLine("\nНажмите любую клавишу");
			Console.ReadKey();

		}

	}
}
