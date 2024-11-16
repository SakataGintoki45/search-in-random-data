namespace search_in_random_data
{
    public partial class Form1 : Form
    {
        List<int> values = new List<int>();
        public Form1()
        {
            InitializeComponent();

            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                values.Add(rand.Next(1, 1000));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearchValue.Text, out int searchValue))
            {
                // Búsqueda Secuencial
                int resultSecuencial = BusquedaSecuencial(searchValue);

                // Actualizar el texto del Label con los resultados
                if (resultSecuencial != -1)
                {
                    lblResult.Text = $"Búsqueda Secuencial: Valor encontrado en el índice {resultSecuencial}.";
                }
                else
                {
                    lblResult.Text = "Búsqueda Secuencial: Valor no encontrado.";
                }

                // Búsqueda Binaria (lista ordenada)
                values.Sort(); // Asegurarse de que esté ordenada
                int resultBinaria = BusquedaBinaria(searchValue);

                if (resultBinaria != -1)
                {
                    lblResult.Text += $"\nBúsqueda Binaria: Valor encontrado en el índice {resultBinaria}.";
                }
                else
                {
                    lblResult.Text += "\nBúsqueda Binaria: Valor no encontrado.";
                }
            }
            else
            {
                lblResult.Text = "Por favor, ingrese un valor válido para buscar.";
            }
        }


        private int BusquedaSecuencial(int valor)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == valor)
                {
                    return i; // Retorna el índice donde se encuentra el valor
                }
            }
            return -1; // Si no se encuentra, retorna -1
        }

        // Método de búsqueda binaria
        private int BusquedaBinaria(int valor)
        {
            // Primero, la lista debe estar ordenada
            values.Sort();

            int left = 0;
            int right = values.Count - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                // Comprobamos si el valor está en el medio
                if (values[middle] == valor)
                    return middle;

                // Si el valor es mayor, se busca en la mitad derecha
                if (values[middle] < valor)
                    left = middle + 1;
                // Si el valor es menor, se busca en la mitad izquierda
                else
                    right = middle - 1;
            }

            return -1; // Si no se encuentra, retorna -1
        }
    }
}
