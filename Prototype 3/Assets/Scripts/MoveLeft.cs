using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float objSpeed;
    public PlayerController playerscript;
    // Start is called before the first frame update
    void Start()
    {
        playerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerscript.gameover == false){
            transform.Translate(Vector3.left * Time.deltaTime * objSpeed);
        }
    }
}
