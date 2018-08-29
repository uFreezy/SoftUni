/*
	Username: Freezy
	Name: Denis Neychev
	Note: Thanks for the awesome course!
*/
#include<iostream>
#include "HolidayLocation.h"
#include "Country.h"
#include <thread>
#include <algorithm>

std::vector<Country> contries;

void searchForHoliday(double averagePrice, std::string name, double priceOfOrangeJuice)
{
	std::vector<HolidayLocation>::const_iterator it;
	for each (Country country in contries)
	{
		std::vector<HolidayLocation> beaches = country.beaches();

		do
		{
			it = std::find_if(
				beaches.begin(),
				beaches.end(),
				[&name, &averagePrice, &priceOfOrangeJuice](HolidayLocation& obj)
				{
					return (
						obj.name() == name &&
						obj.averagePriceForRoom() == averagePrice &&
						obj.priceOfOrangeJuice() == priceOfOrangeJuice);
				});

			if (it != beaches.end())
			{
				HolidayLocation beach = *it;
				beach.printInfo();
				beaches.erase(it);
				it = beaches.begin();
			}
		}
		while (it != beaches.end());
	}
}

int main()
{
	HolidayLocation loc = HolidayLocation("test",
	                                      Coordinates(1, 1), SAND, POOL, 1, 1, 123, 1.55, 1231, 2, 3, 4);
	HolidayLocation loc2 = HolidayLocation("test2",
	                                       Coordinates(1, 1), SAND, POOL, 1, 1, 123, 1.55, 1231, 2, 3, 4);
	HolidayLocation loc3 = HolidayLocation("test3",
	                                       Coordinates(1, 1), SAND, POOL, 1, 1, 123, 1.55, 1231, 2, 3, 4);
	HolidayLocation loc4 = HolidayLocation("test",
	                                       Coordinates(1, 1), SAND, POOL, 1, 1, 123, 1.55, 1231, 2, 3, 4);

	std::vector<HolidayLocation> col;
	col.push_back(loc);
	col.push_back(loc2);
	col.push_back(loc3);
	col.push_back(loc4);

	contries.push_back(Country("test", col, "USD", 1.50));

	std::thread testThread(searchForHoliday, 1.55, "test", 4);
	testThread.join();
	return 0;
}
