using DevOcean.Data.Enums;
using DevOcean.Data.Interfaces;
using System;

namespace DevOcean.Data.Models
{
    public abstract class Spaceship : ISpaceship
    {
        public string PurchaseDate => DateTime.Now.ToString("MM/dd/yyyy");

        public virtual SpaceshipType Type => SpaceshipType.Default;

    }
}
