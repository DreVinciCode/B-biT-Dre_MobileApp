using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicManager : MonoBehaviour
{
    public RectTransform comic_content;
    public Button[] comic_array;

    int index;
    private int lastComicIdx;

    void Start()
    {
        int comic_array_length = comic_array.Length;
        lastComicIdx = comic_array.Length - 1;
    }

    void Update()
    {
        //print(index);    
    }

    public void Move_Left()
    {
        int translate_value = 435;
        index = index - 1;

        if (index <= 0)
        {
            index = 0;
        }
       
        float newX = (index * -translate_value);
        Vector2 newPosition = new Vector2(newX, comic_content.anchoredPosition.y);
        comic_content.anchoredPosition = newPosition;
        
    }

    public void Move_Right()
    {
        int translate_value = 435;
        index = index + 1;

        if (index >= lastComicIdx)
        {
            index = lastComicIdx;
        }
      
        float newX = (index * (-translate_value));
        Vector2 newPosition = new Vector2(newX, comic_content.anchoredPosition.y);
        comic_content.anchoredPosition = newPosition;
     
    }
}
