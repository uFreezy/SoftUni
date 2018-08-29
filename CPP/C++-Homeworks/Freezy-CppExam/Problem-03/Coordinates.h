#pragma once
class Coordinates
{
private:
	double _x;
	double _y;
public:
	Coordinates();
	Coordinates(double x, double y);
	~Coordinates();
	double x();
	void setX(double x);
	double y();
	void setY(double y);
};
