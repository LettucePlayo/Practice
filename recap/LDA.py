import pandas as pd
import numpy as np
import functions as fun
import sklearn.discriminant_analysis as disc
import pandas.api.types as pdt

def inlocuireNanDf(t):
    for c in t.columns:
        if(pdt.is_numeric_dtype(t[c])):
            if(t[c].isna().any()):
                avg=np.mean[t[c]]
                t[c]=t[c].fillna(avg)
        else:
            if (t[c].isna().any()):
                mod = np.mode[t[c]]
                t[c] = t[c].fillna(mod)

def coding(t,vars):
    assert isinstance(t,pd.DataFrame), 'We need a data frame'
    for v in vars:
        t[v]=pd.Categorical(t[v]).codes

f1 = 'dataIN/ProiectB.csv'
f2 = 'dataIN/ProiectBEstimare.csv'
t1 = pd.read_csv(f1, index_col=0)
print(t1)
t2 = pd.read_csv(f2, index_col=0)

inlocuireNanDf(t1)
inlocuireNanDf(t2)

print(t1); print(t2)

# luam variabilele cateogorice din t1
var_categorical=t1.columns[:6].values
print('Variabile categorice:' , var_categorical)
# transformam variabilele cateogorice in var quantitative
coding(t1,var_categorical)
coding(t2,var_categorical)

# luam toate coloanele mai putin cea discriminanta
var_p=t1.columns[:11].values
# luam si col discriminanta
var_c='VULNERAB'

# cream matricile X si Y din curs -> X e cea cu observatii si Y e cea cu variabila discriminanta
X=t1[var_p].values
Y=t1[var_c].values

# cream obiectul LDA
ldaObject=disc.LinearDiscriminantAnalysis()
ldaObject.fit(X=X,y=Y)

# compute the accuracy of prediction
classSetBase = ldaObject.predict(X=X)
classSetBase_df=pd.DataFrame(data={
                                 str(var_c[0]) : Y,
                                 'prediction' : classSetBase },
    index=t1.index)
print(classSetBase_df)
classSetBase_df.to_csv('dataOUt/classSetBase.csv')

# compute the global level of prediction

errClassSetBase = classSetBase_df[Y != classSetBase]
n=len(Y)
n_err=len(errClassSetBase)
accuracy_level=(n-n_err)*100 / n
print('Accuracy level:', accuracy_level)

# predictie pt setul de test
classSetTest=ldaObject.predict(X=t2[var_p].values)
classSetTest_df=pd.DataFrame(data=classSetTest,index=t2.index)
print(classSetTest_df)

g=ldaObject.classes_
q=len(g)

mat=pd.DataFrame(data=np.zeros(shape=(q,q)),index=g,columns=g)
print(mat)

for i in range(n):
    mat.loc[Y[i],classSetBase[i]] +=1

print(mat)
group_accuracy_df=np.diag(mat)*100 / np.sum(mat,axis=1)
mat['Group Accuracy']=group_accuracy_df
print(mat)