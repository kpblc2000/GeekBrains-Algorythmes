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
/// ���������� ������� �����. ��������, ��� 1024 ��������� ����� 1000
/// </summary>
/// <param name="Value">�������������� ��������</param>
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
	printf("������� ����� ��� �������� � ������ ����������� ����� : ");
	scanf("%d", &N);

	int decimals = 0;

	// �� �������� ����������� ����� ��� ��� ������������ �� 5 ��� 6. 0 � 1 �� �������� ������������ ������� 
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