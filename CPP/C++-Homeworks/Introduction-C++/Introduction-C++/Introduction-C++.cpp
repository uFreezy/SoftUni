#include "stdafx.h"
#include "iostream";
#include "string";

using namespace std;

int main()
{
	int capitalLetters = 0;
	int nonCaptalLetters = 0;
	string inputString;

	getline(cin, inputString);

	for each (char letter in inputString)
	{
		if (isupper(letter)) {
			capitalLetters++;
		}
		else {
			nonCaptalLetters++;
		}
	}

	cout << "Capital letters: " << capitalLetters << endl;
	cout << "NonCapital letters: " << nonCaptalLetters << endl;

    return 0;
}

