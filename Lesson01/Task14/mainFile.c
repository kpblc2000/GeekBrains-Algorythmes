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
int ValueExp10(int Value)
{
	int res = 1;
	while (Value)
	{
		Value /= 10;
		res *= 10;
	}
	return res;
}

int IsAutomorph(int Value)
{
	return (Value * Value % ValueExp10(Value)) == Value;
}

int main()
{
	char* locale = setlocale(LC_ALL, "");

	int N;
	printf("Введите число для проверки и вывода автоморфных чисел : ");
	scanf("%d", &N);

	int decimals = 0;

	// По свойства автоморфных чисел все они оканчиваются на 5 или 6. 0 и 1 не являются автоморфными числами 
	for (int d = 0; d <= N / 10; d++)
	{
		for (int i = 5; i <= 6; i++)
		{
			int temp = d * 10 + i;
			if (IsAutomorph(temp))
				printf("\n%d %d", temp, temp * temp);
		}
	}

	return 0;
}