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

    // OnEnable is called before any other initiating functions
    void OnEnable()
    {
        EventManager.OnSpace += Firing;
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

        if(canShoot == true)
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

    // Delay player shooting to only occur at least once every second
    IEnumerator BulletTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}
