#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
Алексей Кулик kpblc2000@yandex.ru
Алгоритмы и структуры данных. Базовый курс
Урок 1, задача 12
Написать функцию нахождения максимального из 3 чисел
*/

double EvaluateMaximum(double Value1, double Value2, double Value3)
{
	double max = Value1 > Value2 ? Value1 : Value2;
	max = Value3 > max ? Value3 : max;
	return max;
}

int main()
{
	char* locale = setlocale(LC_ALL, "");

	double a, b, c;
	printf("Введите первое число : ");
	scanf("%lf", &a);
	printf("Введите второе число : ");
	scanf("%lf", &b);
	printf("Введите третье число : ");
	scanf("%lf", &c);

	printf("\nНаибольшее значение равно %f", EvaluateMaximum(a, b, c));

	return 0;
}