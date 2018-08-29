#include<iostream>
#include <locale>
#include <thread>
#include <mutex>

std::mutex mutex;

void printResults(std::string action, unsigned long long value, double time)
{
	mutex.lock();
	std::cout << action << " " << value << ", " << time << " ms." << std::endl;
	mutex.unlock();
}

bool isPrime(unsigned long long number)
{
	if (number == 1) return false;
	if (number == 2) return true;

	if (number % 2 == 0) return false; //Even number     

	for (int i = 3; i < number; i += 2)
	{
		if (number % i == 0) return false;
	}

	return true;
}

void calcPrime(unsigned long long numb)
{
	if (numb == 1)
	{
		return;
	}

	for (auto i = 1; i < numb; i++)
	{
		clock_t begin = clock();

		if (isPrime(i))
		{
			clock_t end = clock();
			double elapsedSecs = double(end - begin) / CLOCKS_PER_SEC;

			std::thread prt(printResults, "Prime", i, elapsedSecs);
			prt.join();
		}
	}
}

void calcFibonacci(unsigned long long numb)
{
	auto prevNumb = 0;
	auto currNumb = 1;

	for (auto i = 0; i < numb; i++)
	{
		clock_t begin = clock();
		auto midNumb = currNumb;
		currNumb += prevNumb;
		prevNumb = midNumb;
		clock_t end = clock() - begin;
		double elapsedSecs = double(end);

		std::thread prt(printResults, "Fibonacci", currNumb, elapsedSecs);
		prt.join();
	}
}

int main()
{
	unsigned long long inputVal;
	std::cin >> inputVal;

	if (std::cin.fail())
	{
		std::cout << "Number too big." << std::endl;
		return 0;
	}

	std::thread fibThrd(calcFibonacci, inputVal);
	std::thread primeThrd(calcPrime, inputVal);

	fibThrd.join();
	primeThrd.join();

	return 0;
}
