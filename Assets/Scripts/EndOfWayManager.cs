using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfWayManager : MonoBehaviour
{
    private void Update() {
        if (Player.Get().transform.position.z > transform.position.z - 17) gameObject.SetActive(false);
    }
}
