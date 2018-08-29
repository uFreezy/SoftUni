#pragma once
#include "Object.h"

class Character : public Object
{
private:
	float _mass;
	float _jumpSpeed;

public:
	Character(unsigned int identifier, std::string name, float mass, float jumpSpeed);
	~Character();
	float mass();
	void setMass(float mass);
	float jumpSpeed();
	void setJumpSpeed(float jumpSpeed);
};
