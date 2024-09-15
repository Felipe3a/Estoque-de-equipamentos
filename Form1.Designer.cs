/*namespace Estoque_de_equipamentos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.SuspendLayout();

            // Definir o fundo como uma imagem
            this.BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\Felipe\OneDrive - SENAC - SP\Área de Trabalho\ef9a5fd6fb433b1e6d11b0895041db45.jpeg");  // Caminho da imagem de fundo
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            // Adicionar um painel transparente para o login
            this.panelLogin = new System.Windows.Forms.Panel();
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(200, 255, 255, 255);  // Fundo opaco e transparente
            this.panelLogin.Size = new System.Drawing.Size(300, 200);
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelLogin.Padding = new System.Windows.Forms.Padding(20);

            // Adicionar os campos de usuário e senha como linhas
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Width = 260;
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 12);
            this.txtUsuario.Location = new System.Drawing.Point(20, 40);
            this.txtUsuario.Text = "Usuário";  // Placeholder

            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSenha.Width = 260;
            this.txtSenha.Font = new System.Drawing.Font("Arial", 12);
            this.txtSenha.UseSystemPasswordChar = true;  // Para ocultar a senha
            this.txtSenha.Location = new System.Drawing.Point(20, 80);
            this.txtSenha.Text = "Senha";  // Placeholder

            // Adicionar um botão de login estilizado
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogin.Text = "Login";
            this.btnLogin.Width = 260;
            this.btnLogin.Location = new System.Drawing.Point(20, 120);
            this.btnLogin.BackColor = System.Drawing.Color.Green;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 12);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Adicionar os controles ao painel
            this.panelLogin.Controls.Add(this.txtUsuario);
            this.panelLogin.Controls.Add(this.txtSenha);
            this.panelLogin.Controls.Add(this.btnLogin);

            // Adicionar o painel ao formulário
            this.Controls.Add(this.panelLogin);

            // Configurações adicionais do Form1
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Sem bordas
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Evento para garantir que o painel fique centralizado
            this.Load += new System.EventHandler(this.Form1_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnLogin;
    }
}*/




/*------------------------------------------------------------------------------------------------------------





using System.Windows.Forms;

namespace Estoque_de_equipamentos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelLogin.Controls.Add(this.txtUsuario);
            this.panelLogin.Controls.Add(this.txtSenha);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Padding = new System.Windows.Forms.Padding(20);
            this.panelLogin.Size = new System.Drawing.Size(300, 200);
            this.panelLogin.TabIndex = 0;
            this.panelLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogin_Paint);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = BorderStyle.None;

            this.txtUsuario.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 12F);
            this.txtUsuario.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtUsuario.Location = new System.Drawing.Point(20, 40);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(260, 23);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.Text = "Usuário";
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown); // Evento KeyDown
                                                                                                          // 
                                                                                                          // txtSenha
                                                                                                          // 
            this.txtUsuario.BorderStyle = BorderStyle.None;

            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSenha.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSenha.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtSenha.Location = new System.Drawing.Point(20, 80);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(260, 23);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.Text = "Senha";
            this.txtSenha.UseSystemPasswordChar = true;
            this.txtSenha.Enter += new System.EventHandler(this.txtSenha_Enter);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown); // Evento KeyDown
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Green;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(20, 119);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(260, 34);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Form1
            // 
           //
           this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.panelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnLogin;

        // Métodos para capturar a tecla Enter
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e); // Chama o clique do botão de login
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e); // Chama o clique do botão de login
            }
        }
    }
}


-------------------------------------------------------------------------------------------------------------------------------------*/



using System;
using System.Windows.Forms;
using System.Drawing;

namespace Estoque_de_equipamentos
{
    public partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelLogin.Controls.Add(this.txtUsuario);
            this.panelLogin.Controls.Add(this.txtSenha);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Location = new System.Drawing.Point(150, 125);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Padding = new System.Windows.Forms.Padding(20);
            this.panelLogin.Size = new System.Drawing.Size(300, 200);
            this.panelLogin.TabIndex = 0;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 12F);
            this.txtUsuario.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtUsuario.Location = new System.Drawing.Point(20, 40);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(260, 23);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.Text = "Usuário";
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // txtSenha
            // 
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSenha.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSenha.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtSenha.Location = new System.Drawing.Point(20, 80);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(260, 23);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.Text = "Senha";
            this.txtSenha.UseSystemPasswordChar = true;
            this.txtSenha.Enter += new System.EventHandler(this.txtSenha_Enter);
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Green;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(20, 119);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(260, 34);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Form1
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.panelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnLogin;

        // Método para capturar a tecla Enter
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e); // Chama o clique do botão de login
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e); // Chama o clique do botão de login
            }
        }
    }
}


















/*using System;
using System.Windows.Forms;
using System.Drawing;

namespace Estoque_de_equipamentos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Definir o fundo como uma imagem
            this.BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\Felipe\OneDrive - SENAC - SP\Área de Trabalho\ef9a5fd6fb433b1e6d11b0895041db45.jpeg");  // Substitua pelo caminho da imagem
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            // Adicionar um painel transparente para o login
            Panel panelLogin = new Panel();
            panelLogin.BackColor = Color.FromArgb(100, 255, 255, 255);  // Fundo opaco e transparente
            panelLogin.Size = new Size(300, 200);
            panelLogin.Location = new Point((this.Width - panelLogin.Width) / 2, (this.Height - panelLogin.Height) / 2);
            panelLogin.BorderStyle = BorderStyle.None; // Remover borda
            panelLogin.Padding = new Padding(20);

            // Adicionar os campos de usuário e senha como linhas verdes
            TextBox txtUsuario = new TextBox();
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Width = 260;
            txtUsuario.Font = new Font("Arial", 12);
            txtUsuario.Location = new Point(20, 40);
            txtUsuario.BackColor = Color.FromArgb(100, 255, 255, 255); // Fundo transparente
            txtUsuario.ForeColor = Color.Green; // Texto verde
            txtUsuario.Multiline = false;
            txtUsuario.Height = 20; // Ajusta a altura para parecer uma linha

            TextBox txtSenha = new TextBox();
            txtSenha.BorderStyle = BorderStyle.None;
            txtSenha.Width = 260;
            txtSenha.Font = new Font("Arial", 12);
            txtSenha.UseSystemPasswordChar = true; // Para ocultar a senha
            txtSenha.Location = new Point(20, 80);
            txtSenha.BackColor = Color.FromArgb(100, 255, 255, 255); // Fundo transparente
            txtSenha.ForeColor = Color.Green; // Texto verde
            txtSenha.Multiline = false;
            txtSenha.Height = 20; // Ajusta a altura para parecer uma linha

            // Adicionar um botão de login estilizado
            Button btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Width = 260;
            btnLogin.Location = new Point(20, 120);
            btnLogin.BackColor = Color.Green;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Arial", 12);

            // Adicionar os controles ao painel
            panelLogin.Controls.Add(txtUsuario);
            panelLogin.Controls.Add(txtSenha);
            panelLogin.Controls.Add(btnLogin);

            // Adicionar o painel ao formulário
            this.Controls.Add(panelLogin);

            // Configurações adicionais do Form1
            this.ClientSize = new Size(800, 450);
            this.FormBorderStyle = FormBorderStyle.None; // Sem bordas
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}*/













