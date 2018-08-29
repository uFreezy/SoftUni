#include "GuestTeacher.h"

GuestTeacher::GuestTeacher(
	unsigned short id,
	std::string name,
	std::string currentCourseName,
	float salary) : BaseTeacher::BaseTeacher(id, name, currentCourseName, salary)
{
	setCourseSalary(salary);
}

GuestTeacher::~GuestTeacher()
{
}

float GuestTeacher::courseSalary()
{
	return this->_courseSalary;
}

void GuestTeacher::setCourseSalary(float courseSalary)
{
	this->_courseSalary = courseSalary;
}
