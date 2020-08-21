using System;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Урок 5, задача 2
/// Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.
/// </summary>

namespace Task2
{
	class StringStack
	{
		private string[] _array;
		private int _pos;


		public StringStack(int Size)
		{
			_array = new string[Size];
			_pos = -1;
		}

		/// <summary>
		/// Загнать символ в стек
		/// </summary>
		/// <param name="Symbol"></param>
		/// <returns></returns>
		public void Push(string Symbol)
		{
			_pos += 1;
			_array[_pos] = Symbol;
		}

		public string Pop()
		{
			if (_pos >= 0)
			{
				string res = _array[_pos];
				_array[_pos] = null;
				_pos -= 1;
				return res;
			}
			else return null;
		}

		public int Length { get { return _pos + 1; } }
	}

	class Program
	{
		static void Main()
		{
			// Предполагается, что строка все же более-менее нормально сформирована
			// Для чисел с несколькими разрядами надо писать дополнительный функционал, определяющий их границы
			string baseString = "( 1 + 2 ) * (3 - 5 * 8)";
			string resString = "";

			StringStack st = new StringStack(baseString.Length);
			for (int i = 0; i < baseString.Length; i++)
			{
				char curSym = baseString[i];
				string cur = curSym.ToString();
				if (char.IsDigit(curSym))
				{
					resString += " " + cur;
				}
				else if (cur == "+" || cur == "-" || cur == "*" || cur == "/" || cur == "(")
				{
					st.Push(cur);
				}
				else if (cur == ")")
				{
					while ((cur = st.Pop()) != null)
					{
						if (cur != "(")
						{
							resString += " " + cur;
						}
					}
				}
			}

			Console.WriteLine($"Base string : {baseString}");
			Console.WriteLine($"Potfix string : {resString}");

			Console.WriteLine("Нажмите любую клавишу");
			Console.ReadKey();

		}
	}
}
