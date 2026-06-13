import sys

input_data = sys.stdin.read().split()

N = int(input_data[0])
M = int(input_data[1])
grid = [list(row) for row in input_data[2:]]

carpets = 0

for i in range(N):
    for j in range(M):
        if grid[i][j] == '+':
            carpets += 1

            stack = [(i, j)]
            grid[i][j] = '.'
            
            while stack:
                r, c = stack.pop()
                
                if r > 0 and grid[r-1][c] == '+':
                    grid[r-1][c] = '.'
                    stack.append((r-1, c))
                if r < N - 1 and grid[r+1][c] == '+':
                    grid[r+1][c] = '.'
                    stack.append((r+1, c))
                if c > 0 and grid[r][c-1] == '+':
                    grid[r][c-1] = '.'
                    stack.append((r, c-1))
                if c < M - 1 and grid[r][c+1] == '+':
                    grid[r][c+1] = '.'
                    stack.append((r, c+1))
                    
print(carpets)
