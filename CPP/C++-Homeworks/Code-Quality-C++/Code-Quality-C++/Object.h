#pragma once
#include <iostream>

class Object
{
private:
	unsigned int _identifier;
	std::string _name;
public:
	Object(unsigned int identifier, std::string name);
	~Object();
	unsigned int identifier();
	void setIdentifier(unsigned int identifier);
	std::string name();
	void setName(std::string name);
};
