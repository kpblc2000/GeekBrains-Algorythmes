#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
������� ����� kpblc2000@yandex.ru
��������� � ��������� ������. ������� ����
���� 1, ������ 7
� ���������� �������� �������� ���������� ���� ����� ��������� ����� (x1, y1, x2, y2).
��������� ����������, ��������� �� � ���� � ������ ����� ��� ���
*/

int main()
{
	char* locale = setlocale(LC_ALL, "");

	int x1 = 0;
	int y1 = 0;
	int x2 = 0;
	int y2 = 0;
	printf("������� ����� ����� ������� ���� : ");
	scanf("%d", &x1);
	printf("������� ����� ������ ������� ���� : ");
	scanf("%d", &y1);
	printf("������� ����� ����� ������� ���� : ");
	scanf("%d", &x2);
	printf("������� ����� ������ ������� ���� : ");
	scanf("%d", &y2);

	printf(((x1 + y1) % 2 == (x2 + y2) % 2) ? "True" : "False");
	printf("\n");

	return 0;
}