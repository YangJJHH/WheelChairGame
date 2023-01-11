using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : SingletonMonobehaviour<UIManager> 
{
    [SerializeField] private GameObject ESC;
    [SerializeField] private Image image;


    public void FadeIn(UnityAction callback = null)
    {
        StartCoroutine(IFadeIn(callback));
    }
    public void FadeOut(UnityAction callback = null)
    {
        StartCoroutine(IFadeOut(callback));
    }
    IEnumerator IFadeIn(UnityAction callback = null)
    {
        image.DOFade(0.0f, 2.0f).SetEase(Ease.OutBack); ;
        yield return new WaitForSeconds(1.5f);
    }
    IEnumerator IFadeOut(UnityAction callback = null)
    {
        image.DOFade(1.0f, 2.0f).SetEase(Ease.OutBack); ;
        yield return new WaitForSeconds(1.5f);
        callback.Invoke();
    }


    public void ToggleUI()
    {
        ESC.SetActive(!ESC.activeSelf);
    }
}
