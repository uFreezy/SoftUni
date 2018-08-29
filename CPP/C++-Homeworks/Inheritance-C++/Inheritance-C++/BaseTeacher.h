#pragma once
#include "SchoolPerson.h"

class BaseTeacher : public SchoolPerson
{
protected:
	float _salary;
public:
	BaseTeacher(unsigned short id, std::string name, std::string currentCourseName, float salary);
	~BaseTeacher();
	void setSalary(float salary);
};
