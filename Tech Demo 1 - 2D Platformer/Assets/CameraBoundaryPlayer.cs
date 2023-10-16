using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaryPlayer : MonoBehaviour
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
        if (followPlayer)
        {
            moveCam.SetCamPosition(player.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            followPlayer = true;
        }
        if (followPlayer)
        {
            moveCam.SetCamPosition(player.transform.position);
        }
    }
   
}
