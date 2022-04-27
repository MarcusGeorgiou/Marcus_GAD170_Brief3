using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float changeTimer = 0;

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
        if(changeTimer > 0)
        {
            changeTimer -= Time.deltaTime;
        }
    }

    public void ChangeDirection()
    {
        if(changeTimer <= 0)
        {
            EventManager.RunChange();
            print("Direction Changed");

            changeTimer = 2;
        }
    }
}
