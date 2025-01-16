using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player :LazyLoadManager<Player>
{
    public int health = 100;
    public static int score = 0;
    //observer design pattern
    public static event Action<float> OnTakeDamage;
    public static event Action<int> OnGetCoin;
    private PoolManager poolManager;
    private void Awake() {
        poolManager = GameObject.Find("PoolManager").GetComponent<PoolManager>();
    }
    public void TakeDamage(int damage){
        if (health-damage > 0) health -= damage;
        else {
            health = 0;
            PlayerMovement.Get().Speed = 0;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,3,-1)*100);
        }
        OnTakeDamage?.Invoke(health);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Column")){
            TakeDamage(health);
            // Camera_Control.Get().Speed *= 2;
            // StartCoroutine(nameof(Wait));
        }
        else if(other.gameObject.CompareTag("ChainBall")){
            TakeDamage(10);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Coin")
        {
            score++;
            poolManager.ReturnToPull(other.gameObject);
            OnGetCoin?.Invoke(score);
        }
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(3f);
        PlayerMovement.Get().Speed/=2;
    }
}
