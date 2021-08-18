using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : BaseSingletonWithMono<SceneControl>
{
    public GameObject Load;
    public Slider Slider;
    public Text text;

    private bool Loadscene = false;
    float time = 0;

    public GameObject BeginMenu;
    enum Scene
    {
        SceneOne,
        SceneTwo
    };
    Scene scene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        Clock();
    }

    public void LoadScene(int num)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Loadscene = true;
            StartCoroutine(SceneLoad(num));
        }
        else
        {
            BeginMenu.SetActive(false);
            SceneManager.LoadScene(num);
        }
    }
    public int Check()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                scene = Scene.SceneOne;
                return 0;
                break;
            default:
                scene = Scene.SceneTwo;
                return 2;
                break;
        }
    }

    IEnumerator SceneLoad(int num)
    {
        Load.SetActive(true);

        //CenterEvent.Instance.Clear();

        AsyncOperation operation = SceneManager.LoadSceneAsync(num);

        operation.allowSceneActivation = false;

        if (time <= 1f)
        {
            Slider.value = time;
        }

        while (!operation.isDone)
        {
            Slider.value = time;

            if (operation.progress >= 0.9f && time == 1f)
            {
                Slider.value = 0;
                time = 0;
                Loadscene = false;
                //text.text = "点击任意地方继续游戏";

                //if (Input.anyKeyDown)
                //{
                //    text.text = null;
                //    text.text = "Loading...";
                //    operation.allowSceneActivation = true;
                //}
               
                operation.allowSceneActivation = true;
                Load.SetActive(false);
                //Music_Control.Instance.PlayVidio();
                Music_Control.Instance.Clip();
                UI.Instance.DisPlayerBlood();
                //新场景中重新启用监听
                InputManager.Instance.StartListen(true);
                

            }

            yield return null;
        }

    }

    private void Clock()
    {
        if (Loadscene == true)
        {
            if (time <= 1f)
            {
                time += Time.fixedDeltaTime;
            }
            else
            {
                time = 1;
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}


