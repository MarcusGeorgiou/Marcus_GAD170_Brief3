using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Player presses space, shoot bullet and play sound
    public delegate void PlayerShot();
    public static event PlayerShot OnSpace;

    public static void RunSpace()
    {
        print("Shot Fired");
        OnSpace();
    }

    // When player is shot, momentarily pause invaders
    // Reduce lives by one
    // Play death animation
    // Spawn new player ship
}
