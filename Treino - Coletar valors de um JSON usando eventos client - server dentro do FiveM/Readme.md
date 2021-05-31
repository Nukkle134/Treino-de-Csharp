<h1> Teste de JSON - Usando um script(bem besta) real como exemplo </h1>
<br> O script usado como exemplo, é onde você tem que clicar para respirar, mas esse não é o foco. </br>

<h1> OBJETIVO DO TESTE </h1>
<br> o objetivo foi apenas ver como funciona enviar dados de um arquivos JSON, que dentro do Fivem só podem ser coletados pelo Server, pois ele é quem tem acesso as diretórios que precisamos para acesar o .JSON </br>
<br> por meio do client, que enviar um evento ao server assim que o resource é iniciado, o server que já leu todo o json e transformou em uma string, envia isso para o client. Através do Netwonsoft.json.dll esse texto é "desserializado", deixando com que o valor que queremos sela lido com perfeição! </br>
<br> caso você esteja tentando fazer o mesmo, se atente a versão do NEWTONSOFT. dependendo da versão, ele não funciona direito com o FiveM. Utilize a versão do meu rep que funciona :) </br>
