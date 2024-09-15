namespace Estoque_de_equipamentos
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnCadastrarEntrada;
        private System.Windows.Forms.Button btnRegistrarSaida;
        private System.Windows.Forms.Button btnListarProdutos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.NumericUpDown numQuantidade;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnCadastrarEntrada = new System.Windows.Forms.Button();
            this.btnRegistrarSaida = new System.Windows.Forms.Button();
            this.btnListarProdutos = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            this.SuspendLayout();

            // 
            // btnCadastrarEntrada
            // 
            this.btnCadastrarEntrada.Location = new System.Drawing.Point(12, 12);
            this.btnCadastrarEntrada.Name = "btnCadastrarEntrada";
            this.btnCadastrarEntrada.Size = new System.Drawing.Size(120, 23);
            this.btnCadastrarEntrada.TabIndex = 0;
            this.btnCadastrarEntrada.Text = "Cadastrar Entrada";
            this.btnCadastrarEntrada.UseVisualStyleBackColor = true;

            // 
            // btnRegistrarSaida
            // 
            this.btnRegistrarSaida.Location = new System.Drawing.Point(12, 41);
            this.btnRegistrarSaida.Name = "btnRegistrarSaida";
            this.btnRegistrarSaida.Size = new System.Drawing.Size(120, 23);
            this.btnRegistrarSaida.TabIndex = 1;
            this.btnRegistrarSaida.Text = "Registrar Saída";
            this.btnRegistrarSaida.UseVisualStyleBackColor = true;

            // 
            // btnListarProdutos
            // 
            this.btnListarProdutos.Location = new System.Drawing.Point(12, 70);
            this.btnListarProdutos.Name = "btnListarProdutos";
            this.btnListarProdutos.Size = new System.Drawing.Size(120, 23);
            this.btnListarProdutos.TabIndex = 2;
            this.btnListarProdutos.Text = "Listar Produtos";
            this.btnListarProdutos.UseVisualStyleBackColor = true;

            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Marca", HeaderText = "Marca" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Categoria", HeaderText = "Categoria" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Quantidade", HeaderText = "Quantidade" }
            });
            this.dataGridView1.Location = new System.Drawing.Point(138, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(650, 400);
            this.dataGridView1.TabIndex = 3;

            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(12, 100);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(120, 22);
            this.txtProduto.TabIndex = 4;
            this.txtProduto.Text = "Produto";

            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(12, 128);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(120, 22);
            this.txtMarca.TabIndex = 5;
            this.txtMarca.Text = "Marca";

            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
                "Alarme",
                "CFTV",
                "Controle de acesso",
                "Eletrônico",
                "Elétrico",
                "Rede",
                "Iluminação",
                "Nobreaks"

            });
            this.cmbCategoria.Location = new System.Drawing.Point(12, 156);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(120, 24);
            this.cmbCategoria.TabIndex = 6;

            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
                "Novo",
                "Usado"
            });
            this.cmbEstado.Location = new System.Drawing.Point(12, 186);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(120, 24);
            this.cmbEstado.TabIndex = 7;

            // 
            // numQuantidade
            // 
            this.numQuantidade.Location = new System.Drawing.Point(12, 216);
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(120, 22);
            this.numQuantidade.TabIndex = 8;

            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.numQuantidade);
            this.Controls.Add(this.btnCadastrarEntrada);
            this.Controls.Add(this.btnRegistrarSaida);
            this.Controls.Add(this.btnListarProdutos);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Controle de Estoque";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
