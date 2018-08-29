#include "Coordinates.h"

Coordinates::Coordinates()
{
}

Coordinates::Coordinates(double x, double y)
{
	this->setX(x);
	this->setY(y);
}

double Coordinates::x()
{
	return this->_x;
}

void Coordinates::setX(double x)
{
	this->_x = x;
}

double Coordinates::y()
{
	return this->_y;
}

void Coordinates::setY(double y)
{
	this->_y = y;
}

Coordinates::~Coordinates()
{
}
