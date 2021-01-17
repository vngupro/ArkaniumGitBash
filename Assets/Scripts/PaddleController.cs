using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;                //speed factor
    [SerializeField] private int playerNumber = 1;              //player number
    [SerializeField] private float xOffset = 1.0f;              //distance between players

    private GameStatus theGameSession;                          //game status
    private BallController theBall;                             //ball ref
    private Vector2 currentPos;                                 //current position of paddle

    private KeyCode inputPlayerR;                               //Keyboard control right
    private KeyCode inputPlayerL;                               //Keyboard control left
    
    private float xMin;                                         //paddle limit on left (passing by collider is not that good, shake effect on constant collision)
    private float xMax;                                         //paddle limit on right
    private float camHeight;                                    //camera view height
    private float camWidth;                                     //camera view width
    private float playerHeight;                                 //player height
    private float playerWidth;                                  //player width
    private bool autoPlay = false;

    private void Awake()
    {
        GameEvent.autoPlay.AddListener(ActivateAutoPlay);
    }
    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<BallController>();
        playerHeight = GetComponent<BoxCollider2D>().size.y / 2;
        playerWidth = GetComponent<BoxCollider2D>().size.x / 2;

        camHeight = 2 * Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
        xMax = camWidth / 2;
        xMin = -xMax;

        switch (playerNumber)
        {
            case 1:
                inputPlayerL = KeyCode.A;
                inputPlayerR = KeyCode.D;
                transform.position = new Vector3(-(playerWidth + xOffset),(-camHeight + playerHeight) / 2, 0);
                Debug.Log("Okay Player 1");
                break; 
            case 2:
                inputPlayerR = KeyCode.RightArrow;
                inputPlayerL = KeyCode.LeftArrow;
                transform.position = new Vector3(playerWidth + xOffset, (-camHeight + playerHeight) /2, 0);
                Debug.Log("Okay Player 2");
                break;
            default:
                inputPlayerL = KeyCode.A;
                inputPlayerR = KeyCode.D;
                transform.position = new Vector3(-(playerWidth + xOffset), (-camHeight + playerHeight) / 2, 0);
                Debug.Log("Okay Default");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;

        if (Input.GetKey(inputPlayerR) && transform.position.x < xMax)
        {
            transform.position = new Vector2(currentPos.x + 0.1f * speed, currentPos.y);
        }
        else if (Input.GetKey(inputPlayerL) && transform.position.x > xMin)
        {
            transform.position = new Vector2(currentPos.x - 0.1f * speed, currentPos.y);
        }

        if (autoPlay)
        {
            transform.position = new Vector3(theBall.transform.position.x, transform.position.y, transform.position.z);
        }
            
    }

    private void ActivateAutoPlay()
    {
        autoPlay = true;
    }
}
