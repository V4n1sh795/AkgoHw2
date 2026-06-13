# https://acm.timus.ru/problem.aspx?space=1&num=1119
import heapq

def dijkstra(graph, start, target):
    distances = {node: 1000 for node in graph}
    distances[start] = 0.0
    
    priority_queue = [(0.0, start)]
    
    while priority_queue:
        current_distance, current_node = heapq.heappop(priority_queue)
        
        if current_node == target:
            break
            
        if current_distance > distances[current_node]:
            continue
            
        for edge_dict in graph.get(current_node, []):
            neighbor, weight = next(iter(edge_dict.items()))
            
            distance = current_distance + weight
            
            if distance < distances[neighbor]:
                distances[neighbor] = distance
                heapq.heappush(priority_queue, (distance, neighbor))
        
    return distances[target]

def print_graf(graf):
    for elem in graf:
        print(f"{elem}: {graf[elem]}")

N, M = map(int, input().split())

graf = {}

for x in range(N+1):
    for y in range(M+1):
        graf[(x, y)] = []
        point1 = (x+1, y) if x+1 <= N else 0
        point2 = (x, y+1) if y+1 <= M else 0
        if point1 != 0:
            graf[(x, y)].append({point1: 100.0})
        if point2 != 0:
            graf[(x, y)].append({point2: 100.0})

nijds = int(input())
for i in range(nijds):
    x, y = map(int, input().split())
    graf[(x-1, y-1)].append({(x, y): 141.421356237})
print(round(dijkstra(graf,(0, 0), (N, M))))