#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
������� ����� kpblc2000@yandex.ru
��������� � ��������� ������. ������� ����
���� 1, ������ 9
���� ����� ������������� ����� N � K. ��������� ������ �������� �������� � ���������,
����� ������� �� ������� ������ N �� K, � ����� ������� ����� �������
*/

int main()
{
	int n = 130;
	int k = 16;
	printf("%d / %d :\n", n, k);
	int multipl = 0;
	while (n >= k)
	{
		n -= k;
		multipl++;
	}
	printf("%d * %d + %d", multipl, k, n);
	return 0;
}