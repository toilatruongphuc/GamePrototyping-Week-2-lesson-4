using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI display;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
            
    }
    public int Addition()
    {
        score++;
        DisplayScore();
        return score;
    }
    private void DisplayScore()
    {
        display.text = $"Strawberries: {score}";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Addition();
            OnDestroy();
        }
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
