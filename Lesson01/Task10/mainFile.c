#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
������� ����� kpblc2000@yandex.ru
��������� � ��������� ������. ������� ����
���� 1, ������ 10
���� ����� ����� N (>0). � ������� �������� ������� ������ � ������ ������� �� �������
����������, ������� �� � ������ ����� N �������� �����. ���� �������, �� ������� True, ���� ��� �  ������� False
*/

int main()
{
	int n = 124678000;
	int f = 0;
	printf("%d\n", n);
	while (n > 0)
	{
		f = (n % 10) % 2;
		n = n / 10;
		if (f)
		{
			break;
		}
	}
	printf(f ? "True" : "False");
	return 0;
}