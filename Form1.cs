namespace EstructurasGrafos
{
    public partial class Form1 : Form
    {

        // Instancia global del grafo ponderado
        private Graph grafo = new Graph();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargarGrafo_Click(object sender, EventArgs e)
        {
            grafo = new Graph(); // Reiniciar instancia

            // Agregamos rutas ponderadas (ej. Ciudades y distancias en km)
            grafo.AddEdge("Monclova", "Saltillo", 190);
            grafo.AddEdge("Monclova", "Monterrey", 200);
            grafo.AddEdge("Saltillo", "Monterrey", 85);
            grafo.AddEdge("Monterrey", "Torreón", 380);
            grafo.AddEdge("Saltillo", "Torreón", 300);

            lstResultados.Items.Clear();
            lstResultados.Items.Add("¡Grafo ponderado cargado con éxito!");
            lstResultados.Items.Add("Ciudades disponibles: Monclova, Saltillo, Monterrey, Torreón");
            lstResultados.Items.Add("--------------------------------------------------");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string origen = txtOrigen.Text.Trim();
            string destino = txtDestino.Text.Trim();

            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
            {
                MessageBox.Show("Por favor, ingresa un nodo de origen y un nodo de destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ejecutar el algoritmo de Dijkstra
            var (path, totalCost) = grafo.Dijkstra(origen, destino);

            lstResultados.Items.Clear();

            if (totalCost == -1 || path.Count == 0)
            {
                lstResultados.Items.Add($"No se encontró ruta entre '{origen}' y '{destino}'.");
                return;
            }

            // Mostrar resultados principales
            lstResultados.Items.Add($"=== RESULTADO ALGORITMO DE DIJKSTRA ===");
            lstResultados.Items.Add($"Ruta más corta: {string.Join(" -> ", path)}");
            lstResultados.Items.Add($"Costo / Distancia total: {totalCost} km");
            lstResultados.Items.Add("--------------------------------------------------");
            lstResultados.Items.Add("--- TRAZA DE EJECUCIÓN PASO A PASO ---");

            // Mostrar la traza detallada requerida por la rúbrica
            foreach (var traceLine in grafo.ExecutionTrace)
            {
                lstResultados.Items.Add(traceLine);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lstResultados.Items.Clear();
            lstResultados.Items.Add("=== MATRIZ DE ADYACENCIA (PESOS) ===");

            string matrixString = grafo.GetAdjacencyMatrixString();
            string[] lines = matrixString.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                lstResultados.Items.Add(line);
            }
        }
    }
}
