using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public RectTransform arrow;
    // Start is called before the first frame update
    void Start()
    {
        UpDownArrow();

    }
    void UpDownArrow()
    {
        arrow.DOLocalMoveY(-0.5f, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WheelChair")
        {
            Debug.Log("³¡");
            GameManager.Instance.GameEnd();
        }
    }
}
