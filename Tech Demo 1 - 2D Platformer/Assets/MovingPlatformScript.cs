using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{

    [SerializeField] List<Vector3> nodeLocations;
    [SerializeField]List<Rigidbody2D> itemRB;
    [SerializeField] int targetIndex = 0;

    [SerializeField] Vector3 itemPosition;
    [SerializeField] float speed = 1;
    private bool moving = false;

    [SerializeField]LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            MovePlatform();

        }
        //if a an object is colliding with this object. Get it's rigidbody, then add this objects velocity to its
    }
    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, nodeLocations[targetIndex], speed * Time.deltaTime);
        NextNode();
    }

    private void NextNode()
    {
        if (transform.position == nodeLocations[targetIndex])
        {
            if ( targetIndex > nodeLocations.Count)
            {
                targetIndex = 0;
            }
            targetIndex++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != ground )
        {
            collision.transform.parent = transform;
            

        }
        if(collision.transform.tag == "Player")
        {
            itemRB.Add(collision.rigidbody);
            moving = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       

        if (collision.gameObject.layer != ground)
        {
            collision.transform.SetParent(null);
            itemRB.Remove(collision.rigidbody);
        }
        if(collision.transform.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
