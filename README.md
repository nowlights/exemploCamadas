# exemploCamadas

### Desenho da estrutura e referências
![image](https://github.com/nowlights/exemploCamadas/assets/57915897/ebe99c0e-f004-4b7c-a4a9-0f548de7d53d)


### Inverção de Dependência
A inverção de dependência, é aplicada entre a camda <b>Application</b> e <b>Infra.Data</b>, onde, Infra.Data depende de Application, apesar da camada Application buscar os dados no banco de dados pela camada de Infra.Data.

## Como funciona a Inverção?
Na camada Application, vamos registar as Interfaces de repositorios (IClienteRepository) que será abstraida lá na camada de Infra.data.
Na camada Infra.Data, vamos criar a classe (ClienteRepository) que irá referenciar a interface contida em Application (IClienteRepository).
Na camada Infra.CrossCutting.IoC, vamos registrar o serviço das duas de cima:

`services.AddScoped<IClienteRepository, ClienteRepository>();`

Com isso, estamos fazendo com que a camada de Infra.Data dependa de Application onde está nossas abstrações.
![image](https://github.com/nowlights/exemploCamadas/assets/57915897/423b4811-9b50-4a4b-8c24-dc584b62b8bc)
