#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
������� ����� kpblc2000@yandex.ru
��������� � ��������� ������. ������� ����
���� 1, ������ 6
������ ������� �������� (�� 1 �� 150 ���) � ������� ��� ������ � ����������� ������ "���", "����" ��� "���"
*/

int main(void)
{
	char* locale = setlocale(LC_ALL, "");
	printf("������� �������, ��� : ");
	int ageUser = 0;
	scanf("%d", &ageUser);

	char appendix[5];

	int age = ageUser % 100;
	int subage = age % 10;

	if ((age < 10 || age > 20) && (subage == 1))
	{
		strcpy(appendix, "���");
	}
	else if (subage == 0 || (subage >= 5 && subage <= 9) || (age >= 10 && age <= 20))
	{
		strcpy(appendix, "���");
	}
	else
	{
		strcpy(appendix, "����");
	}

	printf("��� %d %s\n", ageUser, appendix);

	return 0;
}
