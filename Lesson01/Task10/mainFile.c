#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
Алексей Кулик kpblc2000@yandex.ru
Алгоритмы и структуры данных. Базовый курс
Урок 1, задача 10
Дано целое число N (>0). С помощью операций деления нацело и взятия остатка от деления
определить, имеются ли в записи числа N нечетные цифры. Если имеются, то вывести True, если нет —  вывести False
*/

int main()
{
	int n = 124678000;
	int f = 0;
	printf("%d\n", n);
	while (n > 0)
	{
		f = (n % 10) % 2;
		n = n / 10;
		if (f)
		{
			break;
		}
	}
	printf(f ? "True" : "False");
	return 0;
}