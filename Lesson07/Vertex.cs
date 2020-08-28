using System.Collections.Generic;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы и структуры данных. Базовый курс
/// Урок 7. Реализация алгоритмы Дейкстры для заранее заданного графа
/// </summary>

namespace Lesson07
{
	/// <summary>
	/// Вершина графа
	/// </summary>
	public class Vertex
	{
		/// <summary>
		/// Название вершины
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Список ребер, подключенных к этой вершине
		/// </summary>
		public List<Edge> Edges { get; }

		/// <summary>
		/// Создание объекта вершины графа
		/// </summary>
		/// <param name="VertexName">Имя вершины</param>
		public Vertex(string VertexName)
		{
			Name = VertexName;
			Edges = new List<Edge>();
		}

		/// <summary>
		/// Добавить ребро к вершине
		/// </summary>
		/// <param name="NewEdge">Ребро</param>
		public void AddEdge(Edge NewEdge)
		{
			Edges.Add(NewEdge);
		}

		/// <summary>
		/// Добавить ребро, подключенное к другой вершине
		/// </summary>
		/// <param name="AnotherVertex">Вершина</param>
		/// <param name="EdgeWeight">Вес</param>
		public void AddEdge(Vertex AnotherVertex, int EdgeWeight)
		{
			AddEdge(new Edge(AnotherVertex, EdgeWeight));
		}

		public override string ToString() => Name;
	}
}
