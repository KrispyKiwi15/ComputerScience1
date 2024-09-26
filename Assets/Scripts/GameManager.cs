using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coins;
    public int health;
    private int maxHealth;
    public static GameManager gm;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    
    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        health = 10;
        maxHealth = 10;
    }

        
    private void Start()
    {
        
        coinText.text = "Coins: " + coins;
        healthText.text = "Health: " + health;
    }
    
    public int GetHealth()
    {
        return health;
    }

    public void ChangeHealth(int amount)
    {
        
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health < 1)
        {
            Die();
        }
        print("health = " + health );
        healthText.text = "Health: " + health;
    }

    void Die()
    {
        print("You Died");
        SceneManager.LoadScene(0);
    }

    public void AddCoins()
    {
        coins += 1;
        coinText.text = "Coins: " + coins;
    }
}
