using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brique : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int ScoreValue;

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
    }
}
