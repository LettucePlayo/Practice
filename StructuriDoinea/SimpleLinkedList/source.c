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

typedef struct node SLinkedList;

// function signatures for memory management
Node* createNode(NodeInfo*);
NodeInfo* createInfo(int,char*,char*,double);

// function signatures for list operations
void printSimpleList(const SLinkedList*);
SLinkedList* insertTail(SLinkedList*,Node*);
SLinkedList* insertHead(SLinkedList*, Node*);
void printInfo(Node*);
void deleteHeadList(SLinkedList**);
SLinkedList* deleteAllOccurences(SLinkedList*,int);



int main() {

    SLinkedList* list = NULL;
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

        printf("\n----------------------------------------------------\n");
        list = deleteAllOccurences(list, 10001);
        printSimpleList(list);

        
    }
}

SLinkedList* insertTail(SLinkedList* head, Node* node){
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

SLinkedList* insertHead(SLinkedList* head, Node* node){
    if(head == NULL) {
        head = node;
    } else {
        Node* temp = head;
        node->pNext = temp;
        head = node;
    }

    return head;
}

void printInfo(Node* node) {

    printf("Code: %d, Name: %s, Departament: %s, Salary%f \n",
        node->info->code,
        node->info->name,
        node->info->departament,
        node->info->salary);
}

void printSimpleList(const SLinkedList* head) {
    for(;head; head = head->pNext){
        printf("Code: %d, Name: %s, Departament: %s, Salary%f \n",
        head->info->code,
        head->info->name,
        head->info->departament,
        head->info->salary);
    }
}

void deleteHeadList(SLinkedList** head){
    Node* iterator = *head;

    while(iterator->pNext != *head) {
        iterator = iterator->pNext;
    }

    iterator->pNext =(*head)->pNext;

    Node* temp = *head;
    *head = temp->pNext;
}

SLinkedList* deleteAllOccurences(SLinkedList* head,int cod) {
    if(head == NULL) {
        return head;
    } else {
        while(head && head->info->code == cod) {
            head = head->pNext;
        }

        Node* current = head;
        Node* prev = NULL;
        while(current) {
            if(current->info->code == cod){
                prev->pNext = current->pNext;
            } else {
                prev = current;
            }
            current = current->pNext;
        }
    }
    return head;
}


