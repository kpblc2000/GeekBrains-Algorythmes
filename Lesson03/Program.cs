using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы, урок 3
/// </summary>

namespace Lesson03
{
	class Program
	{

		static void Main()
		{

			int[] ar;

			long swapCounter, cycleCounter;

			Console.WriteLine(@"Выберите один из вариантов массивов для сравнения количества выполняемых операций:
1. 10 элементов
2. 100 элементов
3. 500 элементов
4. 1000 элементов");
			int answer;
			int.TryParse(Console.ReadLine(), out answer);

			switch (answer)
			{
				case 1:
					ar = CInitArrays.Array10;
					break;
				case 2:
					ar = CInitArrays.Array100;
					break;
				case 3:
					ar = CInitArrays.Array500;
					break;
				case 4:
					ar = CInitArrays.Array1000;
					break;
				default:
					return;
			}

			Console.WriteLine($"\nBase array {ar.Length}: ");
			ArrayToConsole(ar);
			BubbleSortSimple(ar, out swapCounter, out cycleCounter);
			Console.WriteLine($"BubbleSortSimple -> Swaps: {swapCounter}; Cycles: {cycleCounter}");

			BubbleSort(ar, out swapCounter, out cycleCounter);
			Console.WriteLine($"BubbleSort       -> Swaps: {swapCounter}; Cycles: {cycleCounter}");

			ShakerSort1(ar, out swapCounter, out cycleCounter);
			Console.WriteLine($"ShakerSort1      -> Swaps: {swapCounter}; Cycles: {cycleCounter}");

			ShakerSort2(ar, out swapCounter, out cycleCounter);
			Console.WriteLine($"ShakerSort2      -> Swaps: {swapCounter}; Cycles: {cycleCounter}");

			InsSort1(ar, out swapCounter, out cycleCounter);
			Console.WriteLine($"InsSort1         -> Swaps: {swapCounter}; Cycles: {cycleCounter}");

			Console.WriteLine("Нажмите любую клавишу...");
			Console.ReadKey();
		}

		/// <summary>
		/// Простой вывод [части] массива в консоль. Выводится 10 первых элементов массива либо весь массив, если его размер меньше 10
		/// </summary>
		/// <param name="ArrayToPrint">Обрабатываемый массив</param>
		public static void ArrayToConsole(int[] ArrayToPrint)
		{
			for (int i = 0; i < (ArrayToPrint.Length > 10 ? 10 : ArrayToPrint.Length); i++)
			{
				Console.Write($"{ArrayToPrint[i]}\t");
			}
			Console.WriteLine(ArrayToPrint.Length > 10 ? "..." : "");
		}

		/// <summary>
		/// Замена местами двух переменных.
		/// </summary>
		/// <param name="Value1">Переменная 1</param>
		/// <param name="Value2">Переменная 2</param>
		/// <param name="Counter">Счетчик замен (используется только для тестовых задач</param>
		public static void Swap(ref int Value1, ref int Value2, ref long Counter)
		{
			Counter++;
			(Value1, Value2) = (Value2, Value1);
		}

		/// <summary>
		/// Пузырьковая сортировка без какой бы то ни было оптимизации
		/// </summary>
		/// <param name="ArrayToSort">Обрабатываемый массив</param>
		/// <param name="SwapCounter">Счетчик замен местами элементов массива</param>
		/// <param name="CycleCounter">Счетчик проходов по каждому циклу</param>
		public static void BubbleSortSimple(int[] ArrayToSort, out long SwapCounter, out long CycleCounter)
		{
			int[] temp = (int[])ArrayToSort.Clone();
			SwapCounter = 0;
			CycleCounter = 0;
			for (int i = 0; i < temp.Length; i++)
			{
				CycleCounter++;
				for (int j = 0; j < temp.Length; j++)
				{
					CycleCounter++;
					if (temp[i] < temp[j])
						Swap(ref temp[i], ref temp[j], ref SwapCounter);
				}
			}
		}

		/// <summary>
		/// Слегка улучшенная версия пузырьковой сортировки
		/// </summary>
		/// <param name="ArrayToSort">Обрабатываемый массив</param>
		/// <param name="SwapCounter">Счетчик замен местами элементов массива</param>
		/// <param name="CycleCounter">Счетчик проходов по каждому циклу</param>
		public static void BubbleSort(int[] ArrayToSort, out long SwapCounter, out long CycleCounter)
		{
			SwapCounter = 0;
			CycleCounter = 0;
			int[] temp = (int[])ArrayToSort.Clone();
			for (int i = 0; i < temp.Length; i++)
			{
				CycleCounter++;
				for (int j = i + 1; j < temp.Length; j++)
				{
					CycleCounter++;
					if (temp[i] > temp[j])
						Swap(ref temp[i], ref temp[j], ref SwapCounter);
				}
			}
		}

		/// <summary>
		/// Первый вариант "шейкерной" сортировки. 
		/// </summary>
		/// <param name="ArrayToSort"></param>
		/// <param name="SwapCounter"></param>
		/// <param name="CycleCounter"></param>
		public static void ShakerSort1(int[] ArrayToSort, out long SwapCounter, out long CycleCounter)
		{
			SwapCounter = 0;
			CycleCounter = 0;
			int[] temp = (int[])ArrayToSort.Clone();
			for (int arCount = 0; arCount < temp.Length / 2; arCount++)
			{
				CycleCounter++;
				bool flag = false;
				for (int front = arCount; front < temp.Length - arCount - 1; front++)
				{
					CycleCounter++;
					if (temp[front] > temp[front + 1])
					{
						Swap(ref temp[front], ref temp[front + 1], ref SwapCounter);
						flag = true;
					}

					for (int back = temp.Length - 2 - arCount; back > front; back--)
					{
						CycleCounter++;
						if (temp[back - 1] > temp[back])
						{
							Swap(ref temp[back - 1], ref temp[back], ref SwapCounter);
							flag = true;
						}
					}
					if (!flag)
						break;
				}

			}
		}

		/// <summary>
		/// Попытка переработать "шейкерную" сортировку.
		/// </summary>
		/// <param name="ArrayToSort">Обрабатываемый массив</param>
		/// <param name="SwapCounter">Счетчик замен местами элементов массива</param>
		/// <param name="CycleCounter">Счетчик проходов по каждому циклу</param>
		public static void ShakerSort2(int[] ArrayToSort, out long SwapCounter, out long CycleCounter)
		{
			SwapCounter = 0;
			CycleCounter = 0;
			int[] temp = (int[])ArrayToSort.Clone();
			int left = 0;
			int right = temp.Length - 1;
			int last = right;//temp.Length - 1;

			do
			{
				CycleCounter++;
				for (int i = left; i < right; i++)
				{
					CycleCounter++;
					if (temp[i] > temp[i + 1])
						Swap(ref temp[i], ref temp[i + 1], ref SwapCounter);
				}
				right--;
				for (int i = right; i > left; i--)
				{
					CycleCounter++;
					if (temp[i] < temp[i + 1])
						Swap(ref temp[i], ref temp[i + 1], ref SwapCounter);
				}
			} while (left < right);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ArrayToSort"></param>
		/// <param name="SwapCounter"></param>
		/// <param name="CycleCounter"></param>
		public static void InsSort1(int[] ArrayToSort, out long SwapCounter, out long CycleCounter)
		{
			SwapCounter = 0;
			CycleCounter = 0;
			int[] temp = (int[])ArrayToSort.Clone();
			for (int i = 0; i < temp.Length; i++)
			{
				CycleCounter++;
				int key = temp[i];
				int j = i;
				while ((j > 1) && (temp[j - 1] > key))
				{
					Swap(ref temp[j - 1], ref temp[j], ref SwapCounter);
					j--;
				}
				temp[j] = key;
			}
		}
	}
}
