#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <locale.h>
#include <string.h>

/*
Алексей Кулик kpblc2000@yandex.ru
Алгоритмы и структуры данных. Базовый курс
Урок 1, задача 6
Ввести возраст человека (от 1 до 150 лет) и вывести его вместе с последующим словом "год", "года" или "лет"
*/

int main(void)
{
	char* locale = setlocale(LC_ALL, "");
	printf("Введите возраст, лет : ");
	int ageUser = 0;
	scanf("%d", &ageUser);

	char appendix[5];

	int age = ageUser % 100;
	int subage = age % 10;

	if ((age < 10 || age > 20) && (subage == 1))
	{
		strcpy(appendix, "год");
	}
	else if (subage == 0 || (subage >= 5 && subage <= 9) || (age >= 10 && age <= 20))
	{
		strcpy(appendix, "лет");
	}
	else
	{
		strcpy(appendix, "года");
	}

	printf("Вам %d %s\n", ageUser, appendix);

	return 0;
}
