using System;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы, Урок 8
/// Реализовать сортировку подсчетом. Реализовать быструю сортировку.
/// Проанализировать время работы каждого из вида сортировок для 100, 10000, 1000000 элементов.
/// </summary>

namespace Lesson08
{
	/// <summary>
	/// Класс для хранения данных о времени выполнения.
	/// Сделано весьма топорно - только для просмотра результатов.
	/// </summary>
	class ReportDatas
	{

		public int ArrayLength;
		public double SecondsToRunQuickSort;
		public double SecondsToRunCountSort;

		public override string ToString()
		{
			return String.Format("{0:0 000,10}{1,20:F3}{2,20:F3}", ArrayLength, SecondsToRunQuickSort, SecondsToRunCountSort);
		}
	}
}
