using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerShot();
    public static event PlayerShot OnSpace;

    public static void RunSpace()
    {
        print("Shot Fired");
        OnSpace();
    }
}
