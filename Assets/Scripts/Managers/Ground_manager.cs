using UnityEngine;

public class Ground_manager : MonoBehaviour
{
    private GameObject _front;
    private void Start() {
        string name = (gameObject.name.Split('_'))[1] + "_Front";
        _front = GameObject.Find(name);
    }
    private void Update() {
        if (Player.Get().transform.position.z > transform.position.z + 8)
        {
            transform.position = new Vector3(0,0,transform.position.z + 30);
        }
        if (Player.Get().transform.position.z < transform.position.z - 18) _front.SetActive(true);
    }
}
