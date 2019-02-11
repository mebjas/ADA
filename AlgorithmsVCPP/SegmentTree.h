#pragma once
class SegmentTree
{
private:
	int internalLength;
	int *arr;
	int n;

	int GetMid(int start, int end) {
		return (start + end) / 2;
	}

	int Create(int inputArr[], int start, int end, int i) {
		cout << start << ", " << end << ", " << i << "\n";

		if (start == end) {
			this->arr[i] = inputArr[start];
			return this->arr[i];
		}

		int mid = this->GetMid(start, end);
		this->arr[i] = this->Create(inputArr, start, mid, 2 * i + 1)
			+ this->Create(inputArr, mid + 1, end, 2 * i + 2);

		return this->arr[i];
	}

	int Sum(int start, int end, int left, int right, int si) {
		if (right < start || left > end) {
			return 0;
		}

		if (start >= left && end <= right) {
			return this->arr[si];
		}

		int mid = this->GetMid(start, end);
		return this->Sum(start, mid, left, right, 2 * si + 1)
			+ this->Sum(mid + 1, end, left, right, 2 * si + 2);
	}

public:
	SegmentTree(int arr[], int n);
	~SegmentTree();
	void Update(int index, int val);
	int Sum(int start, int end);

	int Height;
};

