using UnityEngine;

namespace Visitor
{
    public interface IVIsitor
    {
        void Visit(BikeShield bikeShield);
        void Visit(BikeEngine bikeEngine);
        void Visit(BikeWeapon bikeWeapon);
    }
    public interface IBikeElement
    {
        void Accept(IVIsitor visitor);
    }
}