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

    // When invaders reach border, change direction
    public delegate void DirectionChange();
    public static event DirectionChange OnChange;

    public static void RunChange()
    {
        OnChange();
    }

    // When player is shot, momentarily pause invaders
    // Destroy all bullets
    // Reduce lives by one
    // Play death animation
    // Spawn new player ship
    public delegate void PlayerDeath();
    public static event PlayerDeath OnDeath;

    public static void RunDeath()
    {
        print("Player lost a life");
        OnDeath();
    }

    // Invader Dies, add to score
    public delegate void Score();
    public static event Score AddScore;

    public static void RunScore()
    {
        print("Score +10");
        AddScore();
    }

    // Game Over
    public delegate void GameOver();
    public static event GameOver ShowScore;

    public static void RunGameEnd()
    {
        ShowScore();
    }
}
