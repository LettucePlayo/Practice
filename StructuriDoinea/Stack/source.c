#define _CRT_SECURE_NO_WARNINGS

#include "stdio.h"
#include "memory.h"
#include "string.h"
#include "stdlib.h"

// STACK - Simple linked list in wich insertion and deletion is restricted
// at the head (top) 

struct Employee {
    short code;
    char* name;
    char* dept;
    double salary;
};

typedef struct node {
    struct Employee* info;
    struct node* pNext;
}Node;

typedef struct Employee NodeInfo;
typedef struct node Stack;

#define LINE_BUFFER 1024

// function signatures for memory management
NodeInfo* createInfo(short, char*, char*, double);
Node* createNode(NodeInfo*);

// function signatures for stack operations
void printInfo(NodeInfo*);
Stack* push(Stack*, NodeInfo*);
NodeInfo* pop(Stack**);
NodeInfo* peek(const Stack*); // -> gets the value fro the first node
Stack* printStack(Stack*);
 
void main(){

    Stack* stack = NULL;
    FILE* pFile = fopen("Data.txt", "r");
    char* token = NULL, lineBuffer[LINE_BUFFER], *sepList = ",\n";
    char* name = NULL, *dept = NULL;
    short code = 0;
    double salary = 0.0;

    if(pFile) {

        // fgets ->  returns the content of a full line untill \n
        while(fgets(lineBuffer, sizeof(lineBuffer), pFile) != NULL) {

            token = strtok(lineBuffer, sepList);
            code = atoi(token);
            name  = strtok(NULL, sepList);
            dept = strtok(NULL, sepList);
            token = strtok(NULL, sepList);
            salary = atof(token);
            
            NodeInfo* info = createInfo(code, name, dept, salary); 
            stack = push(stack, info);
            
        }     

        NodeInfo* emp = pop(&stack);
        printInfo(emp);

        //stack = printStack(stack);
        printf("\n-----------------------------------\n");
        stack = printStack(stack);

        while(stack) {
            NodeInfo* emp = pop(&stack);
            printInfo(emp);
            free(emp->name);
            free(emp->dept);
            free(emp);
        }

        printf("\n-----------------------------------\n");
        stack = printStack(stack); // stiva e goala
    }
}

Stack* printStack(Stack* stack){

    Stack* temp = NULL;
    while(stack) {
        NodeInfo* emp = pop(&stack);
        printInfo(emp);
        temp = push(temp, emp);
    }

    while(temp) {
        stack = push(stack, pop(&temp));
    }

    return stack;

}

NodeInfo* createInfo(short code, char* name, char* dept, double salary){

    struct Employee* emp = (NodeInfo*)malloc(sizeof(NodeInfo));
    emp->code = code;
    emp->name = (char*)malloc(strlen(name) + 1);
    strcpy(emp->name, name);
    emp->dept = (char*)malloc(strlen(dept) + 1);
    strcpy(emp->dept, dept);
    emp->salary = salary;

    return emp; 
}

Node* createNode(NodeInfo* info){
    Node* node = (Node*)malloc(sizeof(Node));
    node->info = info;
    node->pNext = NULL;

    return node;
}

void printInfo(NodeInfo* info){
    printf("Code: %d, Name: %s, Departament: %s, Salary: %f\n",
            info->code,
            info->name,
            info->dept,
            info->salary);
}

Stack* push(Stack* stack, NodeInfo* info){
    Stack* newNode = createNode(info);
    newNode->pNext = stack;
    return newNode;
}

NodeInfo* pop(Stack** stack) {
    NodeInfo* value = NULL;
    if(*stack != NULL) {
        value = (*stack)->info;
        Node* temp = *stack;
        *stack = temp->pNext;
        free(temp);
    }
    return value;
}
