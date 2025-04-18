using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; // 11 line

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        int selected_character = int.Parse(EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharacterIndex = selected_character;

        SceneManager.LoadScene("Gameplay");
    }
}