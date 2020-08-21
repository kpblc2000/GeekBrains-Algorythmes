using System;
using System.Linq;

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

	class CharStack
	{
		// private int _size; // Количество элементо в стеке
		private char[] _array; // Собственно содержимое стека. Сделаю только под символы
		private int _pos; // Текущее количество элементов в стеке

		public CharStack(int Size)
		{
			_array = new char[Size];
			_pos = -1;
		}

		/// <summary>
		/// Загнать символ в стек
		/// </summary>
		/// <param name="Symbol"></param>
		/// <returns></returns>
		public void Push(char Symbol)
		{
			_pos += 1;
			_array[_pos] = Symbol;
		}

		/// <summary>
		/// Получить символ из стека, удалив его
		/// </summary>
		/// <returns></returns>
		public char Pop()
		{
			if (_pos >= 0)
			{
				char res = _array[_pos];
				_array[_pos] = '\0';
				_pos -= 1;
				return res;
			}
			else return '\0';
		}

		public int Length { get { return _pos; } }

		public bool IsEmpty { get { return _pos < 0; } }

	}


	class Program
	{
		static void Main()
		{
			// Предполагается, что строка все же более-менее нормально сформирована
			string baseString = " 198 + 2 * 36 - 5";
			CharStack oper = new CharStack(baseString.Length);
			string digVal = "";

			char[] operations = new char[] { '+', '-', '*', '/' };

			string res = "";

			/*
( 192 + ( 8 - 4 ) ) * ( 36 - 5 )
Символ	Операция	Стек	Выходная строка
(	поместить в стек	(	
192 	добавить к выходной строке	(	192
+	поместить в стек	(, +	192
	добавить к выходной строке	(, +	192 ,
(	поместить в стек	(, +, (	192 ,
8 	добавить к выходной строке	(, +, (	192 , , 8
-	поместить в стек	(, +, (, -	192 , , 8
4 	добавить к выходной строке	(, +, (, -	192 , , 8 , 4
)	1) присоединить содержимое стека до скобки в обратном порядке к выходной строке; 2) удалить скобку из стека.	(, +	192 , , 8 , 4 , -
	добавить к выходной строке	(, +	192 , , 8 , 4 , -,
)	1) присоединить содержимое стека до скобки в обратном порядке к выходной строке; 2) удалить скобку из стека.		192 , , 8 , 4 , -, , +
	добавить к выходной строке		192 , , 8 , 4 , -, , +,
*	поместить в стек	*	192 , , 8 , 4 , -, , +,
	добавить к выходной строке	*	192 , , 8 , 4 , -, , +, ,
(	поместить в стек	*, (	192 , , 8 , 4 , -, , +, ,
36 	добавить к выходной строке	*, (	192 , , 8 , 4 , -, , +, , , 36
-	поместить в стек	*, (, -	192 , , 8 , 4 , -, , +, , , 36
5 	добавить к выходной строке	*, (, -	192 , , 8 , 4 , -, , +, , , 36 , 5
)	1) присоединить содержимое стека до скобки в обратном порядке к выходной строке; 2) удалить скобку из стека.	*	192 , , 8 , 4 , -, , +, , , 36 , 5 , -
			 */

			/*
( 192 + 8 ) * ( 36 - 5 )
Символ	Операция	Стек	Выходная строка
(	поместить в стек	(	
192 	добавить к выходной строке	(	192
+	поместить в стек	(, +	192
8 	добавить к выходной строке	(, +	192 , 8
)	1) присоединить содержимое стека до скобки в обратном порядке к выходной строке; 2) удалить скобку из стека.		192 , 8 , +
	добавить к выходной строке		192 , 8 , +,
*	поместить в стек	*	192 , 8 , +,
	добавить к выходной строке	*	192 , 8 , +, ,
(	поместить в стек	*, (	192 , 8 , +, ,
36 	добавить к выходной строке	*, (	192 , 8 , +, , , 36
-	поместить в стек	*, (, -	192 , 8 , +, , , 36
5 	добавить к выходной строке	*, (, -	192 , 8 , +, , , 36 , 5
)	1) присоединить содержимое стека до скобки в обратном порядке к выходной строке; 2) удалить скобку из стека.	*	192 , 8 , +, , , 36 , 5 , -
			 */

			for (int i = 0; i < baseString.Length; i++)
			{
				char curSym = baseString[i];
				if (char.IsDigit(curSym))
				{
					digVal += curSym.ToString();
				}
				else if (operations.Contains(curSym))
				{
					oper.Push(curSym);
				}
				else
				{
					switch (curSym)
					{
						case '(':
							oper.Push(curSym);
							break;
						case ')':
							// Надо вытаскивать все, пока не получим '('
							char opSym;
							while ((opSym = oper.Pop()) != '\0')
							{
								if (opSym != '(')
								{
									res += opSym.ToString() + digVal;
								}
								else
								{ break; }
							}
							break;
						default:
							break;
					}
				}
			}

			////string tempValue = "";
			////			bool flag = false;
			////char oper;

			//for (int i = 0; i < baseString.Length; i++)
			//{
			//	char curSym = baseString[i];

			//	if (char.IsDigit(curSym))
			//	{
			//		// Это число
			//		switch (st.Length)
			//		{
			//			case 0:
			//				// В стеке вообще ничего нет
			//				st.Push(curSym.ToString());
			//				break;
			//			case 1:
			//				// В стеке что-то есть. Получаем, проверяем.
			//				string val = st.Pop();
			//				if (char.IsDigit(val[0]))
			//				{
			//					// Это у нас число
			//					val += curSym.ToString();
			//					st.Push(val);
			//				}
			//				break;
			//			default:
			//				// В стеке 2 значения

			//				break;
			//		}
			//	}
			//	else if (operations.Contains(curSym))
			//	{
			//		// Какая-то операция
			//	}

			//	if (operations.Contains(curSym))
			//	//(operations.Contains(curSym) && st.Length != 0)
			//	{
			//		switch (st.Length)
			//		{
			//			case 1:
			//				st.Push(curSym.ToString());
			//				break;
			//			case 2:
			//				string val = st.Pop();
			//				res = res + " " + st.Pop() + " " + val + " ";
			//				st.Push(curSym.ToString());
			//				break;
			//			default:
			//				st.Push(curSym.ToString());
			//				//st.Push(curSym.ToString());
			//				//st.Pop();
			//				break;
			//		}
			//	}
			//	else if (char.IsDigit(curSym))
			//	{
			//		if (st.Length < 2)
			//		{
			//			string val = st.Pop();

			//			if (val == null)
			//			{
			//				st.Push(curSym.ToString());
			//			}
			//			else if (char.IsDigit(val[0]))
			//			{
			//				val += curSym.ToString();
			//				st.Push(val);
			//			}
			//			else
			//			{
			//				st.Push(val);
			//				st.Push(curSym.ToString());
			//			}

			//		}
			//		else
			//		{
			//			if (res.Length == 0)
			//			{
			//				res = st.Pop() + " " + st.Pop() + " " + curSym.ToString();
			//			}
			//			else
			//			{
			//				string val = st.Pop();
			//				res = res + " " + st.Pop() + val;
			//			}
			//			//res = res + (res.Length == 0 ? "" : " ") + st.Pop() + " " + st.Pop() + " " + curSym.ToString();
			//		}
			//	}
			//}
			/*

			//if (char.IsDigit(curSym) || operations.Contains(curSym))
			//{
			//	if (curSym == ' ')
			//	{
			//		// Пробел, чего-то от чего-то отделено
			//		switch (st.Length)
			//		{
			//			case 0:
			//			case 1:
			//				st.Push(tempValue);
			//				break;
			//			default:
			//				res = st.Pop() + st.Pop() + tempValue + res;
			//				break;
			//		}
			//		tempValue = "";
			//	}
			//	else
			//	{
			//		tempValue = tempValue + curSym.ToString();
			//	}
			//}
		}
			*/
			// postfix  : 1 12 + 3 * 5 -
			// prefix   : + 1 12 * 3 - 5

			Console.WriteLine($"Base string : {baseString}");
			Console.WriteLine($"Potfix string : {res}");

			Console.WriteLine("Нажмите любую клавишу");
			Console.ReadKey();

		}
	}
}
