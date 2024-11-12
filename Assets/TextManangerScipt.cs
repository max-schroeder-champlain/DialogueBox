using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class TextManangerScipt : MonoBehaviour
{
    public static TextManangerScipt Instance = null;
    private DialogueScript currentDialogue = null;
    private StreamReader textReader = null;
    private TextAsset textAsset = null;
    private void Awake()
    {
        string path = Application.dataPath + "/test.txt";
        Debug.Log(path);
        if (!File.Exists(path))
        {
            Debug.Log("ERROR PATH DOES NOT EXIST");
            this.enabled = false;
        }
        textReader = new StreamReader(path);
    }
    private void OnEnable() //Make instance
    {
        if (Instance == null)
        {
            Debug.Log("Instance created");
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }
    private void OnDisable() //Destroy instance
    {
        if (Instance != null && Instance == this)
        {
            Instance = null;
        }
        textReader.Close();
    }
    public void SetCurrentDialogue(DialogueScript temp)
    {
        if (currentDialogue == null)
        {
            currentDialogue = temp;
        }
        Debug.Log("go");
        currentDialogue.SetText();
    }
    public string ReadAtKey(string key)
    {
        while(!textReader.EndOfStream)
        {
            if(textReader.ReadLine()==key)
            {
                string text = textReader.ReadLine();
                return text;
            }
        }
        return "test";
    }
    public void NextDialogue()
    {
        if(currentDialogue == null) return;
        if (currentDialogue.typing)
        {
            currentDialogue.SkipType();
            return;
        }
        currentDialogue.SetText();
    }
}
