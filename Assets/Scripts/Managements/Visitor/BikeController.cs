using System.Collections.Generic;
using UnityEngine;

namespace Visitor
{
    public class BikeController : MonoBehaviour, IBikeElement
    {
        private List<IBikeElement> bikeElements = new List<IBikeElement>();

        void Start()
        {
            bikeElements.Add(gameObject.AddComponent<BikeShield>());
            bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
            bikeElements.Add(gameObject.AddComponent<BikeEngine>());
        }

        public void Accept(IVIsitor visitor)
        {
            foreach (IBikeElement ele in bikeElements)
                ele.Accept(visitor);
        }
    }
}