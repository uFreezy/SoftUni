#include "Object.h"

Object::Object(unsigned int identifier, std::string name)
{
	this->setIdentifier(identifier);
	this->setName(name);
}

Object::~Object()
{
}

unsigned int Object::identifier()
{
	return this->_identifier;
}

void Object::setIdentifier(unsigned int identifier)
{
	this->_identifier = identifier;
}

std::string Object::name()
{
	return this->_name;
}

void Object::setName(std::string name)
{
	if (name.length() > 0)
	{
		this->_name = name;
	}
	else
	{
		throw "Name cannot be empty.";
	}
}
