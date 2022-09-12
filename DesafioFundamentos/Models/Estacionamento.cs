namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        /// <summary>
        /// Adiciona um veículo no estacionamento
        /// </summary>
        public void AdicionarVeiculo()
        {
            // Solicitar placa
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            
            // Ler placa
            string placa = Console.ReadLine();

            // Se o veículo não existir...
            if (!this.veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
            {
                // Instanciar novo veículo
                Veiculo veiculo = new Veiculo(placa);

                // Adicionar o veículo no estacionamento
                this.veiculos.Add(veiculo);
                //this.veiculos.Add(new Veiculo(placa));

                // Avisar que adicionou com sucesso.
                Console.WriteLine($"Veículo de placa {placa} adicionado no estacionamento.");
            } else {
                Console.WriteLine($"Ops... Já existe um veículo de placa {placa} estacionado aqui.");
            }
            
        }

        /// <summary>
        /// Remove um veículo do estacionamento
        /// </summary>
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Lê a placa
            string placa = Console.ReadLine();

            // Busca o veículo e retorna na variável veiculo.
            Veiculo veiculo = this.veiculos.Find(x => x.Placa.ToUpper() == placa.ToUpper());

            // Verifica se o veículo existe, no caso não estará como nulo.
            if (veiculo != null)
            {
                int horas = 0;
                decimal valorTotal = 0;

                // Hora de saída.
                // TODO: calcular automaticamente o tempo.
                veiculo.Saida = DateTime.Now;
                
                // TODO
                /*
                TimeSpan tempo = veiculo.Saida.Subtract(veiculo.Entrada);
                horas = tempo.Hours;
                // Cobrar hora cheia.
                if (tempo.Minutes > 0){
                    // Adicionar mais uma hora se já passaram minuto(s)
                    horas += 1;
                }
                */

                // Pedir para o usuário quantas horas ficou estacionado.
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                horas = int.Parse(Console.ReadLine());
                //int.TryParse(Console.ReadLine(), out horas);

                // "precoInicial + precoPorHora * horas"
                valorTotal = this.precoInicial + (this.precoPorHora * horas);

                // Arredondaro o valor para 2 casas decimais (dinheiro, reais, R$).
                valorTotal = Math.Round(valorTotal, 2);

                // Remover o veiculo da lista
                this.veiculos.Remove(veiculo);

                Console.WriteLine($"O veículo {veiculo.Placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        /// <summary>
        /// Lista todos veículos estacionados, se houver algum.
        /// </summary>
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (this.veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                // Repetição para exibir os veículos estacionados.
                foreach (Veiculo veiculo in this.veiculos)
                {
                    Console.WriteLine($" {veiculo.Placa} (Entrada: {veiculo.Entrada})");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
