using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] int breakableBlocks;

    private void Awake()
    {
        GameEvent.blockCreate.AddListener(CountBreakableBlocks);
    }
    // CountBreakeableBlocks : Count blocks, each block run this function once
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    // BlockDestoyed : decrease number of block to destroy before next level
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            LoadNextScene();
        }
    }

    // LoadNextScene : go to next level when last block is hit 
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
