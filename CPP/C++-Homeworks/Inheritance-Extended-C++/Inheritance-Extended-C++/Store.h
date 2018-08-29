#pragma once
#include <vector>

class StoreItem; // Forward declaration.
class Purchase; // Forward declaration.


class Store
{
private:
	std::string _name;
	std::string _bic;
	std::string _address;
	std::vector<StoreItem> _items;
	std::vector<Purchase> _purchases;
public:

	Store(
		std::string name,
		std::string bic,
		std::string address,
		std::vector<StoreItem> items,
		std::vector<Purchase> purchases);
	~Store();
	std::string name();
	void setName(std::string name);
	std::string bic();
	void setBic(std::string bic);
	std::string address();
	void setAddress(std::string address);
	std::vector<StoreItem>& items();
	void setItems(std::vector<StoreItem> items);
	std::vector<Purchase>& purchases();
	void setPurchases(std::vector<Purchase> purchases);
};
