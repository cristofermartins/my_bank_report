Referencia gitflow: https://www.alura.com.br/artigos/git-flow-o-que-e-como-quando-utilizar

# Explicações de cada branch
## Branch main:
Produção, é a versão estavel usada pelos usuario final. Brabchs hotfix são criadas a partir daqui.

## Branch develop:
O projeto em desenvolvimento vai estar aqui. Branchs Features são criadas a partir daqui.  

## branchs hotfixes:
Correções de bugs encontrados na main.  

## branchs features:
Desenvolvimento de funcionalidades.  

## Releases:
São os "lançamentos" de versões novas com as novas funcionalidades que estão no develop juntando no main.  
Cada lançamento precisa de uma versão.  

# Workflow
## Desenvolvimento de uma nova funcionalidade:
* Criar um branch a partir do develop
* Trabalhar nessa branch até ter algo funcionando
* Criar pull request o branch develop
* Depois do pull request revisado e aceito, dar merge

## Correção de um bug:
* Criar um branch a partir do main
* Trabalhar nessa branch até ter o bug corrigido
* Criar o pull request para a branch main
* Depois do pull request revisado e aceito, dar merge

## Lançamento / release:
* Criar um branch de release com a versão
* Testar esse branch
* "Lançar" esse release dando merge dessa branch na branch main.

[Voltar](README.md)  
