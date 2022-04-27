using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    bool canMove = true;
    float moveSpeed = 1f;
    float moveDelay = 1f;

    GameManager myManager;

    void OnEnable()
    {
        EventManager.OnChange += ReachedEnd;
    }

    void OnDisable()
    {
        EventManager.OnChange -= ReachedEnd;
    }

    // Start is called before the first frame update
    void Start()
    {
        myManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            this.transform.position += Vector3.right * moveSpeed;
            canMove = false;

            StartCoroutine(MoveTimer(moveDelay));
        }

        if (this.transform.position.x > 14f || this.transform.position.x < -14f)
        {
            //Call to GameManager to chnge direction
            myManager.ChangeDirection();
        }
    }

    void Death()
    {
        // Kill the invader
        print("Invader Killed");
        Destroy(this.gameObject);
    }

    void ReachedEnd()
    {
        // Move invader down, change direction and decrease movement delay
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z);
        moveSpeed *= -1f;
        moveDelay *= 0.9f;
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
