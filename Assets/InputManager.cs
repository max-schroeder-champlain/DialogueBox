using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public void OnDialogueInteract()
    {
        TextManangerScipt.Instance.NextDialogue();
    }
}
