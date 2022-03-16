def IsConnected(graph, src, dest, visited):
    if(src == dest):
        return True

    if(src in visited):
        return False
    
    visited.add(src)
    
    for neighbor in graph[src]:
        if(IsConnected(graph, neighbor, dest, visited) == True):
            return True
    return False


def CreateGraph(edges):
    graph = {}
    for edge in edges:
        if( edge[0] not in graph):
            graph[edge[0]] = []

        if( edge[1] not in graph):
            graph[edge[1]] = []

        graph[edge[0]].append(edge[1])
        graph[edge[1]].append(edge[0])
    
    return graph

edges = [
    ['i', 'j'],
    ['k', 'i'],
    ['m', 'k'],
    ['k', 'l'],
    ['o', 'n'],
]

graph = CreateGraph(edges)
print(IsConnected(graph, 'i', 'n', set()))
