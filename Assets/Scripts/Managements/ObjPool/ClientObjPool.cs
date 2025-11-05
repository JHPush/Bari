using UnityEngine;

namespace ObjPool
{
    public class ClientObjPool : MonoBehaviour
    {
        private DroneObjectPool pool;

        void Start()
        {
            pool = gameObject.AddComponent<DroneObjectPool>();
        }
        void OnGUI()
        {
            if(GUILayout.Button("Spawn Drones"))
            pool.Spawn();
        }
    }
    
}