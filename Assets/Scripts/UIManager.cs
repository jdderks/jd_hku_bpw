using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;

    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI ammoAmountText;
    [SerializeField] private TextMeshProUGUI currentWaveText;

    [SerializeField] private Image healthBarImage; 

    public TextMeshProUGUI MoneyText { get => moneyText; set => moneyText = value; }
    public TextMeshProUGUI AmmoAmountText { get => ammoAmountText; set => ammoAmountText = value; }
    public TextMeshProUGUI CurrentWaveText { get => currentWaveText; set => currentWaveText = value; }
    public GameObject PauseMenu { get => pauseMenu; set => pauseMenu = value; }
    public static UIManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        if (!instance || instance != this)
        {
            instance = this;
        }
    }

    private void Update()
    {

        currentWaveText.text = EnemySpawner.currentWave.ToString();
        healthBarImage.fillAmount = Base.CurrentHealth / 100;
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
