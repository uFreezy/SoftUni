#pragma once
#include "Object.h"

class Enviorment :
	public Object
{
private:
	float _gravity;
public:
	Enviorment(unsigned int identifier, std::string name, float gravity);
	~Enviorment();
	float gravity();
	void setGravity(float gravity);
};
