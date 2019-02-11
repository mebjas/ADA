#include "pch.h"
#include "TSP.h"

TSP::TSP(ull **graph, int N)
{
	if (N > NODELIMIT) {
		throw new exception();
	}

	this->graph = graph;
	this->N = N;

	int limit = 1 << (this->N + 1);
	
	//// init cache
	this->cache = new ull* [limit];
	for (int i = 0; i < limit; i++) {
		this->cache[i] = new ull[this->N];

		for (int j = 0; j < this->N; j++) {
			this->cache[i][j] = INT16_MAX;
		}
	}
}

TSP::~TSP()
{
	delete[] this->graph;
	delete[] this->cache;
}

ull TSP::FindMinCost() {

	//// bit map to indicate set;
	int S = 1;
	ull min_value = INT16_MAX;
	for (int i = 1; i < this->N; i++) {
		min_value = _min(min_value, this->TSPUtil(S, i, this->N - 1));
	}

	return min_value;
}
