using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class guardEvent : MonoBehaviour
{
    // press E : Inspect input prompt
    public GameObject promptTextBox;
    private bool pressed;
    private bool assetIN;
    
    
    
    //for the conversion
    public Transform transformPanelandText;
    
    // cliff event text anchor
    public Transform guardEventLocation;
    public Transform guardPromptLocation;
    
    
    
    public GameObject panelandText;
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;

    

    // to get players ability to move while the text flows.
    public GameObject player;



    [TextArea]
    public string text;
    

    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake() {

        promptTextBox.SetActive(false);

        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);

        
        pressed = false;
        


    }

    public void LateUpdate()
    {
        Vector3 screenPosEventText = Camera.main.WorldToScreenPoint(guardEventLocation.position);
        Vector3 screenPosPromptText = Camera.main.WorldToScreenPoint(guardPromptLocation.position);
        screenPosEventText.z = 0;
        screenPosPromptText.z = 0;
        promptTextBox.transform.position = screenPosPromptText;
        transformPanelandText.position = screenPosEventText;


    }

    public void Update()
    {

        
        
        

        if (Input.GetKeyDown(KeyCode.E) && assetIN == true && pressed == false)
        {
            panelandText.SetActive(true);
            pressed = true;
            promptTextBox.SetActive(false);
            StartCoroutine("startEventandEndIt");
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

    
    
    

    


    private Coroutine typeRoutine = null;
    void PlayDialogue(string message) {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
    IEnumerator startEventandEndIt()
    {
        
        panelandText.SetActive(true);
        PlayDialogue(text);
        yield return new WaitForSeconds(6f);
        panelandText.SetActive(false);
        pressed = false;
    }


}
