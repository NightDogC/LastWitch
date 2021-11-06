using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Explore Infomation UI
    public GameObject expInfoUI;
    private GameObject _expInfoUI;

    public void ShowExpInfo()
    {
        Destroy(_expInfoUI);
        _expInfoUI = Instantiate(expInfoUI, Input.mousePosition, Quaternion.identity, GameObject.Find("Canvas").transform);
        RectTransform rect = _expInfoUI.GetComponent<RectTransform>();
        if (rect.anchoredPosition.x < 0)
        {
            rect.pivot += Vector2.left;
        }
        if (rect.anchoredPosition.y<0)
        {
            rect.pivot += Vector2.down;
        }
    }
}
