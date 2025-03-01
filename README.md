<h1 align="center"> BaseUtils </h1>

[🇺🇸 Documentation in english](#english-section-id) | [🇧🇷 Documentação em português](#portuguese-section-id)

<a name="english-section-id"></a>
## BaseUtils - Description

<a name="portuguese-section-id"></a>
## BaseUtils - Descrição

**BaseUtils** consiste em uma biblioteca na linguagem C#, contendo classes para controle de fluxo, como os tipos _Result_ e _Error_.
Esta biblioteca, baseada em principios funcionais e no comportamento do _Result type_ presente em linguagens como Rust, tem por objetivo 
garantir um fluxo de informações e operações com o mínimo de exceções possíveis. 
Dentre os benefícios deste permitindo uma cobertura melhor de comportamentos, destacam-se:
* Padronização de respostas entre métodos;
* Maior clareza controle sobre os possíveis comportamentos e fluxos de trabalho da aplicação;
* Customização de erros;

### Recursos
A biblioteca traz duas classes principais: _Result_ e _Error_.

o tipo result representa o resultado de uma operação. Existem dois cenários possíveis: sucesso ou falha.
Um objeto do tipo _Result_ em seu estado de sucesso pode ou não possuir um valor T, a depender da implementação utilizada.


O padrão de falha, por sua vez, pode conter um ou mais erros das operações realizadas. 

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
``` C#
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

```C#

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
