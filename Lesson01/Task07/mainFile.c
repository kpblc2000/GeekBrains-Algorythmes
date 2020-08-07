#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
Алексей Кулик kpblc2000@yandex.ru
Алгоритмы и структуры данных. Базовый курс
Урок 1, задача 7
С клавиатуры вводятся числовые координаты двух полей шахматной доски (x1, y1, x2, y2).
Требуется определить, относятся ли к поля к одному цвету или нет
*/

int main()
{
	char* locale = setlocale(LC_ALL, "");

	int x1 = 0;
	int y1 = 0;
	int x2 = 0;
	int y2 = 0;
	printf("Введите номер буквы первого поля : ");
	scanf("%d", &x1);
	printf("Введите номер строки первого поля : ");
	scanf("%d", &y1);
	printf("Введите номер буквы второго поля : ");
	scanf("%d", &x2);
	printf("Введите номер строки второго поля : ");
	scanf("%d", &y2);

	printf(((x1 + y1) % 2 == (x2 + y2) % 2) ? "True" : "False");
	printf("\n");

	return 0;
}