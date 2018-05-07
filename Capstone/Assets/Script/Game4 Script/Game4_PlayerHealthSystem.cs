using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game4_PlayerHealthSystem : MonoBehaviour
{

    Slider playerHealth;
    public float playeHP;
    public Text healthBar;
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(true);
        playerHealth = GetComponent<Slider>();
        playerHealth.maxValue = Game4_PlayerController.Instance.playerHealth;
        playerHealth.value = Game4_PlayerController.Instance.playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.value = Game4_PlayerController.Instance.playerHealth;
        healthBar.text = playerHealth.value + "/100";
    }
}