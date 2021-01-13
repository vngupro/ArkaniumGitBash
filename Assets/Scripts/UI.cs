/* UI - Multiple Scenes Game */
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
class UI : MonoBehaviour
{
    // Game State
    public bool isPaused, isMenued, isSettinged;
    // UI Objects
    // | Layers
    GameObject Layer_Runtime, Layer_Pause, Layer_Menu, Layer_Settings;
    // | Buttons
    Button Button_Resume, Button_Retry, Button_Play, Button_Menu, Button_Quit_P, Button_Quit_M, Button_Settings;
    void Awake()
    {
        // UI Objects
        // | Layers
        Layer_Runtime = GameObject.Find("Layer_Runtime");
        Layer_Pause = GameObject.Find("Layer_Pause");
        Layer_Menu = GameObject.Find("Layer_Menu");
        Layer_Settings = GameObject.Find("Layer_Settings");
        // | Buttons
        Button_Resume = GameObject.Find("Button_Resume").GetComponent<Button>();
        Button_Retry = GameObject.Find("Button_Retry").GetComponent<Button>();
        Button_Play = GameObject.Find("Button_Play").GetComponent<Button>();
        Button_Menu = GameObject.Find("Button_Menu").GetComponent<Button>();
        Button_Quit_P = GameObject.Find("Button_Quit_P").GetComponent<Button>();
        Button_Quit_M = GameObject.Find("Button_Quit_M").GetComponent<Button>();
        Button_Settings = GameObject.Find("Button_Settings").GetComponent<Button>();
        // | Listeners
        Button_Resume.onClick.AddListener(SwitchIsPaused);
        Button_Retry.onClick.AddListener(Play);
        Button_Play.onClick.AddListener(Play);
        Button_Menu.onClick.AddListener(Menu);
        Button_Quit_P.onClick.AddListener(Application.Quit);
        Button_Quit_M.onClick.AddListener(Application.Quit);
        Button_Settings.onClick.AddListener(SwitchIsSettinged);
    }
    void Update()
    {
        // Game State
        Time.timeScale = isPaused ? 0 : isMenued ? 0 : 1;
        if (!isMenued && Input.GetKeyDown(KeyCode.Escape)) SwitchIsPaused();
        // UI Objects
        // | Layers
        Layer_Runtime.SetActive(!isPaused && !isMenued && !isSettinged);
        Layer_Pause.SetActive(isPaused && !isSettinged);
        Layer_Menu.SetActive(isMenued && !isSettinged);
        Layer_Settings.SetActive(isSettinged);
    }
    void SwitchIsPaused() { isPaused ^= true; isSettinged = false; }
    void Play() { SceneManager.LoadScene("Game"); }
    void Menu() { SceneManager.LoadScene("Menu"); }
    void SwitchIsSettinged() { isSettinged ^= true; }
}