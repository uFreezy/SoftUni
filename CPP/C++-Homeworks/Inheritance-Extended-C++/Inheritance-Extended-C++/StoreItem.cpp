#include <iostream>
#include "StoreItem.h"

StoreItem::StoreItem(std::string name, std::string itemCode, float price)
{
	this->setName(name);
	this->setItemCode(itemCode);
	this->setPrice(price);
}

StoreItem::~StoreItem()
{
}

std::string StoreItem::name()
{
	return this->_name;
}

void StoreItem::setName(std::string name)
{
	if(name.length() > 0)
	{
		this->_name = name;
	}
	else
	{
		throw "The name field cannot be empty.";
	}
}

std::string StoreItem::itemCode()
{
	return this->_itemCode;
}

void StoreItem::setItemCode(std::string code)
{
	if (code.length() == 10)
	{
		this->_itemCode = code;
	}
	else
	{
		throw "Invalid code length";
	}
}

float StoreItem::price()
{
	return this->_price;
}

void StoreItem::setPrice(float price)
{
	if (price > 0)
	{
		this->_price = price;
	}
	else
	{
		throw "Price cannot be negative or 0.";
	}
}
