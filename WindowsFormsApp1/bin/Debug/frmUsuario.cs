using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmUsuario : Form
    {
        int atual = 0;
        char flagCod;
        private void Habilita()
        {
            txtNome.Enabled = true;
            txtLogin.Enabled = true;
            txtNvl.Enabled = true;
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
            btnAlterar.Enabled = false;
            btnAnterior.Enabled = false;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = false;
            btnImprimir.Enabled = false;
            btnNovo.Enabled = false;
            btnPesq.Enabled = false;
            btnProximo.Enabled = false;
            btnSair.Enabled = false;
            btnSalvar.Enabled = true;            
        }
        private void Desabilita()
        {
            txtNome.Enabled = false;
            txtLogin.Enabled = false;
            txtNvl.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
            btnAlterar.Enabled = true;
            btnAnterior.Enabled = true;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = true;
            btnImprimir.Enabled = true;
            btnNovo.Enabled = true;
            btnPesq.Enabled = true;
            btnProximo.Enabled = true;
            btnSair.Enabled = true;
            btnSalvar.Enabled = false;
        }
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            Desabilita();
           
            
        }
        private void mostra()
        {
            txtCod.Text = frmPrincipal.usuario[atual].cd_usuario.ToString();
            txtLogin.Text = frmPrincipal.usuario[atual].nm_login;
            txtNome.Text = frmPrincipal.usuario[atual].nm_usuario;
            txtNvl.Text = frmPrincipal.usuario[atual].sg_nivel;
            txtSenha.Text = frmPrincipal.usuario[atual].ds_senha;
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            
            if (frmPrincipal.contusu < 10)
            {
                Habilita();
                txtCod.Text = (frmPrincipal.contusu + 1).ToString();
                txtNome.Text = "";
                txtNvl.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtNome.Focus();
                flagCod = 'n';
            }
        }
        
        //BOTAO ALTERAR
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (frmPrincipal.contusu > 0)
            {
                Habilita();
                txtNome.Focus();
                flagCod = 'a';
            }

            
        }

        //BOTAO SALVAR
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Desabilita();
            if (flagCod=='n') {
                frmPrincipal.usuario[frmPrincipal.contusu].cd_usuario = int.Parse(txtCod.Text);
                frmPrincipal.usuario[frmPrincipal.contusu].nm_usuario = txtNome.Text;
                frmPrincipal.usuario[frmPrincipal.contusu].sg_nivel = txtNvl.Text;
                frmPrincipal.usuario[frmPrincipal.contusu].nm_login = txtLogin.Text;
                frmPrincipal.usuario[frmPrincipal.contusu].ds_senha = txtSenha.Text;
                atual = frmPrincipal.contusu++;

            }
            else
            {
                frmPrincipal.usuario[atual].cd_usuario = int.Parse(txtCod.Text);
                frmPrincipal.usuario[atual].nm_usuario = txtNome.Text;
                frmPrincipal.usuario[atual].sg_nivel = txtNvl.Text;
                frmPrincipal.usuario[atual].nm_login = txtLogin.Text;
                frmPrincipal.usuario[atual].ds_senha = txtSenha.Text;
            }
        }

        //BOTAO CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Desabilita();
            mostra();
        }

        //BOTAO SAIR
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        //BOTAO ANTERIOR
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (atual > 0)
            {
                atual--;
                mostra();
            }
        }

        //BOTAO PROXIMO
        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (atual < frmPrincipal.contusu - 1)
            {
                atual++;
                mostra();
            }
        }

        //BOTAO EXCLUIR
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            frmPrincipal.usuario[atual].cd_usuario = 0;
            frmPrincipal.usuario[atual].nm_usuario = null;
            frmPrincipal.usuario[atual].sg_nivel = null;
            frmPrincipal.usuario[atual].nm_login = null;
            frmPrincipal.usuario[atual].ds_senha = null;          
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = true;
        }

        private void btnSairPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int i;
            if (txtPesquisa.Text != "")
            {
                for(i = 0; i < frmPrincipal.contusu; i++)
                {
                    if (frmPrincipal.usuario[i].nm_usuario == txtPesquisa.Text)
                    {
                        atual = i;
                        mostra();
                        break;
                    }
                }
                if(i >= frmPrincipal.contusu)
                {
                    MessageBox.Show("Usuario não encontrado");
                }
            }
            pnlPesquisa.Visible = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics objImpressao = e.Graphics;
            string strDados;
            strDados = "-------------------Ficha de Usuário-------------------" + (char)10 + (char)10;
            strDados = strDados + "Código: " + txtCod.Text + (char)10;
            strDados = strDados + "Nome: " + txtNome.Text + (char)10;
            strDados = strDados + "Nível: " + txtNvl.Text + (char)10;
            strDados = strDados + "Login: " + txtLogin.Text;

            objImpressao.DrawString(strDados, new System.Drawing.Font("Arial", 24, FontStyle.Bold), Brushes.Black, 50, 50);
        }
    }
}
