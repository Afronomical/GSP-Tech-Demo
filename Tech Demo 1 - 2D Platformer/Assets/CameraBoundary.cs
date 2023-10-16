using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    [SerializeField] MoveCamera moveCam;
    public Vector2 upperLeft;
    public Vector2 bottomRight;
    // Start is called before the first frame update
    void Start()
    {
        moveCam = FindObjectOfType<MoveCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            moveCam.SetCamPosition(transform.position);
        }
    }
}
