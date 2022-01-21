using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AR_World_SideMenu_Manager : MonoBehaviour
{
    public RectTransform sideMenu;

    // Start is called before the first frame update
    void Start()
    {
        //sideMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void Side_menu_btn()
    {
        sideMenu.DOAnchorPos(new Vector2(-100, 0), 0.25f);
    }

    public void Close_Side_menu_btn()
    {
        sideMenu.DOAnchorPos(new Vector2(1300, 0), 0.25f);
    }

}
