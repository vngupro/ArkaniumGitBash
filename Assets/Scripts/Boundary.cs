using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{

    [SerializeField] private float boxThickness = 1.0f;
    private float camHeight;                                    //camera view height
    private float camWidth;                                     //camera view width

    BoxCollider2D wallRightBox, wallLeftBox, wallUpBox, wallDownBox;
    void Awake()
    {
        wallRightBox = GameObject.Find("WallRight").GetComponent<BoxCollider2D>();
        wallLeftBox = GameObject.Find("WallLeft").GetComponent<BoxCollider2D>();
        wallUpBox = GameObject.Find("WallUp").GetComponent<BoxCollider2D>();
        wallDownBox = GameObject.Find("WallDown (Death)").GetComponent<BoxCollider2D>();

        camHeight = 2 * Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        wallRightBox.size = new Vector2(boxThickness, camHeight + boxThickness * 2);
        wallLeftBox.size = wallRightBox.size;
        wallUpBox.size = new Vector2(camWidth + boxThickness * 2, boxThickness);
        wallDownBox.size = wallUpBox.size;

        wallRightBox.transform.position = new Vector2( (-boxThickness - camWidth) / 2.0f, 0);
        wallLeftBox.transform.position = -wallRightBox.transform.position; 
        wallDownBox.transform.position = new Vector2(0, (-boxThickness - camHeight) / 2.0f);
        wallUpBox.transform.position = -wallDownBox.transform.position;

    }
}
