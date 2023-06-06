import math
print('Введите число вершин графа')
n=int(input())
b=[[0 for i in range(n)] for j in range (n)]
print("Введите матрицу весов построчно (b = бесконечность)")
for i in range(n):
    for j in range(n):
        b[i][j]=input()
        if b[i][j]=='b':
            b[i][j]=math.inf
        else:
            b[i][j]=int(b[i][j])
Lamb=[[0 for i in range(n)] for j  in range (n)]
print("Введите вершину от которой идем")
ii=int(input())-1
for i in range(n):
    if i!=ii:
        Lamb[i][0]=math.inf
for i in range(n):
    if i!=ii:
        Lamb[0][ii]=0
for k in range(1,n):
    for i in range(1,n):
        minn=[]
        for j in range(n):
            minn.append(Lamb[j][k-1]+b[j][i])
        Lamb[i][k]=min(minn)
print("Введите вершину к которой идем")
t=int(input())
print('\n'*20)
print(Lamb[t-1][-1])