using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing; // Para alterar as cores e definir a imagem de fundo

namespace Estoque_de_equipamentos
{
    public partial class Form2 : Form
    {
        private string dataFilePath = "estoque.txt"; // Caminho para o arquivo de dados

        public Form2()
        {
            InitializeComponent();
            InitializeCustomComponents();
            // Chama o método para definir a imagem de fundo
            SetBackgroundImage();
            this.Icon = new Icon(@"C:\Users\Felipe\Downloads\favicon.ico");


        }

        // Inicializa componentes personalizados e configurações
        private void InitializeCustomComponents()
        {
            // Inicializar eventos dos botões
            btnCadastrarEntrada.Click += BtnCadastrarEntrada_Click;
            btnRegistrarSaida.Click += BtnRegistrarSaida_Click;
            btnListarProdutos.Click += BtnListarProdutos_Click;
            dataGridView1.CellClick += DataGridView1_CellClick; // Altere para CellClick

            // Adiciona placeholders aos TextBox
            SetPlaceholder(txtProduto, "Digite o nome do produto");
            SetPlaceholder(txtMarca, "Digite a marca");

            // Adiciona Placeholder aos ComboBoxes
            SetComboBoxPlaceholder(cmbCategoria, "Selecione a categoria");
            SetComboBoxPlaceholder(cmbEstado, "Selecione o estado");

            // Carregar dados ao iniciar
            LoadData();
        }

        // Define a imagem de fundo para o formulário
        private void SetBackgroundImage()
        {
            try
            {
                // Defina aqui o caminho da imagem de fundo
                string imagePath = @"C:\Users\Felipe\source\repos\Estoque de equipamentos\65e51ddf1e425.jpg";

                // Carregar a imagem e definir como fundo
                if (File.Exists(imagePath))
                {
                    this.BackgroundImage = Image.FromFile(imagePath);
                    this.BackgroundImageLayout = ImageLayout.Stretch; // Ajusta a imagem ao tamanho do formulário
                }
                else
                {
                    MessageBox.Show("A imagem de fundo não foi encontrada. Verifique o caminho.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a imagem de fundo: {ex.Message}");
            }
        }

        // Evento clicado para cadastrar uma entrada de produto
        private void BtnCadastrarEntrada_Click(object sender, EventArgs e)
        {
            // Verifica se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(txtProduto.Text) || string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Nome do produto e marca são obrigatórios.");
                return;
            }

            // Verifica se os ComboBoxes foram preenchidos
            if (cmbCategoria.SelectedIndex == 0 || cmbEstado.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, selecione uma categoria e um estado válidos.");
                return;
            }

            // Salva os dados no arquivo
            SaveData(txtProduto.Text, txtMarca.Text, cmbCategoria.SelectedItem.ToString(), cmbEstado.SelectedItem.ToString(), (int)numQuantidade.Value);
            MessageBox.Show("Entrada registrada com sucesso.");
            LoadData(); // Atualiza a lista de produtos
        }

        // Evento clicado para registrar uma saída de produto
        private void BtnRegistrarSaida_Click(object sender, EventArgs e)
        {
            // Verifica se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(txtProduto.Text) || string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Nome do produto e marca são obrigatórios.");
                return;
            }

            // Verifica se os ComboBoxes foram preenchidos
            if (cmbCategoria.SelectedIndex == 0 || cmbEstado.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, selecione uma categoria e um estado válidos.");
                return;
            }

            // Verifica se a quantidade no estoque é suficiente para a saída
            int quantidadeSaida = (int)numQuantidade.Value;
            var lines = File.ReadAllLines(dataFilePath).ToList();
            bool produtoExistente = false;

