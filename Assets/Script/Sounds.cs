using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    private enum State {active, inactive};
    private State currentState;
    public Sprite buttonMuted;
    public Sprite buttonActived;
    public string Type;
    public MenuMusic menuMusic;

    public void Start()
    {
        if (PlayerPrefs.GetInt(Type, 0) == 1)
        {
            currentState = State.active;
            this.GetComponent<Image>().sprite = buttonActived;
        }
        else
        {
            currentState = State.inactive;
            this.GetComponent<Image>().sprite = buttonMuted;
           
        }
    }

    public void ButtonClick()
    {
        if (currentState.Equals(State.active))
        {
            currentState = State.inactive;
            this.GetComponent<Image>().sprite = buttonMuted;
            PlayerPrefs.SetInt(Type, 0);
        }
        else
        {
            currentState = State.active;
            this.GetComponent<Image>().sprite = buttonActived;
            PlayerPrefs.SetInt(Type, 1);
        }

        if (Type.Equals("Music"))
        {
            menuMusic.RefreshPlayerPrefs();
        }
    }
}
