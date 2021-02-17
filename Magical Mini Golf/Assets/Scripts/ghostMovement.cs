using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float waitTime = 3f;
    float currentWaitTime = 0f;

    float minX, maxX, minZ, maxZ;
    Vector3 moveSpot;
    
    void Start()
    {
        GetGroundSize();
        moveSpot = GetNewPosition();
    }

  
    void Update()
    {
        WatchYourStep();
        GetToStepping();
        moveSpot = GetNewPosition();
    }

    private void GetGroundSize()
    {
        GameObject ground = GameObject.FindWithTag("Ground");
        Renderer groundSize = ground.GetComponent<Renderer>();
        minX = (groundSize.bounds.center.x - groundSize.bounds.extents.x);
        maxX = (groundSize.bounds.center.x + groundSize.bounds.extents.x);
        minZ = (groundSize.bounds.center.z - groundSize.bounds.extents.z);
        maxZ = (groundSize.bounds.center.z + groundSize.bounds.extents.z);
    }

    Vector3 GetNewPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 newPosition = new Vector3(randomX, transform.position.y, randomZ);
        return newPosition;
    }

    void GetToStepping()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveSpot)<= 0.2f)
        {
            
            if(currentWaitTime <= 0.1f)
            {
                moveSpot = GetNewPosition();
                currentWaitTime = waitTime;
            }
            else
            {
                currentWaitTime -= Time.deltaTime;
            }
        }
    }
    void WatchYourStep()
    {
        Vector3 targetDirection = moveSpot - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 0.3f, 0.1f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}


