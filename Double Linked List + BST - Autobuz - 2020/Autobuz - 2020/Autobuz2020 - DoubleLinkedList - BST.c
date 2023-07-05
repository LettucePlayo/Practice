
#define _CRT_SECURE_NO_WARNINGS
#include "stdio.h"
#include "stdlib.h"
#include "memory.h"
#include "string.h"

struct Evaluation
{
	short Id;
	float km;
	char* name;
	char* producator;
	int capacitate;

};

typedef struct node
{
	struct Evaluation* info;
	struct node* pNext;
	struct node* pPrev;
}Node;

typedef struct Evaluation NodeInfo;
typedef struct node DoubleLinkedList;

typedef struct BST
{
	struct BST* left;
	NodeInfo* info;
	struct BST* right;
}BinarySearchTree;

#define LINE_BUFFEER 1024

/*functions signatures for memory management*/
NodeInfo* createInfo(int, float, char*, char*, int);
Node* createNode(NodeInfo*);
/*functions signatures for list operations*/
void printInfo(Node*);
void InsertionSortedManner(DoubleLinkedList**, DoubleLinkedList*);
void printCircularList(DoubleLinkedList*);
void printList(Node*);
Node* deleteNodebyStudentId(Node*, int);

BinarySearchTree* addTreeProperty(DoubleLinkedList*, BinarySearchTree*);
void insertBST(BinarySearchTree**, NodeInfo*);
BinarySearchTree* createBinaryNode(NodeInfo*);
void inorder_LPR(BinarySearchTree* );
void printInfoTree(NodeInfo*);
//void printLeaves(BinarySearchTree* root);
void printLevels(BinarySearchTree*);
short height(BinarySearchTree*);
int countTwoChildren(BinarySearchTree*);
void freeBTree(BinarySearchTree**);
void freeLinkedList(DoubleLinkedList*);


void main()
{
	DoubleLinkedList* list = NULL;
	int size = 0;
	FILE* pFile = fopen("Data.txt", "r");
	char* token = NULL, lineBuffer[LINE_BUFFEER], * sepList = ",\n";
	int Id = 0;
	float km = 0;
	char* name = NULL;
	char* producator = NULL;
	int capacitate = 0;
	if (pFile)
	{
		while (fgets(lineBuffer, sizeof(lineBuffer), pFile)) {
			token = strtok(lineBuffer, sepList);
			Id = atoi(token);
			token = strtok(NULL, sepList);
			km = atoi(token);
			name = strtok(NULL, sepList);
			producator = strtok(NULL, sepList);
			token = strtok(NULL, sepList);
			capacitate = atoi(token);


			NodeInfo* info = createInfo(Id, km, name, producator, capacitate);

			InsertionSortedManner(&list, info);
			size++;

		}
		printCircularList(list);
		int pos = 13343400;
		list = deleteNodebyStudentId(list, pos);
		printf("--------------------------------\n");
		printCircularList(list);


		BinarySearchTree* bTree = NULL;
		bTree = addTreeProperty(list, bTree);
		printf("\n-------------------------------\n");
		inorder_LPR(bTree);

		int count = countTwoChildren(bTree);
		printf("--------------------------------\n");
		printf("%d", count);
		

	/*	printf("\n-------------------------------\n");
		printLeaves(bTree);

		printf("\n-------------------------------\n");
		printLevels(bTree);*/

		freeLinkedList(list);
		freeBTree(&bTree);
	}
}

//Scrieţi secvenţa de cod care dezalocă structurile Arbore binar de căutare, 
//Lista dublu înlănțuită şi alte structuri suport create la punctele anterioare. (1p)

void freeLinkedList(DoubleLinkedList* list) {
	DoubleLinkedList* tmp = list;
	while (tmp!= NULL)
	{
		DoubleLinkedList* tmp2 = tmp->pNext;
		free(tmp->info->name);
		free(tmp->info->producator);
		free(tmp->info);
		free(tmp);
		tmp = tmp2;
	}

}

void freeBTree(BinarySearchTree** bTree)
{
	/*if (*bTree != NULL) {
		freeBTree(&(*bTree)->left);
		freeBTree(&(*bTree)->right);
		free((*bTree)->info->name);
		free((*bTree)->info->producator);
		free((*bTree)->info);
		free((*bTree));
		*bTree = NULL;
	}*/
	/*if (bTree == NULL)
		return;
	freeBTree(bTree->left);
	freeBTree(bTree->right);
	NodeInfo* tmp = bTree->info;
	free(tmp->name);
	free(tmp->producator);
	free(tmp);*/
	if ((*bTree)) {
		freeBTree((*bTree)->right);
		freeBTree((*bTree)->left);
		free((*bTree));
		*bTree = NULL;
	}
}
	
	


//Scrieţi secvenţa de cod care copiază o parte dintre autobuzele din Lista Dublu Înlănțuită creată anterior într-o structură Arbore Binar de Căutare, 
//cheia fiind unul dintre atributele autobuzului ce se considera a fi unic pentru fiecare autobuz (alt atribut față de cel ales pentru inserarea în listă). 
//Cele două structuri de date NU partajează zone de memorie heap. (3p)

BinarySearchTree* addTreeProperty(DoubleLinkedList* list, BinarySearchTree* bTree) {

	bTree = NULL;
	Node* tmp = list;
	do {
		insertBST(&bTree, tmp->info);
		tmp = tmp->pNext;
	} while (tmp != NULL);
	return bTree;
}

