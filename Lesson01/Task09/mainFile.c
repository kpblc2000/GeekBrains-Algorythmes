#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
Алексей Кулик kpblc2000@yandex.ru
Алгоритмы и структуры данных. Базовый курс
Урок 1, задача 9
Даны целые положительные числа N и K. Используя только операции сложения и вычитания,
найти частное от деления нацело N на K, а также остаток этого деления
*/

int main()
{
	int n = 130;
	int k = 16;
	printf("%d / %d :\n", n, k);
	int multipl = 0;
	while (n >= k)
	{
		n -= k;
		multipl++;
	}
	printf("%d * %d + %d", multipl, k, n);
	return 0;
}