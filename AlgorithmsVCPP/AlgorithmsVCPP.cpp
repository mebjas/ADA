// AlgorithmsVCPP.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include "TSP.h"
#include <iostream>

int main()
{
	/*int arr[] = { 1, 2, 3, 4, 5, 6 ,7 ,8 ,9 ,10 };
	SegmentTree tree(arr, 10);

	std::cout << "SUM 0, 5 = " << tree.Sum(0, 5) << "\n";
	std::cout << "SUM 5, 7 = " << tree.Sum(5, 7) << "\n";
	std::cout << "SUM 9, 9 = " << tree.Sum(9, 9) << "\n";
	std::cout << "SUM 0, 0 = " << tree.Sum(0, 0) << "\n";
	std::cout << "SUM 3, 8 = " << tree.Sum(3, 8) << "\n";*/

	int N, i, j, M, src, dest;
	cin >> N;

	ull **graph = new ull*[N];
	for (i = 0; i < N; i++) {
		graph[i] = new ull[N];
		for (j = 0; j < N; j++) {
			cin >> graph[i][j];
		}
	}

	TSP tsp(graph, N);
	cout << tsp.FindMinCost();
	return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
