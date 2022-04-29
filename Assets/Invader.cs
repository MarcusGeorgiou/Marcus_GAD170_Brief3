using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    bool canMove = true;
    float moveSpeed = 1f;
    float moveDelay = 1f;

    GameManager myManager;

    public GameObject bulletPrefab;
    bool canShoot = false;
    float shoot;
    bool dontShoot = false;

    int killed = 0;

    void OnEnable()
    {
        EventManager.OnChange += ReachedEnd;

        EventManager.ShowScore += Death;

        EventManager.OnDeath += PlayerDead;
    }

    void OnDisable()
    {
        EventManager.OnChange -= ReachedEnd;

        EventManager.ShowScore -= Death;

        EventManager.OnDeath -= PlayerDead;
    }

    // Start is called before the first frame update
    void Start()
    {
        myManager = GameObject.FindObjectOfType<GameManager>();

        StartCoroutine(ShotTimer(2f));
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

            if(this.transform.position.x > 14f || this.transform.position.x < -14f)
            {
                //Call to GameManager to chnge direction
                myManager.ChangeDirection();
            }

            if(dontShoot == false)
            {
                shoot = Random.Range(0, 1500);
                if (canShoot && shoot == 2)
                {
                    canShoot = false;
                    Instantiate(bulletPrefab, transform.position, transform.rotation);

                    StartCoroutine(ShotTimer(Random.Range(1f, 15f)));
                }
            }

            if(killed == 55)
            {
                EventManager.RunGameEnd();
            }
    }

    void Death()
    {
        // Kill the invader
        print("Invader Killed");
        Destroy(this.gameObject);
        KillCount();
    }

    void PlayerDead()
    {
        moveSpeed = 0f;
        dontShoot = true;
        StartCoroutine(DeathTimer(4f));
    }

    void ReachedEnd()
    {
        // Move invader down, change direction and decrease movement delay
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z);
        moveSpeed *= -1f;
        moveDelay *= 0.9f;
    }

    void KillCount()
    {
        killed++;
    }

    // Collision tests
    void OnCollisionEnter2D(Collision2D collisionData)
    {
        // Only continue if colliding with a player bullet
        if(collisionData.gameObject.GetComponent<PlayerBullet>() != null)
        {
            Death();
            EventManager.RunScore();
        }
    }

    IEnumerator MoveTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    IEnumerator ShotTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    IEnumerator DeathTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeed = 1f;
        dontShoot = false;
    }
}
