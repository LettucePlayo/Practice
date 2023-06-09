#define _CRT_SECURE_NO_WARNINGS
#include "stdio.h"
#include "stdlib.h"
#include "memory.h"
#include "string.h"

struct Employee {
	short code;
	char* name;
	char* dept;
	double salary;
};

typedef struct Employee NodeInfo;

typedef struct BST {
	struct BST* left;
	NodeInfo* info;
	struct BST* right;
}BinarySearchTree;


#define LINE_BUFFEER 1024
/*functions signatures for memory management*/
NodeInfo* createInfo(short, char*, char*, double);
BinarySearchTree* createNode(NodeInfo*);
void printInfo(NodeInfo* info);

/*functions signatures for BST operations*/
void insertBST(BinarySearchTree**, NodeInfo*);
void deleteBST(BinarySearchTree**, short);
void inorder_LPR(BinarySearchTree*);
void preorder_PLR(BinarySearchTree*);
void printLeaves(BinarySearchTree*);

void main() {
	BinarySearchTree* bTree = NULL;

	FILE* pFile = fopen("Data.txt", "r");
	char* token = NULL, lineBuffer[LINE_BUFFEER], * sepList = ",\n";
	char* name = NULL, * dept = NULL; short code = 0; double salary = 0.0;
	if (pFile) {
		while (fgets(lineBuffer, sizeof(lineBuffer), pFile) != NULL) {
			token = strtok(lineBuffer, sepList);
			code = atoi(token);
			name = strtok(NULL, sepList);
			dept = strtok(NULL, sepList);
			token = strtok(NULL, sepList);
			salary = atof(token);

			NodeInfo* info = createInfo(code, name, dept, salary);

			insertBST(&bTree, info);
			printf("\n*********************************\n");
			preorder_PLR(bTree);

		}

		printf("\n***********************************\n");
		deleteBST(&bTree, 10003);
		//inorder_LPR(bTree);
		printLeaves(bTree);
	}
}
void printLeaves(BinarySearchTree* root) {
	if (root) {
		printLeaves(root->left);
		if (root->left == NULL && root->right == NULL)
			printInfo(root->info);
		printLeaves(root->right);
	}
}

void preorder_PLR(BinarySearchTree* root) {
	if (root) {
		printInfo(root->info);
		preorder_PLR(root->left);
		preorder_PLR(root->right);
	}
}

void inorder_LPR(BinarySearchTree* root) {
	if (root) {
		inorder_LPR(root->left);
		printInfo(root->info);
		inorder_LPR(root->right);
	}
}

void insertBST(BinarySearchTree** root, NodeInfo* emp) {
	if (*root == NULL) {
		*root = createNode(emp);
	} else {
		if ((*root)->info->code > emp->code)
			insertBST(&(*root)->left, emp);
		else if ((*root)->info->code < emp->code)
			insertBST(&(*root)->right, emp);
		else
			(*root)->info = emp;
	}
}

void logicalDeletion(BinarySearchTree** root, BinarySearchTree** leftSubTree) {
	if ((*leftSubTree)->right)
		logicalDeletion(root, &(*leftSubTree)->right);
	else {
		NodeInfo* tmpInfo = (*root)->info;
		BinarySearchTree* tmpNode = (*leftSubTree);
		(*root)->info = (*leftSubTree)->info;
		(*leftSubTree) = (*leftSubTree)->left;
		free(tmpInfo->name);
		free(tmpInfo->dept);
		free(tmpInfo);
		free(tmpNode);
	}
}

void deleteBST(BinarySearchTree** root, short key) {
	if (*root != NULL) {
		if ((*root)->info->code > key)
			deleteBST(&(*root)->left, key);
		else if ((*root)->info->code < key)
			deleteBST(&(*root)->right, key);
		else {
			if ((*root)->left == NULL && (**root).right == NULL) {
				free((*root)->info->name);
				free((*root)->info->dept);
				free((*root)->info);
				free((*root));
				*root = NULL;
			} else if ((*root)->left == NULL || (*root)->right == NULL) {
				BinarySearchTree* desc = NULL;
				if ((*root)->left)
					desc = (*root)->left;
				else
					desc = (*root)->right;
				free((*root)->info->name);
				free((*root)->info->dept);
				free((*root)->info);
				free(*root);
				*root = desc;
			} else
				logicalDeletion(root, &(*root)->left);
		}
	}
}

void printInfo(NodeInfo* info) {
	if (info)
		printf("Code: %d - Name: %s, Salary: %f\n", info->code, info->name, info->salary);
	else
		printf("No data to print!");
}

BinarySearchTree* createNode(NodeInfo* emp) {
	BinarySearchTree* node = (BinarySearchTree*)malloc(sizeof(BinarySearchTree));
	node->info = emp;
	node->left = node->right = NULL;
	return node;
}

NodeInfo* createInfo(short code, char* name, char* dept, double salary) {
	struct Employee* emp = (NodeInfo*)malloc(sizeof(NodeInfo));
	emp->code = code;
	emp->name = (char*)malloc(strlen(name) + 1);
	strcpy(emp->name, name);
	emp->dept = (char*)malloc(strlen(dept) + 1);
	strcpy(emp->dept, dept);
	emp->salary = salary;
	return emp;
}