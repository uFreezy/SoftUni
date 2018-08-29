#include "Enviorment.h"

Enviorment::Enviorment(unsigned int identifier, std::string name, float gravity):
	Object(identifier, name)
{
	this->setGravity(gravity);
}

Enviorment::~Enviorment()
{
}

float Enviorment::gravity()
{
	return this->_gravity;
}

void Enviorment::setGravity(float gravity)
{
	if (gravity > 0)
	{
		this->_gravity = gravity;
	}
	else
	{
		throw "Gravity cannot be negative.";
	}
}
