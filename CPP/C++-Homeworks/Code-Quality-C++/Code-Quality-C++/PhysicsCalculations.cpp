#include "PhysicsCalculations.h"

class Enviorment;
class Character;

float PhysicsCalculations::maxJumpHeight(Enviorment& env, Character& character)
{
	float result = (character.jumpSpeed() * character.jumpSpeed()) / (env.gravity() * 2);

	return result;
}

float PhysicsCalculations::timeNeededForJump(Enviorment& env, Character& character)
{
	float ymax = character.jumpSpeed() * character.jumpSpeed() / (env.gravity() / 2);
	float time = (character.jumpSpeed() / env.gravity()) + sqrt((2 * ymax) / env.gravity());
	return time;
}

bool PhysicsCalculations::isAbleToJump(Enviorment& env, Character& character, float jumpHeight)
{
	float maxJump = maxJumpHeight(env, character);

	if (jumpHeight <= maxJump)
	{
		return true;
	}

	return false;
}
