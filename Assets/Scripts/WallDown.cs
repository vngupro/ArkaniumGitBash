using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallDown : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D loseCollision)
    {
        SceneManager.LoadScene(0);
    }
}
