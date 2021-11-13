using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cinemachine;

public class Briefing : MonoBehaviour
{
 
    public Transform panelAndText;
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;

    public Transform eventLocation;

    public CinemachineVirtualCamera buttonCam;
    public CinemachineVirtualCamera textCam;

    [TextArea]
    public string text1;
    public string text2;


    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake()
    {

        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
        StartCoroutine("startEventandEndIt");
        
    }

    private void FixedUpdate()
    {
        Vector3 screenPosEventText = Camera.main.WorldToScreenPoint(eventLocation.position);
        screenPosEventText.z = 0;
        panelAndText.position = screenPosEventText;
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
        yield return new WaitForSeconds(1);
        panelAndText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        PlayDialogue(text1);
        yield return new WaitForSeconds(6);
        PlayDialogue(text2);
        yield return new WaitForSeconds(6);
        panelAndText.gameObject.SetActive(false);
        buttonCam.Priority = 11;
        textCam.Priority = 10;

    }


}