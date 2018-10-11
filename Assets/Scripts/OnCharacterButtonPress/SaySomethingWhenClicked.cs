using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaySomethingWhenClicked : MonoBehaviour,ICharacterButtonPress,IBladeInteractable {
    public RPGTalk rpgTalk;
    public int startLine;
    public int endLine;
    public bool isInteractable
    {
        get;set;
    }

    public bool mouseTriggered
    {
        get;set;
    }
    private void OnMouseDown()
    {
        if (isInteractable)
            OnButtonPressed();
    }
    public void OnButtonPressed()
    {
        rpgTalk.NewTalk(startLine.ToString(), endLine.ToString());

    }

    public void BladeInteract()
    {
        if (isInteractable)
            OnButtonPressed();
        //throw new System.NotImplementedException();
    }
}
