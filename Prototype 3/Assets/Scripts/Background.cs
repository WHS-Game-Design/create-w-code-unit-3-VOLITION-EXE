using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Vector3 Bacground;
    public float repeatwidth;
    // Start is called before the first frame update
    void Start()
    {
        Bacground = transform.position;
        repeatwidth = GetComponent<BoxCollider>().size.x/2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < Bacground.x - repeatwidth){
            transform.position = Bacground;
        }
    }
}
