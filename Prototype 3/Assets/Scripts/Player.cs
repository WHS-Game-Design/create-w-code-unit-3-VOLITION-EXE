using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float move = 2;
    public float sideChangetime;
    public Rigidbody playerRb;
    public float JumpForce;
    public float gravityForce;
    private Vector3 currentSide;
    public bool Grounded;
    private Animator playeran;
    public Vector3 startPos;
    public float sideLength;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityForce;
        playeran = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Grounded){
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            playeran.SetTrigger("Jump_trig");
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x != startPos - sideLength){
            transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + sideLength);
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x != startPos + sideLength){
            transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - sideLength)
        }
        //make a simple free fall animation after the jump animation and transition it back into running when landing
        void OnCollisionEnter(Collision col) {
            if(col.gameObject.CompareTag("ground")){
            Grounded = true;
            }
        }
        void OnCollisionExit(Collision col) {
            if(col.gameObject.CompareTag("ground")){
            Grounded = false;
            }
        }

        /*switch (move){
            case 1:
            transform.position = new Vector3 (-35, 0, Mathf.Lerp(currentSide.z, -66, sideChangetime * Time.deltaTime));
            currentSide.z = -66f;
            break;
            case 2:
            transform.position = new Vector3 (-35, 0, Mathf.Lerp(currentSide.z, -60, sideChangetime * Time.deltaTime));
            currentSide.z = -60f;
            break;
            case 3:
            transform.position = new Vector3 (-35, 0, Mathf.Lerp(currentSide.z, -54, sideChangetime * Time.deltaTime));
            currentSide.z = -54f;
            break;
        }
        */
        
        /*if (move == 2){
            transform.position = new Vector3 (-35, 0, Mathf.Lerp(currentSide.z, -60, sideChangetime * Time.deltaTime));
            currentSide.z = -60f;
        } else if (move == 1){
            transform.position = new Vector3 (-35, 0, Mathf.Lerp(currentSide.z, -66, sideChangetime * Time.deltaTime));
            currentSide.z = -66f;
        } else {
            transform.position = new Vector3 (-35, 0, Mathf.Lerp(currentSide.z, -54, sideChangetime * Time.deltaTime));
            currentSide.z = -54f;
        }
        transform.position = Vector3.Lerp(sides, ) */
    }
}
