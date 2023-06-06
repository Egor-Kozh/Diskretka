def sv(b, a, k, c):
    while len(c) != 0:
        k.append(c[0])
        for i in b[c[0]]:
            if i not in c and i not in k:
                c.append(i)
        a.remove(c[0])
        c.pop(0)
    return a, k, c


b = {1: [2, 3], 2: [1, 3], 3: [1, 2, 4], 4: [3, 6, 5], 5: [4, 6], 6: [4, 5]}
a = [1, 2, 3, 4, 5, 6]
k = []
c = []
c.append(int(input()))
a, k, c = sv(b, a, k, c)
print(k)
if len(a) != 0:
    c.append(a[0])
    k = []
    a, k, c = sv(b, a, k, c)
    print(k)
