using System;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    public Canvas GameMenu;
    [SerializeField]
    private Collider gameAreaCollider;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // SceneManager.LoadScene("_Scene_1");
            GameMenu.enabled = true;
            Debug.Log("Player has entered the game area.");
        }
        else
        {
            Debug.Log(other.gameObject.tag);
        }
    }
}