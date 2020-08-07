#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <string.h>
#include <math.h>

/*
Алексей Кулик kpblc2000@yandex.ru
Алгоритмы и структуры данных. Базовый курс
Урок 1, задача 12
Написать функцию, генерирующую случайное число от 1 до 100
а) с использованием стандартной функции rand();
б) без использования стандартной функции rand();
*/

/// <summary>
/// Вычисление псевдослучайного числа по формуле x[n+1]=(A*x[n]+B)%M
/// </summary>
/// <param name="A">Коэффициент A в формуле x[n+1]=(A*x[n]+B)%M</param>
/// <param name="B">Коэффициент B в формуле x[n+1]=(A*x[n]+B)%M</param>
/// <param name="M">Коэффициент M в формуле x[n+1]=(A*x[n]+B)%M</param>
/// <returns></returns>
double GetRnd(int A, int B, int M)
{
	int i;
	double res = 0;
	int ex;
	int x = 1;
	int len = DigitLen(M);
	len -= 1;
	int startLen = len;
	int modul = (int)pow(10, startLen);
	for (i = 0; i < modul; i++)
	{
		x = (A * x + B) % M;
		len += startLen;
		res += x / pow(10, len);
	}
	return res * pow(10, startLen);
}

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

int main()
{
	char* locale = setlocale(LC_ALL, "");

	int value;

#pragma region Псевдослучайные числа с использованием rand()
	srand(time(NULL));
	value = rand() % 100 + 1;
	printf("Стандартный генератора: %d", value);
#pragma endregion

#pragma region Собственная функция создания псевдослучайного числа
	value = (int)(GetRnd(235, 665, 1568) * 100);
	printf("\nСобственный генератор: %d", value);
#pragma endregion

	return 0;
}