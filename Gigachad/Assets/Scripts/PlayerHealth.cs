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
    public float damageCooldown = 1f;
    public float damageTimer = 0;
    public float redCooldown = 0.3f;
    public float redTimer = 0;
    public bool red = false;
    private bool damaging = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (red && redTimer < redCooldown)
        {
            redTimer += Time.deltaTime;
            spriteRenderer.color = Color.red;
        }
        else if (red && redTimer > redCooldown)
        {
            redTimer = 0;
            red = false;
        }
        if (damageTimer < damageCooldown && damaging && !red)
        {
            damageTimer += Time.deltaTime;
            spriteRenderer.color = Color.white;
        }
        else if (damageTimer > damageCooldown && damaging && !red)
        {
            currentHealth -= 0.1f;
            healthBar.value = currentHealth;
            damageTimer = 0;
            red = true;
        }
        if (currentHealth <= 0)
        {
            AudioManager.Instance.SFX[5].Play();
            // Time.timeScale = 0;
            SceneManager.LoadScene("Game Over"); // Game over screen loaded upon 0 health

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !red && !damaging)
        {
            AudioManager.Instance.SFX[6].Play();
            currentHealth -= 0.1f;
            healthBar.value = currentHealth;
            damaging = true;
            red = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            spriteRenderer.color = Color.white;
            damaging = false;
            red = false;
        }
    }
}
