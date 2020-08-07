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
long ValueExp10(long Value)
{
	long res = 1;
	while (Value)
	{
		Value /= 10;
		res *= 10;
	}
	return res;
}

long IsAutomorph(long Value)
{
	return (Value * Value % ValueExp10(Value)) == Value;
}

int main()
{
	char* locale = setlocale(LC_ALL, "");

	long int N;
	printf("������� ����� ��� �������� � ������ ����������� ����� : ");
	scanf("%ld", &N);

	// �� �������� ����������� ����� ��� ��� ������������ �� 5 ��� 6. 0 � 1 �� ��������� ���������� �� ��������� ������������ ������� 
	// ��� ��������� ������ ��������� ������� 0 � 1 ��������

	if (N > 0)
	{
		printf("\n0 0");
		if (N > 1)
		{
			printf("\n1 1");

			for (long d = 0; d <= N / 10; d++)
			{
				printf("\n%ld", d);

				for (long i = 5; i <= 6; i++)
				{
					long temp = d * 10 + i;
					if (IsAutomorph(temp))
						printf("\n%ld %ld", temp, temp * temp);
				}
			}
		}
	}

	return 0;
}