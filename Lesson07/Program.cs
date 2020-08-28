using System;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы и структуры данных. Базовый курс
/// Урок 7. Реализация алгоритмы Дейкстры для заранее заданного графа
/// </summary>

namespace Lesson07
{

	class Program
	{
		static void Main()
		{

			// Восстановление графа из видеоурока
			#region Вершины
			Graph g = new Graph();
			g.AddVertex("x0");
			g.AddVertex("x1");
			g.AddVertex("x2");
			g.AddVertex("x3");
			g.AddVertex("x4");
			g.AddVertex("x5");
			g.AddVertex("x6");
			g.AddVertex("x7");
			#endregion

			#region Связи между вершинами
			g.AddEdge("x0", "x1", 4);
			g.AddEdge("x0", "x2", 8);
			g.AddEdge("x0", "x3", 3);
			g.AddEdge("x1", "x2", 1);
			g.AddEdge("x1", "x4", 8);
			g.AddEdge("x1", "x5", 5);
			g.AddEdge("x2", "x3", 8);
			g.AddEdge("x2", "x4", 2);
			g.AddEdge("x3", "x6", 4);
			g.AddEdge("x4", "x5", 2);
			g.AddEdge("x4", "x7", 5);
			g.AddEdge("x5", "x7", 3);
			g.AddEdge("x6", "x7", 2);
			#endregion

			Deixtra d = new Deixtra(g);
			string path = d.FindShortestPath("x1", "x6");

			Console.WriteLine(path);

			Console.WriteLine("\nНажмите любую клавишу...");
			Console.ReadKey();
		}
	}
}
