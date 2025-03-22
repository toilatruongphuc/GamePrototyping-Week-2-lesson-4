using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject respawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
public void restart()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
