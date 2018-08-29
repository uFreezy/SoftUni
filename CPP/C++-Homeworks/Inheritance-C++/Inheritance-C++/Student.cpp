#include "Student.h"
#include <iostream>

Student::Student(
	unsigned short id,
	std::string name,
	std::string currentCourseName,
	unsigned short currentCoursePoints,
	float averageMark) :
	SchoolPerson::SchoolPerson(id, name, currentCourseName)
{
	setCurrentCoursePoints(currentCoursePoints);
	setAverageMark(averageMark);
}

Student::~Student()
{
}

unsigned short Student::currentCoursePoints()
{
	return _currentCoursePoints;
}

void Student::setCurrentCoursePoints(unsigned short currentCoursePoints)
{
	if (currentCoursePoints <= 100)
	{
		_currentCoursePoints = currentCoursePoints;
	}
	else
	{
		std::cout << "Current course points are invalid." << std::endl;
	}
}

float Student::averageMark()
{
	return _averageMark;
}

void Student::setAverageMark(float averageMark)
{
	if (averageMark >= 2.00 || averageMark <= 6.00)
	{
		_averageMark = averageMark;
	}
	else
	{
		std::cout << "The average mark is invalid." << std::endl;
	}
}
