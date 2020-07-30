using Modulo17.entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Modulo17
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Criando a lista de Funcionários
            List<Employee> Employess = new List<Employee>();

            //Definindo o path onde vamos ler o arquivo, que possui as informações necessárias, poderiamos passar o caminho direto como parametro
            string path = @"G:\Curso de C#\Projetos\Modulo17\employee.csv";

            //Criando uma lista de strings que vão armazenar o que for lido nesse arquivo.
            string[] arrayList = File.ReadAllLines(path);

            //percorrendo a lista de string, separando os valores com variaveis para adicionarmos na lista de funcionários
            foreach (var item in arrayList)
            {
                string[] separado = item.Split(",");
                string name = separado[0];
                string email = separado[1];
                double salary = double.Parse(separado[2], CultureInfo.InvariantCulture);

                Employess.Add(new Employee(name, email, salary));
            }
            double valor = 2000;
            //Query que retorna o email (ordenado) dos funcionário cujo salário for maior que o informado
            var query1 = Employess.Where(e => e.Salary > valor).OrderBy(e => e.Email).Select(e => e.Email);

            Print($"Email of people whose salary is more than {valor.ToString("F2", CultureInfo.InvariantCulture)}", query1);

            //Query que retorna a soma de todos os funcionários que começam com a letra M
            var query2 = Employess.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);

            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + query2.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
