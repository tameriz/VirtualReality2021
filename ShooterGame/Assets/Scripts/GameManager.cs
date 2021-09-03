using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public float timer = 10f;

    public Text scoreText;
    public Text timerText;

    public bool gameStarted;

    private void Update() {
        if (gameStarted)
        {
            timer -= 1 * Time.deltaTime;
            timerText.text = timer.ToString("F0");

            if (timer <= 0) {
                Bottle[] bottles = FindObjectsOfType<Bottle>();
                foreach (Bottle bottle in bottles)
                {
                    Destroy(bottle.gameObject);
                }

                BottleRefresher[] spawners = FindObjectsOfType<BottleRefresher>();
                foreach (BottleRefresher spawn in spawners)
                {
                    spawn.CancelInvoke();
                }
                gameStarted = false;

                Invoke("RestartGame", 3);

            }

        }

        

    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score " + score;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
