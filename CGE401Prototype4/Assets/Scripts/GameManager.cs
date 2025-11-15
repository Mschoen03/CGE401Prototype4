using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI messageText;

    public bool playerLost = false;
    public bool gameStarted = false;

    private PlayerController player;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        Time.timeScale = 0f;
        messageText.text = "Press SPACE to Start!";
    }

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
                Time.timeScale = 1f;
                messageText.text = "";
            }
            return;
        }

        if (!playerLost && player.transform.position.y < -10)
        {
            PlayerLose();
        }

        if (playerLost && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void UpdateWaveUI(int wave)
    {
        waveText.text = "Wave: " + wave;
    }

    public void PlayerLose()
    {
        playerLost = true;
        messageText.text = "YOU LOSE! Press R to Restart!";
    }

    public void PlayerWin()
    {
        playerLost = true;
        messageText.text = "YOU WIN! Press R to Restart!";
    }
}
