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

        private string dataFilePath = "estoque.txt"; // O arquivo deve estar no mesmo diretório que o executável.

        // private string dataFilePath = @"C:\Users\Felipe\source\repos\Estoque de equipamentos\bin\Release\estoque.txt"; // Caminho para o arquivo de dados
        private Estoque produtoSelecionado; // Para armazenar o produto selecionado
        private Timer _timer;
        public Form2()
        {
            InitializeComponent();
            // Inicializa o Timer
            _timer = new Timer();
            _timer.Interval = 10000; // 10 segundos
            _timer.Tick += Timer_Tick;
            InitializeCustomComponents();
            SetBackgroundImage(); // Define a imagem de fundo
            this.Icon = Properties.Resources.iconeteste;  // Certifique-se de que 'icone_teste' é o nome correto no Resources









        }

        private void InitializeCustomComponents()
        {
            // Inicializa eventos dos botões
            btnCadastrarEntrada.Click += BtnCadastrarEntrada_Click;
            btnRegistrarSaida.Click += BtnRegistrarSaida_Click;
          //  btnListarProdutos.Click += BtnListarProdutos_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;

            // Adiciona placeholders
            SetPlaceholder(txtProduto, "Digite o nome do produto");
            SetPlaceholder(txtMarca, "Digite a marca");
            SetComboBoxPlaceholder(cmbCategoria, "Selecione a categoria");
            SetComboBoxPlaceholder(cmbEstado, "Selecione o estado");

            // Carregar dados ao iniciar
            LoadData();
        }

        private void SetBackgroundImage()
        {
            try
            {
                // Acessando a imagem como um recurso
                this.BackgroundImage = Properties.Resources.fundoStv; // Verifique se o nome está correto
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a imagem de fundo: {ex.Message}");
            }
        }


        private void BtnCadastrarEntrada_Click(object sender, EventArgs e)
        {
            // Verifica se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(txtProduto.Text) ||
                string.IsNullOrWhiteSpace(txtMarca.Text) ||
                cmbCategoria.SelectedItem == null ||
                cmbEstado.SelectedItem == null ||
                numQuantidade.Value <= 0)
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            // Verificar se o produto já existe
            var produtoExistente = VerificarProdutoExistente(txtProduto.Text, txtMarca.Text);
            if (produtoExistente != null)
            {
                // Atualiza a quantidade se o produto existir
                AtualizarDadosProduto(produtoExistente.Nome, produtoExistente.Marca, produtoExistente.Quantidade + (int)numQuantidade.Value);
            }
            else
            {
                // Salva o novo produto se não existir
                var newEntry = new Estoque
                {
                    Nome = txtProduto.Text,
                    Marca = txtMarca.Text,
                    Categoria = cmbCategoria.SelectedItem.ToString(),
                    Estado = cmbEstado.SelectedItem.ToString(),
                    Quantidade = (int)numQuantidade.Value
                };

                SaveData(newEntry); // Chame o método para salvar os dados
            }

            LoadData();  // Atualiza a lista após adicionar
            ClearFields(); // Limpa os campos após a adição
        }


        private void BtnRegistrarSaida_Click(object sender, EventArgs e)
        {
            if (produtoSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um produto para registrar a saída.");
                return;
            }

            int quantidadeSaida = (int)numQuantidade.Value;

            if (quantidadeSaida <= 0)
            {
                MessageBox.Show("A quantidade para retirada deve ser maior que zero.");
                return;
            }

            if (produtoSelecionado.Quantidade < quantidadeSaida)
            {
                MessageBox.Show("Quantidade de saída maior que a disponível em estoque.");
                return;
            }

            AtualizarDadosProduto(produtoSelecionado.Nome, produtoSelecionado.Marca, produtoSelecionado.Quantidade - quantidadeSaida);

            LoadData(); // Atualiza a lista após registrar saída
            ClearFields(); // Limpa os campos após a retirada
        }


       private void BtnListarProdutos_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se a linha clicada é válida
            {
                var row = dataGridView1.Rows[e.RowIndex];

                // Verifica se os valores das células não são nulos
                if (row.Cells[0].Value != null &&
                    row.Cells[1].Value != null &&
                    row.Cells[2].Value != null &&
                    row.Cells[3].Value != null &&
                    row.Cells[4].Value != null)
                {
                    produtoSelecionado = new Estoque
                    {
                        Nome = row.Cells[0].Value.ToString(),
                        Marca = row.Cells[1].Value.ToString(),
                        Categoria = row.Cells[2].Value.ToString(),
                        Estado = row.Cells[3].Value.ToString(),
                        Quantidade = int.Parse(row.Cells[4].Value.ToString())
                    };

                    // Preenche os campos com os dados do produto selecionado
                    txtProduto.Text = produtoSelecionado.Nome;
                    txtMarca.Text = produtoSelecionado.Marca;
                    cmbCategoria.SelectedItem = produtoSelecionado.Categoria;
                    cmbEstado.SelectedItem = produtoSelecionado.Estado;
                    numQuantidade.Value = 0; // Define quantidade padrão para 1 na retirada

                    // Reinicia o Timer sempre que um produto é selecionado
                    _timer.Start();
                }
                else
                {
                    MessageBox.Show("Os dados do produto selecionado não estão disponíveis.");
                }
            }
        }

        // Atualiza o método Timer_Tick para chamar ClearFields()
        private void Timer_Tick(object sender, EventArgs e)
        {
            ClearFields(); // Chama ClearFields se nenhuma ação for tomada após 5 segundos
            _timer.Stop(); // Para o Timer
        }





        private void LoadData()
        {
            if (File.Exists(dataFilePath))
            {
                var lines = File.ReadAllLines(dataFilePath);
                dataGridView1.Rows.Clear(); // Limpar linhas existentes antes de carregar novos dados
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 5)
                    {
                        dataGridView1.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Arquivo de dados não encontrado.");
            }
        }

        private void SaveData(Estoque estoque)
        {
            using (var writer = new StreamWriter(dataFilePath, true))
            {
                writer.WriteLine($"{estoque.Nome}|{estoque.Marca}|{estoque.Categoria}|{estoque.Estado}|{estoque.Quantidade}");
            }

            MessageBox.Show("Produto cadastrado com sucesso.");
        }
        private void ClearFields()
        {
            // Limpa os valores dos campos, mas não altera os placeholders
           // txtProduto.Text = "Nome do Produto";  // Placeholder permanece
            txtProduto.ForeColor = Color.Gray;     // Coloca a cor de placeholder
            SetPlaceholder(txtProduto, "Digite o nome do produto");
            SetPlaceholder(txtMarca, "Digite a marca");
            // Repita para outros campos TextBox conforme necessário

            // txtMarca.Text = "Marca do Produto";    // Placeholder permanece
            txtMarca.ForeColor = Color.Gray;       // Coloca a cor de placeholder
            cmbCategoria.Text = "Selecione a categoria";
            cmbCategoria.ForeColor = Color.Black;
            cmbEstado.Text = "Selecione o estado";
            cmbEstado.ForeColor = Color.Black;
           // cmbCategoria.SelectedIndex = -1;       // Reseta o ComboBox da categoria
            //cmbEstado.SelectedIndex = -1;          // Reseta o ComboBox do estado
            numQuantidade.Value = 0;                // Reseta o NumericUpDown da quantidade
         //   txtPreco.Text = "Preço do Produto";     // Placeholder permanece
          //  txtPreco.ForeColor = Color.Gray;       // Coloca a cor de placeholder
          //  txtPesquisa.Text = "Pesquisar Produto"; // Placeholder permanece
           // txtPesquisa.ForeColor = Color.Gray;    // Coloca a cor de placeholder
        }


        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            // Inicializa o TextBox com o placeholder e cor cinza
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholder;

            // Evento ao focar no TextBox
            textBox.GotFocus += (s, e) =>
            {
                // Se o texto for igual ao placeholder, apaga o texto
                if (textBox.Text == placeholder)
                {
                    textBox.Text = ""; // Limpa o campo
                    textBox.ForeColor = Color.Black; // Define a cor preta para o texto real
                }
            };

            // Evento ao desfocar do TextBox
            textBox.LostFocus += (s, e) =>
            {
                // Se o campo estiver vazio ao perder o foco, restaura o placeholder
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder; // Restaura o placeholder
                    textBox.ForeColor = Color.Gray; // Define a cor cinza novamente
                }
            };
        }


        private void SetComboBoxPlaceholder(ComboBox comboBox, string placeholder)
        {
            comboBox.Items.Insert(0, placeholder);
            comboBox.SelectedIndex = 0;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.SelectedIndexChanged += (s, e) =>
            {
                if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() == placeholder)
                {
                    comboBox.ForeColor = Color.Gray;
                }
                else
                {
                    comboBox.ForeColor = Color.Black;
                }
            };
        }

        private Estoque VerificarProdutoExistente(string nome, string marca)
        {
            // Carregar todos os produtos e verificar se existe
            if (File.Exists(dataFilePath))
            {
                var lines = File.ReadAllLines(dataFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 5)
                    {
                        // Comparar nome e marca de forma case-insensitive
                        if (string.Equals(parts[0], nome, StringComparison.OrdinalIgnoreCase) &&
                            string.Equals(parts[1], marca, StringComparison.OrdinalIgnoreCase))
                        {
                            return new Estoque
                            {
                                Nome = parts[0],
                                Marca = parts[1],
                                Categoria = parts[2],
                                Estado = parts[3],
                                Quantidade = int.Parse(parts[4])
                            };
                        }
                    }
                }
            }
            return null;
        }

        private void AtualizarDadosProduto(string nome, string marca, int novaQuantidade)
        {
            // Ler todos os produtos
            var linhas = File.ReadAllLines(dataFilePath).ToList();
            bool produtoRemovido = false; // Para verificar se um produto foi removido

            for (int i = 0; i < linhas.Count; i++)
            {
                var parts = linhas[i].Split('|');
                if (parts[0].Equals(nome, StringComparison.OrdinalIgnoreCase) &&
                    parts[1].Equals(marca, StringComparison.OrdinalIgnoreCase))
                {
                    if (novaQuantidade <= 0)
                    {
                        // Remove o produto se a quantidade for menor ou igual a 0
                        linhas.RemoveAt(i);
                        produtoRemovido = true;
                        MessageBox.Show("Produto removido do estoque.");
                    }
                    else
                    {
                        parts[4] = novaQuantidade.ToString(); // Atualiza a quantidade
                        linhas[i] = string.Join("|", parts); // Recria a linha
                    }
                    break;
                }
            }

            // Salvar as linhas atualizadas de volta no arquivo
            File.WriteAllLines(dataFilePath, linhas);
            if (!produtoRemovido)
            {
                MessageBox.Show("Dados do produto atualizados com sucesso.");
            }
        }

        public class Estoque
        {
            public string Nome { get; set; }
            public string Marca { get; set; }
            public string Categoria { get; set; }
            public string Estado { get; set; }
            public int Quantidade { get; set; }
        }
    }

}



















