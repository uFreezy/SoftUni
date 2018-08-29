#include "Purchase.h"
#include "StoreItem.h"
#include <iostream>

Purchase::Purchase(
	std::vector<StoreItem> items,
	float totalAmount,
	float givenMoney,
	float changeMoney,
	Store* store) : _items(items), _store(store)
{
	this->setTotalAmount(totalAmount);
	this->setGivenMoney(givenMoney);
	this->setChangeMoney(changeMoney);
}

Purchase::~Purchase()
{
}

std::vector<StoreItem>& Purchase::items()
{
	return this->_items;
}

float Purchase::totalAmount()
{
	return this->_toatlAmount;
}

void Purchase::setTotalAmount(float totalAmount)
{
	if (totalAmount > 0)
	{
		this->_toatlAmount = totalAmount;
	}
	else
	{
		throw "The total amount cannot be negative or 0.";
	}
}

float Purchase::givenMoney()
{
	return this->_givenMoney;
}

void Purchase::setGivenMoney(float givenMoney)
{
	if (givenMoney > 0)
	{
		this->_givenMoney = givenMoney;
	}
	else
	{
		throw "The given money cannot be negative or 0.";
	}
}

float Purchase::changeMoney()
{
	return this->_changeMoney;
}

void Purchase::setChangeMoney(float changeMoney)
{
	if (changeMoney >= 0)
	{
		this->_changeMoney = changeMoney;
	}
	else
	{
		throw "The change money cannot be negative.";
	}
}
