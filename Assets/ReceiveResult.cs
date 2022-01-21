using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReceiveResult : MonoBehaviour {

    private TextMeshProUGUI textMesh;
    private ControlScript controlScript;
    string[] blank = { "\"...\"" };
    bool firstMessage = true;

    void Awake()
    {
        controlScript = GameObject.FindObjectOfType<ControlScript> ();
       // GameObject.Find("U_Text").GetComponent<TextMeshProUGUI>().text = "Press the Mic button and say 'wake up!'";

    }

    void Start () {
        //GameObject.Find("Text").GetComponent<Text>().text = "You need to be connected to Internet";
	}
	
    void onActivityResult(string recognizedText){
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);

        controlScript.PhraseReciever(result);
        GameObject.Find("U_Text").GetComponent<TextMeshProUGUI>().text = "\"" + result[0] + "\"";
    
        StartCoroutine(processTask());
    }

    IEnumerator processTask()
    {
        yield return new WaitForSeconds(5);

        if (firstMessage)
        {
            GameObject.Find("U_Text").GetComponent<TextMeshProUGUI>().text = "Say Hi to B-biT! :D";
            firstMessage = false;
        }
        else
        {
            GameObject.Find("U_Text").GetComponent<TextMeshProUGUI>().text = blank[0];
        }
    }

}
