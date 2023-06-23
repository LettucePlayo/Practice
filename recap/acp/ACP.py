import numpy as np

class ACP:
    def __init__(self,X):
        self.X=X
        self.R=np.corrcoef(self.X,rowvar=False)
        self.cov=np.cov(self.X,rowvar=False)

    #     eigenvalues, eigenvectors
        values, vectors=np.linalg.eigh(self.cov)
    #     sort descending
        k_desc=[k for k in reversed(np.argsort(values))]
        self.alpha=values[k_desc]
        self.a=vectors[:,k_desc]
    # regularizare eigenvectors
        for col in range(self.a.shape[1]):
            min=np.min(self.a[:,col])
            max=np.max(self.a[:,col])
            if(np.abs(min)>np.abs(max)):
                self.a[:,col]*=-1

    #  comp principale
        self.C = self.X @ self.a

    #     factor loadings
        self.fl=self.a * np.sqrt(self.alpha)

    # scores
        self.scores=self.a / np.sqrt((self.alpha))

    # communalities
        fl2=self.fl*self.fl
        self.com=np.cumsum(fl2,axis=1)

    # qualities
        pc2=self.C*self.C
        pcsum=np.sum(self.C,axis=1)
        self.qual=np.transpose(np.transpose(pc2)/pcsum)

    # betha
        self.betha=pc2 / (self.alpha * self.X.shape[0])

    def getCorr(self):
        return self.R
    def getCov(self):
        return self.cov
    def getEigenvalues(self):
        return self.alpha
    def getEigenvectors(self):
        return self.a
    def getPrincipalComponents(self):
        return self.C
    def getFactorLoadings(self):
        return self.fl
    def getScores(self):
        return self.scores
    def getCommunalities(self):
        return self.com
    def getQual(self):
        return self.qual
    def getBetha(self):
        return self.betha
    def getValues(self):
        return self.alpha
    def getVectors(self):
        return self.a

