/****************************************************************************
* File Name: PlayerHealth.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Controls a slider, that being the health bar of the player.
* Decreases on contact with enemies, and when it reaches 0, go to game over scene.
*
****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : MonoBehaviour
{
    public float maxHealth = 1;
    public float currentHealth;
    public Slider healthBar;
    public float damageCooldown = 0.5f;
    public float damageTimer = 0;
    public float iframeCooldown = 0.5f;
    public float iframeTimer = 0;
    public bool iFrames = false;
    private bool damaging = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        if (iFrames && iframeTimer < iframeCooldown)
        {
            iframeTimer += Time.deltaTime;
        }
        else if (iFrames && iframeTimer > iframeCooldown)
        {
            iframeTimer = 0;
            iFrames = false;
        }
        if (damageTimer < damageCooldown && damaging)
        {
            damageTimer += Time.deltaTime;
        }
        else if (damageTimer > damageCooldown && damaging)
        {
            currentHealth -= 0.1f;
            damageTimer = 0;
        }
        if (currentHealth <= 0)
        {
            // Time.timeScale = 0;
            SceneManager.LoadScene("Game Over"); // Game over screen loaded upon 0 health

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !iFrames)
        {
            currentHealth -= 0.1f;
            healthBar.value = currentHealth;
            damaging = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damaging = false;
        }
    }
}
