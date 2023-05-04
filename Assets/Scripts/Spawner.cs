using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject rocket;
    private float nextRocket = 0.5f;
    private float myTime = 0.0f;
    private float rocketDelta = 0.5f;
    
    void Start()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        myTime = myTime + Time.deltaTime;
        if(Input.GetButton("Fire1") && myTime > nextRocket)
        {
            nextRocket = myTime + rocketDelta;
            Spawn();
            nextRocket = nextRocket - myTime;
            myTime = 0.0f;
        }
    }

    void FixedUpdate()
    {
        
    }
    void Spawn()
    {

        float xPos = player.transform.position.x;
        float yPos = player.transform.position.y;

        Vector2 position = new Vector2(xPos, yPos);
        Instantiate(rocket, position, Quaternion.identity);

    }
}
