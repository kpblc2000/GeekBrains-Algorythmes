#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
Алексей Кулик kpblc2000@yandex.ru
Алгоритмы и структуры данных. Базовый курс
Урок 1, задача 11
С клавиатуры вводятся числа, пока не будет введен 0.
Подсчитать среднее арифметическое всех положительных четных чисел, оканчивающихся на 8.
*/

int main()
{
	char* locale = setlocale(LC_ALL, "");

	int counter = 0;
	double sum = 0;
	int value = -1;

	do
	{
		printf("\nВведите целое число :");
		scanf("%d", &value);
		if (value && (value > 0) && (value % 10 == 8))
		{
			counter++;
			sum += value;
		}
	} while (value);

	if (sum != 0 && counter != 0)
	{
		printf("\nСреднее равно %f", sum  / counter);
	}
	else
	{
		printf("\nДанные для подсчета не были введены");
	}

	return 0;
}