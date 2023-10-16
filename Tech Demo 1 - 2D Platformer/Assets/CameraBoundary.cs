using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    [SerializeField] GameObject player;

    public bool followPlayer = false;

    [SerializeField] MoveCamera moveCam;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        moveCam = FindObjectOfType<MoveCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && followPlayer == false)
        {
            moveCam.SetCamPosition(transform.position + offset);
        }
        if (followPlayer)
        {
            moveCam.SetCamPosition(player.transform.position);
        }
    }
   
}
