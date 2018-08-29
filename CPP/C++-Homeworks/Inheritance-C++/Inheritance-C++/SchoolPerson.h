#pragma once
#include <string>

class SchoolPerson
{
private:
	unsigned short _id;
	std::string _name;
	std::string _currentCourseName;
public:
	SchoolPerson(unsigned short id, std::string name, std::string currentCourseName);
	~SchoolPerson();

	unsigned short id();
	void setId(unsigned short id);
	std::string name();
	void setName(std::string name);
	std::string currentCourseName();
	void setCurrentCourseName(std::string currentCourseName);
};
