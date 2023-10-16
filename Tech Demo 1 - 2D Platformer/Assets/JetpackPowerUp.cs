using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackPowerUp : MonoBehaviour
{

    
    private float jetPackFuelMax = 1000;
    public float jetPackFuel;
    public float jetPackStrength = 10;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Image jetPackMeter;

    [Header("UI and HUD")]
    private float inputY;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jetPackFuel = jetPackFuelMax;
        jetPackMeter = FindObjectOfType<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        inputY = Input.GetAxis("Jump");

        PlayerJetPack();
    }

    private void PlayerJetPack()
    {
        if (inputY > 0.1 && jetPackFuel > 0)
        {
            jetPackFuel--;
            rb.AddForce(new Vector2(0, jetPackStrength), ForceMode2D.Force);

            jetPackMeter.fillAmount = jetPackFuel / jetPackFuelMax;
    
        }
    }
}
