#include "pch.h"
#include "Dequeue.h"
#include <iostream>

Dequeue::Dequeue()
{
	this->front = nullptr;
	this->rear = nullptr;
}

Dequeue::~Dequeue()
{
	DequeueNode *node = this->front, *tmp;
	while (node != nullptr) {
		tmp = node;
		node = node->next;
		delete tmp;
	}
}

void Dequeue::EnqueueFront(int i) {
	DequeueNode *node = new DequeueNode();
	node->Data = i;

	if (this->front = nullptr) {
		this->front = node;
		this->rear = node;
		return;
	}

	this->front->prev = node;
	node->next = this->front;
	this->front = node;
}

void Dequeue::EnqueueRear(int i) {
	DequeueNode *node = new DequeueNode();
	node->Data = i;

	if (this->front = nullptr) {
		this->front = node;
		this->rear = node;
		return;
	}

	this->rear->next = node;
	node->prev = this->rear;
	this->rear = node;
}

int Dequeue::DequeueFront() {
	if (this->front == nullptr) {
		throw new _exception();
	}

	DequeueNode *node = this->front;
	this->front = this->front->next;

	int data = node->Data;
	delete node;
	return data;
}

int Dequeue::DequeueRear() {
	if (this->rear == nullptr) {
		throw new _exception();
	}

	DequeueNode *node = this->rear;
	this->rear = this->rear->prev;

	int data = node->Data;
	delete node;
	return data;
}
