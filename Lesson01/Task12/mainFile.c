#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
������� ����� kpblc2000@yandex.ru
��������� � ��������� ������. ������� ����
���� 1, ������ 12
�������� ������� ���������� ������������� �� 3 �����
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
	printf("������� ������ ����� : ");
	scanf("%lf", &a);
	printf("������� ������ ����� : ");
	scanf("%lf", &b);
	printf("������� ������ ����� : ");
	scanf("%lf", &c);

	printf("\n���������� �������� ����� %f", EvaluateMaximum(a, b, c));

	return 0;
}