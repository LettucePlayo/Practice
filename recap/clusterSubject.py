import numpy as np
import pandas as pd
import functions as fun
import scipy.cluster.hierarchy as hiclu
import scipy.spatial.distance as hdist
import matplotlib.pyplot as plt

# Cluster analysis subject
# 1) citit fisierul s initializati cu datele din el un pd
indicatori = pd.read_csv('dataIN/Indicatori.csv',na_values=':',index_col=0)
print(indicatori)

# 2) tipariti la consola etichetele col, liniilor si matricea numerica
rows = indicatori.index.values
cols = indicatori.columns.values
print(rows)
print(cols)

ind=cols[4:]
print(ind)
numeric_matrix = indicatori[ind].values
print(numeric_matrix)
X=fun.inlocuireNan(numeric_matrix)

# 3) standardizati X si scrieti Xstd la consola impreuna cu etichetele coresp
Xstd=fun.standardizare(X)
Xstd_df=pd.DataFrame(data=Xstd,index=rows,columns=ind)
print(Xstd_df)

# 4) extrageti lista metodelor si a metricilor
methods=list(hiclu._LINKAGE_METHODS)
print(methods)
metrics=list(hdist._METRICS_NAMES)
print(metrics)

# 5) det grupurile de tari pe baza legaturii medii si a distantei euclidiene. scrieti rez intr-un fisier csv
h_1=hiclu.linkage(y=Xstd,method='average',metric='euclidean');
print(h_1)
h1_df=pd.DataFrame(data=h_1)
h1_df.to_csv('dataOUT/h1.csv')


def calculThreshold(h):
    # nr de linii
    # n = h.shape[0]
    n,p=np.shape(h)
    # ignoram prima linie si luam toata coloana 2
    dist_1=h[1:,2]
    # ignoram ultima linie si luam toata coloana 2
    dist_2=h[:n-1,2]
    # facem diferenta
    diff=dist_2-dist_1
    # luam pozitia unde avem cea mai mare dif
    difMax=np.argmax(diff)
    # t = h[max,2] + h[max+1 , 2] / 2
    threshold = (h[difMax,2]+h[difMax+1,2])/2
    return threshold, n, difMax


threshold,nrJonctiuni,difMax=calculThreshold(h_1)
print('Threshold',threshold)
print('Nr jonctiuni',nrJonctiuni)
print('Jonctiune dif max',difMax)

def determinareClustere(h,difMax):
    # luam nr de linii
    n= h.shape[0]
#     facem un array numit groups cu cate linii avem
    groups=np.arange(n)
    # print(groups)
    for i in  range(difMax+1):
        # luam primul nod
        k1=h[i,0]
        #luam al doilea nod
        k2=h[i,1]
        groups[groups==k1]=n+1
        groups[groups==k2]=n+1
        # print(groups)
    clustere=pd.Categorical(groups)
    codes=clustere.codes
    # print('Codes:' , codes)
    obsCluster=['C' + str(j+1) for j in codes]
    # print(obsCluster)
    return obsCluster




obsCluster=determinareClustere(h_1,difMax)
print('Groups:') ; print(obsCluster)

obsCluster_df=pd.DataFrame(data=obsCluster)
obsCluster_df.to_csv('dataOUT/obsClustere.csv')

# 6) construiti graficul dendograma si afisati ierarhia de tari det anterior
def dendograma(h,title='Dendogram',threshold=None,labels=None):
    plt.figure(title,figsize=[15,15])
    plt.title(title,c='r',fontsize=16)
    hiclu.dendrogram(h,labels=labels)
    if threshold is not None:
        plt.axhline(threshold,c='r')

dendograma(h_1,title='Average method')
plt.show()

# 7) calculati threshold si utilizati dendograma pt a face o taietura pe orizontala

dendograma(h_1,threshold=threshold,title='Average method with threshold')
plt.show()

# 8) det grupurile de variabile pe baza metodei mediene
h_2=hiclu.linkage(Xstd,method='median')

# 9)construiti dendograma
dendograma(h_2,title='Median method')
plt.show()

