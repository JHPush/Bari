using System.Security.Cryptography;
using UnityEngine;

namespace Visitor
{
    [CreateAssetMenu(fileName ="PowerUp",menuName ="PowerUp")]
    public class PowerUp : ScriptableObject, IVIsitor
    {
        public string powerUpName;
        public GameObject powerUpPrefab;
        public string powerUpDescription;

        [Tooltip("Fully heal shield")]
        public bool healthShield;

        [Range(0f, 50f)]
        [Tooltip("Boost turbo settings up to increments of 50/mph")]
        public float turboBoost;

        [Range(0f, 25f)]
        [Tooltip("Boost Weapon range in increments of up to 25units")]
        public int weaponRange;

        [Range(0f, 50f)]
        [Tooltip("Boost weapon strength in increments of up to 50%")]
        public float weaponStrength;

        public void Visit(BikeShield bikeShield)
        {
            if (healthShield) bikeShield.health = 100f;
        }

        public void Visit(BikeWeapon bikeWeapon)
        {
            int range = bikeWeapon.range += weaponRange;
            if (range >= bikeWeapon.maxRange)
                bikeWeapon.range = bikeWeapon.maxRange;
            else
                bikeWeapon.range = range;

            float strength = bikeWeapon.strength += Mathf.Round(bikeWeapon.strength * weaponStrength / 100);

            if (strength >= bikeWeapon.maxStrength)
                bikeWeapon.strength = bikeWeapon.maxStrength;
            else bikeWeapon.strength = strength;
        }
        public void Visit(BikeEngine bikeEngine)
        {
            float boost = bikeEngine.turboBoost += turboBoost;
            if (boost < 0f) bikeEngine.turboBoost = 0f;
            if (boost >= bikeEngine.maxTurboBoost)
                bikeEngine.turboBoost = bikeEngine.maxTurboBoost;
        }
    }
}