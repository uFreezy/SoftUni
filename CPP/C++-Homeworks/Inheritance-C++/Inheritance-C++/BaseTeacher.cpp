#include "BaseTeacher.h"

BaseTeacher::BaseTeacher(
	unsigned short id,
	std::string name,
	std::string currentCourseName,
	float salary) : SchoolPerson::SchoolPerson(id, name, currentCourseName)
{
	setSalary(salary);
}

BaseTeacher::~BaseTeacher()
{
}

void BaseTeacher::setSalary(float salary)
{
	this->_salary = salary;
}
