#pragma once
#include <vector>

class StoreItem; // Forward declaration.
class Store; // Forward declaration.

class Purchase
{
private:
	std::vector<StoreItem> _items;
	float _toatlAmount;
	float _givenMoney;
	float _changeMoney;
	Store* _store;
public:
	Purchase(
		std::vector<StoreItem> items,
		float totalAmount,
		float givenMoney,
		float changeMoney,
		Store* store);
	~Purchase();
	std::vector<StoreItem>& items();
	float totalAmount();
	void setTotalAmount(float totalAmount);
	float givenMoney();
	void setGivenMoney(float givenMoney);
	float changeMoney();
	void setChangeMoney(float changeMoney);
};
