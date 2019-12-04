using System;

namespace testeFinal
{
    class CaixaEletronico
    {
        // Parametros
        private decimal _notasCinquentaReais { get; set; }
        private decimal _notasVinteReais { get; set; }
        private decimal _notasDezReais { get; set; }
        private decimal _notasCincoReais { get; set; }
        private decimal _notasDoisReais { get; set; }

        // Construtor
        public CaixaEletronico(decimal notasCinquentaReais, decimal notasVinteReais, decimal notasDezReais, decimal notasCincoReais, decimal notasDoisReais)
        {
            _notasCinquentaReais = notasCinquentaReais;
            _notasVinteReais = notasVinteReais;
            _notasDezReais = notasDezReais;
            _notasCincoReais = notasCincoReais;
            _notasDezReais = notasDoisReais;
        }

        // Metodos
        // Repoem as notas somando com as que já existem no caixa eletrônico
        public void ReporNotas(decimal notasCinquentaReais, decimal notasVinteReais, decimal notasDezReais, decimal notasCincoReais, decimal notasDoisReais)
        {
            _notasCinquentaReais += notasCinquentaReais;
            _notasVinteReais += notasVinteReais;
            _notasDezReais += notasDezReais;
            _notasCincoReais += notasCincoReais;
            _notasDoisReais += notasDoisReais;
        }//public void ReporNotas(decimal notasCinquentaReais, decimal notasVinteReais, decimal notasDezReais, decimal notasCincoReais, decimal notasDoisReais)

        public string ConsultarQuantidadesNotas()
        {
            string quantidadeNotas = $"Valor total disponível é de {CalcularTotalDisponivel()} Reais";

            if (_notasCinquentaReais != 0)
                quantidadeNotas += $"\n50 - {_notasCinquentaReais} cédula(s) disponívei(s)";

            if (_notasVinteReais != 0)
                quantidadeNotas += $"\n20 - {_notasVinteReais} cédula(s) disponívei(s)";

            if (_notasDezReais != 0)
                quantidadeNotas += $"\n10 - {_notasDezReais} cédula(s) disponívei(s)";

            if (_notasVinteReais != 0)
                quantidadeNotas += $"\n5 - {_notasCincoReais} cédula(s) disponívei(s)";

            if (_notasDoisReais != 0)
                quantidadeNotas += $"\n2 - {_notasDoisReais} cédula(s) disponívei(s)";

            return quantidadeNotas;
        } // public string ConsultarQuantidadesNotas()
        public decimal CalcularTotalDisponivel()
        {
            decimal totalDinheiro = _notasDoisReais * 2;
            totalDinheiro += _notasDezReais * 10;
            totalDinheiro += _notasDezReais * 10;
            totalDinheiro += _notasVinteReais * 20;
            totalDinheiro += _notasCinquentaReais * 50;

            return totalDinheiro;
        }//public decimal CalcularTotalDisponivel()
        public bool VerificarNotaDisponivel(decimal nota)
        {
            switch (nota)
            {
                case 50:
                    return _notasCinquentaReais > 0;
                case 20:
                    return _notasVinteReais > 0;
                case 10:
                    return _notasDezReais > 0;
                case 5:
                    return _notasCincoReais > 0;
                case 2:
                    return _notasDoisReais > 0;
                default:
                    return false;
            }
        }//public bool VerificarNotaDisponivel(decimal nota)

        // REFATORAR FUTURAMENTE
        public decimal[] SacarNotas(int valorDesejado)
        {
            int aux = 0;
            decimal[] notas = new decimal[]{0, 0, 0, 0, 0};
            while (valorDesejado > 0)
            {
                if (valorDesejado >= 50)
                {
                    aux = (valorDesejado / 50);
                    _notasCinquentaReais -= aux;
                    notas[0] = aux;
                    valorDesejado -= aux * 50;
                }
                else if (valorDesejado >= 20)
                {
                    aux = (valorDesejado / 20);
                    _notasVinteReais -= aux;
                    notas[1] = aux;
                    valorDesejado -= aux * 20;
                }
                else if (valorDesejado >= 10)
                {
                    aux = (valorDesejado / 10);
                    _notasDezReais -= aux;
                    notas[2] = aux;
                    valorDesejado -= aux * 10;
                }
                else if (valorDesejado >= 5)
                {
                    aux = (valorDesejado / 5);
                    _notasCincoReais -= aux;
                    notas[3] = aux;
                    valorDesejado -= aux * 5;
                }
                else if (valorDesejado >= 2)
                {
                    aux = (valorDesejado / 2);
                    _notasDoisReais -= aux;
                    notas[4] = aux;
                    valorDesejado -= aux * 2;
                }
            }
            return notas;
        }//public decimal[] SacarNotas(int valorDesejado)

    }
}