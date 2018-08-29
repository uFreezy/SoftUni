#pragma once
#include <string>
#include "TerrarianType.h"
#include "WaterpoolType.h"
#include "Coordinates.h"

class Coordinates; // Forward declaration

class HolidayLocation
{
private:
	std::string _name;
	Coordinates _location;
	TerrarianType _terrarianType;
	WaterpoolType _waterpoolType;
	unsigned short _terrarianCleaness;
	unsigned short _waterCleaness;
	unsigned int _visitorsPerYear;
	double _averagePriceForRoom;
	unsigned short _numberOfPubs;
	double _priceOfDaikiri;
	double _priceOfMojito;
	double _priceOfOrangeJuice;

public:
	HolidayLocation(
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
		double orangeJuice);
	~HolidayLocation();
	std::string name();
	void setName(std::string name);
	Coordinates location();
	void setLocation(Coordinates cor);
	TerrarianType terrarianType();
	void setTerrarianType(TerrarianType terType);
	WaterpoolType waterpoolType();
	void setWaterpoolType(WaterpoolType watpoolType);
	unsigned short terrarianCleaness();
	void setTerrarianCleaness(unsigned short terrCleaness);
	unsigned short waterCleaness();
	void setWaterCleaness(unsigned short watCleaness);
	unsigned int visitorsPerYear();
	void setVisitorsPerYear(unsigned int visitorsPerYear);
	double averagePriceForRoom();
	void setAveragePriceForRoom(double avgPriceRoom);
	unsigned short numberOfPubs();
	void setNumberOfPubs(unsigned short numberOfPubs);
	double priceOfDaikiri();
	void setPriceOfDaikiri(double priceOfDaikiri);
	double priceOfMojito();
	void setPriceOfMojito(double priceOfMojito);
	double priceOfOrangeJuice();
	void setPriceOfOrangeJuice(double priceOfOrangeJuice);
	void printInfo();
};
