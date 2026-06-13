N, M = map(int, input().split())
str_N = input()
str_M = input()

previos_line = list(range(N + 1))

for i in range(1, M + 1):
    curr = [i] + [0] * N
    for j in range(1, N + 1):
        cost = 0 if str_N[j - 1] == str_M[i - 1] else 1
        
        curr[j] = min(
            previos_line[j] + 1,
            curr[j - 1] + 1,
            previos_line[j - 1] + cost
        )
    
    previos_line = curr

print(previos_line[N])