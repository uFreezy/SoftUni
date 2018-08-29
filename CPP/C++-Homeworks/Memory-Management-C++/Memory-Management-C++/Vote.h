#pragma once
#include <iostream>
#include <memory>
#include "Person.h"
#include "VoteChoice.h"

class Vote
{
private:
	//Person * _voter;
	VoteChoice _voteChoice;
public:
	Vote(VoteChoice vote);
	~Vote();
	//Person * voter();
	//void setVoter(Person voter);
	VoteChoice& voteChoice();
	void setVoteChoice(VoteChoice voteChoice);
};
