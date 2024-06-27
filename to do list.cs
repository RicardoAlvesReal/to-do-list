using System;
using System.Collections.Generic;

class Tarefa
{
    public string Descricao { get; set; }
    public bool Concluida { get; set; }

    public Tarefa(string descricao)
    {
        Descricao = descricao;
        Concluida = false;
    }

    public override string ToString()
    {
        return $"{Descricao} - {(Concluida ? "Concluída" : "Pendente")}";
    }
}

class Program
{
    static List<Tarefa> tarefas = new List<Tarefa>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarTarefa();
                    break;
                case "2":
                    ListarTarefas();
                    break;
                case "3":
                    MarcarTarefaComoConcluida();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarTarefa()
    {
        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();
        tarefas.Add(new Tarefa(descricao));
        Console.WriteLine("Tarefa adicionada com sucesso!");
    }

    static void ListarTarefas()
    {
        Console.WriteLine("Lista de Tarefas:");
        for (int i = 0; i < tarefas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tarefas[i]}");
        }
    }

    static void MarcarTarefaComoConcluida()
    {
        ListarTarefas();
        Console.Write("Digite o número da tarefa a ser marcada como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int numero) && numero > 0 && numero <= tarefas.Count)
        {
            tarefas[numero - 1].Concluida = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Número inválido. Tente novamente.");
        }
    }
}