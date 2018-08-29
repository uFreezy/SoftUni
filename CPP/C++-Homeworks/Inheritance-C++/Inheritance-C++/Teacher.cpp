#include "Teacher.h"
#include <iostream>

Teacher::Teacher(
	unsigned short id,
	std::string name,
	std::string currentCourseName,
	float monthlySalary,
	unsigned short daysPassedSinceJoin) :
	BaseTeacher::BaseTeacher(id, name, currentCourseName, monthlySalary)
{
	setMonthlySalary(monthlySalary);
	setDaysPassedSinceJoin(daysPassedSinceJoin);
}

Teacher::~Teacher()
{
}

float Teacher::monthlySalary()
{
	return this->_monthlySalary;
}

void Teacher::setMonthlySalary(float monthlySalary)
{
	if (monthlySalary > 0)
	{
		this->_monthlySalary = monthlySalary;
	}
	else
	{
		std::cout << "The monthly salary provided is invaild." << std::endl;
	}
}

unsigned short Teacher::daysPassedSinceJoin()
{
	return this->_daysPassedSinceJoin;
}

void Teacher::setDaysPassedSinceJoin(unsigned short daysPassedSinceJoin)
{
	this->_daysPassedSinceJoin = daysPassedSinceJoin;
}
