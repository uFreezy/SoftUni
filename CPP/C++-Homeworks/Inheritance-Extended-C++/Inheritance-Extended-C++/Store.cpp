#include "Store.h"
#include "StoreItem.h"
#include "Purchase.h"

Store::Store(std::string name, std::string bic, std::string address, std::vector<StoreItem> items, std::vector<Purchase> purchases)
{
	this->setName(name);
	this->setBic(bic);
	this->setAddress(address);
	this->setItems(items);
	this->setPurchases(purchases);
}

Store::~Store()
{
}

std::string Store::name()
{
	return this->_name;
}

void Store::setName(std::string name)
{
	if (name.length() > 0)
	{
		this->_name = name;
	}
	else
	{
		throw "Name cannot be empty.";
	}
}

std::string Store::bic()
{
	return this->_bic;
}

void Store::setBic(std::string bic)
{
	if (bic.length() > 0)
	{
		this->_bic = bic;
	}
	else
	{
		throw "BIC cannot be empty.";
	}
}

std::string Store::address()
{
	return this->_address;
}

void Store::setAddress(std::string address)
{
	if (address.length() > 0)
	{
		this->_address = address;
	}
	else
	{
		throw "Address cannot be empty.";
	}
}

std::vector<StoreItem>& Store::items()
{
	return this->_items;
}

void Store::setItems(std::vector<StoreItem> items)
{
	this->_items = items;
}

std::vector<Purchase>& Store::purchases()
{
	return this->_purchases;
}

void Store::setPurchases(std::vector<Purchase> purchases)
{
	this->_purchases = purchases;
}
