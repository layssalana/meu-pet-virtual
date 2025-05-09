using PetVirtual.Models;
using System;

namespace PetVirtual.Services
{
    public class PetService
    {
        private Pet _pet;
        private Random _rand = new Random();

        public PetService(Pet pet) => _pet = pet;

        public Pet GetPet() => _pet;

        public void Comer()
        {
            if (!_pet.Vivo) return;

            Console.WriteLine($"{_pet.N
