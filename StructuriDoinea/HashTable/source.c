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

typedef struct HT {
	NodeInfo** items;
	int size;
}HashTable;

#define LINE_BUFFEER 1024
#define HT_INITIAL_CAPACITY 3
/*functions signatures for memory management*/
NodeInfo* createInfo(short, char*, char*, double);
void printInfo(NodeInfo*);
/*functions signatures for HT operations*/
void putHT(HashTable*, NodeInfo*);
NodeInfo* get(HashTable, char*);
int fhash(char*,int);
void resizeHT(HashTable*);
int linearProbing(HashTable*,int, char*);

void main()
{
	HashTable hashTable = { .items = NULL, .size = 0 };

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
			putHT(&hashTable, info);

			printf("\n***************************\n");
			printf("\nSize: %d\n", hashTable.size);
			for (int i = 0; i < hashTable.size; i++)
				if (hashTable.items[i] != NULL) {
					printf("Index: %d --", i);
					printInfo(hashTable.items[i]);
				}
			NodeInfo* emp = get(hashTable, "Cazacu Robert");
			printInfo(emp);
		}
	}
}

NodeInfo* get(HashTable hTable, char* key) {
	NodeInfo* result = NULL;
	if (hTable.items != NULL) {
		int index = fhash(key, hTable.size);
		while (index < hTable.size && hTable.items[index] != NULL && strcmp(key, hTable.items[index]->name) != 0)
			index++;
		if (index < hTable.size && hTable.items[index] != NULL)
			result = hTable.items[index];
	}
	return result;
}

int fhash(char* key, int size) {
	return key[0] % size;
}

void resizeHT(HashTable* hTable) {
	NodeInfo** aux = hTable->items;
	hTable->items = (NodeInfo**)malloc(sizeof(NodeInfo*) * 2 * hTable->size);
	memset(hTable->items, NULL, sizeof(NodeInfo*) * 2 * hTable->size);
	hTable->size *= 2;
	for (int i = 0; i < hTable->size / 2; i++) {
		if (aux[i] != NULL)
			putHT(hTable, aux[i]);
	}
	free(aux);
}

int linearProbing(HashTable* hTable, int index, char* key) {
	while (hTable->items[index] != NULL &&
		strcmp(hTable->items[index]->name, key) !=0) {
		index++;
		if (index == hTable->size) {
			resizeHT(hTable);
			index = fhash(key, hTable->size);
		}
	}
	return index;
}

void putHT(HashTable* hTable, NodeInfo* emp) {
	//first initialization of the hashtable
	if (hTable->items == NULL) {
		hTable->items = (NodeInfo**)malloc(sizeof(NodeInfo*) * HT_INITIAL_CAPACITY);
		memset(hTable->items, NULL, sizeof(NodeInfo*) * HT_INITIAL_CAPACITY);
		hTable->size = HT_INITIAL_CAPACITY;
	}
	int index = fhash(emp->name, hTable->size);
	if (hTable->items[index] != NULL) {
		//probing which returns a valid index
		index = linearProbing(hTable, index, emp->name);
	}
	hTable->items[index] = emp;
}

void printInfo(NodeInfo* info) {
	if (info)
		printf("Code: %d - Name: %s\n", info->code, info->name);
	else
		printf("No data to print!");
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