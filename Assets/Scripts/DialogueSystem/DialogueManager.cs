using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public RectTransform canvasRectT;
    public RectTransform textRectTransform;
    public Transform player;

    private Vector2 offset;
    
    public GameObject panelandText;
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;

    

    [TextArea]
    public string cliff;
    [TextArea]
    public string trappedwolf;
    [TextArea]
    public string guardpost;

    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake() {
        panelandText.SetActive(false);
        offset = new Vector2(0, 2f);
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
        
    }

    private void LateUpdate()
    {
       Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, player.position);
       textRectTransform.anchoredPosition = screenPoint - canvasRectT.sizeDelta / 2f + offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if ( collision.tag == "Trigger")
        {
            StartCoroutine(startcliffeventandendit());
        }
        
    }

    private void PlayDialogue1() {
        PlayDialogue(cliff);
    }

    private void PlayDialogue2() {
        PlayDialogue(trappedwolf);
    }

    private void PlayDialogue3() {
        PlayDialogue(guardpost);
    }


    private Coroutine typeRoutine = null;
    void PlayDialogue(string message) {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
    IEnumerator startcliffeventandendit()
    {
        yield return new WaitForSeconds(3f);
        panelandText.SetActive(true);
        PlayDialogue(cliff);
        yield return new WaitForSeconds(10f);
        panelandText.SetActive(false);
    }

}
