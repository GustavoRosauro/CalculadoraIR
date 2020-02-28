# Calculadora Imposto Renda

Instruções para utilizar o projeto:

1- Mudar a configuração do banco de dados no arquivo appsettings.json

2- Para realizar os testes também é necessário informar o caminho do seu banco de dados


3- Após feito esses passos inicie uma migration, em seu console do gerenciador de pacotes para gerar a base em sua máquina 
utilizando os seguintes comandos, Add-Migration Nome_Migracao e logo em seguida você dará o comando Update-Database para atualizar sua base de dados

4- Feito esses passos quando você iniciar a aplicação a primeira tela que irá aparecer será a de cadastrar contribuintes, nessa tela basta informar os dados dos contribuintes e clicar em salvar e será cadastrado na base.

5- Quando finalizar os cadastros, basta clicar no botão com o nome finalizar Cadastro 

6- agora basta informar o valor do salário minimo e clicar em Salvar Salario e será gerado o calculo de imposto de renda para os contribuintes informados no passo anterior  
