import numpy as np
import pandas.api.types as pdt

def inlocuireNan(X):
    mean=np.nanmean(X,axis=0)
    pos = np.where(np.isnan(X))
    X[pos]=mean[pos[1]]
    return X

def standardizare(X):
    avgs=np.mean(X,axis=0)
    std=np.std(X,axis=0)
    Xstd=(X-avgs)/std
    return Xstd

def inlocuireNanDf(t):
    for c in t.columns:
        if pdt.is_numeric_dtype(t[c]):
            if t[c].isna().any():
                avg=t[c].mean()
                t[c]=t[c].fillna(avg)
        else:
            if t[c].isna().any():
                mod=t[c].mode()
                t[c]=t[c].fillna(mod)