void insertBST(BinarySearchTree** root, NodeInfo* emp)
{
	if (*root == NULL)
	{
		*root = createBinaryNode(emp);
	}
	else
	{
		if ((*root)->info->Id > emp->Id)
			insertBST(&(*root)->left, emp);
		else if ((*root)->info->Id < emp->Id)
			insertBST(&(*root)->right, emp);
		else
			(*root)->info = emp;
	}
}

BinarySearchTree* createBinaryNode(NodeInfo* emp)
{
	BinarySearchTree* node = (BinarySearchTree*)malloc(sizeof(BinarySearchTree));
	node->info = emp;
	node->left = node->right = NULL;
	return node;
}
void inorder_LPR(BinarySearchTree* root)
{
	if (root)
	{
		inorder_LPR(root->left);
		printInfoTree(root->info);
		inorder_LPR(root->right);
	}
}

void printInfoTree(NodeInfo* info)
{
	if (info)
		printf("Id: %d, KM: %f, NumeSofer: %s, Producator: %s, Capacitate: %d\n",
			info->Id,
			info->km,
			info->name,
			info->producator,
			info->capacitate);
	else
		printf("No data to print!");
}

int countTwoChildren(BinarySearchTree* root)
{
	if (root == NULL) {
		return 0;
	}
	if (root->left != NULL && root->right != NULL) {
		return 1 + countTwoChildren(root->left) + countTwoChildren(root->right);
	}
	return countTwoChildren(root->left) + countTwoChildren(root->right);
}

//void printLeaves(BinarySearchTree* root)
//{
//	if (root)
//	{
//		if (root->left == NULL && root->right == NULL)
//			printInfoTree(root->info);
//		printLeaves(root->left);
//		printLeaves(root->right);
//	}
//}
//
//void printLevel(BinarySearchTree* root, int lvl)
//{
//	if (root)
//	{
//		if (lvl == 0)
//			printInfoTree(root->info);
//		printLevel(root->left, lvl - 1);
//		printLevel(root->right, lvl - 1);
//	}
//}
//void printLevels(BinarySearchTree* root)
//{
//	int levels = height(root);
//	for (int i = 0; i < levels; i++)
//	{
//		printf("\nLevel %d\n", i);
//		printLevel(root, i);
//	}
//}
//short height(BinarySearchTree* root)
//{
//	if (root)
//		return 1 + max(height(root->left), height(root->right));
//	else
//		return 0;
//}



//Scrieţi şi apelaţi funcţia pentru ștergerea unui Autobuz din Lista Dublu Înlănțuită.
//Modul de alegere a nodului se face după un atribut al structuri Autobuz.Pentru verificare, structura este afișată înainte și după modificare

Node* deleteNodebyStudentId(Node* head, int pos)
{
	int index = 1;
	Node* tmp = (Node*)malloc(sizeof(Node));
	tmp = head;
	do {
		Node* aux = NULL;
		if (tmp->pNext->info->km == pos)
		{
			aux = tmp->pNext;
			tmp->pNext = aux->pNext;

		}
		else {
			tmp = tmp->pNext;
		}

		if (aux)
		{
			free(aux->info->name);
			free(aux->info->producator);
			free(aux->info);
			free(aux);
		}
	} while (tmp->pNext != NULL);
	return head;
}

void printCircularList(DoubleLinkedList* list)
{
	Node* tmp = list;
	while (tmp != NULL) {
		printf("Id: %d, KM: %f, NumeSofer: %s, Producator: %s, Capacitate: %d\n",
			tmp->info->Id,
			tmp->info->km,
			tmp->info->name,
			tmp->info->producator,
			tmp->info->capacitate);
		tmp = tmp->pNext;
	}
}


void InsertionSortedManner(DoubleLinkedList** head, NodeInfo* newNode)
{
	Node* node = (Node*)malloc(sizeof(Node));
	node = createNode(newNode);
	DoubleLinkedList* current;

	if (*head == NULL) {
		*head = node;
	}
	
	else if ((*head)->info->km >= node->info->km) {
		node->pNext = *head;
		node->pNext->pPrev = node;
		*head = node;
	}

	else {
		current = *head;
		while (current->pNext != NULL && current->pNext->info->km < node->info->km) {
			current = current->pNext;
		}

		node->pNext = current->pNext;

		if (current->pNext != NULL) {
			node->pNext->pPrev = node;
		}

		current->pNext = node;
		node->pPrev = current;
	}
}

NodeInfo* createInfo(int Id,float km, char* name ,char* producator,int capacitate)
{
	struct Evaluation* emp = (NodeInfo*)malloc(sizeof(NodeInfo));
	emp->Id = Id;
	emp->km = km;
	emp->name = (char*)malloc(strlen(name) + 1);
	strcpy(emp->name, name);
	emp->producator = (char*)malloc(strlen(producator) + 1);
	strcpy(emp->producator, producator);
	emp->capacitate = capacitate;
	return emp;
}
Node* createNode(NodeInfo* info)
{
	Node* node = (Node*)malloc(sizeof(Node));
	node->info = info;
	node ->pPrev = node->pNext = NULL;
	return node;
}

//void DealocateBST(BinarySearchTree* bst)
//{
//	if (bst)
//	{
//		if (bst->left == NULL && bst->right == NULL)
//		{
//			free(bst);
//		}
//		else
//		{
//			DealocateBST(bst->left);
//			DealocateBST(bst->right);
//			free(bst);
//		}
//	}
//}
//
//void DealocateList(Node* list)
//{
//	Node* temp = NULL;
//	while (list)
//	{
//		temp = list->next;
//		free(list);
//		list = temp;
//	}
//	free(temp);
//}
