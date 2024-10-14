from collections import deque


def bfs_shortest_path(graph, start, end):
    queue = deque([[start]])  # struktura do przechowywania ściezki
    visited = set()

    while queue:
        path = queue.popleft()  # usuwa i zwraca 1 od lewej element
        node = path[-1]
        if node == end:
            return path

        if node not in visited:
            for neighbor in graph.get(node,[]):
                new_path = list(path)
                new_path.append(neighbor)
                queue.append(new_path)
            visited.add(node)
    return None


graph = {
    'A': ['B','C'],
    'B': ['A','D','E'],
    'C': ['A','F'],
    'D': ['A'],
    'E': ['B','F'],
    'F': ['C','E']
}


print(bfs_shortest_path(graph, 'A','F'))