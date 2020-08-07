#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>
#include <math.h>

/*
������� ����� kpblc2000@yandex.ru
��������� � ��������� ������. ������� ����
���� 1, ������ 14
����������� �����.
����������� ����� ���������� �����������, ���� ��� ����� ��������� ������ ������ ��������.
��������, 25^2=625.
�������� ���������, ������� ������ ����������� ����� N � ������� �� ����� ��� ����������� �����, �� ������������� N.
*/

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

/// <summary>
/// ���������, �������� �� ����� ������������, �.�. ������ ��������� ������ ������ ��������
/// </summary>
/// <param name="Value">����������� �����</param>
/// <returns>1, ���� ����� �����������. ����� 0</returns>
int IsAntropomorph(int Value)
{
	int len = DigitLen(Value);
	int sq = Value * Value % (int)pow(10, len);
	return (Value == sq ? 1 : 0);
}

int main()
{
	char* locale = setlocale(LC_ALL, "");

	int N;
	printf("������� ����� ��� �������� � ������ ����������� ����� : ");
	scanf("%d", &N);

	for (int i = 0; i <= N; i++)
	{
		if (IsAntropomorph(i))
		{
			printf("\n%d %d", i, i * i);
		}
	}

	return 0;
}