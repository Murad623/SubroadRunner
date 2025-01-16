using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private int coinPoolSize = 8;
    private int chainBallPoolSize = 3;
    private int columnPoolSize = 2;
    private static float z = 0;
    private float columnZ = 72;
    private float chainBallZ = 36;
    public static int[] xPos = {0,0,0};
    private Queue<GameObject> coinPool;
    private Queue<GameObject> columnPool;
    private Queue<GameObject> chainBallPool;
    [SerializeField] private GameObject coinPref;
    [SerializeField] private GameObject chainBallPref;
    [SerializeField] private GameObject columnPref;
    private void Awake() 
    {
        // Coins -->
        coinPool = new Queue<GameObject>();
        for (int i = 0; i < coinPoolSize; i++)
        {
            GameObject coin = Instantiate(coinPref,Vector3.zero,Quaternion.identity);
            coin.SetActive(false);
            coinPool.Enqueue(coin);
        }
        // ChainBall -->
        chainBallPool = new Queue<GameObject>();
        for (int i = 0; i < chainBallPoolSize; i++)
        {
            GameObject chainBall = Instantiate(chainBallPref,Vector3.zero,Quaternion.identity);
            chainBall.SetActive(false);
            chainBallPool.Enqueue(chainBall);
        }
        // Column -->
        columnPool = new Queue<GameObject>();
        for (int i = 0; i < columnPoolSize; i++)
        {
            GameObject column = Instantiate(columnPref,Vector3.zero,Quaternion.identity);
            column.SetActive(false);
            columnPool.Enqueue(column);
        }
    }
    private GameObject GetFromPool(Queue<GameObject> pool){
        if(pool.Count > 0){
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return null;
    }
    public void ReturnToPull(GameObject obj){
        obj.SetActive(false);
        switch (obj.tag)
        {
            case "Coin":
                coinPool.Enqueue(obj);
                break;
            case "ChainBall":
                chainBallPool.Enqueue(obj);
                break;
            case "Column":
                columnPool.Enqueue(obj);
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        if (chainBallZ <= z)
        {
            GameObject chainBall = GetFromPool(chainBallPool);
            if (chainBall != null) SetPos(chainBall);
            chainBallZ = z+(Random.Range(1,11)*3);
            print($"New ChainBall Z : {chainBallZ}");
        }
        if(columnZ <= z){
            GameObject column = GetFromPool(columnPool);
            if (column != null) SetPos(column);
            columnZ = z+(Random.Range(5,16)*3);
            print($"New Column Z : {columnZ}");
        }
        GameObject coin = GetFromPool(coinPool);
        if (coin != null) 
        {
            SetPos(coin);
            z += 3;
            ResetXPos();
        }
    }
    private void SetPos(GameObject obj){
        float x = 0;
        bool loop = true;
        while(loop){
            x = Random.Range(-1,2)*1.5f;
            switch (x)
            {
                case 1.5f:
                    if (xPos[2] != 1) 
                    {
                        xPos[2] = 1;
                        loop = false;
                    }
                    break;
                case 0:
                    if (xPos[1] != 1)
                    {
                        xPos[1] = 1;
                        loop = false;
                    }
                    break;
                case -1.5f:
                    if (xPos[0] != 1)
                    {
                        xPos[0] = 1;
                        loop = false;
                    }
                    break;
                default:
                    break;
            }
        }
        obj.transform.position = new Vector3(x,obj.tag == "Column" ? 0 : 1,z);
    }
    private void ResetXPos(){
        for (int i = 0; i < xPos.Length; i++) xPos[i] = 0;
    }
}
