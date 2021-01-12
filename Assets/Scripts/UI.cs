/* UI - One Scene Game Version */
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
class UI : MonoBehaviour
{
    // Game State
    public bool isPaused, isMenued;
    // UI Objects
    // | Layers
    GameObject Layer_Runtime, Layer_Pause, Layer_Menu;
    // | Buttons
    Button Button_Resume, Button_Play, Button_Menu, Button_Quit;
    void Awake()
    {
        // UI Objects
        // | Layers
        Layer_Runtime = GameObject.Find("Layer_Runtime");
        Layer_Pause = GameObject.Find("Layer_Pause");
        Layer_Menu = GameObject.Find("Layer_Menu");
        // | Buttons
        Button_Play = GameObject.Find("Button_Play").GetComponent<Button>();
        Button_Menu = GameObject.Find("Button_Menu").GetComponent<Button>();
        Button_Quit = GameObject.Find("Button_Quit").GetComponent<Button>();
        Button_Resume = GameObject.Find("Button_Resume").GetComponent<Button>();
        // | Listeners
        Button_Resume.onClick.AddListener(SwitchIsPaused);
        Button_Play.onClick.AddListener(SwitchIsMenued);
        Button_Menu.onClick.AddListener(SwitchIsMenued);
        Button_Quit.onClick.AddListener(Application.Quit);
    }
    void Update()
    {
        // Game State
        Time.timeScale = isPaused ? 0 : isMenued ? 0 : 1;
        if (!isMenued && Input.GetKeyDown(KeyCode.Escape)) SwitchIsPaused();
        // UI Objects
        // | Layers
        Layer_Runtime.SetActive(!isPaused && !isMenued);
        Layer_Pause.SetActive(isPaused);
        Layer_Menu.SetActive(isMenued);
    }
    void SwitchIsPaused() { isPaused ^= true; }
    void SwitchIsMenued() { isMenued ^= true; isPaused = false; }
}