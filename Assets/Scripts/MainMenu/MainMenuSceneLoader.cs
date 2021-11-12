using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoader : MonoBehaviour
{

    public Animator animator;
    public GameObject firstFrame;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    
    public void clicks()
    {
        Debug.Log("It be clicking");
    }

    public void teleAndSceneChange()
    {
        StartCoroutine("AnimationandChange");
    }
    IEnumerator AnimationandChange()
    {
        firstFrame.SetActive(false);
        Debug.Log("pushed it");
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("tele");
        Debug.Log("teled it");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
