using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject player1;                //player1 ref
    [SerializeField] float xPush = 2f;                  //x direction
    [SerializeField] float yPush = 15f;                 //y direction
    [SerializeField] AudioClip[] ballSound;             //sound

    float yOffset;                                      //offset on paddle before launch
    bool hasStarted = false;                            //if has launch
    Rigidbody2D ballRigidBody;                          //ball rigidbody ref
    AudioSource ballAudioSource;                        //ball audiosource ref

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballAudioSource = GetComponent<AudioSource>();
        yOffset = player1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LauchOnMouseClick();
        }
    }

    // LauchOnMouseClick : On mouse left click lauch the ball once
    private void LauchOnMouseClick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballRigidBody.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    // LockBallToPaddle : Lock to paddle at start of game until lauch
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(player1.transform.position.x, player1.transform.position.y + yOffset);
        transform.position = paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Make sound on collision
        if (hasStarted)
        {
            AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
            ballAudioSource.PlayOneShot(clip);
        }
    }
}
