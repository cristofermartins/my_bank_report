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
* Relatórios de texto (escrito no console ou arquivo .txt).
* Relatórios em PDF (Incluindo textos mas mais interessante gráficos).
* Tabelas Excel / Calc.

### Modificadores do relatorio
* Seleção do periodo - ultimo dia, ultimos 7 dias, ultimos 30 dias, entre uma data e outra, inlcuindo a opção dos meses do primeiro ao ultimo dia, também pode ser sem periodo, usando todos os dias disponiveis.  
* Organizar itens por data ou do maior para o menor ou do menor para o maior.  

### Tipos de relatorios
* Relatorio de gastos medio: total do periodo, medio diario, medio semanal (7 dias), medio "mensal" (30 dias). (relatorio em .txt, .pdf e .csv).
* Relatorio de gastos totais: Gasto de cada dia (e a %), gasto de cada semana (e a %), gasto de cada mês (e a %). (relatorio em .txt, .pdf e .csv).
* Relatorio de gastos medio por tag: total do periodo, medio diario, medio semanal (7 dias), medio "mensal" (30 dias). Bater com medio de um periodo para descobrir a % em relação ao total. (relatorio em .txt, .pdf e .csv).  
* Relatorio de gastos totais por tag: Gasto de cada dia (e a %), gasto de cada semana (e a %), gasto de cada mês (e a %). Bater com gastos de um periodo para descobrir a % em relação ao total. (relatorio em .txt, .pdf e .csv).  
* Listagem de cada item organizado por cada Tag com o identificador único, data, valor e tags identificadas nessa compra. (relatorio em .txt, .pdf e .csv).   
* Listagem de cada item com o identificador único, data, valor e tags identificadas nessa compra. (relatorio em .txt, .pdf e .csv).  

# Versão 2.0
Criar um programa com interface gráfica que utilizada tudo que a gente já implementou até agora.  
Ter um forma para editar as entradas que foram geradas a partir dos arquivos, poder editar e adicionar manualmente.  
Depois desse forma as entradas serão processadas, e depois de processadas poderão ser editadas (tags, preço, qualquer coisa).  
Poder editar uma entrada (exemplo, mercado) e definir o que compõem aquela compra.  
Editar tags e outros métodos de categorização diretamente na interface gráfica.  
Usar os métodos já conhecidos para gerar os relatórios a partir de dados selecionados (tudo, meses, semana ou dia especifico).   

[Voltar](README.md)  
