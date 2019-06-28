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
    public partial class frmFornecedor : Form
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
        public frmFornecedor()
        {
            InitializeComponent();
        }

        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            Desabilita();


        }
        private void mostra()
        {
            txtCod.Text = frmPrincipal.fornecedor[atual].cd_fornecedor.ToString();
            txtLogin.Text = frmPrincipal.fornecedor[atual].nm_login;
            txtNome.Text = frmPrincipal.fornecedor[atual].nm_fornecedor;
            txtNvl.Text = frmPrincipal.fornecedor[atual].sg_nivel;
            txtSenha.Text = frmPrincipal.fornecedor[atual].ds_senha;
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

        //BOTAO NOVO
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

        //BOTAO EXCLUIR
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            frmPrincipal.fornecedor[atual].cd_fornecedor = 0;
            frmPrincipal.fornecedor[atual].nm_fornecedor = null;
            frmPrincipal.fornecedor[atual].sg_nivel = null;
            frmPrincipal.fornecedor[atual].nm_login = null;
            frmPrincipal.fornecedor[atual].ds_senha = null;
        }

        //BOTAO SALVAR
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Desabilita();
            if (flagCod=='n') {
                frmPrincipal.fornecedor[frmPrincipal.contusu].cd_fornecedor = int.Parse(txtCod.Text);
                frmPrincipal.fornecedor[frmPrincipal.contusu].nm_fornecedor = txtNome.Text;
                frmPrincipal.fornecedor[frmPrincipal.contusu].sg_nivel = txtNvl.Text;
                frmPrincipal.fornecedor[frmPrincipal.contusu].nm_login = txtLogin.Text;
                frmPrincipal.fornecedor[frmPrincipal.contusu].ds_senha = txtSenha.Text;
                atual = frmPrincipal.contusu++;

            }
            else
            {
                frmPrincipal.fornecedor[atual].cd_fornecedor = int.Parse(txtCod.Text);
                frmPrincipal.fornecedor[atual].nm_fornecedor = txtNome.Text;
                frmPrincipal.fornecedor[atual].sg_nivel = txtNvl.Text;
                frmPrincipal.fornecedor[atual].nm_login = txtLogin.Text;
                frmPrincipal.fornecedor[atual].ds_senha = txtSenha.Text;
            }
        }

        //BOTAO CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Desabilita();
            mostra();
        }

        //BOAO SAIR
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmFornecedor_Load_1(object sender, EventArgs e)
        {
            Desabilita();
        }

        private void btnPesquisaSair_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = false;
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int i;
            if (txtPesquisa.Text != "")
            {
                for (i = 0; i < frmPrincipal.contusu; i++)
                {
                    if (frmPrincipal.fornecedor[i].nm_fornecedor == txtPesquisa.Text)
                    {
                        atual = i;
                        mostra();
                        break;
                    }
                }
                if (i >= frmPrincipal.contusu)
                {
                    MessageBox.Show("Fornecedor não encontrado");
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
