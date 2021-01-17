using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brique : MonoBehaviour
{
    public int ScoreValue;
    [SerializeField] private int health;
    [SerializeField] private GameObject deathVfx;
    [SerializeField] private Sprite RedSprite, PurpleSprite, BlueSprite, CyanSprite;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        //Listener : LevelManager
        GameEvent.blockCreate.Invoke();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health == 3)
        {
            spriteRenderer.sprite = PurpleSprite;
        }
        else if (health == 2)
        {
            spriteRenderer.sprite = BlueSprite;
        }
        else if (health == 1)
        {
            spriteRenderer.sprite = CyanSprite;
        }
        else if (health == 0)
        {
            //Listener : GamesStatus & LevelManager
            GameEvent.addScore.Invoke(ScoreValue);
            GameEvent.blockDestroy.Invoke();
            Instantiate(deathVfx, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}