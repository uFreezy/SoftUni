#pragma once
#include "Character.h"
#include "Enviorment.h"

class Enviorment;
class Character;

static class PhysicsCalculations
{
public:
	static float maxJumpHeight(Enviorment& env, Character& character);
	static float timeNeededForJump(Enviorment& env, Character& character);
	static bool isAbleToJump(Enviorment& env, Character& character, float jumpHeight);
};
