using UnityEngine;

namespace Adapter
{
    public class ClientAdapter: MonoBehaviour
    {
        public InventoryItem item;
        private InventorySystem inventorySystem;
        private IInventorySystem inventorySystemAdapter;

        void Start()
        {
            inventorySystem = new InventorySystem();
            inventorySystemAdapter = new InventorySystemAdapter();
        }
        void OnGUI()
        {
            if (GUILayout.Button("Add item (no Adapter)"))
                inventorySystem.AddItem(item);
            if (GUILayout.Button("Add Item (with Adapter)"))
                inventorySystemAdapter.AddItem(item, SaveLocation.Both);
        }
    }
}