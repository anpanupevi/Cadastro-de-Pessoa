<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CadastroDePessoas._Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center" style="font-family: 'Times New Roman', Times, serif; font-size: xx-large; text-decoration: underline"><strong id="h1.text.Titulo">PROGRAMA CADASTRO DE PESSOAS</strong></h1>
        <p>
            <asp:Button ID="btnSair" runat="server" style="font-family: 'Times New Roman', Times, serif" Text="Sair" OnClick="btnSair_Click" />
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h6>
                <asp:Button ID="btnConsultar" runat="server" style="font-family: 'Times New Roman', Times, serif" Text="Consultar" OnClick="btnConsultar_Click" />
                <asp:TextBox ID="txtConsulta" runat="server" OnTextChanged="txtConsulta_TextChanged" Width="601px">Digite o Nome para Consulta</asp:TextBox>
            </h6>
        </div>
        <div class="col-md-4">
            <h2 id="lblTelefone" style="font-size: large" class="text-right">
                <asp:Label ID="lblNome" runat="server" style="font-size: large; font-family: 'Times New Roman', Times, serif" Text="Nome   "></asp:Label>
                <asp:TextBox ID="txtNome" runat="server" style="font-family: 'Times New Roman', Times, serif" Width="629px" OnTextChanged="txtNome_TextChanged"></asp:TextBox>
           </h2>
            <h2 id="lblTelefone0" style="font-size: large" class="text-right">
                <asp:Label ID="lblEmail" runat="server" style="font-size: large; font-family: 'Times New Roman', Times, serif" Text="E-mail  "></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" style="font-family: 'Times New Roman', Times, serif" Width="629px" OnTextChanged="txtNome_TextChanged" TextMode="Email"></asp:TextBox>
            </h2>
            <h2 style="font-size: large" class="text-right">
                <asp:Label ID="lblCPF" runat="server" style="font-size: large; font-family: 'Times New Roman', Times, serif" Text="  CPF   "></asp:Label>
                <span style="font-size: large">
                <asp:TextBox ID="txtCPF" runat="server" OnTextChanged="TextBox3_TextChanged" style="font-family: 'Times New Roman', Times, serif; margin-left: 11px" Width="626px"></asp:TextBox>
                </span></h2>
            <h2 style="font-size: large" class="text-right"><span style="font-size: large">
                <asp:Label ID="lblTelefone" runat="server" style="font-family: 'Times New Roman', Times, serif; font-size: large" Text="Telefone     "></asp:Label>
                </span>
                <asp:DropDownList ID="drpTipo" runat="server">
                    <asp:ListItem>Celular</asp:ListItem>
                    <asp:ListItem>Residencial</asp:ListItem>
                    <asp:ListItem>Comercial</asp:ListItem>
                    <asp:ListItem>Recado</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtDDD" runat="server" ForeColor="Black" OnTextChanged="txtDDD_TextChanged" Width="96px">DDD</asp:TextBox>
                <asp:TextBox ID="txtTelefone" runat="server" style="font-family: 'Times New Roman', Times, serif; margin-left: 12px" Width="257px" TextMode="Phone"></asp:TextBox>
            </h2>
            <h2 class="text-right">
                <asp:Label ID="lblCEP" runat="server" style="font-family: 'Times New Roman', Times, serif; font-size: large" Text="      CEP   "></asp:Label>
                <asp:TextBox ID="txtCEP" runat="server" style="font-family: 'Times New Roman', Times, serif; margin-left: 3px" Width="630px"></asp:TextBox>
            </h2>
            <h2 class="text-right">
                <asp:Label ID="lblRua" runat="server" style="font-family: 'Times New Roman', Times, serif; font-size: large" Text="   Rua"></asp:Label>
                <asp:TextBox ID="txtRua" runat="server" style="font-family: 'Times New Roman', Times, serif; margin-left: 3px" Width="630px" ForeColor="Black">Logradouro</asp:TextBox>
            </h2>
            <h2 id="lblNumero" style="font-size: large" class="text-right">&nbsp;<asp:Label ID="lblNumero" runat="server" style="font-family: 'Times New Roman', Times, serif" Text="Número   "></asp:Label>
&nbsp;<asp:TextBox ID="txtNumero" runat="server" style="font-family: 'Times New Roman', Times, serif; margin-left: 9px" Width="593px"></asp:TextBox>
                <span style="font-family: 'Times New Roman', Times, serif">&nbsp;</span></h2>
            <h2 style="font-size: large" class="text-right"><span style="font-family: 'Times New Roman', Times, serif">
                <asp:Label ID="lblBairro" runat="server" Text="Bairro"></asp:Label>
&nbsp;&nbsp; </span>
                <asp:TextBox ID="txtBairro" runat="server" style="font-family: 'Times New Roman', Times, serif" Width="611px"></asp:TextBox>
            </h2>
            <h2 id="lblCidadeEstado" style="font-size: large" class="text-right">
                <asp:Label ID="lblCidade" runat="server" style="font-family: 'Times New Roman', Times, serif" Text="Cidade"></asp:Label>
                <span style="font-family: 'Times New Roman', Times, serif">&nbsp; </span>
                <asp:TextBox ID="txtCidade" runat="server" style="font-family: 'Times New Roman', Times, serif; margin-left: 7px" Width="602px"></asp:TextBox>
            </h2>
            <h2 style="font-size: large" class="text-right"><span style="font-family: 'Times New Roman', Times, serif">
                <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
&nbsp;&nbsp; </span>
                <asp:TextBox ID="txtEstado" runat="server" style="font-family: 'Times New Roman', Times, serif" Width="602px"></asp:TextBox>
            </h2>
            <h6 class="text-right" style="font-family: 'Times New Roman', Times, serif; font-size: large">
                &nbsp;</h6>
        </div>
        <div class="col-md-4" style="text-align: right">
            <h6>
                <asp:Button ID="btnLimpar" runat="server" OnClick="Button1_Click" style="margin-left: 45px" Text="Limpar" Width="86px" />
            </h6>
            <h6>
                &nbsp;</h6>
            <h6>
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
                <asp:Button ID="btnEditar" runat="server" style="font-family: 'Times New Roman', Times, serif" Text="Editar" OnClick="btnEditar_Click1" />
                <asp:Button ID="btnCadastrar" runat="server" style="font-family: 'Times New Roman', Times, serif" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </h6>
        </div>
        <div class="text-right">
        </div>
    </div>

</asp:Content>
