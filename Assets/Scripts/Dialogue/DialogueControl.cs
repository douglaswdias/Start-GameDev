using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum lang
    {
        pt,
        en,
        sp
    }

    public lang language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;

    [Header("Settings")]
    public float dialogueSpeed;

    private bool isShowing;
    private int index;
    private string[] letters;

    public static DialogueControl Instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Dialogue()
    {
        foreach (char letter in letters[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(dialogueSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == letters[index])
        {
            if(index < letters.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(Dialogue());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                letters = null;
                IsShowing = false;
            }
        }
        
    }

    public void Speech(string[] txt)
    {
        if (!IsShowing)
        {
            dialogueObj.SetActive(true);
            letters = txt;
            StartCoroutine(Dialogue());
            IsShowing = true;
        }
    }
}
