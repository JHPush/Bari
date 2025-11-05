using System.Collections.Generic;
using UnityEngine;

namespace Adapter
{
    public class InventorySystem
    {
        public void AddItem(InventoryItem item)
        {
            Debug.Log("Adding item to the Cloud");
        }
        public void RemoveItem(InventoryItem item)
        {
            Debug.Log("Removing item from the cloud");
        }
        public List<InventoryItem> GetInventory()
        {
            Debug.Log("Returning an inventory list stored in the cloud");
            return new List<InventoryItem>();
        }
    }
}