namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        // Construtor
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        //Se a placa estiver no formato adequado retorna true se não retorna false
        private bool VerificaPlaca(string placa)
        {
            string[] placaArray = placa.Split("-");         
            if((placaArray[0].All(c => Char.IsLetter(c)) && placaArray[0].Length == 3) && (placaArray[1].All(c => Char.IsNumber(c)) && placaArray[1].Length == 4))
            {
                return true;
            }
            return false;
        }

        //Se o veiculo já estiver no estacionamento retorna true se não retorna false
        private bool VerificaVeiculo(string placa)
        {
            if(veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                return true;
            }
            return false;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if(VerificaPlaca(placa))
            {
                //Verificar se o veiculo já esta no estacionamento
                if(VerificaVeiculo(placa))
                {
                    Console.WriteLine("Não foi possível adicionar veículo. Veículo já existente.");
                }
                else
                {
                    this.veiculos.Add(placa.ToLower());
                    Console.WriteLine("Veículo Adicionado");
                }     
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar veículo. Entrada Inválida.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                //
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horasEstacionado;
                int.TryParse(Console.ReadLine(),out horasEstacionado);

                decimal valorTotal = precoInicial + precoPorHora * horasEstacionado; 

                this.veiculos.Remove(placa.ToLower());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
            }
        public void ListarVeiculos()
        {
            
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo.ToUpper());
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
