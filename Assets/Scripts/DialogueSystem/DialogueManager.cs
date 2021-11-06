using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    // press E : Inspect input prompt
    public GameObject promptTextBox;
    private bool pressed;
    private bool assetIN;
    private Vector3 promptOffset;
    
    
    //for the conversion
    public Transform transformPanelandText;
    
    // cliff event text anchor
    public Transform cliffEventLocation;
    
    // offset for the anchor - if needed;
    private Vector2 offset;
    
    public GameObject panelandText;
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;

    // to get players ability to move while the text flows.
    public GameObject player;



    [TextArea]
    public string cliff;
    [TextArea]
    public string trappedwolf;
    [TextArea]
    public string guardpost;

    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake() {

        panelandText.SetActive(false);
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);

        
        pressed = false;
        promptOffset = new Vector2(0, 5f);


    }

    private void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(cliffEventLocation.position);
      
        screenPos.y = (Screen.height - screenPos.y);
        
        transformPanelandText.position = screenPos;
        promptTextBox.transform.position = screenPos - promptOffset;

        if (Input.GetKeyDown(KeyCode.E) && assetIN == true && pressed == false)
        {
            panelandText.SetActive(true);
            pressed = true;
            promptTextBox.SetActive(false);
            StartCoroutine("startcliffeventandendit");
        }

        

       
        if (assetIN == true && pressed == false)
        {
            promptTextBox.SetActive(true);
        }

        if (assetIN == false)
        {
            promptTextBox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Trigger") && pressed == false)
        {
            
            assetIN = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Trigger") && pressed == false)
        {
            
            assetIN = false;
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
        
        panelandText.SetActive(true);
        PlayDialogue(cliff);
        yield return new WaitForSeconds(10f);
        panelandText.SetActive(false);
        pressed = false;
    }

}
