using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InGameDialogue : MonoBehaviour
{
    private AudioSource audiosourceref;
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textSpeed;
    private AudioScript audioref;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        audiosourceref = GetComponent<AudioSource>();
        audioref = GetComponent<AudioScript>();
        textcomponent.text = string.Empty;


    }

    private void Update()
    {
        if (textcomponent.text == lines[index])
        {
            audiosourceref.Stop();
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        audioref.playAudio();

    }



    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


}