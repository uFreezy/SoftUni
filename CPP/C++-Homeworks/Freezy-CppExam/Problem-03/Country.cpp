#include "Country.h"
#include <algorithm>
#include <iostream>
#include <mutex>

std::mutex mutex;

Country::Country(std::string name, std::vector<HolidayLocation> beaches, std::string currency, double tradeCourse)
{
	this->setName(name);
	this->setBeaches(beaches);
	this->setCurrency(currency);
	this->setTradeCourseEUR(tradeCourse);
}

std::string Country::name()
{
	return this->_name;
}

void Country::setName(std::string name)
{
	this->_name = name;
}

std::vector<HolidayLocation> Country::beaches()
{
	return this->_beaches;
}

void Country::setBeaches(std::vector<HolidayLocation> beaches)
{
	this->_beaches = beaches;
}

std::string Country::currency()
{
	return this->_currency;
}

void Country::setCurrency(std::string currency)
{
	this->_currency = currency;
}

double Country::tradeCourseEUR()
{
	return this->_tradeCourseEUR;
}

void Country::setTradeCourseEUR(double tradeCourse)
{
	this->_tradeCourseEUR = tradeCourse;
}

void Country::addNewBeach(HolidayLocation beach)
{
	this->_beaches.push_back(beach);
}

void Country::removeBeachByName(std::string name)
{
	auto it = std::find_if(
		this->_beaches.begin(),
		this->_beaches.end(),
		[&name](HolidayLocation& obj)
		{
			return obj.name() == name;
		});
}


Country::~Country()
{
}
