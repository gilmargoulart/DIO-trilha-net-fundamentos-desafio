namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        /// <summary>
        /// Placa do veículo
        /// </summary>
        public string Placa { get; set; }
        
        /// <summary>
        /// Horário de entrada do veículo no estacionamento
        /// </summary>
        public DateTime Entrada { get; set; }
        
        /// <summary>
        /// Horário de saída do veículo no estacionamento
        /// </summary>
        public DateTime Saida { get; set; }

        public Veiculo() {
            this.Placa = String.Empty;
        }

        /// <summary>
        /// Instancia um novo veiculo com a placa e Horário de entrada (DateTime.Now)
        /// </summary>
        /// <param name="placa">Placa do veículo. Ex: ABC-1234, ABC-0I34</param>
        public Veiculo(string placa) {
            this.Placa = placa;
            this.Entrada = DateTime.Now;
        }
    }
}
