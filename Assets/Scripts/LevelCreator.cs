using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] Level level;
    private float camHeight;                                    //camera view height
    private float camWidth;                                     //camera view width
    private float brickHeight;
    private float brickWidth;
    private int numberOfLines = 5;
    private int numberOfBricksPerLine = 17;
    void Awake()
    {
        camHeight = 2 * Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
        brickHeight = level.brickPrefabsList[0].GetComponent<BoxCollider2D>().size.y;
        brickWidth = level.brickPrefabsList[0].GetComponent<BoxCollider2D>().size.x;

        numberOfLines = Random.Range(1, 15);
        //numebrOfBricksPerLine = Random.Range(10, 17);

        for (int i = 1; i <= numberOfLines; i++)
        {
            for (int j = 1; j <= numberOfBricksPerLine; j++)
            {
                int index = Random.Range(0, level.brickPrefabsList.Count);
                Instantiate(level.brickPrefabsList[index], new Vector3(-camWidth / 2 + brickWidth * j, (camHeight - brickHeight) / 2 - brickHeight * i, 0), transform.rotation);
            }
        }
        //for (int i = 1; i <= level.numberOfLines; i++)
        //{
        //    for(int j = 1; j <= level.numberOfBricksPerLines; j++)
        //    {
        //        int index = Random.Range(0, level.brickPrefabsList.Count);
        //        Instantiate(level.brickPrefabsList[index], new Vector3(-camWidth / 2 + brickWidth * j, (camHeight - brickHeight) / 2 - brickHeight * i, 0), transform.rotation);
        //    }
        //}
    }
}
