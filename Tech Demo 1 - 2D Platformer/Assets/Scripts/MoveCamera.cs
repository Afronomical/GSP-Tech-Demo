using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Vector2 target;
    [SerializeField] float step = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector2.MoveTowards(transform.position, target, step );
    }

    public void SetCamPosition(Vector2 newPosition)
    {
        target = newPosition;
    }
}
