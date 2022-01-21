using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SrollRectSnap_CS : MonoBehaviour
{
    //Pubilc Variables
    public RectTransform panel; // To hold the Animation_List
    public Button[] bttn;
    public RectTransform center; // Center to compare the distance for each bottom

    //Private Variables
    private float[] distance; // All buttons' distance to the center
    private bool dragging = false; // Will be True, while we drag the panel
    private int bttnDistance; // Will hold the distance between the buttons
    private int minButtonNum; // To hold the number of the button, with smallest distance to center
    private int lastBttnIdx;

    void Start()
    {
        int bttnLength = bttn.Length;
        distance = new float[bttnLength];
        lastBttnIdx = bttn.Length - 1;
        print(lastBttnIdx);
        //Get distance between buttons
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
        print( "total distance: " + bttnDistance);
        
    }

    void Update()
    {
        for (int i = 0; i < bttn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - bttn[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance); //Get the min distance

        for (int a = 0; a < bttn.Length; a++)
        {
            if (minDistance == distance[a])
            {
                minButtonNum = a;
            }
        }
        
        if (!dragging)
        {
            LerpToBttn(minButtonNum * -bttnDistance);
        }
        
    }

    void LerpToBttn(int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 20f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }


    //Trigger with left/right button
    public void Left_video()
    {
        if (minButtonNum == 0)
            LerpToBttn(lastBttnIdx * -bttnDistance);
        else
            LerpToBttn((minButtonNum - 1) * -bttnDistance);
    }

    public void Right_video()
    {
        if (minButtonNum == lastBttnIdx)
            LerpToBttn(0);
        else
            LerpToBttn((minButtonNum + 1) * -bttnDistance);
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }
}
