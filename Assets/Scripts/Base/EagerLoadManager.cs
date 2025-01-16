using UnityEngine;

public class EagerLoadManager<AnyClass> : MonoBehaviour where AnyClass : MonoBehaviour
{
    private AnyClass _instance;
    public AnyClass Instance => _instance;

    public void Awake()
    {
        _instance = FindObjectOfType<AnyClass>();
    }
}
