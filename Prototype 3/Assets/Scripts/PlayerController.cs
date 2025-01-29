using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float JumpForce;
    public float gravityForce;
    public bool Grounded = false;
    public bool gameover = false;
    private Animator playeran;
    public ParticleSystem fivexboom;
    public ParticleSystem dirt;
    public AudioClip crash;
    public AudioClip jump;
    private AudioSource playersound;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityForce;
        playeran = GetComponent<Animator>();
        playersound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Grounded && !gameover){
        playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        playeran.SetTrigger("Jump_trig");
        playersound.PlayOneShot(jump, 1f);
        }
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("ground")){
        Grounded = true;
        dirt.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacles") && !gameover){
        gameover = true;
        Destroy(collision.gameObject);
        Debug.Log("game over");
        playeran.SetBool("Death_b", true);
        playeran.SetInteger("DeathType_int", 1);
        fivexboom.Play();
        dirt.Stop();
        playersound.PlayOneShot(crash, 1f);
        }
    }
    void OnCollisionExit(Collision col) {
        if(col.gameObject.CompareTag("ground")){
        Grounded = false;
        dirt.Stop();
        }
    }
}