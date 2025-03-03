using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Parameters")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float delay;

    [Header("Game Objects")]
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform lava;

    [Header("UI Elements")]
    [SerializeField]
    private GameObject loseScreen;
    [SerializeField]
    private GameObject winScreen;

    private bool gameWon = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else if (lava.transform.position.y >= 25)
        {
            WinGame();
        }
        else if (!gameWon)
        {
            lava.transform.position = new Vector3(lava.transform.position.x, lava.transform.position.y + Time.deltaTime * speed, lava.transform.position.z);
        }

        if (player.transform.position.y < lava.transform.position.y && !gameWon)
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        gameWon = true;
        winScreen.SetActive(true);
        Invoke("ResetScene", 5f);
    }

    private void LoseGame()
    {
        loseScreen.SetActive(true);
        Invoke("ResetScene", 5f);
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
