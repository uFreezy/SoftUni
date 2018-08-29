/*
	Username: Freezy
	Name: Denis Neychev
	Note: Thanks for the awesome course!
*/
#include <iostream>
#include <string>
#include <vector>
#include <sstream>

std::vector<std::string> split(std::string str, char delimiter)
{
	std::vector<std::string> internal;
	std::stringstream ss(str);
	std::string tok;

	while (getline(ss, tok, delimiter))
	{
		internal.push_back(tok);
	}

	return internal;
}

int main()
{
	std::string inputString;
	getline(std::cin, inputString);
	std::vector<std::string> params = split(inputString, ' ');

	int a = std::stoi(params.at(0));
	int b = std::stoi(params.at(1));
	int c = std::stoi(params.at(2));

	double x1 = (-b + sqrt(b * b - 4 * a * c)) / (2 * a);
	double x2 = (-b - sqrt(b * b - 4 * a * c)) / (2 * a);

	double d = (b * b) - (4 * a * c);

	if (d == 0)
	{
		printf("%.2g , %.2f", x1, x1);
	}
	else if (d > 0)
	{
		printf("%.2f ,", x1);
		printf(" %.2f\n", x2);
	}
	else
	{
		std::cout << "nan, nan" << std::endl;
	}

	return 0;
}
