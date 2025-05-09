using System;
using System.Collections.Generic;

namespace PetVirtual.Models
{
    public enum EstadoDeSaude { Saudavel, Doente }

    public class Pet
    {
        public string Nome { get; private set; }
        public int Energia { get; set; }
        public int Fome { get; set; }
        public int Felicidade { get; set; }
        public int Idade { get; set; }
        public bool Vivo { get; set; }
        public EstadoDeSaude EstadoSaude { get; set; }

        public int Nivel { get; set; }
        public int Experiencia { get; set; }
        public List<string> Conquistas { get; set; }

        public Pet(string nome)
        {
            Nome = nome;
            Energia = 100;
            Fome = 0;
            Felicidade = 100;
            Idade = 0;
            Vivo = true;
            EstadoSaude = EstadoDeSaude.Saudavel;

            Nivel = 1;
            Experiencia = 0;
            Conquistas = new List<string>();
        }

        public void MostrarStatus()
        {
            Console.WriteLine($"\n📊 Status de {Nome}");
            Console.WriteLine($"Idade: {Idade} | Energia: {Energia} | Fome: {Fome} | Felicidade: {Felicidade}");
            Console.WriteLine($"Saúde: {EstadoSaude} | Nível: {Nivel} | XP: {Experiencia}");
            Console.WriteLine("🏆 Conquistas:");
            if (Conquistas.Count == 0) Console.WriteLine("Nenhuma conquista ainda.");
            foreach (var c in Conquistas)
                Console.WriteLine($"- {c}");
        }
    }
}
