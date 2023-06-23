import numpy as np
import pandas as pd
import acp.ACP as acp
import grafice as g

# 1) cititi fisierul si initializati cu datele din el un pd
tabel=pd.read_csv('dataIN/Teritorial.csv',na_values=':',index_col=0)
print(tabel)

# 2) imprimati la consola etichete;e col si randurilor si un ndarray cu valorile numerice
rows=tabel.index.values
cols=tabel.columns.values
col_numerice=cols[1:]
print('Rows',rows)
print('Columnns',cols)
print('Columns with numerical data:',col_numerice)
X=tabel[col_numerice]
numerical_values=tabel[col_numerice].values
print(numerical_values)
print(type(numerical_values))

# 3)standardizati matricea initiala ; salvati in csv + etichete
def standardise(X):
    avgs=np.mean(X,axis=0)
    std=np.std(X,axis=0)
    Xstd=(X-avgs)/std
    return Xstd

Xstd=standardise(X)
print(Xstd)
Xstd_df=pd.DataFrame(data=Xstd,index=rows,columns=col_numerice)
print(Xstd_df)
Xstd_df.to_csv('dataOUT/Xstd.csv')

# 4)matricea de corelatie R
acpModel = acp.ACP(Xstd)
R = acpModel.getCorr()
print('Matricea de corelatie')
print(R)

# 5) eigenvalues si vectors
valn=acpModel.getValues()
vecn=acpModel.getVectors()
print('Eigenvalues'); print(valn)
print('Eigenvectors'); print(vecn)

# 6) eigenvalues si vectors sortati
values=acpModel.getEigenvalues()
vectors=acpModel.getEigenvectors()
print('Eigenvalues sorted'); print(values)
print('Eigenvectors sorted'); print(vectors)

# 7) principal components
pComponents=acpModel.getPrincipalComponents()
print(pComponents)

# 8)creati un grafic reprezentand valorile proprii (variantaa componentelor principale) in ordine descrescatoare
# si evidentiati printr-o linie orizontala valoarea variatiei egala cu 1
g.componentePrincipale(values)


# Alte grafice din proiectele profului

# genereaza graficul corelograma
# pentru matricea de corelatie a variabilelor cauzale
g.correlogram(R,titlu='matricea de corelatie a variabilelor cauzale')


# genereaza corelograma scorurilor
scores=acpModel.getScores()
g.correlogram(scores,titlu='corelograma scorurilor')


# genereaza corelograma ce reflecta calitatea obsevatiilor
# # pe axele componentelor principale
qualities=acpModel.getQual()
g.correlogram(qualities,titlu='calitatea obsevatiilor')

# genereaza corelograma ce reflecta contributiei obsevatiilor
# # la varianta axele componentelor principale
betha=acpModel.getBetha()
g.correlogram(betha,titlu='contributia observatiilor la varianta axele componentelor principale')


# genereaza corelograma comunalitatilor
comm=acpModel.getCommunalities()
g.correlogram(comm,titlu='corelograma comunalitatilor')

# genereaza cercul corelatiilor
# variabile initiale in campul componentelor 1 si 2
g.correlationCircle(R,0,1)


# scatter R
g.norPuncte(R[:,0],R[:,1])
g.show()