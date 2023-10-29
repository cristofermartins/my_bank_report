# Principal
É um processo que primariamente é dividido em três partes: 
* Gerar os dados de input a partir dos arquivos do usuário.
* Processar esses dados de input.
* Gerar os relatórios a partir desses dados.

## Input
processando os arquivos (.txt, .cvs, .pdf, .ofx) produzir uma estrutura que representa uma lista de entradas / lançamentos de compras do usuário. 
Cada tipo de arquivo é processado por Parser próprio especifico. Podemos usar nome do arquivo, extensão e conteúdo para definir qual Parser usar. Nós precisamos remover informações imuteis ou duplicadas extraídas também. 

### Passos
* Identificar o arquivo e qual Parser deve usar.
* Extrair os dados do arquivo.
* Preprocessar esses dados, remover duplicados e informações imuteis para nós.

## Processamento

### Único
Primeiro, nos processamos uma entrada / lançamento para criar uma entrada / lançamento processado que é composto combinando dados que vieram dos arquivos com dados customizados do processo. 
Aqui entra o sistema de tag. Nós usamos o sistema de tag para identificar qual grupo ou categoria a entrada / lançamento pertence. 

### Múltiplo
Aqui nos processamentos as entradas / lançamentos como um todo. 
Remover duplicações de entradas ou remover entradas que não devem estar e serem usadas parar os relatórios. 

## Relatório
Aqui nós usamos a lista de lançamentos / entradas para criar todos tipo de relatórios. 
O Trabalho aqui é simplesmente construir dados que representam os resultados que queremos mostrar nos relatórios usando o método de saída desejado. 

