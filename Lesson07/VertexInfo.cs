/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Алгоритмы и структуры данных. Базовый курс
/// Урок 7. Реализация алгоритмы Дейкстры для заранее заданного графа
/// </summary>

namespace Lesson07
{
	/// <summary>
	/// Информация о вершине
	/// </summary>
	public class VertexInfo
	{
		/// <summary>
		/// Вершина
		/// </summary>
		public Vertex Vertex { get; set; }

		/// <summary>
		/// Не посещенная вершина
		/// </summary>
		public bool IsUnvisited { get; set; }

		/// <summary>
		/// Сумма весов ребер
		/// </summary>
		public int EdgesWeightSum { get; set; }

		/// <summary>
		/// Предыдущая вершина
		/// </summary>
		public Vertex PreviousVertex { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="vertex">Вершина</param>
		public VertexInfo(Vertex vertex)
		{
			Vertex = vertex;
			IsUnvisited = true;
			EdgesWeightSum = int.MaxValue;
			PreviousVertex = null;
		}
	}
}
