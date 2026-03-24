using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public float maxHealth = 1;
    public float currentHealth;
    public Slider healthBar;
    public float healthCooldown = 0.5f;
    public float timer = 0;
    public bool iFrames = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !iFrames)
        {
            currentHealth -= 0.1f;
            healthBar.value = currentHealth;
            iFrames = true;
        }
        else if (iFrames && timer < healthCooldown)
        {
            timer += Time.deltaTime;
        }
        else if (iFrames && timer > healthCooldown)
        {
            timer = 0;
            iFrames = false;
        }
    }
}
