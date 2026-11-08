using System;
using System.Collections.Generic;
using System.Text;

namespace EstructurasGrafos
{
    internal class Graph
    {
        // Diccionario para almacenar los vértices y sus vecinos (Vecino -> Peso/Distancia)
        private Dictionary<string, Dictionary<string, int>> adjList = new Dictionary<string, Dictionary<string, int>>();

        // Almacena la traza del último cálculo de Dijkstra para mostrarla en el reporte o interfaz
        public List<string> ExecutionTrace = new List<string>();

        // Agregar un vértice (ej. una ciudad)
        public void AddVertex(string vertex)
        {
            if (!adjList.ContainsKey(vertex))
            {
                adjList[vertex] = new Dictionary<string, int>();
            }
        }

        // Agregar una arista ponderada (dirigida o no dirigida, aquí la manejaremos bidireccional por defecto)
        public void AddEdge(string origen, string destino, int peso)
        {
            AddVertex(origen);
            AddVertex(destino);

            adjList[origen][destino] = peso;
            adjList[destino][origen] = peso; // Grafo no dirigido (ida y vuelta)
        }

        // Obtener la lista de todos los vértices
        public List<string> GetVertices()
        {
            return new List<string>(adjList.Keys);
        }

        // =====================================================================
        // MATRIZ DE ADYACENCIA (Requisito de la rúbrica)
        // =====================================================================
        public string GetAdjacencyMatrixString()
        {
            var vertices = GetVertices();
            vertices.Sort();
            StringBuilder sb = new StringBuilder();

            // Encabezado
            sb.Append(string.Format("{0,-12}", "Nodo"));
            foreach (var v in vertices)
            {
                sb.Append(string.Format("{0,-10}", v));
            }
            sb.AppendLine();
            sb.AppendLine(new string('-', 12 + (vertices.Count * 10)));

            // Filas
            foreach (var v1 in vertices)
            {
                sb.Append(string.Format("{0,-12}", v1));
                foreach (var v2 in vertices)
                {
                    int peso = 0;
                    if (v1 == v2)
                    {
                        peso = 0;
                    }
                    else if (adjList[v1].ContainsKey(v2))
                    {
                        peso = adjList[v1][v2];
                    }
                    else
                    {
                        peso = 999; // Infinito (sin conexión directa)
                    }
                    sb.Append(string.Format("{0,-10}", peso == 999 ? "INF" : peso.ToString()));
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        // =====================================================================
        // ALGORITMO DE DIJKSTRA (Camino más corto + Traza de ejecución)
        // =====================================================================
        public (List<string> path, int totalCost) Dijkstra(string inicio, string destino)
        {
            ExecutionTrace.Clear();
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var unvisited = new List<string>();

            foreach (var vertex in adjList.Keys)
            {
                distances[vertex] = int.MaxValue;
                previous[vertex] = null;
                unvisited.Add(vertex);
            }

            if (!distances.ContainsKey(inicio) || !distances.ContainsKey(destino))
            {
                ExecutionTrace.Add("Error: El nodo de inicio o destino no existe en el grafo.");
                return (new List<string>(), -1);
            }

            distances[inicio] = 0;
            ExecutionTrace.Add($"[Inicio] Estableciendo distancia 0 al nodo de origen '{inicio}'.");

            while (unvisited.Count > 0)
            {
                // Encontrar el nodo no visitado con la distancia mínima menor
                string current = null;
                int minDistance = int.MaxValue;

                foreach (var vertex in unvisited)
                {
                    if (distances[vertex] < minDistance)
                    {
                        minDistance = distances[vertex];
                        current = vertex;
                    }
                }

                if (current == null || minDistance == int.MaxValue)
                {
                    break; // No hay más nodos alcanzables
                }

                ExecutionTrace.Add($"-> Visitando nodo actual '{current}' con distancia acumulada actual: {minDistance}");

                if (current == destino)
                {
                    ExecutionTrace.Add($"[Llegada] Se ha alcanzado el nodo destino '{destino}'.");
                    break;
                }

                unvisited.Remove(current);

                // Relajación de aristas vecinas
                foreach (var neighbor in adjList[current])
                {
                    string v = neighbor.Key;
                    int weight = neighbor.Value;

                    if (unvisited.Contains(v))
                    {
                        int alt = distances[current] + weight;
                        ExecutionTrace.Add($"   Evaluando vecino '{v}' (peso arista: {weight}). Distancia alternativa: {alt} vs actual: {distances[v]}");

                        if (alt < distances[v])
                        {
                            distances[v] = alt;
                            previous[v] = current;
                            ExecutionTrace.Add($"   Actualizado: Menor distancia a '{v}' ahora es {alt} (vía '{current}')");
                        }
                    }
                }
            }

            // Reconstruir el camino más corto
            var path = new List<string>();
            string curr = destino;

            while (curr != null)
            {
                path.Insert(0, curr);
                curr = previous[curr];
            }

            int totalCost = distances[destino];
            return (path, totalCost);
        }
    }
}
