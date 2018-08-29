#include "Person.h"

Person::Person(std::string name, unsigned age, Gender gender, Ethnos ethnos, std::string town, Vote vote)
{
	this->setName(name);
	this->setAge(age);
	this->setGender(gender);
	this->setEthnos(ethnos);
	this->setTown(town);
	this->setVote(vote);
}

Person::~Person()
{
}

std::string Person::name()
{
	return this->_name;
}

void Person::setName(std::string name)
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

unsigned Person::age()
{
	return this->_age;
}

void Person::setAge(unsigned age)
{
	this->_age = age;
}

Gender& Person::gender()
{
	return this->_gender;
}

void Person::setGender(Gender gender)
{
	this->_gender = gender;
}

Ethnos& Person::ethnos()
{
	return this->_ethnos;
}

void Person::setEthnos(Ethnos ethnos)
{
	this->_ethnos = ethnos;
}

std::string Person::town()
{
	return this->_town;
}

void Person::setTown(std::string town)
{
	this->_town = town;
}

Vote* Person::vote()
{
	return this->_vote;
}

void Person::setVote(Vote vote)
{
	this->_vote = new Vote(vote);
}
