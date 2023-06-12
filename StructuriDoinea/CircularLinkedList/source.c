#define _CRT_SECURE_NO_WARNING

#include "stdio.h"
#include "stdlib.h"
#include "string.h"
#include "memory.h"

#define LINE_BUFFER 1024

struct Employee {
    int code;
    char* name;
    char* departament;
    double salary;
};

typedef struct Employee NodeInfo;

typedef struct node {
    NodeInfo* info;
    struct node* pNext;
}Node;

typedef struct node CLinkedList;

// function signatures for memory management
Node* createNode(NodeInfo*);
NodeInfo* createInfo(int,char*,char*,double);

// function signatures for list operations
void printSimpleList(const CLinkedList*);
CLinkedList* insertTail(CLinkedList*,Node*);
CLinkedList* insertHead(CLinkedList*, Node*);
CLinkedList* addCircularProperty(CLinkedList*);
void printInfo(Node*);
void printCircularList(CLinkedList*);
void deleteHeadList(CLinkedList**);
void deleteCircularList(CLinkedList**);


int main() {

    CLinkedList* list = NULL;
    FILE* pFile = fopen("Data.txt", "r");

    char* token = NULL;
    char lineBuffer[LINE_BUFFER];
    char* sepList = ",\n";

    char* name = NULL;
    char* dept = NULL;
    int code = 0;
    double salary = 0.0;

    if(pFile) {
        while(fgets(lineBuffer, sizeof(lineBuffer), pFile)) {
            token = strtok(lineBuffer, sepList);
            code = atoi(token);
            name = strtok(NULL, sepList);
            dept = strtok(NULL, sepList);
            token = strtok(NULL, sepList);
            salary = atof(token);

            NodeInfo* info = createInfo(code, name, dept, salary);
            Node* node =  createNode(info);

            list = insertTail(list, node); 
        }
        

        printSimpleList(list);

        printf("\n---------------------------------------------\n");

        list = addCircularProperty(list);
        printCircularList(list);

        printf("\n---------------------------------------------\n");

        deleteHeadList(&list);
        printCircularList(list);

        

        while(list){
            printf("\n---------------------------------------------\n");
            printCircularList(list);
            deleteCircularList(&list);
        }
        
    }
}

CLinkedList* insertTail(CLinkedList* head, Node* node){
    if(head == NULL) {
        head = node;
    } else {
        Node* temp = head;
        while(temp->pNext){
            temp = temp->pNext;
        }

        temp->pNext = node;
    }

    return head;

}

Node* createNode(NodeInfo* info) {
    Node* newNode = (Node*)malloc(sizeof(Node));
    newNode->info = info;
    newNode->pNext =NULL;
    return newNode;
}

NodeInfo* createInfo(int code, char* name, char* dept, double salary) {
    NodeInfo* info = (NodeInfo*)malloc(sizeof(NodeInfo));

    info->code = code;
    info->name = (char*)malloc(strlen(name) + 1);
    strcpy(info->name, name);
    info->departament = (char*)malloc(strlen(dept) + 1);
    strcpy(info->departament, dept);
    info->salary = salary;

    return info;

}

CLinkedList* insertHead(CLinkedList* head, Node* node){
    if(head == NULL) {
        head = node;
    } else {
        Node* temp = head;
        node->pNext = temp;
        head = node;
    }

    return head;
}

CLinkedList* addCircularProperty(CLinkedList* list){
    Node* head = list;
    while(list->pNext != NULL) {
        list = list->pNext;
    }
    list->pNext = head;
    return head;

}

void printCircularList(CLinkedList* list) {
    Node* temp = list;
    if(list != NULL) {
        do {
            printInfo(temp);
            temp = temp->pNext;
        } while(temp != list);
    }
}

void printInfo(Node* node) {

    printf("Code: %d, Name: %s, Departament: %s, Salary%f \n",
        node->info->code,
        node->info->name,
        node->info->departament,
        node->info->salary);
}

void printSimpleList(const CLinkedList* head) {
    for(;head; head = head->pNext){
        printf("Code: %d, Name: %s, Departament: %s, Salary%f \n",
        head->info->code,
        head->info->name,
        head->info->departament,
        head->info->salary);
    }
}

void deleteHeadList(CLinkedList** head){
    Node* iterator = *head;

    while(iterator->pNext != *head) {
        iterator = iterator->pNext;
    }

    iterator->pNext =(*head)->pNext;

    Node* temp = *head;
    *head = temp->pNext;
}

void deleteCircularList(CLinkedList** list) {
    Node* temp = *list;
    if(*list) {
        if((*list)->pNext == *list) {
            *list = NULL;
        } else {
            Node* iterator = *list;

            while(iterator->pNext != *list) {
                iterator = iterator->pNext;
            }
            iterator->pNext = (*list)->pNext;
            *list = temp->pNext;
        }
        free(temp->info->name);
        free(temp->info->departament);
        free(temp->info);
        
    }
    free(temp);
}


