using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5;
    public GameObject playerShot;

    void OnEnable()
    {
        EventManager.OnDead += Destroy;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Provide bullet with velocity and destroy at screen border
        this.transform.position += Vector3.up * Time.deltaTime * speed;
        if(this.transform.position.y >= 6.5)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Destroy(playerShot);
    }
}
