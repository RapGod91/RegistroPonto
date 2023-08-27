# RegistroPonto


<br/>

Trata-se de um projeto onde é desenvolvida uma aplicação completa de software considerando tecnologias apresentadas durante o curso de Extensão Tecnologias Microsoft da UNICAMP.
<br/>
Tem por objetivo a criação de uma aplicação para Windows capaz de gerenciar o registro de ponto de funcionários, utilizando C#, e o framework WPF e XAML.

<br/>

# Aplicação de Registro de Ponto

Esta aplicação de Registro de Ponto é uma ferramenta simples para registrar os horários de entrada e saída de funcionários, gerenciar seus dados e visualizar relatórios de presença.

## Pré-requisitos

- **Sistema Operacional:** A aplicação foi desenvolvida para ser executada em sistemas operacionais Windows.
- **Banco de Dados:** A aplicação utiliza um banco de dados SQLite integrado.

## Como Executar

1. Faça o download do código-fonte ou clone o repositório para o seu computador.

2. Certifique-se de ter o .NET Framework instalado em sua máquina. Você pode baixá-lo em: [Download .NET Framework](https://dotnet.microsoft.com/download/dotnet-framework).

3. Abra o diretório do projeto em um ambiente de desenvolvimento integrado (IDE) compatível com C#, como o Visual Studio ou o Visual Studio Code.

4. Execute a aplicação:

   - Abra o projeto `RegistroPonto` em seu IDE.
   - Compile o projeto para garantir que não haja erros.
   - Execute a aplicação a partir da classe `MainWindow`.

5. A aplicação será iniciada e você verá a interface principal.

## Funcionalidades

- **Registrar Ponto:** Permite registrar os horários de entrada e saída de funcionários.
- **Gerenciar Funcionários:** Permite cadastrar, atualizar e excluir funcionários.
- **Visualizar Folha de Ponto:** Exibe a folha de ponto de um funcionário, mostrando os registros de presença e ausência.

## Perguntas Frequentes

**1. Como faço para adicionar um novo funcionário?**
   - Na tela principal, clique no botão "Gerenciar", entre com o usuário e senha(admin/admin), em seguida preencha as informações do novo funcionário (nome, cargo e selecione a foto) e clique em "Cadastrar".

**2. Como registro o ponto de um funcionário?**
   - Na tela principal, clique no botão "Registrar Ponto". Insira o ID do funcionário e clique em "OK". O registro de ponto será feito automaticamente.

**3. Como vejo a folha de ponto de um funcionário?**
   - Na tela principal, clique no botão "Gerenciar", entre com o usuário e senha(admin/admin), em seguida escolha a opção "Folha de Ponto". Insira o nome do funcionário e clique em "Buscar". A folha de ponto com os registros de presença e ausência será exibida.

## Problemas e Sugestões

Para facilitar alterações no código, comentei a maior parte das classes e métodos.

Se você encontrar problemas ou tiver sugestões para melhorias, sinta-se à vontade para abrir uma [issue](https://github.com/seu-usuario/seu-repositorio/issues) neste repositório.


