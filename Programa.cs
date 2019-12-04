using System;

namespace testeFinal
{
    class Programa : Menu
    {
        CaixaEletronico Caixa;
        int ValorPedidoSaque = 0;
        // Menus
        public int MostraMenuPrincipal()
        {
            Escrever("#######################################");
            Escrever("########   CAIXA ELETRÔNICO   #########");
            Escrever("#######################################");
            Escrever("[0] Sair");
            Escrever("[1] Reposição");
            Escrever("[2] Saque");
            return int.Parse(Ler());
        }// public int MostraMenuPrincipal()

        // Cria menu Saque conforme disponibilidade de dinheiro
        public int MostrarMenuSaque()
        {
            if (TestarSaque().Equals(false))
                return 0;

            Escrever("Notas Disponíveis:");
            Escrever($"{ (Caixa.VerificarNotaDisponivel(50) ? "50$" : "") }\t{(Caixa.VerificarNotaDisponivel(20) ? "20$" : "")}\n"
            + $"{(Caixa.VerificarNotaDisponivel(20) ? "10$" : "")}\t{(Caixa.VerificarNotaDisponivel(10) ? "5$" : "")}");
            Escrever($"{(Caixa.VerificarNotaDisponivel(10) ? "2$" : "")}");
            Escrever($"[0] Cancelar  Operação \t [1] Continuar");

            return int.Parse(Ler());
        }//public int MostrarMenuSaque()
        public int MenuReposicao()
        {
            Escrever("Escolha uma Opção:");
            Escrever("[1] Visualisar Quantidade de Notas");
            Escrever("[2] Repor Notas");
            return int.Parse(Ler());
        }//public int MenuReposicao()

        // Métodos
        public bool TestarSaque()
        {
            if (Caixa.CalcularTotalDisponivel() == 0)
            {
                Escrever("Estamos sem Saque no momento!");
                SegurarTela();
                return false;
            }

            Escrever("Qual a quantidade que deseja sacar?");
            int quantidadeSaque = int.Parse(Ler());
            ValorPedidoSaque = quantidadeSaque;

            if (Caixa.CalcularTotalDisponivel() < ValorPedidoSaque | ValorPedidoSaque.Equals(0))
            {
                LimparTela();
                Escrever("Não é possível sacar a quantidade desejada!");
                SegurarTela();
                return false;
            }
            return true;
        }//public bool TestarSaque()
        public void ReporNotas()
        {
            decimal[] notas = new decimal[5];

            if (MenuReposicao().Equals(1))
            {
                Escrever(Caixa.ConsultarQuantidadesNotas());
            }
            else
            {
                Escrever("Quantas notas de 50$ deseja adicionar?");
                notas[0] = decimal.Parse(Ler());

                Escrever("Quantas notas de 20$ deseja adicionar?");
                notas[1] = decimal.Parse(Ler());

                Escrever("Quantas notas de 10$ deseja adicionar?");
                notas[2] = decimal.Parse(Ler());

                Escrever("Quantas notas de 5$ deseja adicionar?");
                notas[3] = decimal.Parse(Ler());

                Escrever("Quantas notas de 2$ deseja adicionar?");
                notas[4] = decimal.Parse(Ler());

                Caixa.ReporNotas(notas[0], notas[1], notas[2], notas[3], notas[4]);
                Escrever(Caixa.ConsultarQuantidadesNotas());
            }
        }//public void ReporNotas()
        public void FazerSaque()
        {
            switch (MostrarMenuSaque())
            {
                case 0:
                    break;
                case 1:
                    var valores = Caixa.SacarNotas(ValorPedidoSaque);
                    Escrever($"{ (valores[0] > 0 ? "50$ - " + valores[0] + " nota(s)\n" : "") }"
                    + $"{ (valores[1] > 0 ? "20$ - " + valores[1] + " nota(s)\n" : "") }"
                    + $"{ (valores[2] > 0 ? "10$ - " + valores[2] + " nota(s)\n" : "") }"
                    + $"{ (valores[3] > 0 ? "5$ - " + valores[3] + " nota(s)\n" : "") }"
                    + $"{ (valores[4] > 0 ? "2$ - " + valores[4] + " nota(s)\n" : "") }"
                    + $"= {ValorPedidoSaque}");
                    SegurarTela();
                    break;
                default:
                    break;
            }
        }//public void FazerSaque()

        public void Executar()
        {
            // Inicializo o Caixa vazio
            Caixa = new CaixaEletronico(0, 0, 0, 0, 0);

            int variavelControle = -1;
            do
            {
                switch (variavelControle)
                {
                    case 1:
                        ReporNotas();
                        SegurarTela();
                        break;
                    case 2:
                        FazerSaque();
                        break;
                    default:
                        break;
                }
                LimparTela();
                variavelControle = MostraMenuPrincipal();
                LimparTela();

            } while (variavelControle != 0);
        }//public void Executar()

    }
}