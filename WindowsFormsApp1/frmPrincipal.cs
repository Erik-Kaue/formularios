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
    public partial class frmPrincipal : Form
    {
        public static int contusu = 0, contcli = 0, contfor = 0;

        //Form Usuario
        public struct Usuario
        {
            public int cd_usuario;
            public string nm_usuario;
            public string sg_nivel;
            public string nm_login;
            public string ds_senha;
        }
        public static Usuario[] usuario = new Usuario [10];
        public frmPrincipal()
        {
            InitializeComponent();
       
        }
        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario fu = new frmUsuario();
            fu.ShowDialog();
        }

        //Form Cliente
        public struct Cliente
        {
            public int cd_cliente;
            public string nm_cliente;
            public string sg_nivel;
            public string nm_login;
            public string ds_senha;
        }
        public static Cliente[] cliente = new Cliente[10];

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente fc = new frmCliente();
            fc.ShowDialog();
        }

        //Form Cliente
        public struct Fornecedor
        {
            public int cd_fornecedor;
            public string nm_fornecedor;
            public string sg_nivel;
            public string nm_login;
            public string ds_senha;
        }
        public static Fornecedor[] fornecedor = new Fornecedor[10];
        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedor ff = new frmFornecedor();
            ff.ShowDialog();
        }



        //Relatório Usuario
        private void pdcUsuario_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics objImpressao = e.Graphics;
            string strDados="";
            int pag = 0, i = 0, lin = 0;
            bool cab = true, det = true;

            while (cab)
            {
                pag++;
                strDados = strDados + "------------------------------LISTAGEM DE USUÁRIOS------------------------------\n";
                strDados = strDados + "Página: " + pag.ToString() + "                                                                 ARsoft\n";
                strDados = strDados + "--------------------------------------------------------------------------------\n";
                strDados = strDados + "Código Nome                                     Nível Login               \n";
                strDados = strDados + "--------------------------------------------------------------------------------\n";
                lin = 5;
                det = true;
                while (det)
                {
                    strDados = strDados + usuario[i].cd_usuario.ToString("000000") + " " + (usuario[i].nm_usuario + "                                        ").Substring(0, 40) + "   " + usuario[i].sg_nivel + "   " + usuario[i].nm_login + "\n";
                    i++;
                    lin++;
                    if (lin >= 66)
                    {
                        det = false;
                    }
                    if (i >= contusu)
                    {
                        det = false;
                        cab = false;
                    }
                }
                strDados = strDados + (char)12;
            }
            objImpressao.DrawString(strDados, new System.Drawing.Font("Courier New", 10, FontStyle.Bold), Brushes.Black, 50, 50);
        }

        private void usuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ppdUsuario.ShowDialog();
        }

        //Relatório Cliente
        private void pdcCliente_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics objImpressao = e.Graphics;
            string strDados = "";
            int pag = 0, i = 0, lin = 0;
            bool cab = true, det = true;

            while (cab)
            {
                pag++;
                strDados = strDados + "------------------------------LISTAGEM DE CLIENTES------------------------------\n";
                strDados = strDados + "Página: " + pag.ToString() + "                                                                 ARsoft\n";
                strDados = strDados + "--------------------------------------------------------------------------------\n";
                strDados = strDados + "Código Nome                                     Nível Login               \n";
                strDados = strDados + "--------------------------------------------------------------------------------\n";
                lin = 5;
                det = true;
                while (det)
                {
                    strDados = strDados + cliente[i].cd_cliente.ToString("000000") + " " + (cliente[i].nm_cliente + "                                        ").Substring(0, 40) + "   " + cliente[i].sg_nivel + "   " + cliente[i].nm_login + "\n";
                    i++;
                    lin++;
                    if (lin >= 66)
                    {
                        det = false;
                    }
                    if (i >= contusu)
                    {
                        det = false;
                        cab = false;
                    }
                }
                strDados = strDados + (char)12;
            }
            objImpressao.DrawString(strDados, new System.Drawing.Font("Courier New", 10, FontStyle.Bold), Brushes.Black, 50, 50);
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ppdCliente.ShowDialog();
        }

        //Relatório Fornecedor
        private void pdcFornecedor_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics objImpressao = e.Graphics;
            string strDados = "";
            int pag = 0, i = 0, lin = 0;
            bool cab = true, det = true;

            while (cab)
            {
                pag++;
                strDados = strDados + "------------------------------LISTAGEM DE FORNECEDORES------------------------------\n";
                strDados = strDados + "Página: " + pag.ToString() + "                                                                 ARsoft\n";
                strDados = strDados + "--------------------------------------------------------------------------------\n";
                strDados = strDados + "Código Nome                                     Nível Login               \n";
                strDados = strDados + "--------------------------------------------------------------------------------\n";
                lin = 5;
                det = true;
                while (det)
                {
                    strDados = strDados + fornecedor[i].cd_fornecedor.ToString("000000") + " " + (fornecedor[i].nm_fornecedor + "                                        ").Substring(0, 40) + "   " + fornecedor[i].sg_nivel + "   " + fornecedor[i].nm_login + "\n";
                    i++;
                    lin++;
                    if (lin >= 66)
                    {
                        det = false;
                    }
                    if (i >= contusu)
                    {
                        det = false;
                        cab = false;
                    }
                }
                strDados = strDados + (char)12;
            }
            objImpressao.DrawString(strDados, new System.Drawing.Font("Courier New", 10, FontStyle.Bold), Brushes.Black, 50, 50);
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ppdFornecedor.ShowDialog();
        }

        //Form Principal
        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }



    }
}
