using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Component
{
    private static T _inst;
    void Awake()
    {
        if (_inst)
            Destroy(_inst);
        else
        {
            _inst = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static T Instance
    {
        get
        {
            if (!_inst)
            {
                _inst = FindAnyObjectByType<T>();
                if (!_inst)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _inst = obj.AddComponent<T>();
                }
            }
            return _inst;
        }
    }
}
