using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    bool canMove = true;
    public float moveSpeed = 1f;

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
        if(canMove)
        {
            this.transform.position += Vector3.right * moveSpeed;
            canMove = false;

            MoveTimer(1f);
        }
    }

    void Death()
    {
        // Kill the invader
        print("Invader Killed");
        Destroy(this.gameObject);
    }

    // Collision tests
    void OnCollisionEnter2D(Collision2D collisionData)
    {
        // Only continue if colliding with a player bullet
        if(collisionData.gameObject.GetComponent<PlayerBullet>() != null)
        {
            Death();
        }
    }

    IEnumerator MoveTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}
