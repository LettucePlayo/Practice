import efa.efa as efa
import numpy as np
import pandas as pd
import functions as fun
from sklearn.preprocessing import StandardScaler
import factor_analyzer as fa
import grafice as g

tabel=pd.read_csv('dataIN/MortalityEU.csv',index_col=0,na_values=':')
obsNume = tabel.index.values
varNume = tabel.columns.values
matrice_numerica = tabel.values
print(matrice_numerica)
X = fun.inlocuireNan(matrice_numerica)
print(X)

aefModel = efa.EAF(X)
scalare=StandardScaler()
Xstd=scalare.fit_transform(X)

# salvarea matricei standardizate in fisier CSV
Xstd_df = pd.DataFrame(data=Xstd, index=obsNume, columns=varNume)
Xstd_df.to_csv('dataOUT/Xstd.csv')

sphBartlett=fa.calculate_bartlett_sphericity(Xstd_df)
print('Bartlett sphericity test:')
print(sphBartlett)

if(sphBartlett[0]>sphBartlett[1]):
    print('At least one common factor')
else:
    print('No common factor')

# KMO indices
kmo=fa.calculate_kmo(Xstd_df)
print('KMO: ',kmo)
vector=kmo[0]
print('Vector',vector)
matrice=vector[:,np.newaxis]
print('Matrice:', matrice)

matrice_df = pd.DataFrame(data=matrice,
        columns=['Indici_KMO'],
        index=varNume)

g.correlogram(matrice_df,titlu='KMO indices')
g.show()

if(kmo[1] > 0.5):
    print('At least one common factor')
else:
    print('No common factor')

# extragere factori semnificativi
nrFactoriSemnificativi=1
chi2TabMin=1
for k in range(1,varNume.shape[0]):
    faModel=fa.FactorAnalyzer(n_factors=k)
    faModel.fit(X=Xstd_df)
    factoriComuni=faModel.loadings_
    factoriSpecifici=faModel.get_uniquenesses()

    chi2Calc,chi2Tab=aefModel.testBarlett(factoriComuni,factoriSpecifici)
    print(chi2Calc,chi2Tab)

    if np.isnan(chi2Calc) or np.isnan(chi2Tab):
        break
    if chi2Tab < chi2TabMin:
        chi2TabMin = chi2Tab
        nrFactoriSemnificativi = k

print(nrFactoriSemnificativi)

# Crearea modelului cu numarul de factori semnificativi
faFitModel=fa.FactorAnalyzer(n_factors=nrFactoriSemnificativi)
faFitModel.fit(Xstd_df)

fit_loadings = faFitModel.loadings_
numeFactori=['F' + str(i+1) for i in range(nrFactoriSemnificativi)]
fit_loadings_df=pd.DataFrame(data=fit_loadings,columns=numeFactori,index=varNume)
g.correlogram(fit_loadings_df,titlu='Corel factorilor de corelatie din FA')


fit_eigenvalues=faFitModel.get_eigenvalues()
g.componentePrincipale(fit_eigenvalues[0])

g.show()