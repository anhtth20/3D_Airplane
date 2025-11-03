using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;  
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; 
    private GameSession gameSession;

    [System.Obsolete]
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();  
        gameSession = FindObjectOfType<GameSession>(); 
    }

    void Update()
    {
        if (gameSession != null)
        {
            scoreText.text = "Score: " + gameSession.GetScore().ToString();
            
        }
    }
}