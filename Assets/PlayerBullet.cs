using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5;

    void OnEnable()
    {
        
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
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    // Collision tests
    void OnCollisionEnter2D(Collision2D collisionData)
    {
        // Only continue if colliding with an invader
        if(collisionData.gameObject.GetComponent<Invader>() != null)
        {
            DestroyBullet();
        }
    }
}
