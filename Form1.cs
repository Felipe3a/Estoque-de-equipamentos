using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Estoque_de_equipamentos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void CenterPanel()
        {
            if (panelLogin != null)
            {
                panelLogin.Location = new Point((this.ClientSize.Width - panelLogin.Width) / 2, (this.ClientSize.Height - panelLogin.Height) / 2);
            }
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;  // Raio para bordas arredondadas
            Rectangle rect = new Rectangle(0, 0, panelLogin.Width, panelLogin.Height);
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            panelLogin.Region = new Region(path);
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuário")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Green;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.Text = "Usuário";
                txtUsuario.ForeColor = Color.Gray;
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Senha")
            {
                txtSenha.Text = "";
                txtSenha.UseSystemPasswordChar = true;
                txtSenha.ForeColor = Color.Green;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                txtSenha.Text = "Senha";
                txtSenha.UseSystemPasswordChar = false;
                txtSenha.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Verifica se o nome do usuário e a senha estão corretos
            if (txtUsuario.Text == "admin" && txtSenha.Text == "1234") // Usuário: admin, Senha: 1234
            {
                // Se o login estiver correto, abre o formulário de controle de estoque (Form2)
                Form2 formControleEstoque = new Form2();
                formControleEstoque.Show();

                // Esconde o formulário de login
                this.Hide();
            }
            else
            {
                // Se o login falhar, exibe uma mensagem de erro
                MessageBox.Show("Usuário ou senha incorretos. Tente novamente.");
            }
        }
    }
}





