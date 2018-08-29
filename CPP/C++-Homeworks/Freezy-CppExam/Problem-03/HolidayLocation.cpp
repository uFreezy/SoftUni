#include "HolidayLocation.h"
#include <iostream>

void HolidayLocation::printInfo()
{
	std::cout << "Name: " << this->name() <<
		"\nCoordinates: { X:" << this->location().x() <<
		", Y:" << this->location().y() <<
		"\nTerrarian type: " << this->terrarianType() <<
		"\nWaterpool type: " << this->waterpoolType() <<
		"\nTerrarian cleaness: " << this->terrarianCleaness() <<
		"\nWater cleaness: " << this->waterCleaness() <<
		"\nVisitors per year: " << this->visitorsPerYear() <<
		"\nAverage price for a room per day: " << this->averagePriceForRoom() <<
		"\nNumber of pubs in the area: " << this->numberOfPubs() <<
		"\nPrice of Daikiri: " << this->priceOfDaikiri() <<
		"\nPrice of Mojito: " << this->priceOfMojito() <<
		"\nPrice of Orange juice: " << this->priceOfOrangeJuice() << std::endl;
}

HolidayLocation::HolidayLocation(
	std::string name,
	Coordinates location,
	TerrarianType terrarianType,
	WaterpoolType waterpoolType,
	unsigned short terrarianCleaness,
	unsigned short waterCleaness,
	unsigned int visitorsPerYear,
	double averagePriceForRoom,
	unsigned short numberOfPubs,
	double priceOfDaikiri,
	double priceOfMojito,
	double orangeJuice)
{
	this->setName(name);
	this->setLocation(location);
	this->setTerrarianType(terrarianType);
	this->setWaterpoolType(waterpoolType);
	this->setTerrarianCleaness(terrarianCleaness);
	this->setWaterCleaness(waterCleaness);
	this->setVisitorsPerYear(visitorsPerYear);
	this->setAveragePriceForRoom(averagePriceForRoom);
	this->setNumberOfPubs(numberOfPubs);
	this->setPriceOfDaikiri(priceOfDaikiri);
	this->setPriceOfMojito(priceOfMojito);
	this->setPriceOfOrangeJuice(orangeJuice);
}

HolidayLocation::~HolidayLocation()
{
}

std::string HolidayLocation::name()
{
	return this->_name;
}

void HolidayLocation::setName(std::string name)
{
	this->_name = name;
}

Coordinates HolidayLocation::location()
{
	return this->_location;
}

void HolidayLocation::setLocation(Coordinates cor)
{
	this->_location = cor;
}

TerrarianType HolidayLocation::terrarianType()
{
	return this->_terrarianType;
}

void HolidayLocation::setTerrarianType(TerrarianType terType)
{
	this->_terrarianType = terType;
}

WaterpoolType HolidayLocation::waterpoolType()
{
	return this->_waterpoolType;
}

void HolidayLocation::setWaterpoolType(WaterpoolType watpoolType)
{
	this->_waterpoolType = watpoolType;
}

unsigned short HolidayLocation::terrarianCleaness()
{
	return this->_terrarianCleaness;
}

void HolidayLocation::setTerrarianCleaness(unsigned short terrCleaness)
{
	this->_terrarianCleaness = terrCleaness;
}

unsigned short HolidayLocation::waterCleaness()
{
	return this->_waterCleaness;
}

void HolidayLocation::setWaterCleaness(unsigned short watCleaness)
{
	this->_waterCleaness = watCleaness;
}


unsigned HolidayLocation::visitorsPerYear()
{
	return this->_visitorsPerYear;
}

void HolidayLocation::setVisitorsPerYear(unsigned int visitorsPerYear)
{
	this->_visitorsPerYear = visitorsPerYear;
}

double HolidayLocation::averagePriceForRoom()
{
	return this->_averagePriceForRoom;
}

void HolidayLocation::setAveragePriceForRoom(double avgPriceRoom)
{
	this->_averagePriceForRoom = avgPriceRoom;
}

unsigned short HolidayLocation::numberOfPubs()
{
	return this->_numberOfPubs;
}

void HolidayLocation::setNumberOfPubs(unsigned short numberOfPubs)
{
	this->_numberOfPubs = numberOfPubs;
}

double HolidayLocation::priceOfDaikiri()
{
	return this->_priceOfDaikiri;
}

void HolidayLocation::setPriceOfDaikiri(double priceOfDaikiri)
{
	this->_priceOfDaikiri = priceOfDaikiri;
}

double HolidayLocation::priceOfMojito()
{
	return this->_priceOfMojito;
}

void HolidayLocation::setPriceOfMojito(double priceOfMojito)
{
	this->_priceOfMojito = priceOfMojito;
}

double HolidayLocation::priceOfOrangeJuice()
{
	return this->_priceOfOrangeJuice;
}

void HolidayLocation::setPriceOfOrangeJuice(double priceOfOrangeJuice)
{
	this->_priceOfOrangeJuice = priceOfOrangeJuice;
}
