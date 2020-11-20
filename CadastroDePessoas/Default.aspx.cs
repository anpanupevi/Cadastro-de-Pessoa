using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace CadastroDePessoas
{

    public partial class _Default : Page
    {
        public object MessageBox { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtRua_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            close();
        }

        private void close()
        {
            throw new NotImplementedException();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string strcon = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\ANA PAULA\Documents\UNIP SISTEMAS ANA PAULA\TERCEIRO SEMESTRE\PIM VIII\CadastroDePessoas\CadastroDePessoas\obj\Debug\Database1.mdb";
            string comandoEndereco = "INSERT INTO Database1 (Logradouro, Numero, CEP, Bairro, Cidade, Estado)values (@Logradouro, @Numero, @CEP, @Bairro, @Cidade, @Estado)";
            string comandoPessoa = "INSERT INTO Database1 (Nome, CPF, Email,Telefone, Endereco) values (@Nome, @CPF, @Email,@Telefone, @Endereco)";
            string comandoPessoa_Telefone = "INSERT INTO Database1 (ID_Pessoa, ID_Telefone) values (@ID_Pessoa, @ID_Telefone)";
            string comandoTelefone = "INSERT INTO Database1 (Numero, DDD, Tipo) values (@Numero, @DDD, @Tipo)";
            string comandoTelefone_Tipo = "INSERT INTO Database1 (Tipo) values (@Tipo)";



            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand comEndereco = new OleDbCommand(comandoEndereco, con);
            OleDbCommand comPessoa = new OleDbCommand(comandoPessoa, con);
            OleDbCommand comPessoa_Telefone = new OleDbCommand(comandoPessoa_Telefone, con);
            OleDbCommand comTelefone = new OleDbCommand(comandoTelefone, con);
            OleDbCommand comTelefone_Tipo = new OleDbCommand(comandoTelefone_Tipo, con);



            comEndereco.Parameters.Add("@Logradouro", OleDbType.VarChar).Value = txtRua.Text;
            comEndereco.Parameters.Add("@Numero", OleDbType.VarChar).Value = txtNumero.Text;
            comEndereco.Parameters.Add("@CEP", OleDbType.VarChar).Value = txtCEP.Text;
            comEndereco.Parameters.Add("@Bairro", OleDbType.VarChar).Value = txtBairro.Text;
            comEndereco.Parameters.Add("@Cidade", OleDbType.VarChar).Value = txtCidade.Text;
            comEndereco.Parameters.Add("@Estado", OleDbType.VarChar).Value = txtEstado.Text;
            comPessoa.Parameters.Add("@Nome", OleDbType.VarChar).Value = txtNome.Text;
            comPessoa.Parameters.Add("@CPF", OleDbType.VarChar).Value = txtCPF.Text;
            comPessoa.Parameters.Add("@Email", OleDbType.VarChar).Value = txtEmail.Text;
            comPessoa.Parameters.Add("@Telefone", OleDbType.VarChar).Value = txtTelefone.Text;
            comPessoa.Parameters.Add("@Endereco", OleDbType.VarChar).Value = comEndereco.Parameters;
            comPessoa_Telefone.Parameters.Add("@ID_Pessoa", OleDbType.VarChar).Value = comPessoa.Parameters;
            comPessoa_Telefone.Parameters.Add("@ID_Telefone", OleDbType.VarChar).Value = comTelefone.Parameters;
            comTelefone.Parameters.Add("@Numero", OleDbType.VarChar).Value = txtTelefone.Text;
            comTelefone.Parameters.Add("@DDD", OleDbType.VarChar).Value = txtDDD.Text;
            comTelefone.Parameters.Add("@Tipo", OleDbType.VarChar).Value = drpTipo.Text;
            comTelefone_Tipo.Parameters.Add("@Tipo", OleDbType.VarChar).Value = drpTipo.Text;

            try
            {
                con.Open();
                comEndereco.ExecuteNonQuery();
                comPessoa.ExecuteNonQuery();
                comPessoa_Telefone.ExecuteNonQuery();
                comTelefone.ExecuteNonQuery();
                comTelefone_Tipo.ExecuteNonQuery();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso",
                    "alert('Cadastro Efetuado Com Sucesso!');", true);
                
            }
            catch (Exception E)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Erro",
                    "alert('Erro ao Cadastrar!');", true);
                
            }
            finally
            {
                con.Close();
            }
        }

        protected void txtDDD_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string strcon = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\ANA PAULA\Documents\UNIP SISTEMAS ANA PAULA\TERCEIRO SEMESTRE\PIM VIII\CadastroDePessoas\CadastroDePessoas\obj\Debug\Database1.mdb";
            string comandoPessoa = "select* from Pessoa where Nome=@Nome";
            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand com = new OleDbCommand(comandoPessoa, con);

            com.Parameters.Add("@Nome", OleDbType.VarChar).Value = txtConsulta.Text;

            try
            {
                if (txtConsulta.Text == "")
                {
                    throw new Exception(" Digite o Nome para Pesquisar!");
                }
                con.Open();
                OleDbDataReader cs = com.ExecuteReader();

                if (cs.HasRows == false)
                {
                    throw new Exception("Não não Cadastrado!");
                   
                }
                else {
                    cs.Read();
                    txtNome.Text = Convert.ToString(cs["Nome"]);
                    txtEmail.Text = Convert.ToString(cs["Email"]);
                    txtCPF.Text = Convert.ToString(cs["CPF"]);
                    drpTipo.Text = Convert.ToString(cs["Tipo"]);
                    txtDDD.Text = Convert.ToString(cs["DDD"]);
                    txtTelefone.Text = Convert.ToString(cs["Telefone"]);
                    txtCEP.Text = Convert.ToString(cs["CEP"]);
                    txtRua.Text = Convert.ToString(cs["Rua"]);
                    txtNumero.Text = Convert.ToString(cs["Numero"]);
                    txtBairro.Text = Convert.ToString(cs["Bairro"]);
                    txtCidade.Text = Convert.ToString(cs["Cidade"]);
                    txtEstado.Text = Convert.ToString(cs["Estado"]);

                }

            }
            catch (Exception E)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso",
                     "alert('Nome Não Cadaastrado!');", true);
               
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            string strcon = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\ANA PAULA\Documents\UNIP SISTEMAS ANA PAULA\TERCEIRO SEMESTRE\PIM VIII\CadastroDePessoas\CadastroDePessoas\obj\Debug\Database1.mdb";

            string comandoPessoa = "delete from Pessoa Where Nome, CPF, Email,Telefone, Endereco=@Nome, @CPF, @Email,@Telefone, @Endereco";
            string comandoEndereco = "delete from Endereço Where Logradouro, Numero, CEP, Bairro, Cidade, Estado=@Logradouro, @Numero, @CEP, @Bairro, @Cidade, @Estado";
            string comandoPessoa_Telefone = "delete from Pessoa_Telefone Where ID_Pessoa, ID_Telefone=@ID_Pessoa, @ID_Telefone";
            string comandoTelefone = "delete from Telefone Where Numero, DDD, Tipo=@Numero, @DDD, @Tipo";
            string comandoTelefone_Tipo = "delete from Telefone_Tipo Where Tipo=@Tipo";

            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand comPessoa = new OleDbCommand(comandoPessoa, con);
            OleDbCommand comEndereco = new OleDbCommand(comandoEndereco, con);
            OleDbCommand comPessoa_Telefone = new OleDbCommand(comandoPessoa_Telefone, con);
            OleDbCommand comTelefone = new OleDbCommand(comandoTelefone, con);
            OleDbCommand comTelefone_Tipo = new OleDbCommand(comandoTelefone_Tipo, con);

            comEndereco.Parameters.Add("@Logradouro", OleDbType.VarChar).Value = txtRua.Text;
            comEndereco.Parameters.Add("@Numero", OleDbType.VarChar).Value = txtNumero.Text;
            comEndereco.Parameters.Add("@CEP", OleDbType.VarChar).Value = txtCEP.Text;
            comEndereco.Parameters.Add("@Bairro", OleDbType.VarChar).Value = txtBairro.Text;
            comEndereco.Parameters.Add("@Cidade", OleDbType.VarChar).Value = txtCidade.Text;
            comEndereco.Parameters.Add("@Estado", OleDbType.VarChar).Value = txtEstado.Text;
            comPessoa.Parameters.Add("@Nome", OleDbType.VarChar).Value = txtNome.Text;
            comPessoa.Parameters.Add("@CPF", OleDbType.VarChar).Value = txtCPF.Text;
            comPessoa.Parameters.Add("@Email", OleDbType.VarChar).Value = txtEmail.Text;
            comPessoa.Parameters.Add("@Telefone", OleDbType.VarChar).Value = txtTelefone.Text;
            comPessoa.Parameters.Add("@Endereco", OleDbType.VarChar).Value = comEndereco.Parameters;
            comPessoa_Telefone.Parameters.Add("@ID_Pessoa", OleDbType.VarChar).Value = comPessoa.Parameters;
            comPessoa_Telefone.Parameters.Add("@ID_Telefone", OleDbType.VarChar).Value = comTelefone.Parameters;
            comTelefone.Parameters.Add("@Numero", OleDbType.VarChar).Value = txtTelefone.Text;
            comTelefone.Parameters.Add("@DDD", OleDbType.VarChar).Value = txtDDD.Text;
            comTelefone.Parameters.Add("@Tipo", OleDbType.VarChar).Value = drpTipo.Text;
            comTelefone_Tipo.Parameters.Add("@Tipo", OleDbType.VarChar).Value = drpTipo.Text;

            try
            {
                con.Open();
                comEndereco.ExecuteNonQuery();
                comPessoa.ExecuteNonQuery();
                comPessoa_Telefone.ExecuteNonQuery();
                comTelefone.ExecuteNonQuery();
                comTelefone_Tipo.ExecuteNonQuery();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso",
                    "alert('Cadastro EXcluido Com Sucesso!');", true);
                

            }
            catch (Exception E)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ERRO",
                    "alert('Erro ao Excluir!');", true);
                
            }
            finally
            {
                con.Close();
            }
        }

        protected void txtConsulta_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click1(object sender, EventArgs e)
        {
            string strcon = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\ANA PAULA\Documents\UNIP SISTEMAS ANA PAULA\TERCEIRO SEMESTRE\PIM VIII\CadastroDePessoas\CadastroDePessoas\obj\Debug\Database1.mdb";

            string comandoPessoa = "update Pessoa set nome=@Nome, cpf= @CPF, email=@Email, telefone=@Telefone, endereco=@Endereco";
            string comandoEndereco = " update Pessoa set logradouro logradouro=@Logradouro, numero=@Numero, cep=@CEP, bairro=@Bairro, cidade=@Cidade, estado=@Estado";
            string comandoPessoa_Telefone = "update Pessoa set id_pessoa=@ID_Pessoa, id_telefone=@ID_Telefone";
            string comandoTelefone = "update Pessoa set numero=@Numero, ddd=@DDD, tipo=@Tipo";
            string comandoTelefone_Tipo = "update Pessoa set tipo=@Tipo";

            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand comPessoa = new OleDbCommand(comandoPessoa, con);
            OleDbCommand comEndereco = new OleDbCommand(comandoEndereco, con);
            OleDbCommand comPessoa_Telefone = new OleDbCommand(comandoPessoa_Telefone, con);
            OleDbCommand comTelefone = new OleDbCommand(comandoTelefone, con);
            OleDbCommand comTelefone_Tipo = new OleDbCommand(comandoTelefone_Tipo, con);

            comEndereco.Parameters.Add("@Logradouro", OleDbType.VarChar).Value = txtRua.Text;
            comEndereco.Parameters.Add("@Numero", OleDbType.VarChar).Value = txtNumero.Text;
            comEndereco.Parameters.Add("@CEP", OleDbType.VarChar).Value = txtCEP.Text;
            comEndereco.Parameters.Add("@Bairro", OleDbType.VarChar).Value = txtBairro.Text;
            comEndereco.Parameters.Add("@Cidade", OleDbType.VarChar).Value = txtCidade.Text;
            comEndereco.Parameters.Add("@Estado", OleDbType.VarChar).Value = txtEstado.Text;
            comPessoa.Parameters.Add("@Nome", OleDbType.VarChar).Value = txtNome.Text;
            comPessoa.Parameters.Add("@CPF", OleDbType.VarChar).Value = txtCPF.Text;
            comPessoa.Parameters.Add("@Email", OleDbType.VarChar).Value = txtEmail.Text;
            comPessoa.Parameters.Add("@Telefone", OleDbType.VarChar).Value = txtTelefone.Text;
            comPessoa.Parameters.Add("@Endereco", OleDbType.VarChar).Value = comEndereco.Parameters;
            comPessoa_Telefone.Parameters.Add("@ID_Pessoa", OleDbType.VarChar).Value = comPessoa.Parameters;
            comPessoa_Telefone.Parameters.Add("@ID_Telefone", OleDbType.VarChar).Value = comTelefone.Parameters;
            comTelefone.Parameters.Add("@Numero", OleDbType.VarChar).Value = txtTelefone.Text;
            comTelefone.Parameters.Add("@DDD", OleDbType.VarChar).Value = txtDDD.Text;
            comTelefone.Parameters.Add("@Tipo", OleDbType.VarChar).Value = drpTipo.Text;
            comTelefone_Tipo.Parameters.Add("@Tipo", OleDbType.VarChar).Value = drpTipo.Text;

            try
            {
                con.Open();
                comEndereco.ExecuteNonQuery();
                comPessoa.ExecuteNonQuery();
                comPessoa_Telefone.ExecuteNonQuery();
                comTelefone.ExecuteNonQuery();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso",
                    "alert('Dados Alterado Com Sucesso!');", true);
                          }
            catch (Exception E)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ERRO",
                    "alert('Erro ao Alterar!');", true);
               
            }
            finally
            {
                con.Close();
            }
        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtConsulta.Text = "";
            txtEmail.Text = "";
            txtCPF.Text = "";
            drpTipo.SelectedValue = "";
            txtDDD.Text = "";
            txtTelefone.Text = "";
            txtCEP.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";



        }
    }
} 