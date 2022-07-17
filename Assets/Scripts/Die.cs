using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{ 
public bool isDied = false;
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
        if (isDied)
        {
            Time.timeScale = 0f;
            menu.SetActive(true);
            isDied = true;
            light.intensity = 0.35f;

            if(Input.GetKeyDown("z"))
        {
                Application.Quit();
            }
            if (Input.GetKeyDown("space")) 
            {
                menu.SetActive(false);
                isDied = false;
                light.intensity = 1;
                if (Player.lvl == 0)
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