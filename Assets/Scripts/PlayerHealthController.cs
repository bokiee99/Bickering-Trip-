using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public SpriteRenderer[] heartDisplay;
    public Sprite heartFull, heartEmpty;

    public Transform heartHolder;

    public float invincibilityTime, helathFlashTime = .2f;
    private float invincCounter, flashCounter;

    public GameObject GAMEOVER;
    public GameObject overScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;

            if (flashCounter < 0)
            {
                flashCounter = helathFlashTime;

                heartHolder.gameObject.SetActive(!heartHolder.gameObject.activeInHierarchy);
            }

            if (invincCounter <= 0)
            {
                heartHolder.gameObject.SetActive(true);
            }
        }
    }

    private void LateUpdate()
    {
        heartHolder.localScale = transform.localScale;
    }

    public void UpdateHealthDisplay()
    {
        switch (currentHealth)
        {
            case 3:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartFull;
                heartDisplay[2].sprite = heartFull;
                break;
            case 2:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartFull;
                heartDisplay[2].sprite = heartEmpty;
                break;
            case 1:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartEmpty;
                heartDisplay[2].sprite = heartEmpty;
                break;
            case 0:
                heartDisplay[0].sprite = heartEmpty;
                heartDisplay[1].sprite = heartEmpty;
                heartDisplay[2].sprite = heartEmpty;
                break;
        }
    }

    public void DamagePlayer(int damageToTake)
    {

        if (invincCounter <= 0)
        {
            //AudioManager.instance.PlaySFX(5);

            currentHealth -= damageToTake;

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

            UpdateHealthDisplay();

            if (currentHealth == 0)
            {
                StartCoroutine(GameOver());

                //AudioManager.instance.PlaySFX(4);
            }

            invincCounter = invincibilityTime;
        }
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();

        invincCounter = 0;

        heartHolder.gameObject.SetActive(true);
    }

    public void MakeInvincible(float invincLenght)
    {
        invincCounter = invincLenght;
    }

    IEnumerator GameOver()
    {
        GAMEOVER.SetActive(true);
        overScreen.SetActive(true); 
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
