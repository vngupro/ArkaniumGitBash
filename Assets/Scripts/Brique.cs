using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brique : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int ScoreValue;

    private void Start()
    {
        //Listener : LevelManager
        GameEvent.blockCreate.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            //Listener : GamesStatus & LevelManager
            GameEvent.addScore.Invoke(ScoreValue);
            GameEvent.blockDestroy.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
    }
}