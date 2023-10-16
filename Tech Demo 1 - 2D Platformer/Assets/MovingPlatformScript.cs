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

    [SerializeField]LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        MovePlatform();
    }


    // Update is called once per frame
    void Update()
    {
        MovePlatform();
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
            targetIndex++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != ground )
        {
            collision.transform.parent = transform;
            itemRB.Add(collision.rigidbody);

        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       

        if (collision.gameObject.layer != ground)
        {
            collision.transform.SetParent(null);

        }
    }
}
