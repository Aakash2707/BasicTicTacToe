using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void PlayGame(){
        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
    public void PauseGame(){
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevel(int levelIndex){

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("This is called");
        SceneManager.LoadScene(levelIndex);
    }
}
