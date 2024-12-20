using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TMP_Text Name = null;
    public TMP_Text DialogueText = null;
    public string CharacterName = null;
    public string[] TextKeys = null;
    private int arrayIndex = 0;
    private int arrayMax;
    private float delayTime = .1f;
    public bool typing = false;
    private void Start()
    {
        Name.text = CharacterName;
        arrayMax = TextKeys.Length;
        TextManangerScipt.Instance.SetCurrentDialogue(this); 
    }

    public void SetText()
    {
        if (arrayIndex == arrayMax) return;
        StartCoroutine(Typewriting(TextManangerScipt.Instance.ReadAtKey(TextKeys[arrayIndex])));
        arrayIndex++;
    }

    private IEnumerator Typewriting(string textToWrite)
    {
        typing = true;
        for(int i = 0; i < textToWrite.Length; i++)
        {
            DialogueText.text = textToWrite.Substring(0, i);
            yield return new WaitForSeconds(delayTime);
            if(!typing)
            {
                DialogueText.text = textToWrite;
                break;
            }
        }
        typing = false;
    }
    public void SkipType()
    {
        typing = false;
    }
}
