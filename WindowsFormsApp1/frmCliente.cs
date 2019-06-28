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
    public partial class frmCliente : Form
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
        public frmCliente()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Desabilita();


        }
        private void mostra()
        {
            txtCod.Text = frmPrincipal.cliente[atual].cd_cliente.ToString();
            txtLogin.Text = frmPrincipal.cliente[atual].nm_login;
            txtNome.Text = frmPrincipal.cliente[atual].nm_cliente;
            txtNvl.Text = frmPrincipal.cliente[atual].sg_nivel;
            txtSenha.Text = frmPrincipal.cliente[atual].ds_senha;
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (atual < frmPrincipal.contusu - 1)
            {
                atual++;
                mostra();
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
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

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            if (frmPrincipal.contusu > 0)
            {
                Habilita();
                txtNome.Focus();
                flagCod = 'a';
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            frmPrincipal.cliente[atual].cd_cliente = 0;
            frmPrincipal.cliente[atual].nm_cliente = null;
            frmPrincipal.cliente[atual].sg_nivel = null;
            frmPrincipal.cliente[atual].nm_login = null;
            frmPrincipal.cliente[atual].ds_senha = null;
        }

        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            if (atual > 0)
            {
                atual--;
                mostra();
            }
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Show();
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            Desabilita();
            if (flagCod == 'n')
            {
                frmPrincipal.cliente[frmPrincipal.contusu].cd_cliente = int.Parse(txtCod.Text);
                frmPrincipal.cliente[frmPrincipal.contusu].nm_cliente = txtNome.Text;
                frmPrincipal.cliente[frmPrincipal.contusu].sg_nivel = txtNvl.Text;
                frmPrincipal.cliente[frmPrincipal.contusu].nm_login = txtLogin.Text;
                frmPrincipal.cliente[frmPrincipal.contusu].ds_senha = txtSenha.Text;
                atual = frmPrincipal.contusu++;

            }
            else
            {
                frmPrincipal.cliente[atual].cd_cliente = int.Parse(txtCod.Text);
                frmPrincipal.cliente[atual].nm_cliente = txtNome.Text;
                frmPrincipal.cliente[atual].sg_nivel = txtNvl.Text;
                frmPrincipal.cliente[atual].nm_login = txtLogin.Text;
                frmPrincipal.cliente[atual].ds_senha = txtSenha.Text;
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Desabilita();
            mostra();
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
                for (i = 0; i < frmPrincipal.contusu; i++)
                {
                    if (frmPrincipal.cliente[i].nm_cliente == txtPesquisa.Text)
                    {
                        atual = i;
                        mostra();
                        break;
                    }
                }
                if (i >= frmPrincipal.contusu)
                {
                    MessageBox.Show("Cliente não encontrado");
                }
            }
            pnlPesquisa.Visible = false;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics objImpressao = e.Graphics;
            string strDados;
            strDados = "-------------------Ficha de Usuário-------------------" + (char) 10 + (char) 10;
            strDados = strDados + "Código: " + txtCod.Text + (char) 10;
            strDados = strDados + "Nome: " + txtNome.Text + (char) 10;
            strDados = strDados + "Nível: " + txtNvl.Text + (char) 10;
            strDados = strDados + "Login: " + txtLogin.Text;

            objImpressao.DrawString(strDados,new System.Drawing.Font("Arial",24,FontStyle.Bold),Brushes.Black,50,50);
        }
    }
}
