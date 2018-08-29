#include "Vote.h"

Vote::Vote(VoteChoice vote)
{
	this->setVoteChoice(vote);
}

Vote::~Vote()
{
}


VoteChoice& Vote::voteChoice()
{
	return this->_voteChoice;
}

void Vote::setVoteChoice(VoteChoice voteChoice)
{
	this->_voteChoice = voteChoice;
}
