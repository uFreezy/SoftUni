/*
	Username: Freezy
	Name: Denis Neychev
	Note: Thanks for the awesome course!
*/
#include <iostream>
#include <string>
#include <sstream>
#include <map>
#include <vector>

std::vector<std::string> split(std::string str, char delimiter)
{
	std::vector<std::string> internal;
	std::stringstream ss(str);
	std::string tok;

	while (std::getline(ss, tok, delimiter))
	{
		internal.push_back(tok);
	}

	return internal;
}

int main()
{
	std::string inputString;
	std::map<unsigned short, unsigned short> num_map;
	getline(std::cin, inputString);
	std::vector<std::string> nums = split(inputString, ' ');

	for each (std::string num in nums)
	{
		unsigned short number = (unsigned short)stoi(num);
		// If true it mean that the element exist => increment occurance
		if (num_map.find(number) != num_map.end())
		{
			num_map.at(number)++;
		}
		else
		{
			// else create new entry with occurance 1
			num_map.insert(std::pair<unsigned short, unsigned short>(number, 1));
		}
	}

	std::pair<unsigned short, unsigned short> highestNumb(0, 0);

	// Checks all the occurances to see which value has the most 
	for each (std::pair<unsigned short, unsigned> num_pair in num_map)
	{
		if (num_pair.second > highestNumb.second)
		{
			highestNumb = num_pair;
		}
		else if (num_pair.second == highestNumb.second && num_pair.first > highestNumb.first)
		{
			highestNumb = num_pair;
		}
	}

	std::cout << highestNumb.first << std::endl;

	return 0;
}
