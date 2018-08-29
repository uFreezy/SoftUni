#include "Character.h"

Character::Character(unsigned int identifier, std::string name, float mass, float jumpSpeed)
	: Object(identifier, name)
{
	this->setMass(mass);
	this->setJumpSpeed(jumpSpeed);
}

Character::~Character()
{
}

float Character::mass()
{
	return this->_mass;
}


void Character::setMass(float mass)
{
	if (mass > 0)
	{
		this->_mass = mass;
	}
	else
	{
		throw "Mass cannot be negative";
	}
}

float Character::jumpSpeed()
{
	return this->_jumpSpeed;
}

void Character::setJumpSpeed(float jumpSpeed)
{
	if (jumpSpeed > 0)
	{
		this->_jumpSpeed = jumpSpeed;
	}
	else
	{
		throw "Jump speed cannot be a negative number.";
	}
}
