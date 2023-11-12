# Versão 1.0
## Objetivo
Criar relatórios dos meus gastos, usando estratos de debito e credito dos bancos e manual.

### Arquivos aceitos
Tipos de inputs aceitos: .txt (para suportar inserção manual), .cvs, .pdf, .ofx, json (próprio, gerado pelo próprio programa e utilizado para reinserir meses anteriores).

### Tipos de contas suportadas
* Credito
* Debito

## Relatórios

### Métodos de saida
* No console, para que a gente possa testar mais facilmente.
* Relatórios de texto (relatórios .txt que sejam fáceis de ler, copiar e colar).
* Relatórios em PDF (Incluindo textos mas mais interessante gráficos).
* Tabelas do excel.

### O que pode ser inlcuido nos relatórios / tipos de relatórios
* Gastos mensal, Gasto semanal (7 dias), Gasto diário.
* Estatísticas de Cada grupo / categoria de compra (Quanto foi gasto por dia / semana / mês, e a percentagem de cada um).
* Compras de cada grupo / categoria (Útil para identificar onde está indo o dinheiro, mas também para saber se a compra está sendo categorizada corretamente).
* Gráfico de volume, mostrando o gasto total de cada grupo em relação ao gasto global.
* Gráfico pizza que representa o total de gastos, com cada parte da pizza sendo um grupo, não pode haver gasto que pertence a dois grupos ou esse gráfico vai ficar zoado.
* Total gasto no mês (do primeiro ao ultimo dia), gasto por dia e gasto por semana (7 dias).
* Total do valor gasto por Tags / grupo (exemplo: uber/99, restaurantes, mercados) por mês, por semana (7 dias) e por dia.
* mostrando o gasto total de cada Tag / grupo em relação ao gasto global mensal, semanal, diário.
* Listagem de cada item com o identificador único, data e valor de cada Tag / grupo.

# Versão 2.0
Criar um programa com interface gráfica que utilizada tudo que a gente já implementou até agora.  
Ter um forma para editar as entradas que foram geradas a partir dos arquivos, poder editar e adicionar manualmente.  
Depois desse forma as entradas serão processadas, e depois de processadas poderão ser editadas (tags, preço, qualquer coisa).  
Poder editar uma entrada (exemplo, mercado) e definir o que compõem aquela compra.  
Editar tags e outros métodos de categorização diretamente na interface gráfica.  
Usar os métodos já conhecidos para gerar os relatórios a partir de dados selecionados (tudo, meses, semana ou dia especifico).   

[Voltar](README.md)  
