using System;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    public Canvas GameMenu;
    [SerializeField]
    private Collider gameAreaCollider;

    [Obsolete]
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameMenu.enabled = true;
            Debug.Log("Player has entered the game area.");

            GameSession gameSession = FindObjectOfType<GameSession>();
            if (gameSession != null)
            {
                gameSession.ResetGame();  
            }
        }
        else
        {
            Debug.Log(other.gameObject.tag);
        }
    }
}