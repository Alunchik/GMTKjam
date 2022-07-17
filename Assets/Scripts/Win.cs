using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{ 
public bool isWin = false;
public GameObject menu;
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
        if (isWin)
        {
            Time.timeScale = 0f;
            menu.SetActive(true);
            isWin = true;
            light.intensity = 0.35f;

            if(Input.GetKeyDown("z"))
        {
                Application.Quit();
            }
            if (Input.GetKeyDown("space")) 
            {
                menu.SetActive(false);
                isWin = false;
                light.intensity = 1;
                    Player.lvl = 0;
                Player.keysRequired = 0;
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                Time.timeScale = 1f;
            }
        }
    }
}