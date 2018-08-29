#include "iostream"
#include "Enviorment.h"
#include "PhysicsCalculations.h"
#include "Character.h"

int main()
{
	Enviorment earth = Enviorment(123, "Earth", 3.18);
	Character human = Character(123, "Gosho", 100, 10);

	float maxJumpHeight = PhysicsCalculations::maxJumpHeight(earth, human);

	std::cout << "The maximum jump height is: " << maxJumpHeight << std::endl;

	bool isAbleToMakeJump = PhysicsCalculations::isAbleToJump(earth, human, 11);

	std::cout << "Will the human be able to make the jump: " << isAbleToMakeJump << std::endl;

	float timeToJump = PhysicsCalculations::timeNeededForJump(earth, human);

	std::cout << "The human will complete it's jump in: " << timeToJump << " seconds." << std::endl;

	return 0;
}
