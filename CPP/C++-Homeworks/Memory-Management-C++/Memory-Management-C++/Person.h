#pragma once
#include <iostream>
#include "Gender.h"
#include "Ethnos.h"
#include <memory>
#include "Vote.h"

class Vote;

class Person
{
private:
	std::string _name;
	unsigned int _age;
	Gender _gender;
	Ethnos _ethnos;
	std::string _town;
	Vote* _vote;
public:
	Person(
		std::string name,
		unsigned int age,
		Gender gender,
		Ethnos ethnos,
		std::string town,
		Vote vote);
	~Person();
	std::string name();
	void setName(std::string name);
	unsigned int age();
	void setAge(unsigned int age);
	Gender& gender();
	void setGender(Gender gender);
	Ethnos& ethnos();
	void setEthnos(Ethnos ethnos);
	std::string town();
	void setTown(std::string town);
	Vote* vote();
	void setVote(Vote vote);
};
