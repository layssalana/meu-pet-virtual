using PetVirtual.Models;
using System.IO;
using System.Linq;

namespace PetVirtual.Data
{
    public static class PetStorage
    {
        private const string path = "petdata.txt";

        public static void Salvar(Pet pet)
        {
            var linhas = new List<string>
            {
                $"{pet.Nome};{pet.Energia};{pet.Fome};{pet.Felicidade};{pet.Idade};{pet.Nivel};{pet.Experiencia};{pet.Vivo};{pet.Estado}",
                string.Join(",", pet.Conquistas)
            };

            File.WriteAllLines(path, linhas);
        }

        public static Pet Carregar()
        {
            if (!File.Exists(path)) return null;

            string[] linhas = File.ReadAllLines(path);
            string[] dados = linhas[0].Split(';');

            Pet pet = new Pet(dados[0]);
            typeof(Pet).GetProperty("Energia").SetValue(pet, int.Parse(dados[1]));
            typeof(Pet).GetProperty("Fome").SetValue(pet, int.Parse(dados[2]));
            typeof(Pet).GetProperty("Felicidade").SetValue(pet, int.Parse(dados[3]));
            typeof(Pet).GetProperty("Idade").SetValue(pet, int.Parse(dados[4]));
            typeof(Pet).GetProperty("Nivel").SetValue(pet, int.Parse(dados[5]));
            typeof(Pet).GetProperty("Experiencia").SetValue(pet, int.Parse(dados[6]));
            typeof(Pet).GetProperty("Vivo").SetValue(pet, bool.Parse(dados[7]));
            typeof(Pet).GetProperty("Estado").SetValue(pet, Enum.Parse(typeof(EstadoDeSaude), dados[8]));

            if (linhas.Length > 1)
                typeof(Pet).GetProperty("Conquistas").SetValue(pet, linhas[1].Split(',').ToList());

            return pet;
        }
    }
}
