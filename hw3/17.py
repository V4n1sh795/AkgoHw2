import sys

input_data = sys.stdin.read().split()

N = int(input_data[0])
M = int(input_data[1])

grid = []
idx = 2
for _ in range(N):
    grid.append([int(x) for x in input_data[idx:idx+M]])
    idx += M
    

if N > M:
    grid = [list(x) for x in zip(*grid)]
    N, M = M, N
    
max_sum = -1
for r1 in range(N):
    col_sum = [0] * M
    for r2 in range(r1, N):
        row = grid[r2]
        current_sum = 0
        
        for j in range(M):
            col_sum[j] += row[j]
            current_sum += col_sum[j]
            
            if current_sum > max_sum:
                max_sum = current_sum
                
            if current_sum < 0:
                current_sum = 0
                
print(max_sum)
