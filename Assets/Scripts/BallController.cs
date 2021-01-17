using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BallController : MonoBehaviour
{
    [SerializeField] PaddleController player1;                  //player ref
    [SerializeField] private float ballSpeed = 1.0f;            //speed factor
    [SerializeField] private float xPush = 2f;                  //x velocity
    [SerializeField] private float yPush = 15f;                 //y velocity
    [SerializeField] AudioClip[] ballSound;                     //sounds list

    private float yOffset;                                      //offset on paddle before launch
    private bool hasStarted = false;                            //if has launch
    private Rigidbody2D ballRigidBody;                          //ball rigidbody ref
    private AudioSource ballAudioSource;                        //ball audiosource ref

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
            ballRigidBody.velocity = new Vector2(xPush, yPush) * ballSpeed;
            hasStarted = true;
        }
    }

    // LockBallToPaddle : Lock to paddle at start of game until lauch
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(player1.transform.position.x, player1.transform.position.y + yOffset * player1.transform.localScale.y);
        transform.position = paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hasStarted)
        {
            //Sound on collision
            AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
            ballAudioSource.PlayOneShot(clip);

            //Anti stuck ball
            if (Mathf.Abs(ballRigidBody.velocity.x) <= 0.1f)
            {
                ballRigidBody.velocity = new Vector2(xPush, ballRigidBody.velocity.y);
            }

            if (Mathf.Abs(ballRigidBody.velocity.y) <= 1.0f)
            {
                ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, yPush);
            }
        }
    }
}
