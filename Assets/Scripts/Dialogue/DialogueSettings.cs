using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/New Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;
    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}


[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Language sentence;
}

[System.Serializable]
public class Language
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR

[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;

        Language lang = new Language();
        lang.portuguese = ds.sentence;

        Sentences sentences = new Sentences();
        sentences.profile = ds.speakerSprite;
        sentences.sentence = lang;

        if(GUILayout.Button("Create Dialogue"))
        {
            if(ds.sentence != "")
            {
                ds.dialogues.Add(sentences);

                ds.speakerSprite = null;
                ds.sentence = "";

            }
        }
    }
}

#endif
