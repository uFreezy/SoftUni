#pragma once

class StoreItem
{
private:
	std::string _name;
	std::string _itemCode;
	float _price;
public:
	StoreItem(std::string name, std::string itemCode, float price);
	~StoreItem();
	std::string name();
	void setName(std::string name);
	std::string itemCode();
	void setItemCode(std::string code);
	float price();
	void setPrice(float price);
};
