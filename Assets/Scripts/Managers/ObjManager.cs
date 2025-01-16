using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    private PoolManager poolManager;
    private void Start() {
        poolManager = GameObject.Find("PoolManager").GetComponent<PoolManager>();
    }
    private void Update() {
        if (Player.Get().transform.position.z-4 > transform.position.z)
        {
            poolManager.ReturnToPull(gameObject);
        }
    }
}
