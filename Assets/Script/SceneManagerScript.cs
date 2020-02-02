using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void MenuGotoScene()
    {
        GotoScene(this.gameObject.name);
    }

    public void GotoScene(string s)
    {
        if (Application.CanStreamedLevelBeLoaded(s)) {
            SceneManager.LoadScene(s, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(Constant.MENU, LoadSceneMode.Single);
        }
         
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        GotoScene(scene.name);
    }

    public void NextScene()
    {
        string scene = SceneManager.GetActiveScene().name;
        try
        {
            int sceneNumber = Int32.Parse(scene.Substring(4));
            if (sceneNumber == 30)
            {
                GotoScene("Fim");
            }
            else
            {
                sceneNumber++;
                string nextScene = Constant.FASE_PREFIX + sceneNumber.ToString();
                Debug.Log("Goto nextScne: " + nextScene);
                GotoScene(nextScene);
            }

        }
        catch (FormatException)
        {
            Debug.Log("Unable to parse int");
            GotoScene(Constant.MENU);
        }
    }

    public void RateApp()
    {
        Debug.Log("market://details?id=" + Application.identifier);
        Application.OpenURL("market://details?id=" + Application.identifier);
    }
}
