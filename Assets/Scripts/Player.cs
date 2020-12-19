using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] Slider healthBar;
    [SerializeField] GameObject gameOverCanvas;
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
        healthBar.value = --health;

        if (health <= 0)
        {
            // stop game time
            Time.timeScale = 0;
            Controller.Instance.DisplayCursor(true);
            gameOverCanvas.SetActive(true);
        }
    }
}
