using PetVirtual.Models;
using System;

namespace PetVirtual.Services
{
    public class PetService
    {
        private Pet _pet;
        private Random _rand = new Random();

        public PetService(Pet pet)
        {
            _pet = pet;
        }

        public Pet GetPet() => _pet;

        public void Comer()
        {
            if (!_pet.Vivo) return;

            Console.WriteLine($"{_pet.Nome} está comendo...");
            _pet.Energia += 5;
            _pet.Fome -= 30;
            _pet.Felicidade += 2;
            VerificarDoenca("comer");
            VerificarNivel();
            Envelhecer();
        }

        public void Dormir()
        {
            if (!_pet.Vivo) return;

            Console.WriteLine($"{_pet.Nome} foi dormir...");
            _pet.Energia += 30;
            _pet.Fome += 10;
            VerificarNivel();
            Envelhecer();
        }

        public void Brincar()
        {
            if (!_pet.Vivo) return;

            if (_pet.Energia < 20)
            {
                Console.WriteLine($"{_pet.Nome} está cansado demais para brincar!");
                return;
            }

            Console.WriteLine($"{_pet.Nome} está brincando feliz!");
            _pet.Energia -= 20;
            _pet.Fome += 15;
            _pet.Felicidade += 10;

            if (_pet.Felicidade > 100) _pet.Felicidade = 100;

            VerificarDoenca("brincar");
            VerificarNivel();
            Envelhecer();
        }

        public void Curar()
        {
            if (_pet.EstadoSaude == EstadoDeSaude.Saudavel)
            {
                Console.WriteLine($"{_pet.Nome} está saudável e não precisa de cura.");
                return;
            }

            if (_pet.Energia < 10)
            {
                Console.WriteLine("Energia insuficiente para curar. Faça o pet dormir.");
                return;
            }

            _pet.Energia -= 10;
            _pet.EstadoSaude = EstadoDeSaude.Saudavel;
            Console.WriteLine($"🩺 {_pet.Nome} foi ao veterinário e está curado!");
        }

        public void Status()
        {
            _pet.MostrarStatus();
        }

        public bool EstaVivo()
        {
            return _pet.Vivo;
        }

        private void VerificarNivel()
        {
            if (_pet.Felicidade >= 100)
            {
                _pet.Experiencia += 5;
                _pet.Felicidade = 95; // reduz um pouco após ganhar XP

                if (_pet.Experiencia >= 10)
                {
                    _pet.Nivel++;
                    _pet.Experiencia = 0;
                    _pet.Conquistas.Add($"Alcançou nível {_pet.Nivel}!");
                    Console.WriteLine($"🎉 {_pet.Nome} subiu para o nível {_pet.Nivel}!");
                }
            }
        }

        private void VerificarDoenca(string acao)
        {
            if (_pet.EstadoSaude == EstadoDeSaude.Doente) return;

            if (acao == "brincar" && _pet.Energia < 20)
            {
                if (_rand.NextDouble() < 0.3)
                {
                    _pet.EstadoSaude = EstadoDeSaude.Doente;
                    Console.WriteLine($"⚠ {_pet.Nome} ficou doente por brincar cansado!");
                }
            }

            if (acao == "comer" && _pet.Fome < 0)
            {
                if (_rand.NextDouble() < 0.2)
                {
                    _pet.EstadoSaude = EstadoDeSaude.Doente;
                    Console.WriteLine($"⚠ {_pet.Nome} ficou doente por comer demais!");
                }
            }

            if (_pet.EstadoSaude == EstadoDeSaude.Doente)
            {
                _pet.Energia -= 5;
                _pet.Felicidade -= 5;
            }
        }

        private void Envelhecer()
        {
            _pet.Idade++;
            if (_pet.Idade > 30)
            {
                _pet.Vivo = false;
                Console.WriteLine($"💀 {_pet.Nome} morreu de velhice aos {_pet.Idade} anos...");
            }
        }
    }
}
