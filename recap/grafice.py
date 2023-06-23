import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sb
import numpy as np

def show():
    plt.show()

def componentePrincipale(eigenvalues=None,titlu='Varianta componentelor principale',labelsx='X',labelsY=None):
    plt.figure(titlu,figsize=[15,15])
    plt.title(titlu,fontsize=14,c='purple')
    components=['C' + str(j+1) for j in range (len(eigenvalues))]
    plt.plot(components,eigenvalues)
    plt.xlabel('Principal components')
    plt.ylabel('Eigenvalues')
    plt.axhline(1,c='r')

def correlogram(X=None,titlu='Correlogram',vmin=-1,vmax=1):
    plt.figure(titlu,figsize=[15,15])
    plt.title(titlu,fontsize=14,c='b')
    sb.heatmap(X,vmin=vmin,vmax=vmax,annot=True,cmap='bwr')

def correlationCircle(R,R1,R2,titlu=None):
    plt.figure(titlu, figsize=[15, 15])
    plt.title(titlu, fontsize=14, c='b')

    T=[t for t in np.arange(0, np.pi*2, 0.01)]
    X=[np.cos(t) for t in T]
    Y=[np.sin(t) for t in T]
    plt.plot(X,Y)
    plt.axhline(0)
    plt.axvline(0)
    if isinstance(R, np.ndarray):
        plt.scatter(R[:,R1],R[:,R2])
        for i in range(len(R)):
            plt.text(R[i,R1],R[i,R2],s='('+str(R[i,R1])+', '+str(R[i,R2])+')')
    if isinstance(R,pd.DataFrame):
        plt.scatter(R.iloc[:,R1],R.iloc[:,R2])
        for i in range(len(R)):
            plt.text(R.iloc[i,R1],R.iloc[i,R2],R.index[i])


def norPuncte(x,y,label=None, xLabel="", yLabel="", titlu='Scatterplot'):
    plt.figure(titlu, figsize=[10, 10])
    plt.title(titlu, fontsize=14, c='b')
    plt.xlabel(xLabel)
    plt.ylabel(yLabel)
    plt.scatter(x,y,cmap='viridis')

