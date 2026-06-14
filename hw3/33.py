import math
import heapq

v_walk, v_subway = map(float, input().split())

n = int(input().strip())

pts = [None] * (n + 2)
for i in range(1, n + 1):
    x, y = map(float, input().split())
    pts[i] = (x, y)
    
adj = [[] for _ in range(n + 2)]

# 3. Считываем соединения метро
while True:
    u, v = map(int, input().split())
    if u == 0 and v == 0:
        break
    
    d = math.hypot(pts[u][0] - pts[v][0], pts[u][1] - pts[v][1])
    w = d / v_subway

    adj[u].append((v, w))
    adj[v].append((u, w))

xa, ya = map(float, input().split())
pts[0] = (xa, ya)

xb, yb = map(float, input().split())
pts[n + 1] = (xb, yb)

for i in range(n + 2):
    for j in range(i + 1, n + 2):
        d = math.hypot(pts[i][0] - pts[j][0], pts[i][1] - pts[j][1])
        w = d / v_walk
        adj[i].append((j, w))
        adj[j].append((i, w))
        

dist = [float('inf')] * (n + 2)
parent = [-1] * (n + 2)


pq = [(0.0, 0)]
dist[0] = 0.0

while pq:
    d, curr = heapq.heappop(pq)
    
    if d > dist[curr]:
        continue

    if curr == n + 1:
        break
        
    for neighbor, weight in adj[curr]:
        new_dist = dist[curr] + weight
        if new_dist < dist[neighbor]:
            dist[neighbor] = new_dist
            parent[neighbor] = curr
            heapq.heappush(pq, (new_dist, neighbor))
            
path = []
curr = n + 1
while curr != -1:
    path.append(curr)
    curr = parent[curr]

path.reverse()

stations = [node for node in path if 1 <= node <= n]

print(f"{dist[n + 1]:.7f}")
print(f"{len(stations)} " + " ".join(map(str, stations)))
