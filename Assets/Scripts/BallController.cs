using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] PaddleController player1;          //player ref
    [SerializeField] float ballSpeed = 1.0f;            //speed
    [SerializeField] float xPush = 2f;                  //x velocity
    [SerializeField] float yPush = 15f;                 //y velocity
    [SerializeField] AudioClip[] ballSound;             //sound

    [SerializeField] private float yOffset;                                      //offset on paddle before launch
    bool hasStarted = false;                            //if has launch
    Rigidbody2D ballRigidBody;                          //ball rigidbody ref
    AudioSource ballAudioSource;                        //ball audiosource ref

    [Header("DEBUG")]
    [SerializeField] float rbvelocityX;


    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballAudioSource = GetComponent<AudioSource>();
        yOffset = player1.GetComponent<BoxCollider2D>().size.y;
        rbvelocityX = ballRigidBody.velocity.x;
    }

    // Update is called once per frame
    void Update()
    {
        rbvelocityX = ballRigidBody.velocity.x;
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
        //Make sound on collision
        if (hasStarted)
        {
            AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
            ballAudioSource.PlayOneShot(clip);

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
