# Conexão com o banco MySQL utilizando ASP.NET CORE MVC

Essa documentação trata-se de um passo a passo de como implementar uma conexão com o banco MySQL utilizando .NET.

## Instalação do Banco de dados

#### 1 - Download do Instalador
- Link para baixar o MSI Installer: `https://dev.mysql.com/downloads/installer/`

#### 2 - Selecionando o Setup de Instalação
 Selecione a opção Custom e escolha as seguintes ferramentas:
 - MySQL Server
 - MySQL Workbench

#### 3 - Configurando o MySQL Server
 - Defina um usuário e senha para acessar o server

#### 4 - Criando Projeto ASP.NET CORE
 - Abra o visual Studio , e clique em `Create new project`
 - Escolha o padrão de projeto `ASP.NET Core Web app (Model-View-Controller)`

#### 5 - Instalando Plugins necessários para conexão
 Para fazermos o CRUD no banco de dados precisaremos de instalar o plugin EntityFrameWork, para instalar, vá até a `barra de ferramenta superior > Tools > Nuget Package Manager > Package Manager Console` , e digite os seguintes comandos:
 
 ``` powershell
 Install-Package Microsoft.EntityFrameworkCore
 ```
  ``` powershell
 Install-Package Microsoft.EntityFrameworkCore.Design
 ```
  ``` powershell
 Install-Package Pomelo.EntityFrameworkCore.MySql
 ```

#### 6 - Criando Model
 Dentro da pasta Models crie os seguintes arquivos:
 - UserModel.cs:
```cs

using NameSpaceDoProjeto.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NameSpaceDoProjeto.Models;

[Table("USER")]
public class UserModel
{
    [Display(Name = "Código")]
    [Column("id")]
    public int Id { get; set; }
    [Display(Name = "Código do endereço")]
    [ForeignKey("address_id")]
    [Column("address_id")]
    public int AddressId { get; set; }
    [Display(Name = "Nome")]
    [Column("name")]
    public string Name { get; set; }
    [Display(Name = "Email")]
    [Column("email")]
    public string Email { get; set; }
    [Display(Name = "Telefone")]
    [Column("phone")]
    public string Phone { get; set; }
    [Display(Name = "Documento")]
    [Column("document")]
    public string Document { get; set; }
    [Display(Name = "Status")]
    [Column("status")]
    public string Status { get; set; }

    public AddressModel? Address { get; set; }

}

```
 - AddressModel.cs:
```cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestMySQLConnection.Models;

namespace NameSpaceDoProjeto.Models;

[Table("ADDRESS")]
public class AddressModel
{
    [Display(Name = "Código")]
    [Column("id")]
    public int Id { get; set; }
    [Display(Name = "Número")]
    [Column("number")]
    public string Number { get; set; }
    [Display(Name = "Rua")]
    [Column("street")]
    public string Street { get; set; }
    [Display(Name = "Complemento")]
    [Column("complement")]
    public string Complement { get; set; }
    [Display(Name = "Cidade")]
    [Column("city")]
    public string City { get; set; }
    [Display(Name = "Estado")]
    [Column("state")]
    public string State { get; set; }
    [Display(Name = "Zip Code")]
    [Column("zip_code")]
    public string ZipCode { get; set; }
    [Display(Name = "País")]
    [Column("country")]
    public string Country { get; set; }
    [Display(Name = "País")]
    [Column("country")]
    public ICollection<User?> Users { get; set; } = new List<User?>();
}
```

#### 6 - Criando Contexto do Banco
Crie uma pasta na raiz do projeto com o nome Database e adicione o seguinte arquivo:
 - Contexto.cs:
```cs

using Microsoft.EntityFrameworkCore;
using NameSpaceDoProjeto.Models;

namespace NameSpaceDoProjeto.Data;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }
   public DbSet<User> Users { get; set; }
   public DbSet<Address> Addresses { get; set; }
}




```

#### 7 - Registrando a Depêndencia do contexto na inicialização da aplicação
 - O ASP.NET possui um contêiner de injeção de dependência (DI), onde são registradas as dependências. Quando um Controller ou Serviço necessita de uma delas o ASP.NET faz a injeção dessa instância.
 - No nosso caso, para que os Controllers e Serviços façam a interação com o banco, é preciso de uma instancia  ``Contexto``.
 - Para Registrar uma instancia de contexto adicione esse trecho ao arquivo ``program.cs``:
```cs
// BEGIN
    builder.Services.AddDbContext<Contexto>(
        options => options.UseMySql("server=localhost;initial catalog=MYSQL_CONNECTION;uid=user;pwd=senha",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"),
        ));
// END
 var app = builder.Build();

```

#### 8 - Criando Controllers e Views
 - Vá na pasta Controllers e clique com botão direito do mouse > add > Controller.. e adicione um controller
 - Escolha a opção `MVC Controller with views, using Entity Framework`
 - Escolha a classe modelo (Nossas entidades/tabelas do banco)
 - Escolha a classe Contexto

 #### 9 - Executar Migration  para criação do banco
Antes de executar o programa, precisamos criar o migration/update do banco de dados, para fazer isso execute os seguintes comandos:
 
 ``` powershell
Add-Migration Criacao-Inicial -Context Contexto
 ```
  ``` powershell
Update-Database -Context Contexto
 ```


#### 10 - Adicionando link para outras views na home
 - navegue na pasta Views > Home > Index.cshtml:
 - Substitua o codigo por esse:
```html
@{
    ViewData["Title"] = "Home Page";
}

<div class="text-center">
    <h1 class="display-4">Conexão com o MySQL Utilizando ASP.NET Core MVC </h1>
    <h5 >Tabelas</h5>
    <p>CRUD Tabela  <a href="@Url.Action("Index", "User")">User</a>.</p>
    <p>CRUD Tabela  <a href="@Url.Action("Index", "Address")">Address</a>.</p>

</div>

```

