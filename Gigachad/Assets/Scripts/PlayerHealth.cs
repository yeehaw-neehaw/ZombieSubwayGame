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
    public GameObject healthOutline;
    private Animator anim;
    public static bool playerDead;
    private float deathTimer = 0;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = healthOutline.GetComponent<Animator>();
        playerDead = false;
}

    void Update()
    {
        anim.SetFloat("currentHealth", currentHealth);
        if (red && redTimer < redCooldown && !playerDead)
        {
            redTimer += Time.deltaTime;
            spriteRenderer.color = Color.red;
            AudioManager.Instance.SFX[6].Play();
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
            anim.SetFloat("currentHealth", currentHealth);
            damageTimer = 0;
            red = true;
        }
        if (currentHealth <= 0)
        {
            AudioManager.Instance.SFX[5].Play();
            for (int i = 0; i < 5; i++)
            {
                if (PlayerStats.CurrentLevel - 1 == i)
                {
                    AudioManager.Instance.Music[i].Stop();
                }
            }
            playerDead = true;
            red = false;
            deathTimer += Time.deltaTime;
            if (deathTimer >= 1f)
            {
                SceneManager.LoadScene("Game Over"); // Game over screen loaded upon 0 health
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !red && !damaging)
        {
            AudioManager.Instance.SFX[6].Play();
            currentHealth -= 0.1f;
            healthBar.value = currentHealth;
            anim.SetFloat("currentHealth", currentHealth);
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
