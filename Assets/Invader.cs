using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public GameObject enemy;

    void OnEnable()
    {
        EventManager.OnDead += Death;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        Destroy(enemy);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EventManager.RunDead();
    }
}
