#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>
#include <math.h>

/*
Алексей Кулик kpblc2000@yandex.ru
Алгоритмы и структуры данных. Базовый курс
Урок 1, задача 8
Ввести a и b и вывести квадраты и кубы чисел от a до b

Решение не универсальное - можно запросто получить переполнение int, если запрашивать обработку больших чисел.
*/

/// <summary>
/// Возведение в квадат целого числа.
/// </summary>
/// <param name="value">Возводимое число</param>
/// <returns></returns>
int Quadr(int value)
{
	return value * value;
}

/// <summary>
/// Возведение числа в кубическую степень
/// </summary>
/// <param name="value">Возводимое число</param>
/// <returns></returns>
int Cubic(int value)
{
	return Quadr(value) * value;
}

/// <summary>
/// Рекурсивная функция вычисления степени числа
/// </summary>
/// <param name="value">Возводимое число</param>
/// <param name="exp">Необходимая степень</param>
/// <returns></returns>
int Power(int value, int expon)
{
	// Отказался от использования, проще взять из методички
	long res = 1;
	while (expon)
	{
		if (expon % 2)
		{
			expon--;
			res *= value;
		}
		else
		{
			value *= value;
			expon /= 2;
		}
	}
	return res;
	/*int eval;
	int last;
	switch (expon)
	{
	case 1:
		return value;
		break;
	case 2:
		return value * value;
		break;
	default:
		last = expon % 2;
		eval = Power(value, expon / 2);
		if (last == 0)
		{
			return eval * eval;
		}
		else
		{
			return Power(value, expon - 1) * value;
		}
		break;
	}*/
}

int main()
{
	char* locale = setlocale(LC_ALL, "");

	int a;
	int b;

#pragma region Вариант с использованием math.h
	a = 1;
	b = 10;
	printf("Вариант с использованием math.h:\n");
	while (a <= b)
	{
		double res1 = pow(a, 2);
		double res2 = pow(a, 3);
		printf("\n %ld \t %0.f \t %0.f", a, res1, res2);
		a++;
	}
#pragma endregion

#pragma region Вариант с использованием собственных функций
	a = 1;
	b = 10;
	printf("\n\nВариант с использованием ограниченных функций:");
	while (a <= b)
	{
		int res1 = Quadr(a);
		int res2 = Cubic(a);
		printf("\n %ld \t %ld \t %ld", a, res1, res2);
		a++;
	}
#pragma endregion

#pragma region Рекурсия
	a = 1;
	b = 10;
	printf("\n\nВариант с использованием рекурсии:\n");
	while (a <= b)
	{
		for (int ex = 1; ex < 5; ex++)
		{
			printf("\t %ld ", Power(a, ex));
		}
		printf("\n");
		a++;
	}
#pragma endregion

	return 0;
}