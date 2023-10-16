using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoomerang : MonoBehaviour
{

    [SerializeField] bool isThrown = false;
    [SerializeField] GameObject Boomerang;
    [SerializeField] Transform throwPosition;
    [SerializeField] float cooldown;
     private GameObject newBoomerang;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            CheckForBoomerang();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isThrown == false)
        {
            isThrown = true;

            newBoomerang = Instantiate(Boomerang, throwPosition);
            newBoomerang.transform.position = transform.position;
            newBoomerang.transform.parent = null;

            //StartCoroutine(ThrowDelay());
        }
    }

    private void CheckForBoomerang()
    {
        if(newBoomerang != null)
        {
            isThrown = true;
        }
        else if (newBoomerang == null)
        {
            isThrown = false;
        }
    }

    //IEnumerator ThrowDelay()
    //{
    //    yield return new WaitForSeconds(cooldown);
    //    isThrown= false;
    //}


}
