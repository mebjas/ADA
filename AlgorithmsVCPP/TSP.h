#pragma once
#define NODELIMIT 14
#define ull unsigned long long int
#define _min(a, b) ((a) > (b)) ? (b) : (a)

class TSP
{
private:
	ull **graph;
	int N;
	ull **cache;

	ull TSPUtil(int S, int i, int left) {
		if (left == 1) {
			return this->graph[1][i];
		}

		if (this->cache[S][i] == INT16_MAX) {
			ull min_value = INT16_MAX;
			int mask = S | (i << i);
			for (int j = 1; j < this->N; j++) {
				if (j == i || (S & (1 << j)) != 0) {
					//// already in set or is same
					continue;
				}

				min_value = _min(min_value, this->TSPUtil(mask, j, left - 1) + graph[j][i]);
			}

			cache[S][i] = min_value;
		}

		return this->cache[S][i];
	}

public:
	TSP(ull **graph, int N);
	~TSP();

	ull  FindMinCost();
};

