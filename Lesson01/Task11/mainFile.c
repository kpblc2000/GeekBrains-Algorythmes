#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
������� ����� kpblc2000@yandex.ru
��������� � ��������� ������. ������� ����
���� 1, ������ 11
� ���������� �������� �����, ���� �� ����� ������ 0.
���������� ������� �������������� ���� ������������� ������ �����, �������������� �� 8.
*/

int main()
{
	char* locale = setlocale(LC_ALL, "");

	int counter = 0;
	double sum = 0;
	int value = -1;

	do
	{
		printf("\n������� ����� ����� :");
		scanf("%d", &value);
		if (value && (value > 0) && (value % 10 == 8))
		{
			counter++;
			sum += value;
		}
	} while (value);

	if (sum != 0 && counter != 0)
	{
		printf("\n������� ����� %f", sum  / counter);
	}
	else
	{
		printf("\n������ ��� �������� �� ���� �������");
	}

	return 0;
}