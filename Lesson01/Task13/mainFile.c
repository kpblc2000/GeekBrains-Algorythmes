#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <string.h>
#include <math.h>

/*
������� ����� kpblc2000@yandex.ru
��������� � ��������� ������. ������� ����
���� 1, ������ 12
�������� �������, ������������ ��������� ����� �� 1 �� 100
�) � �������������� ����������� ������� rand();
�) ��� ������������� ����������� ������� rand();
*/

/// <summary>
/// ���������� ���������������� ����� �� ������� x[n+1]=(A*x[n]+B)%M
/// </summary>
/// <param name="A">����������� A � ������� x[n+1]=(A*x[n]+B)%M</param>
/// <param name="B">����������� B � ������� x[n+1]=(A*x[n]+B)%M</param>
/// <param name="M">����������� M � ������� x[n+1]=(A*x[n]+B)%M</param>
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
/// ��������� ���������� �������� ������ �����
/// </summary>
/// <param name="Digit">�������������� �����</param>
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

#pragma region ��������������� ����� � �������������� rand()
	srand(time(NULL));
	value = rand() % 100 + 1;
	printf("����������� ����������: %d", value);
#pragma endregion

#pragma region ����������� ������� �������� ���������������� �����
	value = (int)(GetRnd(235, 665, 1568) * 100);
	printf("\n����������� ���������: %d", value);
#pragma endregion

	return 0;
}