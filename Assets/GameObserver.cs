
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameObserver : MonoBehaviour
{
    public static GameObserver instance;

    public int pollen = 0;

    public float hiveHealth = 4;
    public int larvae = 2;

    public TMP_Text pollenText;
    public TMP_Text larvaeText;

    public Slider hiveHealthBar;

    public GameObject winImage;
    public GameObject loseImage;

    public float timer = 30;
    public TMP_Text timerText;

    private float damageTimer = 5;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        winImage.SetActive(false);
        loseImage.SetActive(false);

        hiveHealthBar.maxValue = 4;

        UpdateUI();
    }

    void Update()
    {
        // Game timer
        timer -= Time.deltaTime;

        // Honeycomb slowly gets damaged
        damageTimer -= Time.deltaTime;

        if (damageTimer <= 0)
        {
            hiveHealth -= 1;

            damageTimer = 5;

            UpdateUI();
        }

        // Lose if hive gets too damaged
        if (hiveHealth <= 1 || larvae < 2)
        {
            LoseGame();
        }

        // Win if you survive the timer
        if (timer <= 0 && hiveHealth >= 2 && larvae >= 2)
        {
            WinGame();
        }

        timerText.text = "Time: " + Mathf.CeilToInt(timer);
    }

    public void AddPollen()
    {
        pollen++;

        if (pollen > 10)
        {
            pollen = 10;
        }

        UpdateUI();
    }

    public void RepairHive()
    {
        // Costs 2 pollen
        if (pollen >= 2 && hiveHealth < 4)
        {
            pollen -= 2;

            hiveHealth += 1;

            UpdateUI();
        }
    }

    public void FeedLarvae()
    {
        // Costs 1 pollen
        if (pollen >= 1)
        {
            pollen -= 1;

            larvae = 2;

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        pollenText.text = "Pollen: " + pollen + "/10";

        larvaeText.text = "Baby Bees: " + larvae;

        hiveHealthBar.value = hiveHealth;
    }

    void WinGame()
    {
        winImage.SetActive(true);

        Time.timeScale = 0;
    }

    void LoseGame()
    {
        loseImage.SetActive(true);

        Time.timeScale = 0;
    }
}
