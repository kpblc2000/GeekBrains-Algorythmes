/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы и структуры данных. Базовый курс
/// Урок 7. Реализация алгоритмы Дейкстры для заранее заданного графа
/// </summary>

namespace Lesson07
{
	/// <summary>
	/// Ребро графа. Однонаправленное.
	/// </summary>
	public class Edge
	{
		/// <summary>
		/// Вершина графа, к которой "привязано" ребро
		/// </summary>
		public Vertex ConnectedVertex { get; }

		/// <summary>
		/// Значимость (вес) ребра
		/// </summary>
		public int EdgeWeight { get; }

		/// <summary>
		/// Создание объекта ребра
		/// </summary>
		/// <param name="СonnectedVertex">Вершина графа, к которой "привязано" ребро</param>
		/// <param name="Weight">Значимость (вес) ребра</param>
		public Edge(Vertex СonnectedVertex, int Weight)
		{
			this.ConnectedVertex = СonnectedVertex;
			EdgeWeight = Weight;
		}
	}
}
