import numpy as np
import pandas as pd

industrie=pd.read_csv('dataIN/Industrie.csv',index_col=0)
# print(industrie)

poploc=pd.read_csv('dataIN/PopulatieLocalitati.csv',index_col=0)
# print(poploc)

t=industrie.merge(right=poploc,left_index=True,right_index=True)
print(type(t))
print(t)
# t.to_csv('dataOUT/joaca.csv')

industrii_etichete=list(industrie.columns[1:].values)
print('Industrii etichete');print(industrii_etichete)
def caLoc(t,variabile,populatie):
    x=t[variabile].values/t[populatie]
    # print(x)
    v=list(x)
    v.insert(0,t['Localitate_x'])
    return pd.Series(data=v,index=['Localitate']+variabile)
t_ind=t[['Populatie','Localitate_x'] + industrii_etichete ].apply(func=caLoc,axis=1,variabile=industrii_etichete,populatie='Populatie')
print(t_ind)

def avg2(t,variabile,populatie):
    x=t[variabile].values/t[populatie]
    v=list(x)
    v.insert(0,t['Localitate_x'])
    return pd.Series(data=v,index=[['Localitate']+variabile])
t_ind_2=t[['Populatie','Localitate_x']+industrii_etichete].apply(func=avg2,axis=1,variabile=industrii_etichete,populatie='Populatie')
print(t_ind_2)
# 2

def max_ca(t):
    x=t.values
    max_linie=np.argmax(x)
    return pd.Series(data=[t.index[max_linie],x[max_linie]],index=['Activitate','Cifra afaceri'])

t3=t[industrii_etichete + ['Judet']].groupby(by='Judet').agg(sum)
print(t3)

t4=t3[industrii_etichete].apply(func=max_ca,axis=1)
print(t4)

# min cifra afaceri
def min_ca(t):
    x=t.values
    min_linie=np.argmin(x)
    return pd.Series(data=[t.index[min_linie],x[min_linie]],index=['Activitate','Min ca'])

t5=t[industrii_etichete +['Judet']].groupby('Judet').agg(func=sum)
t6=t5[industrii_etichete].apply(func=min_ca,axis=1)
print(t6)