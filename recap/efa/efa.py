import acp.ACP as acp
import scipy.stats as sts
import numpy as np

class EAF:
    def __init__(self,X):
        self.X=X
        acpModel=acp.ACP(self.X)
        self.R=acpModel.getCorr()
        self.scores=acpModel.getScores()
        self.alpha=acpModel.getEigenvalues()
        self.a=acpModel.getEigenvectors()
        self.qual=acpModel.getQual()

    def getCorr(self):
        return self.R
    def getEigenvalues(self):
        return self.alpha
    def getEigenvectors(self):
        return self.a
    def getScores(self):
        return self.scores
    def getQual(self):
        return self.qual

    def testBarlett(self,loading,epsilon):
        m,q=loading.shape
        n=self.X.shape[0]
        V=self.R
        psi=np.diag(epsilon)
        u_ut_psi=loading @ np.transpose(loading) + psi
        u_ut_psi_V=np.linalg.inv(u_ut_psi) @ V
        detInv=np.linalg.det(u_ut_psi_V)
        if detInv>0:
            trace=np.trace(u_ut_psi_V)
            lg=np.log(detInv)
            test=(n-1-(2*m + 4*q -5)/6) * (trace - lg - m)
            r=((m-q)*(m-q)-m-q)/2
            cdf=sts.chi2.cdf(test,r)
        else:
            test,cdf= np.nan,np.nan
        return test,cdf