            for (int i = 0; i < lines.Count; i++)
            {
                var values = lines[i].Split('|');
                if (values[0].Equals(txtProduto.Text, StringComparison.OrdinalIgnoreCase) &&
                    values[1].Equals(txtMarca.Text, StringComparison.OrdinalIgnoreCase) &&
                    values[3].Equals(cmbEstado.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    int quantidadeAtual = int.Parse(values[4]);
                    if (quantidadeAtual < quantidadeSaida)
                    {
                        MessageBox.Show("Quantidade insuficiente no estoque.");
                        return;
                    }
                    lines[i] = $"{values[0]}|{values[1]}|{values[2]}|{values[3]}|{quantidadeAtual - quantidadeSaida}";
                    produtoExistente = true;

                    // Remove o produto se a quantidade chegar a zero
                    if (quantidadeAtual - quantidadeSaida == 0)
                    {
                        lines.RemoveAt(i);
                    }
                    break;
                }
            }

            if (!produtoExistente)
            {
                MessageBox.Show("Produto não encontrado.");
                return;
            }

            File.WriteAllLines(dataFilePath, lines);
            MessageBox.Show("Saída registrada com sucesso.");
            LoadData(); // Atualiza a lista de produtos
        }

        // Evento clicado para listar todos os produtos
        private void BtnListarProdutos_Click(object sender, EventArgs e)
        {
            LoadData(); // Atualiza a lista de produtos
        }

        // Carrega dados do arquivo e exibe no DataGridView
        private void LoadData()
        {
            dataGridView1.Rows.Clear(); // Limpa os dados existentes no DataGridView

            if (File.Exists(dataFilePath))
            {
                var lines = File.ReadAllLines(dataFilePath);
                foreach (var line in lines)
                {
                    var values = line.Split('|');
                    if (values.Length == 5)
                    {
                        dataGridView1.Rows.Add(values); // Adiciona cada linha ao DataGridView
                    }
                }
            }
        }

        // Salva dados no arquivo e adiciona novos produtos se necessário
        private void SaveData(string nome, string marca, string categoria, string estado, int quantidade)
        {
            var lines = File.ReadAllLines(dataFilePath).ToList();
            bool produtoExistente = false;

            for (int i = 0; i < lines.Count; i++)
            {
                var values = lines[i].Split('|');
                if (values[0].Equals(nome, StringComparison.OrdinalIgnoreCase) &&
                    values[1].Equals(marca, StringComparison.OrdinalIgnoreCase) &&
                    values[3].Equals(estado, StringComparison.OrdinalIgnoreCase)) // Verifica estado
                {
                    // Atualiza a quantidade se o produto já existir
                    int novaQuantidade = int.Parse(values[4]) + quantidade;
                    if (novaQuantidade < 0)
                    {
                        MessageBox.Show("Quantidade insuficiente no estoque.");
                        return;
                    }
                    lines[i] = $"{values[0]}|{values[1]}|{values[2]}|{values[3]}|{novaQuantidade}";

                    // Remove o produto se a quantidade chegar a zero
                    if (novaQuantidade == 0)
                    {
                        lines.RemoveAt(i);
                    }
                    produtoExistente = true;
                    break;
                }
            }

            if (!produtoExistente)
            {
                // Adiciona um novo produto ao arquivo, considerando o estado
                var entry = $"{nome}|{marca}|{categoria}|{estado}|{quantidade}";
                lines.Add(entry);
            }

            File.WriteAllLines(dataFilePath, lines); // Salva as linhas atualizadas no arquivo
        }

        // Evento clicado na célula do DataGridView para selecionar um produto
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                // Preenche os campos com as informações do produto
                txtProduto.Text = row.Cells[0].Value.ToString(); // Nome
                txtMarca.Text = row.Cells[1].Value.ToString(); // Marca
                cmbCategoria.SelectedItem = row.Cells[2].Value.ToString(); // Categoria
                cmbEstado.SelectedItem = row.Cells[3].Value.ToString(); // Estado

                // Configura a quantidade para 0, mas permite edição
                numQuantidade.Value = 0;
                numQuantidade.Enabled = true; // Permite edição
            }
        }

        // Método para simular placeholders nos TextBox
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        // Método para simular placeholders nos ComboBoxes
        private void SetComboBoxPlaceholder(ComboBox comboBox, string placeholder)
        {
            comboBox.Items.Insert(0, placeholder);
            comboBox.SelectedIndex = 0;

            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                if (comboBox.SelectedIndex == 0)
                {
                    comboBox.BackColor = Color.LightGray;
                }
                else
                {
                    comboBox.BackColor = Color.White;
                }
            };
        }
    }
}

