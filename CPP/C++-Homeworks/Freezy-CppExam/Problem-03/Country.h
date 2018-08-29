#pragma once
#include <string>
#include "HolidayLocation.h"
#include <vector>
#include <mutex>

class Country
{
private:
	std::string _name;
	std::vector<HolidayLocation> _beaches;
	std::string _currency;
	double _tradeCourseEUR;
	void _printLocationInfo(HolidayLocation beach);
public:
	Country(
		std::string name,
		std::vector<HolidayLocation> beaches,
		std::string currency,
		double tradeCourse);
	~Country();
	std::string name();
	void setName(std::string name);
	std::vector<HolidayLocation> beaches();
	void setBeaches(std::vector<HolidayLocation> beaches);
	std::string currency();
	void setCurrency(std::string currency);
	double tradeCourseEUR();
	void setTradeCourseEUR(double tradeCourse);

	void addNewBeach(HolidayLocation beach);
	void removeBeachByName(std::string name);
	void searchForHoliday(double averagePrice, std::string name, double priceOfOrangeJuice);
	// TODO: Add one more method to search by params of choice
};
