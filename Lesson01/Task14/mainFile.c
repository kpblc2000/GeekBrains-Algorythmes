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
/// Определяет степень числа. Например, для 1024 результат будет 1000
/// </summary>
/// <param name="Value">Обрабатываемое значение</param>
/// <returns></returns>
long ValueExp10(long Value)
{
	long res = 1;
	while (Value)
	{
		Value /= 10;
		res *= 10;
	}
	return res;
}

long IsAutomorph(long Value)
{
	return (Value * Value % ValueExp10(Value)) == Value;
}

int main()
{
	char* locale = setlocale(LC_ALL, "");

	long int N;
	printf("Введите число для проверки и вывода автоморфных чисел : ");
	scanf("%ld", &N);

	// По свойства автоморфных чисел все они оканчиваются на 5 или 6. 0 и 1 по некоторым источникам не считаются автоморфными числами 
	// Для ускорения общего алгоритма выводим 0 и 1 отдельно

	if (N > 0)
	{
		printf("\n0 0");
		if (N > 1)
		{
			printf("\n1 1");

			for (long d = 0; d <= N / 10; d++)
			{
				printf("\n%ld", d);

				for (long i = 5; i <= 6; i++)
				{
					long temp = d * 10 + i;
					if (IsAutomorph(temp))
						printf("\n%ld %ld", temp, temp * temp);
				}
			}
		}
	}

	return 0;
}