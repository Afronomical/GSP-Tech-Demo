using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidVaniaTrigger : MonoBehaviour
{
    [SerializeField]CameraBounds camBounds;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CameraBounds camControl = FindObjectOfType(typeof(CameraBounds)) as CameraBounds;
            camControl.upperLeft = new Vector2(this.transform.position.x + (camBounds.upperLeft.x), this.transform.position.y + (camBounds.upperLeft.y));
            camControl.bottomRight = new Vector2(this.transform.position.x + (camBounds.bottomRight.x ), this.transform.position.y + (camBounds.bottomRight.y));
        }

    }   }
