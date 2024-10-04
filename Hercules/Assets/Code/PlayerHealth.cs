using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
    }

    public float playerHealth;
    public float maxHealth;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(playerHealth / maxHealth, 0, 1);        
    }

    public void takeDamage(float damage){
        playerHealth -= damage;
        Debug.Log("Player Health: " + playerHealth);
        if(playerHealth <= 0){
            Destroy(gameObject);
        }
    }
}
