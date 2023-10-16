using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupJetpack : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void Interact()
    {
        player.AddComponent<JetpackPowerUp>();
        Destroy(gameObject);
    }

}
