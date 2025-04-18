using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] characters;

    private int character_index;

    public int CharacterIndex
    {
        get { return character_index; }
        set { character_index = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // 'this' refers to the class where it is used
            DontDestroyOnLoad(gameObject); // Move from one scene to another scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading; // Subcribes to the event
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading; // Unsubcribes to the event
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            Instantiate(characters[character_index]);
        }
    }
}