using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switchscence : MonoBehaviour
{
    private string firstname = "first";
    private string secondname = "ScendOne";
    private string thirdname = "Third";
    private string forthname = "Fourth";
    private string fifthname = "Fifth";
    private string sixthname = "Sixth";

    private string CurrentScene;

    public static Switchscence instance;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetPositionForScene(scene.name);
      
    
    }

    public void Start()
    {
        CurrentScene = forthname;
        SetPositionForScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScence(string currentScene)
    {
        SceneManager.LoadScene(currentScene);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            LoadScence(CurrentScene);
            gameObject.SetActive(false);
        }
    }

    public void SwitchCurrentSecene()
    {
        SetPositionForScene(SceneManager.GetActiveScene().name);

        CurrentScene = SceneManager.GetActiveScene().name;

        if (CurrentScene == firstname)
        {
            CurrentScene = secondname;
            return;
        }
        else if (CurrentScene == secondname)
        {
            CurrentScene = thirdname;
            return;
        }
        else if (CurrentScene == thirdname)
        {
            CurrentScene = forthname;
            return;
        }
        else if (CurrentScene == forthname)
        {
            CurrentScene = fifthname;
            return;
        }
        else if (CurrentScene == fifthname)
        {
            CurrentScene = sixthname;
            return;
        }
    }

    private void SetPositionForScene(string sceneName)
    {
        if (sceneName == firstname)
        {
            transform.position = new Vector3(0f, -1f, 0f);
        }
        else if (sceneName == secondname)
        {
            transform.position = new Vector3(2f, -1f, 0f);
        }
        else if (sceneName == thirdname)
        {
            transform.position = new Vector3(0f, -1f, 0f);
        }
        else if (sceneName == forthname)
        {
            transform.position = new Vector3(0f, -1f, 0f);
        }
        else if (sceneName == fifthname)
        {
            transform.position = new Vector3(0f, -4f, 0f);
        }
        else if (sceneName == sixthname)
        {
            transform.position = new Vector3(0f, -1f, 0f);
        }
    }
}