#include "SchoolPerson.h"
#include <iostream>
#include <string>

SchoolPerson::SchoolPerson(unsigned short id, std::string name, std::string currentCourseName)
{
	setId(id);
	setName(name);
	setCurrentCourseName(currentCourseName);
}

SchoolPerson::~SchoolPerson()
{
}

unsigned short SchoolPerson::id() {
	return this->_id;
}

void SchoolPerson::setId(unsigned short id) {
	this->_id = id;
}

std::string SchoolPerson::name() {
	return this->_name;
}

void SchoolPerson::setName(std::string name) {
	if (!name.empty()) {
		this->_name = name;
	}
	else {
		std::cout << "The name cannot be empty" << std::endl;
	}
}

std::string SchoolPerson::currentCourseName() {
	return this->_currentCourseName;
}

void SchoolPerson::setCurrentCourseName(std::string currentCourseName) {
	if (!currentCourseName.empty()) {
		this->_currentCourseName = currentCourseName;
	}
	else {
		std::cout << "Current course name cannot be empty." << std::endl;
	}
	
}