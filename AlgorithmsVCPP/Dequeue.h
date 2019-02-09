#pragma once

struct DequeueNode {
public:
	int Data;
	DequeueNode *next;
	DequeueNode *prev;
};

class Dequeue
{
	DequeueNode *front, *rear;

public:
	Dequeue();
	~Dequeue();
	void EnqueueFront(int i);
	void EnqueueRear(int i);
	int DequeueFront();
	int DequeueRear();
};

