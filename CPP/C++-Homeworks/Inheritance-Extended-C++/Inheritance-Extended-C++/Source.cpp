#include <iostream>
#include "StoreItem.h"
#include "Purchase.h"
#include "Store.h"
#include <string>

float calcTotalVal(std::vector<StoreItem> shoppingCart)
{
	float totalVal = 0;

	for (size_t i = 0; i < shoppingCart.size(); i++)
	{
		totalVal += shoppingCart.at(i).price();
	}

	return totalVal;
}

int main()
{
	Store mainStore = Store(
		"Supermarket",
		"12345678",
		"Supermarket street 1",
		std::vector<StoreItem>{StoreItem("Sirene","1234567890", 30.00)},
		std::vector<Purchase>());

	std::string input;
	std::vector<StoreItem> shoppingCart;

	std::cout << "If you want to add an item to the card enter the item's ID." << std::endl
		<< "If you want to clear your current shopping cart press C." << std::endl
		<< "If you want to see the total value of the items in your cart press T." << std::endl
		<< "If you want to check out press G." << std::endl
		<< "If you want to change the item's price press P." << std::endl
		<< "If you want to see info about your purchase press I." << std::endl
		<< "If you wish to exit the programm press E." << std::endl;

	while (true)
	{
		getline(std::cin, input);

		if (input.length() == 10)
		{
			for (size_t i = 0; i < mainStore.items().size(); i++)
			{
				if (mainStore.items().at(i).itemCode() == input)
				{
					shoppingCart.push_back(mainStore.items().at(i));
				}
			}
		}
		else
		{
			switch (input[0])
			{
			case 'C':
				{
					// On writing character ‘C’ the total value is cleared
					shoppingCart.clear();
					break;
				}

			case 'T':
				{
					// On writing character ‘T’ the program displays the total value

					std::cout << "Total value: " << calcTotalVal(shoppingCart) << std::endl;
					break;
				}

			case 'G':
				{
					/* On writing character ‘G’ the program shows message “Please enter the amount of money”
					and wait for float number, then calculates the change and
					shows on console “The change is <xx.xx> leva” */
					std::cout << "Please enter the amount of money" << std::endl;

					std::string amountOfMoneyStr;
					std::cin >> amountOfMoneyStr;
					float amountOfMoney = stof(amountOfMoneyStr);

					float totalValue = 0.00;

					for (size_t i = 0; i < shoppingCart.size(); i++)
					{
						totalValue += shoppingCart.at(i).price();
					}

					if (totalValue <= amountOfMoney)
					{
						Purchase purch = Purchase(
							shoppingCart,
							calcTotalVal(shoppingCart),
							amountOfMoney,
							amountOfMoney - calcTotalVal(shoppingCart),
							&mainStore
						);

						mainStore.purchases().push_back(purch);
						shoppingCart.clear();

						std::cout << "The change is " << purch.changeMoney() << " leva" << std::endl;
					}
					else
					{
						std::cout << "You need more money!" << std::endl;
					}
					break;
				}

			case 'P':
				{
					// Add option to change the price of an item, by inputting it’s code.
					std::cout << "Enter the item's code: ";
					std::string itemCode;
					std::cin >> itemCode;

					std::cout << std::endl << "Enter the item's new price: ";
					std::string newPrice;
					std::cin >> newPrice;

					if (itemCode.length() == 10)
					{
						for (size_t i = 0; i < mainStore.items().size(); i++)
						{
							if (mainStore.items().at(i).itemCode() == itemCode)
							{
								mainStore.items().at(i).setPrice(stof(newPrice));
							}
						}
					}
					break;
				}

			case 'I':
				{
					// Add option to display customer information about the purchase 
					Purchase purch = mainStore.purchases().back();			
					std::cout << mainStore.name() << std::endl <<
						"BIC: " << mainStore.bic() << std::endl <<
						"Address: " << mainStore.address() << std::endl <<
						"Purchases: " << purch.totalAmount() << " leva" << std::endl <<
						"Given: " << purch.givenMoney() << std::endl <<
						"Change: " << purch.changeMoney() << std::endl;
					break;
				}

			case 'E':
				{
					return EXIT_SUCCESS; // Exits the program
				}
			}
		}
	}
}
