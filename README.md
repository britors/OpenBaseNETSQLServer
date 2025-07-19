## 🚀 Uso como Template do .NET CLI

Você pode instalar este projeto como um template local na sua máquina para criar novas soluções rapidamente usando o comando `dotnet new`.

### Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0 ou superior).
* [Git](https://git-scm.com/downloads).

### Instalação Local

Siga os passos abaixo para instalar o template:

1.  **Clone o repositório:**
    Abra seu terminal ou prompt de comando e clone este projeto:
    ```bash
    git clone [https://github.com/britors/OpenBaseNETSQLServer.git](https://github.com/britors/OpenBaseNETSQLServer.git)
    ```

2.  **Navegue até a pasta do projeto:**
    ```bash
    cd OpenBaseNETSQLServer
    ```

3.  **Instale o template:**
    Execute o seguinte comando para que o .NET CLI reconheça este projeto como um template:
    ```bash
    dotnet new install .
    ```
    Após a execução, você deverá ver uma mensagem de sucesso confirmando que o template "OpenBaseNET SQLServer Template" foi instalado.

### Como Usar o Template

Uma vez instalado, você pode criar um novo projeto baseado nele a qualquer momento.

1.  Crie uma pasta para sua nova solução e navegue até ela:
    ```bash
    mkdir MinhaNovaAPI
    cd MinhaNovaAPI
    ```

2.  Execute o comando `dotnet new` usando o nome curto do template (`openbasenet-sql`) e defina um nome para o seu novo projeto com a opção `-n`:
    ```bash
    dotnet new openbasenet-sql -n MinhaNovaAPI
    ```
    Pronto!