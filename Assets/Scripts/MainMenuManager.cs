using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MainMenuManager : MonoBehaviour
{
    bool playerTap;
    public string gameScene;

    [SerializeField]
    GameObject gameTitle;

    private void Start()
    {
        playerTap = false;
        StartCoroutine(OpenGameTitle());
    }

    private void Update()
    {
        if(Input.touchCount > 0 && !playerTap)
        {
            SceneManager.LoadScene(gameScene);
        }
    }

    IEnumerator OpenGameTitle()
    {
        yield return new WaitForSeconds(.1f);
        gameTitle.GetComponent<CanvasGroup>().DOFade(1, 1.5f).SetEase(Ease.InCirc);
    }

}
