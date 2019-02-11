#include "pch.h"
#include "math.h"
#include "SegmentTree.h"


SegmentTree::SegmentTree(int inputArr[], int n)
{
	this->n = n;
	this->Height = ceil(log2(n));
	this->internalLength = 2 * (int)pow(2, this->Height) - 1;
	this->arr = new int[this->internalLength];

	this->Create(inputArr, 0, n - 1, 0);

	cout << "Height of segment tree: " << this->Height << "\n";
	cout << "internalLength of segment tree: " << this->internalLength << "\n";
}


SegmentTree::~SegmentTree()
{
	delete[] this->arr;
}

void SegmentTree::Update(int index, int val) {
	throw new NotImplementedException();
}

int SegmentTree::Sum(int start, int end) {
	//// TODO: add basic sanitation
	return this->Sum(0, this->n - 1, start, end, 0);
}
