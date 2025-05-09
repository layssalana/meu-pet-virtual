using PetVirtual.Models;
using PetVirtual.Services;
using PetVirtual.Data;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🐾 PET VIRTUAL 2.0");

        Pet pet = PetStorage.Carregar();
        if (pet == null)
        {
            Console.Write("Digite o nome do novo Pet: ");
            pet = new Pet(Console.ReadLine());
        }

        var service = new PetService(pet);

        int opcao = -1;
        while (opcao != 0 && service.EstaVivo())
        {
            Console.WriteLine("\n[1] Status\n[2] Comer\n[3] Dormir\n[4] Brincar\n[5] Levar ao veterinário\n[0] Sair");
            Console.Write("Escolha: ");
            if (!int.TryParse(Console.ReadLine(), out opcao)) continue;

            switch (opcao)
            {
                case 1: service.Status(); break;
                case 2: service.Comer(); break;
                case 3: service.Dormir(); break;
                case 4: service.Brincar(); break;
                case 5: service.Curar(); break;
                case 0:
                    Console.WriteLine("Salvando...");
                    PetStorage.Salvar(service.GetPet());
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        Console.WriteLine("Jogo encerrado.");
    }
}
