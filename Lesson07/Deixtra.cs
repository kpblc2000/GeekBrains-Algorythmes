using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы и структуры данных. Базовый курс
/// Урок 7. Реализация алгоритмы Дейкстры для заранее заданного графа
/// </summary>

namespace Lesson07
{
	/// <summary>
	/// Дейкстра
	/// </summary>
	public class Deixtra
	{
		Graph graph;

		List<VertexInfo> VertexList;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="graph">Граф</param>
		public Deixtra(Graph graph)
		{
			this.graph = graph;
		}

		/// <summary>
		/// Получение информации о вершине графа
		/// </summary>
		/// <param name="v">Вершина</param>
		/// <returns>Объект вершины</returns>
		VertexInfo GetVertexInfo(Vertex v)
		{
			foreach (var i in VertexList)
			{
				if (i.Vertex.Equals(v))
				{
					return i;
				}
			}
			return null;
		}

		/// <summary>
		/// Поиск непосещенной вершины с минимальным значением суммы
		/// </summary>
		/// <returns>Информация о вершине</returns>
		public VertexInfo FindUnvisitedVertexWithMinSum()
		{
			var minValue = int.MaxValue;
			VertexInfo minVertexInfo = null;
			foreach (var i in VertexList)
			{
				if (i.IsUnvisited && i.EdgesWeightSum < minValue)
				{
					minVertexInfo = i;
					minValue = i.EdgesWeightSum;
				}
			}
			return minVertexInfo;
		}

		/// <summary>
		/// Поиск кратчайшего пути по названиям вершин
		/// </summary>
		/// <param name="StartName">Название стартовой вершины</param>
		/// <param name="FinishName">Название финишной вершины</param>
		/// <returns>Кратчайший путь</returns>
		public string FindShortestPath(string StartName, string FinishName)
		{
			Vertex startVertex = graph.FindVertex(StartName);
			if (startVertex != null)
			{
				Vertex endVertex = graph.FindVertex(FinishName);
				if (endVertex != null)
					return FindShortestPath(startVertex, endVertex);
				else
					return null;
			}
			else
				return null;
		}

		/// <summary>
		/// Поиск кратчайшего пути по вершинам
		/// </summary>
		/// <param name="startVertex">Стартовая вершина. Должна существовать в графе.</param>
		/// <param name="finishVertex">Финишная вершина. Должна существовать в графе.</param>
		/// <returns>Кратчайший путь</returns>
		public string FindShortestPath(Vertex startVertex, Vertex finishVertex)
		{
			VertexList = new List<VertexInfo>();
			foreach (var v in graph.Vertices)
			{
				VertexList.Add(new VertexInfo(v));
			}
			var first = GetVertexInfo(startVertex);
			first.EdgesWeightSum = 0;
			while (true)
			{
				var current = FindUnvisitedVertexWithMinSum();
				if (current == null)
				{
					break;
				}
				SetSumToNextVertex(current);
			}
			return GetPath(startVertex, finishVertex);
		}

		/// <summary>
		/// Вычисление суммы весов ребер для следующей вершины
		/// </summary>
		/// <param name="info">Информация о текущей вершине</param>
		void SetSumToNextVertex(VertexInfo info)
		{
			info.IsUnvisited = false;
			foreach (var e in info.Vertex.Edges)
			{
				var nextInfo = GetVertexInfo(e.ConnectedVertex);
				var sum = info.EdgesWeightSum + e.EdgeWeight;
				if (sum < nextInfo.EdgesWeightSum)
				{
					nextInfo.EdgesWeightSum = sum;
					nextInfo.PreviousVertex = info.Vertex;
				}
			}
		}

		/// <summary>
		/// Формирование пути
		/// </summary>
		/// <param name="startVertex">Начальная вершина</param>
		/// <param name="endVertex">Конечная вершина</param>
		/// <returns>Путь</returns>
		string GetPath(Vertex startVertex, Vertex endVertex)
		{
			var path = endVertex.ToString();
			while (startVertex != endVertex)
			{
				endVertex = GetVertexInfo(endVertex).PreviousVertex;
				path = endVertex.ToString() + "; " + path;
			}
			return path;
		}
	}
}
