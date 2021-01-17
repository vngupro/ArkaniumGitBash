using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Level", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject
{
    [Range(1, 15)] public int numberOfLines = 1;
    [Range(1, 17)] public int numberOfBricksPerLines = 15;
    public List<GameObject> brickPrefabsList = new List<GameObject>();
}
