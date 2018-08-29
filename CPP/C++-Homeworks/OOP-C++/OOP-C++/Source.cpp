#include <iostream>
#include <string>
#include <unordered_map>
#include <algorithm>
#include <vector> 

using namespace std;

class Building {
private:
	int _floors;
	int _offices;
	int _empoyees;
	int _freeWorkingSeats;
	int _otherRooms; /* Contains the amount of rooms which aren't offices */

public:
	Building();
	Building(string name, int floors, int offices, int employees, int freeWorkingSeats);
	Building(string name, int floors, int offices, int employees, int freeWorkingSeats, int otherRooms);
	~Building();
	string name;
	inline int floors() { return _floors; };
	void setFloors(int floors);
	inline int offices() { return _offices; };
	void setOffices(int offices);
	inline int employees() { return _empoyees; };
	void setEmployees(int employees);
	inline int freeWorkingSeats() { return _freeWorkingSeats; };
	void setFreeWorkingSeats(int freeWorkingSeats);
	inline int otherRooms() { return _otherRooms; };
	void setOtherRooms(int otherRooms);
};

Building::Building() {};

Building::Building(string name, int floors, int offices, int employees, int freeWorkingSeats) {
	this->name = name;
	setFloors(floors);
	setOffices(offices);
	setEmployees(employees);
	setFreeWorkingSeats(freeWorkingSeats);
	_otherRooms = 0;
}

Building::Building(string name, int floors, int offices, int employees, int freeWorkingSeats, int otherRooms) {
	this->name = name;
	setFloors(floors);
	setOffices(offices);
	setEmployees(employees);
	setFreeWorkingSeats(freeWorkingSeats);
	setOtherRooms(otherRooms);
}

Building::~Building() {
	//cout << "Object went poof!" << endl;
}

void Building::setFloors(int floors) {
	if (floors <= 0) return;
	_floors = floors;
}

void Building::setOffices(int offices) {
	if (offices <= 0) return;
	_offices = offices;
}

void Building::setEmployees(int employees) {
	if (employees < 0) return;
	_empoyees = employees;
}

void Building::setFreeWorkingSeats(int freeWorkingSeats) {
	if (freeWorkingSeats < 0) return;
	_freeWorkingSeats = freeWorkingSeats;
}

void Building::setOtherRooms(int otherRooms) {
	if (otherRooms < 0) return;
	_otherRooms = otherRooms;
}

class BusinessPark {
private:
	Building * _buildings;
public:
	BusinessPark(Building buildings[]);
	inline Building * buildings() { return _buildings; }; /* returning pointer a.k.a magic */
	void setBuildings(Building buildings[]);
	void sortCompanies(unordered_map<string, float> values, string typeSort);
};

BusinessPark::BusinessPark(Building buildings[]) {
	setBuildings(buildings);
}

void BusinessPark::setBuildings(Building buildings[]) {
	_buildings = buildings;
}

void BusinessPark::sortCompanies(unordered_map<string, float> values, string typeSort) {
	typedef pair<string, float> mypair;

	// Sorting algorithm
	struct IntCmp {
		bool operator()(const mypair &lhs, const mypair &rhs) {
			return lhs.second < rhs.second;
		}
	};

	vector<mypair> myvec(values.begin(), values.end());
	sort(myvec.begin(), myvec.end(), IntCmp());
	
	if (typeSort == "up") {
		cout << myvec[2].first << endl;
	} else if(typeSort == "down"){
		cout << myvec[0].first << endl;
	
	} else {
		return;
	}
	
	cout << endl;	
}

int main() {
	Building buildings[3];
	buildings[0] = Building("XYY Industries", 6, 127, 600, 196);
	buildings[1] = Building("Rapid Development Crew", 8, 210, 822, 85, 1);
	buildings[2] = Building("SoftUni", 11, 106, 200, 60);

	BusinessPark park = BusinessPark(buildings);

	unordered_map<string, float> employeesCount;
	unordered_map<string, float> freeWorkingSeatsCount;
	unordered_map<string, float> peoplePerFloorCount;
	unordered_map<string, float> mostOfficesPerFloor;
	unordered_map<string, float> mostPeoplePerOffice;
	unordered_map<string, float> highestCoefficient;

	for (int i = 0; i < 3; i++) {
		pair<string, float> employeesPerBuilding(buildings[i].name, buildings[i].employees());
		pair<string, float> freeSeatsPerBuilding(buildings[i].name, buildings[i].freeWorkingSeats());
		pair<string, float> peoplePerFloor(buildings[i].name,
			(buildings[i].employees() / (buildings[i].floors() - buildings[i].otherRooms())));
		pair<string, float> officesPerFloor(buildings[i].name,
			(buildings[i].offices() / (buildings[i].floors() - buildings[i].otherRooms())));
		pair<string, float> peoplePerOffice(buildings[i].name,
			(buildings[i].employees() / buildings[i].offices()));
		pair<string, float> highestCoefficientPair(buildings[i].name,
			(buildings[i].employees() / (buildings[i].employees() + buildings[i].freeWorkingSeats())));

		employeesCount.insert(employeesPerBuilding);
		freeWorkingSeatsCount.insert(freeSeatsPerBuilding);
		peoplePerFloorCount.insert(peoplePerFloor);
		mostOfficesPerFloor.insert(officesPerFloor);
		mostPeoplePerOffice.insert(peoplePerOffice);
		highestCoefficient.insert(highestCoefficientPair);
	}

	// Gets the company with most employees.
	cout << "The company with most employees: ";
	park.sortCompanies(employeesCount, "up");

	// Gets the company with most free seats;
	cout << "The company with most free seats: ";
	park.sortCompanies(freeWorkingSeatsCount, "up");

	// Gets the company with most people per floor
	cout << "The company with most people per floor: ";
	park.sortCompanies(peoplePerFloorCount, "up");

	// Gets the company with most offices per floor
	cout << "The company with most offices per floor: ";
	park.sortCompanies(mostOfficesPerFloor, "up");

	// Gets the company with most people per office
	cout << "The company with most people per office: ";
	park.sortCompanies(mostPeoplePerOffice, "up");

	// Gets the companny with highest coefficient employees/(employees + free seats)
	cout << "The company with highest coefficient employees/(employees + free seats): ";
	park.sortCompanies(highestCoefficient, "up");

	// Gets the company with least people per floor
	cout << "The company with least people per floor: ";
	park.sortCompanies(peoplePerFloorCount, "down");

	// Gets the company with least offices per floor 
	cout << "The company with least offices per floor: ";
	park.sortCompanies(mostOfficesPerFloor, "down");

	// Gets the company with least people per office 
	cout << "The company with least people per office: ";
	park.sortCompanies(mostPeoplePerOffice, "down");

	return 0;
}
