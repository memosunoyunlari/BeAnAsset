using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoader : MonoBehaviour
{

    public Animator animator;

    private void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "shredder")
        {

            StartCoroutine(AnimationandChange());


        }
    }

    IEnumerator AnimationandChange()
    {
        animator.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
