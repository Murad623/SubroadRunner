using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : LazyLoadManager<Camera_Control>
{
    public float Speed {get
    {
        return _speed;
    }
    set{
        _speed=value;
    }}
    private float _speed = 10.0f;
    void Update()
    {
        // Camera_0_z  Player_0_z
        // -9.76965   -  (-5.6)   =   -4.16965
        if (transform.position.z - Player.Get().transform.position.z < -3.4f)
        {
            transform.position += new Vector3(0,0,1)*_speed*Time.deltaTime;
        }
    }
}
