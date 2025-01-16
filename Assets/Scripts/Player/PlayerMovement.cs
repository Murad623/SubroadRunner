using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : LazyLoadManager<PlayerMovement>
{
    public float Speed {get
    {
        return _speed;
    }
    set{
        _speed=value;
    }}
    private float _speed = 10.0f;
    private float _jumpForce = 50.0f, horizontal;
    private bool _onGround;
    private Rigidbody rigidbody;


    private void Awake() {
         rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Physics.Raycast();
        horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal,0,1)*_speed*Time.deltaTime;
        if (horizontal > 0) horizontal = 1;
        else if (horizontal < 0) horizontal = -1;
        transform.position = new Vector3(horizontal*1.5f,transform.position.y,transform.position.z);
        
        if(Input.GetKey(KeyCode.Space) && _onGround)
            rigidbody.AddForce(Vector3.up*_jumpForce);
        if (transform.position.y < 0.5)
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        else
            rigidbody.constraints = RigidbodyConstraints.None;
    }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Ground") _onGround = true;
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Ground") _onGround = false;
    }
    
}
