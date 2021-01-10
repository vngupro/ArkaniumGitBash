using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class GameEvent
{
    public static UnityEvent blockCreate = new UnityEvent();
    public static UnityEvent blockDestroy = new UnityEvent();
    public static AddScore addScore = new AddScore();
}

public class AddScore : UnityEvent<int> { }
