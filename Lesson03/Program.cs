using System;
using System.Runtime.InteropServices;

namespace Lesson03
{
	class Program
	{

		static void Main()
		{
			// Заполнение массивов

			long counter = 0;
			int v1 = 10, v2 = 20;
			Console.WriteLine($"{v1} {v2} {counter}");
			Swap(ref v1, ref v2, ref counter);
			Console.WriteLine($"{v1} {v2} {counter}");

			int[] ar;


			//int[][] ar1 = new int[3][];
			//ar1[0] = CInitArrays.Array100;
			//ar1[1] = CInitArrays.Array500;
			//ar1[2] = CInitArrays.Array1000;

			counter = 0;
			ar = CInitArrays.Array100;
			BubbleSort(ar, ref counter);
			Console.WriteLine($"Bubble swaps {ar.Length}: {counter}");
			counter = 0;
			ar = CInitArrays.Array500;
			BubbleSort(ar, ref counter);
			Console.WriteLine($"Bubble swaps {ar.Length}: {counter}");
			ar = CInitArrays.Array1000;
			BubbleSort(ar, ref counter);
			Console.WriteLine($"Bubble swaps {ar.Length}: {counter}");

			counter = 0;
			ar = CInitArrays.Array100;
			ShakerSort(ar, ref counter);
			Console.WriteLine($"Shaker swaps {ar.Length}: {counter}");
			counter = 0;
			ar = CInitArrays.Array500;
			ShakerSort(ar, ref counter);
			Console.WriteLine($"Shaker swaps {ar.Length}: {counter}");
			ar = CInitArrays.Array1000;
			ShakerSort(ar, ref counter);
			Console.WriteLine($"Shaker swaps {ar.Length}: {counter}");

			Console.ReadKey();
		}

		public static void Swap(ref int Value1, ref int Value2, ref long Counter)
		{
			Counter++;
			(Value1, Value2) = (Value2, Value1);
		}

		public static void BubbleSort(int[] ArrayToSort, ref long Counter)
		{
			for (int i = 0; i < ArrayToSort.Length; i++)
			{
				for (int j = i + 1; j < ArrayToSort.Length; j++)
				{
					if (ArrayToSort[i] > ArrayToSort[j])
					{
						Swap(ref ArrayToSort[i], ref ArrayToSort[j], ref Counter);
					}
				}
			}
		}

		/// <summary>
		/// Неправильная реализация. Что-то я сделал не так...
		/// </summary>
		/// <param name="ArrayToSort"></param>
		/// <param name="Counter"></param>
		public static void ShakerSort(int[] ArrayToSort, ref long Counter)
		{
			for (int arCount = 0; arCount < ArrayToSort.Length/2; arCount++)
			{
				bool flag = false;
				for (int front = arCount; front < ArrayToSort.Length-arCount-1; front++)
				{
					if (ArrayToSort[front]> ArrayToSort[front+1])
					{
						Swap(ref ArrayToSort[front], ref ArrayToSort[front + 1], ref Counter);
						flag = true;
					}

					for (int back = ArrayToSort.Length - 2 - arCount; back > front; back--)
					{
						if (ArrayToSort[back-1]> ArrayToSort[back])
						{
							Swap(ref ArrayToSort[back - 1], ref ArrayToSort[back], ref Counter);
							flag = true;
						}
					}
					if (!flag)
						break;
				}
				
			}
		}
	}
}
