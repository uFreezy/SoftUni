#pragma once
#include "BaseTeacher.h"

class Teacher : public BaseTeacher
{
private:
	float _monthlySalary;
	unsigned short _daysPassedSinceJoin;
public:
	Teacher
	(unsigned short id,
	 std::string name,
	 std::string currentCourseName,
	 float monthlySalary,
	 unsigned short daysPassedSinceJoin);
	~Teacher();
	float monthlySalary();
	void setMonthlySalary(float monthlySalary);
	unsigned short daysPassedSinceJoin();
	void setDaysPassedSinceJoin(unsigned short daysPassedSinceJoin);
};
