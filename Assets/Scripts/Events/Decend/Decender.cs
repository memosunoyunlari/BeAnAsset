using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Decender : MonoBehaviour
{ 
    // box collider2d for the edge so that player doesn't fall and this will be set deactive 
    // so that asset can move through a set string during animation.
    GameObject cliffProtection;


    public GameObject promptTextBox;
    private bool pressed;
    private bool assetIN;



    //for the conversion
    public Transform transformPanelandText;

    // cliff event text anchor
    public Transform decendEventLocation;
    public Transform decendPromptLocation;

    public GameObject panelandText;
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;

    [TextArea]
    public string text;

    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake()
    {

        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);

        pressed = false;

    }
    

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Trigger"))
        {
            assetIN = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Trigger"))
        {
            assetIN = false;
        }
    }

    
    void Update()
    {
        if (assetIN == true && pressed == false)
        {
            promptTextBox.SetActive(true);
        }

        if (assetIN == false)
        {
            promptTextBox.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && assetIN == true && pressed == false)
            {
                panelandText.SetActive(true);
                pressed = true;
                promptTextBox.SetActive(false);
                StartCoroutine("textThenDecend");
            }  
        }


    public void FixedUpdate()
    {
        Vector3 screenPosEventText = Camera.main.WorldToScreenPoint(decendEventLocation.position);
        Vector3 screenPosPromptText = Camera.main.WorldToScreenPoint(decendPromptLocation.position);
        screenPosEventText.z = 0;
        screenPosPromptText.z = 0;
        promptTextBox.transform.position = screenPosPromptText;
        transformPanelandText.position = screenPosEventText;


    }

    private void moveThroughTheString()
    {
        cliffProtection.SetActive(false);
        //ýþýðý ekle ve movetowards için 2 AYRI NOkta belirle ve ye

    }

    IEnumerator textThenDecend()
    {
        panelandText.SetActive(true);
        PlayDialogue(text);
        yield return new WaitForSeconds(6f);
        panelandText.SetActive(false);
        pressed = false;
        moveThroughTheString();
    }

    private Coroutine typeRoutine = null;
    void PlayDialogue(string message)
    {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
}
