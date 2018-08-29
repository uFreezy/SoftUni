#pragma once
#include "BaseTeacher.h"

class GuestTeacher : public BaseTeacher
{
private:
	float _courseSalary;
public:
	GuestTeacher(unsigned short id, std::string name, std::string currentCourseName, float salary);
	~GuestTeacher();
	float courseSalary();
	void setCourseSalary(float courseSalary);
};
