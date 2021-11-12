using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Briefing : MonoBehaviour
{
 
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;

    // to get players ability to move while the text flows.




    [TextArea]
    public string text1;
    public string text2;


    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake()
    {

        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);

    }


    private Coroutine typeRoutine = null;
    void PlayDialogue(string message)
    {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
    IEnumerator startEventandEndIt()
    {
        textBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        PlayDialogue(text1);
        yield return new WaitForSeconds(6);
        PlayDialogue(text2);
        yield return new WaitForSeconds(6);
        textBox.gameObject.SetActive(false);

    }


}