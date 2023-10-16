using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float collapseTimer = 1.0f;

    [SerializeField] float destroyTimer = 1.0f;

    [SerializeField] GameObject player;

    [SerializeField] LayerMask ground;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            collision.transform.parent = transform;

            StartCoroutine(Collapse());

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            player = collision.gameObject;
            collision.transform.SetParent(null);

        }
    }







    IEnumerator Collapse()
    {
        yield return new WaitForSeconds(collapseTimer);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        

        yield return new WaitForSeconds(destroyTimer);

        if(player.transform.parent == transform)
        {
            player.transform.SetParent(null);
        }
        Destroy(gameObject);
    }


    
    
       
        
        
        
    
}
