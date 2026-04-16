<h1 align="center"> BaseUtils </h1>

[🇺🇸 Documentation in english](#english-section-id) | [🇧🇷 Documentação em português](#portuguese-section-id)

<a name="english-section-id"></a>
## BaseUtils - Description

**BaseUtils** is a C# library containing classes for flow control, such as the Result and Error types.
This library, inspired by functional programming principles and the Result type behavior found in languages like Rust, aims to ensure an information and operation flow with minimal exceptions.
Among its benefits, which enable better coverage of possible behaviors, the following stand out:

* Standardized method responses;
* Greater clarity and control over the possible behaviors and workflows of the application;
* Error customization;

[For historic of updates: ](docs/versions.md)

### Resources

The library provides two main classes: Result and Error.

The Result type represents the outcome of an operation. There are two possible scenarios: success or failure.
A Result object in a success state may or may not contain a value of type T, depending on the implementation used.

The failure state, on the other hand, can contain one or more errors related to the executed operations.

to verify releases and updates in [versions](docs/versions-en-us.md)

#### _ErrorResponse Type_

An Error object contains an enum indicating the type of error. There are five predefined categories in version 9.X:

* InvalidOperationError: For issues with a generic operation;
* InvalidTypeError: For incorrect type usage within the given context;
* NotFoundError: For missing objects in queries or searches;
* NoAccessError: For access-related issues when attempting to reach a resource;
* CriticalError: For critical errors (typically in case of thrown exceptions).

The error types were designed to carry meaningful information about the issues that prevented the continuation of operations.
In addition to the error type, you can provide a custom error message and an optional value for message parameterization.

#### _Result Type_

The Result type stores the outcome of a behavior to be validated.
It has two possible states—Success or Failure—and two mutually exclusive properties: Value¹ and a list of errors.

¹ One of the Result implementations does not require a return value, allowing it to be used as a "boolean-like" response pattern, where the result itself represents success or failure.

<a name="portuguese-section-id"></a>
## BaseUtils - Descrição

**BaseUtils** consiste em uma biblioteca na linguagem C#, contendo classes para controle de fluxo, como os tipos _Result_ e _Error_.
Esta biblioteca, baseada em principios funcionais e no comportamento do _Result type_ presente em linguagens como Rust, tem por objetivo 
garantir um fluxo de informações e operações com o mínimo de exceções possíveis. 
Dentre os benefícios deste permitindo uma cobertura melhor de comportamentos, destacam-se:
* Padronização de respostas entre métodos;
* Maior clareza controle sobre os possíveis comportamentos e fluxos de trabalho da aplicação;
* Customização de erros;

[Para histórico de atualizações: ](docs/versions-pt-br.md)
### Instalação

1°) Adicione o canal _https://nuget.pkg.github.com/MateuSerafim/index.json_ as configurações de canais NuGet e 
configure as opções de login utilizando seu Github, conforme o exemplo abaixo:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget" value="https://api.nuget.org/v3/index.json" />
    <add key="github" value="https://nuget.pkg.github.com/MateuSerafim/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
      <add key="Username" value="%GH_USERNAME%" />
      <add key="ClearTextPassword" value="%GH_TOKEN%" />
    </github>
  </packageSourceCredentials>
</configuration>
```
onde _**GH_Username**_ é a variável de ambiente contendo seu _username_ e _**GH_TOKEN**_ é o seu token de acesso a github.


> ⚠️ **Atenção:** Nunca insira suas credenciais diretamente em projetos ou deixe-a exposta em código aberto. O login é exigência do github para baixar os pacotes.


2°) No seu terminal, execute o seguinte comando: 
```sh
dotnet add package Rodovia.BaseUtils --version 9.0.2
```

### Recursos
A biblioteca traz duas classes principais: _Result_ e _Error_.

o tipo result representa o resultado de uma operação. Existem dois cenários possíveis: sucesso ou falha.
Um objeto do tipo _Result_ em seu estado de sucesso pode ou não possuir um valor T, a depender da implementação utilizada.


O padrão de falha, por sua vez, pode conter um ou mais erros das operações realizadas.

🚀 **Dica:** para lista completa de mudanças e adições por versão, consultar documento: .

#### _ErrorResponse Type_
Um objeto da classe _Error_ possui um Enum indicando o tipo de erro. São 5 padrões, na versão 9.X:

* InvalidOperationError: para problemas em alguma operação genérica;
* InvalidTypeError: para chamados de tipos incorretos no contexto;
* NotFoundError: para ausência de objetos em pesquisas;
* NoAccessError: para problemas de acesso a recursos;
* CriticalError: para errors críticos (em ocorrência de exceções),

Os tipos de erros foram pensados para comportar informações para indicar os problemas que 
inviabilizaram a continuidade das operações. Além do tipo, é possível passar uma mensagem
customizada para explicação do erro, e um valor para preenchimento na mensagem.

#### _Result Type_

O tipo _Result_ por sua vez guarda a resposta de um comportamento a ser validado. Possui
dois parâmetros - Sucesso ou Falha - e duas propriedades auto excludentes - Valor¹ e lista de erros.

¹Uma das implementações de result não necessita de um retorno de valores, podendo ser entendido
como um padrão de resposta "booleano" onde o próprio resultado é o valor.

### Exemplos de uso
Considere a classe [_NeuralNetwork_](https://pt.wikipedia.org/wiki/Rede_neural_artificial), representando uma rede neural.
```csharp
public Interface INeuron
{
}

public partial class NeuralNetwork
{
    public float DropoutTaxe {get; set; } 
    public float LearningRate {get; set; }
    public List<INeuron> NeuronsList {get; set; }

    private NeuralNetwork(float dropoutTaxe, float learningRate, List<INeuron> neuronsList)
    {
       DropoutTaxe = dropoutTaxe;
       LearningRate = learningRate;
       NeuronsList = neuronsList;
    }
} 
```

#### Construção de objetos
Muitas vezes, necessita-se de um controle fino na construção da classe. Dentre as diversas estratégias, uma das possibilidade
é criar um método estático que faz as verificações, retornando um resultado positivo ou negativo, conforme as verificações:

```csharp

public partial class NeuralNetwork
{
    public static Result<NeuralNetwork> Neuron(float dropoutTaxe, float learningRate, List<INeuron> neuronsList)
    {
      List<ErrorResponse> errorsList = [ValidateDropoutTaxe(dropoutTaxe), ];

     if (dropoutTaxe >= 1.0)
        errorsList.add(ErrorResponse.InvalideOperationError<float>(messageError1));

    if (learningRate <= 0)
        errorsList.add(ErrorResponse.InvalideOperationError<float>(messageError2));

    if (neuronsList is null || neuronsLis.Count = 0)
       errorList.add(ErrorResponse.InvalideOperationError<float>(messageError3));

    // Conversão implicita dos tipos T para Result<T> (Success) e ErrorResponse para Result<T> (Failure)
    return errorsList.Count == 0 ? new(dropoutTaxe, learningRate, neuronsList) : errorsList;
    }
} 
```
