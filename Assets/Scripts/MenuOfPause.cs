using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOfPause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject lightingObj;
    private UnityEngine.Rendering.Universal.Light2D light;

    // Start is called before the first frame update
    void Start()
    {
        light = lightingObj.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) // ������������ ����
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                isPaused = false;
                light.intensity = 1;
            }
            else // ������ �� �����
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                isPaused = true;
                light.intensity = 0.35f;
            }
        }
        if (isPaused)
        {
            if (Input.GetKeyDown("z"))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown("space")) //������� ����
            {
                pauseMenu.SetActive(false);
                isPaused = false;
                light.intensity = 1;
                if (Player.lvl==0)
                {
                    Player.lvl = 0;
                }
                else
                {
                    Player.lvl = 1;
                }
                Player.keysRequired = 0;
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                Time.timeScale = 1f;
            }
        }
    }
}