using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы, Урок 8
/// Реализовать сортировку подсчетом. Реализовать быструю сортировку.
/// Проанализировать время работы каждого из вида сортировок для 100, 10000, 1000000 элементов.
/// </summary>

namespace Lesson08
{

	class Program
	{

		/// <summary>
		/// Чтение массива из текстового файла. В файле массив располагается в одну строку. Числа разделены символами ' ' или ',' (или и тем, и другим)
		/// </summary>
		/// <param name="FileName">Имя файла, из которого выполняется чтение массива</param>
		/// <returns></returns>
		static int[] ReadArrayFromFile(string FileName)
		{
			string[] arStr;
			using (StreamReader sr = new StreamReader(FileName))
			{
				arStr = sr.ReadLine().Split(new char[] { ',' });
			}
			int[] res = new int[arStr.Length];
			int idx = 0;
			foreach (string val in arStr)
			{
				int x;
				int.TryParse(val, out x);
				res[idx] = x;
				idx++;
			}
			return res;
		}

		/// <summary>
		/// Сортировка подсчетом. Реализовать без определения максимального / минимального числа не удалось
		/// </summary>
		/// <param name="ArrayForSorting">Обрабатываемый массив</param>
		static void SortByCount(int[] ArrayForSorting)
		{
			int minVal = ArrayForSorting[0];
			int maxVal = ArrayForSorting[0];
			foreach (int item in ArrayForSorting)
			{
				if (item > maxVal)
					maxVal = item;
				else if (item < minVal)
					minVal = item;
			}

			// Создаем новый массив, в котором будем хранить количество вхождений каждого из элементов начального массива.
			int[] countArray = new int[maxVal + 1];
			for (int i = 0; i < ArrayForSorting.Length; i++)
			{
				// Например, для первого вхождения значения 5: countArray[5] = 1;
				// Для второго - уже 2
				// И т.д.
				countArray[ArrayForSorting[i]]++;
			}

			// Проходим по всем элементам массива подсчета вхождений
			int index = 0;
			for (int i = 0; i < countArray.Length; i++)
			{
				// Игнорим все нулевые вхождения
				for (int j = 0; j < countArray[i]; j++)
				{
					// Учитывая, что index - это индекс элемента в базовом массиве,
					// а i - что-то ненулевое, и являющееся тем самым числом, можно выполнять присваивание
					ArrayForSorting[index] = i;
					index++;
				}
			}
		}

		/// <summary>
		/// Попытка реализации быстрой сортировки
		/// </summary>
		/// <param name="ArrayForSorting">Обрабатываемый массив</param>
		/// <param name="StartIdex">Начальный индекс сортируемого куска</param>
		/// <param name="LastIndex">Конечный индекс сортируемого куска</param>
		static void QuickSort(int[] ArrayForSorting, int StartIdex, int LastIndex)
		{
			// Если диапазон состоит всего из одного элемента, действия можно не выполнять
			// Сортировка по среднему элементу
			int mid = ArrayForSorting[(StartIdex + LastIndex) / 2];
			int start = StartIdex;
			int last = LastIndex;
			while (start <= last)
			{
				// Увеличиваем начальную позицию, пока либо не найдем бОльший элемент, чем средний, либо пока начальный и конечный индекс не будут равны
				while (ArrayForSorting[start] < mid && start <= LastIndex) ++start;
				// Уменьшаем конечную позицию, пока либо не найдем меньший элемент, чем средний, либо пока начальная и конечная позиция не будут равны
				while (ArrayForSorting[last] > mid && last >= StartIdex) --last;
				// Если начальная позиция все еще не больше конечной
				if (start <= last)
				{
					// выполняем перемену значений местами и сдвигаем позиции дальше
					(ArrayForSorting[start], ArrayForSorting[last]) = (ArrayForSorting[last], ArrayForSorting[start]);
					++start;
					--last;
				}
			}
			// Если последняя позиция все еще больше начального индекса, сортируем от начального индекса и до этой позиции
			if (last > StartIdex) QuickSort(ArrayForSorting, StartIdex, last);
			// Если начальная позиция все еще меньше конечного индекса, сортируем от начальной позиции и до конечного индекса
			if (start < LastIndex) QuickSort(ArrayForSorting, start, LastIndex);

		}

		/// <summary>
		/// Сервисная функция поэлементного сравнения целочисленных массивов.
		/// </summary>
		/// <param name="Array1">Сравниваемый массив</param>
		/// <param name="Array2">Сравниваемый массив</param>
		/// <param name="ErrorPosition">Первая позиция, на которой элементы оказываются не равными</param>
		/// <returns></returns>
		static bool ArraysAreEqual(int[] Array1, int[] Array2, out int ErrorPosition)
		{
			ErrorPosition = -1;
			bool res = Array1.Length == Array2.Length;
			if (res)
			{
				for (int i = 0; i < Array1.Length; i++)
				{
					if (Array1[i] != Array2[i])
					{
						res = false;
						ErrorPosition = i;
						break;
					}
				}
			}
			return res;
		}

		static void Main(string[] args)
		{
			List<ReportDatas> lst = new List<ReportDatas>();

			foreach (int key in new int[] { 100, 1000, 10000, 1000000})
			{
				// Оставил для целей тестирования
				int[] baseArray;
				string fileName = $"Array{key}.txt";
				if (File.Exists(fileName))
				{
					baseArray = ReadArrayFromFile($"Array{key}.txt");
				}
				else
				{
					baseArray = new int[key];
					Random rnd = new Random();
					for (int i = 0; i < key; i++)
					{
						baseArray[i] = rnd.Next(1, key);
					}
				}
				int[] arr1 = baseArray.Clone() as int[];
				int[] arr2 = baseArray.Clone() as int[];
				ReportDatas rep = new ReportDatas
				{
					ArrayLength = baseArray.Length
				};
				DateTime startTime = DateTime.Now;
				SortByCount(arr1);
				rep.SecondsToRunCountSort = (DateTime.Now - startTime).TotalMilliseconds;

				startTime = DateTime.Now;
				QuickSort(arr2, 0, arr2.Length - 1);
				rep.SecondsToRunQuickSort = (DateTime.Now - startTime).TotalMilliseconds;

				int errorPos;
				if (!ArraysAreEqual(arr1, arr2, out errorPos))
				{
					Console.WriteLine($"Ошибка на позиции {errorPos} для {key} элементов");
					Console.ReadKey();
					rep.SecondsToRunCountSort = -1;
					rep.SecondsToRunQuickSort = -1;
				}
				lst.Add(rep);
			}

			Console.WriteLine("{0,10}{1,20}{2,20}", "Элементов", "Quick, ms", "Count, ms");
			foreach (var item in lst)
				Console.WriteLine(item);

			Console.WriteLine("\nНажмите любую клавишу");
			Console.ReadKey();
		}
	}
}
