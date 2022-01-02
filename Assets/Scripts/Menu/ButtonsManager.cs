using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttonsList;
    [SerializeField] private Ease ease;
    [SerializeField] private float animationDuration = 2f;

    private void Awake()
    {
        GetButtons();
    }

    private void GetButtons()
    {
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            buttonsList.Add(t.gameObject);
            t.DOScale(1, animationDuration).SetEase(ease).SetDelay(0.5f);
        }
    }

}
