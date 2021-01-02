using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float health = 10f;
    [SerializeField] Slider healthBar;
    [SerializeField] GameObject gameOverCanvas;

    [SerializeField] Image healthImage;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(1f);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.value = health;

        if (health <= 0)
        {
            // stop game time
            Time.timeScale = 0;
            Controller.Instance.DisplayCursor(true);
            gameOverCanvas.SetActive(true);
        }
        else if (health <= 2f)
        {
            healthImage.color = Color.red;
        }
        else if (health <= 5f)
        {
            healthImage.color = Color.yellow;
        }
    }
}
