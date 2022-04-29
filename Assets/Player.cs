using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float lowerLimit = -14f;
    private float upperLimit = 14f;
    public float speed;

    public GameObject bulletPrefab;
    private bool canShoot = true;
    private bool isDead = false;
    private bool dontShoot = false;

    // OnEnable is called before any other initiating functions
    void OnEnable()
    {
        EventManager.OnSpace += Firing;

        EventManager.OnDeath += LoseLife;

        EventManager.ShowScore += LoseLife;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Stop player from moving off camera
        float curPos = Mathf.Clamp(this.transform.position.x + Input.GetAxis("Horizontal") * speed, lowerLimit, upperLimit);
        this.transform.position = new
        Vector3(curPos, this.transform.position.y, this.transform.position.z);

        if(canShoot && dontShoot == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canShoot = false;
                EventManager.RunSpace();
            }
        }
    }

    void Firing()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        StartCoroutine(BulletTimer(1f));
    }

    void LoseLife()
    {
        // Kill the player
        isDead = true;
        dontShoot = true;
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;

        StartCoroutine(DeathTimer(4f));
    }

    // Collision tests
    void OnCollisionEnter2D(Collision2D collisionData)
    {
        // Only continue if colliding with an invader bullet
        if (collisionData.gameObject.GetComponent<InvaderBullet>() != null)
        {
            EventManager.RunDeath();
        }
    }

    // Delay player shooting to only occur at least once every second
    IEnumerator BulletTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    IEnumerator DeathTimer(float delay)
    {
        yield return new WaitForSeconds(delay);

        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
        isDead = false;
        dontShoot = false;
    }
}
