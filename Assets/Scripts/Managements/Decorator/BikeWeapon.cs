using System.Collections;
using UnityEngine;


namespace Decorator
{
    public class BikeWeapon : MonoBehaviour
    {
        public WeaponConfig weaponConfig;
        public WeaponAttachment mainAttachment;
        public WeaponAttachment subAttachment;

        private bool isFiring;
        private IWeapon weapon;
        private bool isDecorated;
        void Start()
        {
            weapon = new Weapon(weaponConfig);
        }

        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(5, 50, 150, 100), "Range : " + weapon.Range);
            GUI.Label(new Rect(5, 70, 150, 100), "Strength : " + weapon.Strength);
            GUI.Label(new Rect(5, 90, 150, 100), "Cooldown : " + weapon.Cooldown);
            GUI.Label(new Rect(5, 110, 150, 100), "Firing Rate : " + weapon.Rate);
            GUI.Label(new Rect(5, 130, 150, 100), "Weapon Firing : " + isFiring);

            if (mainAttachment && isDecorated)
                GUI.Label(new Rect(5, 150, 150, 100), "Main Attachment : " + mainAttachment.name);

            if (subAttachment && isDecorated)
                GUI.Label(new Rect(5, 150, 150, 100), "sub Attachment : " + subAttachment.name);
        }

        public void ToggleFire()
        {
            isFiring = !isFiring;
            if (isFiring) StartCoroutine(FireWeapon());
        }
        IEnumerator FireWeapon()
        {
            float firingRate = 1f / weapon.Rate;
            while (isFiring)
            {
                yield return new WaitForSeconds(firingRate);
                Debug.Log("fire");
            }
        }
        public void Reset()
        {
            weapon = new Weapon(weaponConfig);
            isDecorated = !isDecorated;
        }
        public void Decorate()
        {
            if (mainAttachment && !subAttachment)
                weapon = new WeaponDecorator(weapon, mainAttachment);
            if (mainAttachment && subAttachment)
                weapon = new WeaponDecorator(
                    new WeaponDecorator(weapon, mainAttachment)
                    , subAttachment);
            isDecorated = !isDecorated;
        }
    }
    
}