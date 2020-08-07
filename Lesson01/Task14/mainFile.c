#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>
#include <math.h>

/*
Алексей Кулик kpblc2000@yandex.ru
Алгоритмы и структуры данных. Базовый курс
Урок 1, задача 14
Автоморфные числа.
Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата.
Например, 25^2=625.
Напишите программу, которая вводит натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.
*/

/// <summary>
/// Вычисляет количество символов целого числа
/// </summary>
/// <param name="Digit">Обрабатываемое число</param>
/// <returns></returns>
int DigitLen(int Digit)
{
	int res = 0;
	Digit = abs(Digit);
	while (Digit)
	{
		res++;
		Digit /= 10;
	}
	return res;
}

/// <summary>
/// Проверяет, является ли число автоморфрным, т.е. равным последним числам своего квадрата
/// </summary>
/// <param name="Value">Проверяемое число</param>
/// <returns>1, если число автоморфное. Иначе 0</returns>
int IsAntropomorph(int Value)
{
	int len = DigitLen(Value);
	int sq = Value * Value % (int)pow(10, len);
	return (Value == sq ? 1 : 0);
}

int main()
{
	char* locale = setlocale(LC_ALL, "");

	int N;
	printf("Введите число для проверки и вывода автоморфных чисел : ");
	scanf("%d", &N);

	for (int i = 0; i <= N; i++)
	{
		if (IsAntropomorph(i))
		{
			printf("\n%d %d", i, i * i);
		}
	}

	return 0;
}