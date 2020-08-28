using System.Collections.Generic;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы и структуры данных. Базовый курс
/// Урок 7. Реализация алгоритмы Дейкстры для заранее заданного графа
/// </summary>

namespace Lesson07
{
	/// <summary>
	/// Граф
	/// </summary>
	public class Graph
	{
		/// <summary>
		/// Список вершин графа
		/// </summary>
		public List<Vertex> Vertices { get; }

		/// <summary>
		/// Создание объекта графа
		/// </summary>
		public Graph()
		{
			Vertices = new List<Vertex>();
		}

		/// <summary>
		/// Добавление вершины
		/// </summary>
		/// <param name="VertexName">Имя вершины</param>
		public void AddVertex(string VertexName)
		{
			Vertices.Add(new Vertex(VertexName));
		}

		/// <summary>
		/// Поиск вершины
		/// </summary>
		/// <param name="VertexName">Название вершины</param>
		/// <returns>Найденная вершина</returns>
		public Vertex FindVertex(string VertexName)
		{
			foreach (Vertex v in Vertices)
			{
				if (v.Name.Equals(VertexName))
				{
					return v;
				}
			}
			return null;
		}

		/// <summary>
		/// Добавление ребра в граф
		/// </summary>
		/// <param name="FirstVertexName">Имя первой вершины</param>
		/// <param name="SecondVertexName">Имя второй вершины</param>
		/// <param name="EdgeWeight">Вес ребра соединяющего вершины</param>
		public void AddEdge(string FirstVertexName, string SecondVertexName, int EdgeWeight)
		{
			var v1 = FindVertex(FirstVertexName);
			if (v1 != null)
			{
				var v2 = FindVertex(SecondVertexName);
				if (v2 != null)
				{
					v1.AddEdge(v2, EdgeWeight);
					v2.AddEdge(v1, EdgeWeight);
				}
			}
		}
	}
}
