using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class HomeScene : MonoBehaviour
{
    [SerializeField] private Image image;
    public void OnclickNewGame()
    {
        StartCoroutine(FadeOutScene(1));
    }
    public void OnclickExit()
    {
        if (SceneManager.GetActiveScene().name =="SampleScene")
        {
            SceneManager.LoadScene(0);
            return;
        }
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator FadeOutScene(int idx)
    {
        image.DOFade(1.0f, 2.0f).SetEase(Ease.OutBack); ;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(idx);
    }
}
