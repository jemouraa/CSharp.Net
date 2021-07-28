using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            string opUsuario = ObterOpUser();
          Aluno[] alunos = new Aluno[5];
          var indiceAluno = 0;
          

            

            while (opUsuario.ToLower() != "x")
            {
                switch (opUsuario)
                {
                    case "1":
                    Console.WriteLine("Informe o nome do aluno:");
                    Aluno aluno = new Aluno();
                    aluno.Nome = Console.ReadLine();

                    Console.WriteLine("Informe a nota do aluno:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nota)){
                         aluno.Nota = nota;
                    }
                       
                    
                    else{
                        throw new ArgumentException("Valor da nota deve ser deciamal");
                    }
                    alunos[indiceAluno] = aluno;
                    indiceAluno++;

                        break;
                    
                    
                    case "2":
                        foreach(var a in alunos){
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            } 
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for(int i=0; i < alunos.Length; i++){
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        ConceitoE conceitoGeral;

                        if (mediaGeral < 2 ){
                            conceitoGeral = ConceitoE.E;
                        } 
                        else if(mediaGeral < 4 ){
                            conceitoGeral = ConceitoE.D;
                        } 
                         else if(mediaGeral < 6 ){
                            conceitoGeral = ConceitoE.C;
                        }
                         else if(mediaGeral < 8 ){
                            conceitoGeral = ConceitoE.B;
                        }
                        else {
                            conceitoGeral = ConceitoE.A;
                        }

                        Console.WriteLine($"Média Geral: {mediaGeral}");
                        Console.WriteLine($"Conceito: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                    
 
                }

                opUsuario = ObterOpUser();
            }
        }

        private static string ObterOpUser()
        {
            string opUsuario;
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            opUsuario = Console.ReadLine();
            Console.WriteLine();
            return opUsuario;
        }
    }
}
