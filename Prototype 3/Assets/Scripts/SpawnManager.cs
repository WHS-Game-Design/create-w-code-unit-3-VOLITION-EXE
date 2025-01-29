using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 objSpawn = new Vector3(25,0,0);
    private float timer;
    public float spawnRate;
    public PlayerController playerscript;
    // Start is called before the first frame update
    void Start()
    {
        playerscript = GameObject.Find("Player").GetComponent<PlayerController>();
        
        InvokeRepeating("spawn", spawnRate + 1, spawnRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (timer < spawnRate){
            timer += Time.deltaTime;
        } else {
        timer = 0;
        }
        */
    }
    void spawn(){
        if (playerscript.gameover == false){
        Instantiate(obstaclePrefab, objSpawn, obstaclePrefab.transform.rotation);
        }
    }
}
