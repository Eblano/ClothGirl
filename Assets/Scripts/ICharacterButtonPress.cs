using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterButtonPress{
    bool isInteractable { set; get; }
    bool mouseTriggered { set; get; }
    // if character is near and presses button.
    void OnButtonPressed();
}
