#pragma once
#include "SchoolPerson.h"

class Student : public SchoolPerson
{
private:
	unsigned short _currentCoursePoints;
	unsigned short _averageMark;

public:
	Student(
		unsigned short id,
		std::string name,
		std::string currentCourseName,
		unsigned short currentCoursePoints,
		float averageMark);
	~Student();

	unsigned short currentCoursePoints();
	void setCurrentCoursePoints(unsigned short currentCoursePoints);
	float averageMark();
	void setAverageMark(float averageMark);
};
