using System;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// Урок 5, задача 1
/// Написать программу, которая определяет, является ли введенная скобочная последовательность правильной.
/// Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), 
/// неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{. 
/// Например: (2+(2*2)) или [2/{5*(4+7)}]
/// </summary>

namespace Task1
{

	class CharStack
	{
		// private int _size; // Количество элементо в стеке
		private const int _defSize = 20; // Размер стека по умолчанию
		private char[] _array; // Собственно содержимое стека. Сделаю только под символы
		private int _pos; // Текущее количество элементов в стеке

		public CharStack()
		{
			_array = new char[_defSize];
			_pos = -1;
		}

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

		public int Length
		{
			get
			{
				return _pos;
			}
		}

		public bool IsEmpty { get { return _pos < 0; } }

	}

	class Program
	{
		static void Main()
		{
			//string checkString = ;
			//string incorrectString = ;

			CharStack st;

			foreach (string checkString in new string[] { "(1+2*16)/[(16-400)/{2*3}]", "(1+2*16)/[16-400]/{2*3]" }			)
			{
				st = new CharStack(checkString.Length - 1);

				for (int i = 0; i < checkString.Length; i++)
				{
					char curSym = checkString[i];
					char stackSym;
					switch (curSym)
					{
						case '(':
						case '[':
						case '{':
							st.Push(curSym);
							break;
						case ')':
							stackSym = st.Pop();
							if (stackSym != '(')
							{
								st.Push(stackSym);
								st.Push(curSym);
							}
							break;
						case '}':
							stackSym = st.Pop();
							if (stackSym != '{')
							{
								st.Push(stackSym);
								st.Push(curSym);
							}
							break;
						case ']':
							stackSym = st.Pop();
							if (stackSym != '[')
							{
								st.Push(stackSym);
								st.Push(curSym);
							}
							break;
						default:
							break;
					}
				}

				Console.WriteLine("Строка \"{0}\" {1}является корректной", checkString, st.IsEmpty ? "" : "не ");

			}


			Console.WriteLine("Нажмите любую клавишу...");
			Console.ReadKey();

		}
	}
}
