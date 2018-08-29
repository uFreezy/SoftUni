#include <iostream>
#include <vector>
#include <string>
#include "Person.h"

const std::string secretPass = "12344321";
std::vector<Person> voters;

// Parses char as enum gender.
Gender parseGender(char gender)
{
	switch (gender)
	{
	case 'M':
		{
			return Male;
		}

	case 'F':
		{
			return Female;
		}

	default:
		{
			return Gender::Other;
		}
	}
}

// Parses char as enum ethnos
Ethnos parseEthnos(char ethnos)
{
	switch (ethnos)
	{
	case 'W':
		{
			return White;
		}
	case 'B':
		{
			return Black;
		}
	case 'L':
		{
			return Latino;
		}
	case 'G':
		{
			return Gypsy;
		}
	default:
		{
			return Ethnos::Else;
		}
	}
}

// Returns Vote obj based on char input
Vote parseVote(char vote)
{
	switch (vote)
	{
	case 'S':
		{
			return Vote(VoteChoice::Stay);
		}
	case 'L':
		{
			return Vote(VoteChoice::Leave);
		}
	default:
		break;
	}
}

// Puts some initial testing data.
void seed()
{
	for (size_t i = 0; i < 10; i++)
	{
		if (i % 2 == 0)
		{
			voters.push_back(Person("Gosho", i, Gender::Male, Ethnos::Gypsy, "Sofia", Vote(Stay)));
		}
		else
		{
			voters.push_back(Person("Penka", i, Gender::Female, Ethnos::Latino, "Sofia", Vote(Leave)));
		}
	}
}



int main()
{
	seed();
	std::cout << "Press enter to begin the program." << std::endl;
	std::string initInput;
	getline(std::cin, initInput);

	if (secretPass == initInput)
	{
		std::cout << "1. Results in percent." << std::endl
			<< "2. Results in numbers." << std::endl
			<< "3. Results based on Age." << std::endl
			<< "4. Results based on name." << std::endl
			<< "5. Results based on Ethnos." << std::endl
			<< "6. Results based on Living city/village." << std::endl
			<< "7. All possible for age, living city/village, ethnos." << std::endl
			<< "8. Give specific result for an Age, Name, Ethnos, Gender or Living City/Village." << std::endl;

		char input;
		std::cin >> input;

		unsigned int stayTotal = 0, leaveTotal = 0;

		switch (input)
		{
		case '1':
			{
				for (Person voter : voters)
				{
					if (voter.vote()->voteChoice() == Stay)
					{
						stayTotal++;
					}
					else
					{
						leaveTotal++;
					}
				}

				if (stayTotal + leaveTotal > 0)
				{
					auto stayPercentage = ((stayTotal * 100) / (stayTotal + leaveTotal));
					auto leavePercentage = ((leaveTotal * 100) / (stayTotal + leaveTotal));

					std::cout << "Stay: " << stayPercentage << "%" << std::endl;
					std::cout << "Leave: " << leavePercentage << "%" << std::endl;
				}
				else
				{
					std::cout << "No records." << std::endl;
				}

				break;
			}
		case '2':
			{
				std::cout << "Stay: " << stayTotal << std::endl;
				std::cout << "Leave: " << leaveTotal << std::endl;
				break;
			}
		case '3':
			{
				std::cout << "Enter the age: ";
				std::string ageStr;
				std::cin >> ageStr;

				unsigned int age, stay = 0, leave = 0;
				age = stoi(ageStr);

				for (Person voter : voters)
				{
					if (voter.age() == age)
					{
						switch (voter.vote()->voteChoice())
						{
						case Stay:
							{
								stay++;
							}
						case Leave:
							{
								leave++;
							}
						}
					}
				}

				std::cout << age <<" y.o - " << stay <<" Stay, "<< leave <<" Leave" << std::endl;
				break;
			}
		case '4':
		{
			std::cout << "Enter name: ";
			std::string nameToCheck;
			unsigned int stay = 0, leave = 0;
			std::cin >> nameToCheck;

			for (Person voter : voters)
			{
				if (voter.name() == nameToCheck)
				{
					switch (voter.vote()->voteChoice())
					{
					case Stay:
						{
							stay++;
							break;
						}
					case Leave:
						{
							leave++;
							break;
						}
					}
				}
			}

			std::cout << nameToCheck << " - " << stay << " Stay, " << leave << " Leave" << std::endl;

			break;
		}
		case '5':
			{
				break;
			}
		case '6':
			{
				break;
			}
		case '7':
			{
				break;
			}
		case '8':
			{
				break;
			}
		}
	}
	else
	{
		std::string ageStr;
		float age;
		std::string name;
		std::string city;
		Gender gender;
		Ethnos ethnos;

		std::cout << "Please enter your name: ";
		std::cin >> name;

		std::cout << "Please enter your age: ";
		std::cin >> ageStr;
		age = stof(ageStr);

		std::cout << "Please enter your city: ";
		std::cin >> city;

		std::cout << "Please choose your gender (M - Male, F - Female or O - Other) : ";
		char genderChoice;
		std::cin >> genderChoice;
		gender = parseGender(genderChoice);

		std::cout << "Please enter your ethnos (W - White, B - Black, L - Latino, G - Gypsy, O - Other): ";
		char ethnosChoice;
		std::cin >> ethnosChoice;
		ethnos = parseEthnos(ethnosChoice);

		std::cout << "Please enter your vote (S - Stay, L - Leave )";
		char voteChoice;
		std::cin >> voteChoice;

		voters.push_back(Person(name, age, gender, ethnos, city, parseVote(voteChoice)));
	}

	return 0;
}
