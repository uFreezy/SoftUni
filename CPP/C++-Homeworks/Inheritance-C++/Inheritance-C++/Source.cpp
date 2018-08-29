#include "SchoolPerson.h"
#include "Student.h"
#include "BaseTeacher.h"
#include "Teacher.h"
#include "GuestTeacher.h"
#include <iostream>
#include <vector>
#include <sstream>

namespace types
{
	enum PersonType
	{
		Student = 1,
		Teacher = 2,
		GuestTeacher = 3
	};
}

static std::vector<Student> students;
static std::vector<Teacher> teachers;
static std::vector<GuestTeacher> guestTeachers;

std::vector<std::string>& split(const std::string& s, char delim, std::vector<std::string>& elems)
{
	std::stringstream ss(s);
	std::string item;
	while (getline(ss, item, delim))
	{
		elems.push_back(item);
	}
	return elems;
}

std::vector<std::string> split(const std::string& s, char delim)
{
	std::vector<std::string> elems;
	split(s, delim, elems);

	return elems;
}


void getDataById(int id, types::PersonType type)
{
	bool entryIsFound = false;

	switch (type)
	{
	case types::Student:

		if (!students.empty())
		{
			for each (Student st in students)
			{
				if (st.id() == id)
				{
					entryIsFound = true;
					std::cout <<
						"Id: " << st.id() <<
						"\nName: " << st.name() <<
						"\nCurrent course: " << st.currentCourseName() <<
						"\nCurrent course points: " << st.currentCoursePoints() <<
						"\nAverage grade: " << st.averageMark() << std::endl;
				}
			}

			if (!entryIsFound)
			{
				std::cout << "There is no such student with id: " << id << std::endl;
			}
		}

		break;
	case types::Teacher:

		if (!teachers.empty())
		{
			for each (Teacher tch in teachers)
			{
				if (tch.id() == id)
				{
					entryIsFound = true;

					std::cout <<
						"Id: " << tch.id() <<
						"\nName: " << tch.name() <<
						"\nCurrent course: " << tch.currentCourseName() <<
						"\nMonthly salary: " << tch.monthlySalary() <<
						"\nDays passed since joined: " << tch.daysPassedSinceJoin() << std::endl;
				}
			}

			if (!entryIsFound)
			{
				std::cout << "There is no such teacher with id: " << id << std::endl;
			}
		}
		break;
	case types::GuestTeacher:
		if (!guestTeachers.empty())
		{
			for each (GuestTeacher tch in guestTeachers)
			{
				if (tch.id() == id)
				{
					entryIsFound = true;

					std::cout <<
						"Id: " << tch.id() <<
						"\nName: " << tch.name() <<
						"\nCurrent course: " << tch.currentCourseName() <<
						"\nCourse salary: " << tch.courseSalary() << std::endl;
				}
			}

			if (!entryIsFound)
			{
				std::cout << "There is no such guest teacher with id: " << id << std::endl;
			}

			break;
		default:
			break;
		}

		if (!entryIsFound)
		{
			std::cout << "No entity data found!" << std::endl;
		}
	}
}

void getId(types::PersonType type)
{
	std::cout << "Enter id: ";
	int id;
	std::cin >> id;
	getDataById(id, type);
}

void addData(types::PersonType type)
{
	std::cout << "Enter all the data required to create an entry in one line separated by comma.";

	std::string userInput;
	std::cin >> userInput;
	std::vector<std::string> userData = split(userInput, ',');
	std::string userDataArr[10];
	std::copy(userData.begin(), userData.end(), userDataArr);

	switch (type)
	{
	case types::Student:
		students.push_back(Student(
			(unsigned short)stoi(userDataArr[0]),
			userDataArr[1],
			userDataArr[2],
			(unsigned short)stoi(userDataArr[3]),
			stof(userDataArr[4])));
		break;
	case types::Teacher:
		teachers.push_back(Teacher(
			static_cast<unsigned short>(stoi(userDataArr[0])),
			userDataArr[1],
			userDataArr[2],
			stof(userDataArr[3]),
			(unsigned short)stoi(userDataArr[4])));
		break;
	case types::GuestTeacher:
		guestTeachers.push_back(GuestTeacher(
			(unsigned short)stoi(userDataArr[0]),
			userDataArr[1],
			userDataArr[2],
			stof(userDataArr[3])
		));
		break;
	default:
		break;
	}
}

int main()
{
	std::cout << "Choose how to proceed:" << std::endl;
	std::cout << "1. Get data for student with ID \n"
		"2. Get	data for teacher with ID \n"
		"3. Get	data for guest teacher with ID \n"
		"4. Add	data for new student \n"
		"5. Add	data for new teacher \n"
		"6. Add	data for new guest teacher \n"
		"7. End the program." << std::endl;

	bool isWorking = true;
	int choice;

	while (isWorking)
	{
		std::cin >> choice;

		switch (choice)
		{
		case 1:
			{
				getId(types::Student);
				break;
			}
		case 2:
			{
				getId(types::Teacher);
				break;
			}
		case 3:
			{
				getId(types::GuestTeacher);
				break;
			}
		case 4:
			{
				addData(types::Student);
				break;
			}
		case 5:
			{
				addData(types::Teacher);
				break;
			}
		case 6:
			{
				addData(types::GuestTeacher);
				break;
			}
		case 7:
			{
				isWorking = false;
				break;
			}
		default:
			std::cout << "Invalid choise." << std::endl;
			break;
		}
	}
}
