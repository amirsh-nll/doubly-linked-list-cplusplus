#include "stdafx.h"
#include "iostream"

using namespace std;

struct  node
{
	int data;
	struct  node *next;
	struct  node *last;
};
struct  node *p, *start, *q;

class Node
{
public :
	void create(int a,int b)
	{
		p = start = (struct node*)malloc(sizeof(node));
		if (b == 1)
		{
			start->data = a;
			start->last = NULL;
		}
		else
		{
			p->next = (struct node*)malloc(sizeof(node));
			p->next->last = p;
			p->next->data = a;
			p = p->next;
		}
	}
	void add(int a,int b)
	{
		while (p->data != a)
		{
			p = p->next;
		}
		q = (struct node*)malloc(sizeof(node));
		q->next = p->next;
		q->data = b;
		p->next = q;
		p->next->last = p->last;
	}
	void del(int a)
	{
		p = q = start = (struct node*)malloc(sizeof(node));
		if (start->data == a)
		{
			start = start->next;
			start->last = NULL;
			free(p);
		}
		else
		{
			while (p->data != a && p->next != NULL)
			{
				q = p;
				p = p->next;
			}
			q->next = p->next;
			p->next->last = q;
			free(p);
		}
	}
	void view()
	{
		p = start = (struct node*)malloc(sizeof(node));
		cout << start->data;
		for (int i = 1; i < 10; i++)
		{
			cout << p->data;
		}
	}
};

void main()
{
	int x;
	Node n1;
	cout << "Please Enter Number :";
	cin >> x;
	cout << endl;
	n1.create(x, 1);
	for (int i = 1; i < 10; i++)
	{
		cin >> x;
		cout << endl;
		n1.create(x, 2);
	}
	cout << "ADD 6 After 8" << endl;
	n1.add(8, 6);
	cout << "Delete 8" << endl << endl;
	n1.del(8);
	cout << "View List  :";
	n1.view();
}

