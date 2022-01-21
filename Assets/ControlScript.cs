using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public ParticleSystem left_Thruster;
    public ParticleSystem right_Thruster;
    public Material dissolveMat_Body;
    public Material dissolveMat_Face;
    public float dissolve_value;
    public float max;
    public float waitSeconds;
    bool isVisible = false;

    void Start()
    {
        dissolveMat_Face.SetFloat("_Dissolve_Value", dissolve_value / max);
        dissolveMat_Body.SetFloat("_Dissolve_Value", dissolve_value / max);    
    }

    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            if (!isVisible)
            {
                StartCoroutine(AppearFunction());
            }              
        }

        if (Input.GetKeyDown("d"))
        {
            if (isVisible)
            {
                StartCoroutine(DisappearFunction());
            }
        }

        //GetComponent<Animator>().SetFloat("speed", Input.GetAxis("Vertical"));
    }

    // Update is called once per frame
    public void PhraseReciever(string[] phrase)
    {
        string[] words = new string[] {"hello", "hi"};

        if (phrase[0] == "hi" || phrase[0] == "hello" )
        {
            WaveCalled();
        }
        else if (phrase[0] == "salute")
        {
            SaluteCalled();
        }
        else if (phrase[0] == "yes")
        {
            YesCalled();
        }
        else if (phrase[0] == "no")
        {
            NoCalled();
        }
        else if (phrase[0] == "how are you")
        {
            SlideDanceCalled();
        }
        else if (phrase[0] == "curious")
        {
            CuriousCalled();
        }
        else if (phrase[0] == "what's the weather outside")
        {
            LeaveCalled();
        }
        else if (phrase[0] == "huh")
        {
            IDKCalled();
        }

        if (phrase[0] == "hey B" || phrase[0] == "hey b" || phrase[0] == "b-bit" || phrase[0] == "wake up" || phrase[0] == "show yourself")
        {
            StartCoroutine(AppearFunction());
        }

        if (phrase[0] == "sleep" || phrase[0] == "bye" || phrase[0] == "disappear" || phrase[0] == "goodbye" || phrase[0] == "see you later")
        {
            StartCoroutine(DisappearFunction());
        }
    }

    void WaveCalled()
    {
        GetComponent<Animator>().SetTrigger("wave_start");
    }
    void SaluteCalled()
    {
        GetComponent<Animator>().SetTrigger("salute_start");
    }
    void YesCalled()
    {
        GetComponent<Animator>().SetTrigger("yes_start");
    }
    void NoCalled()
    {
        GetComponent<Animator>().SetTrigger("no_start");
    }
    void SlideDanceCalled()
    {
        GetComponent<Animator>().SetTrigger("slide_dance_start");
    }
    void CuriousCalled()
    {
        GetComponent<Animator>().SetTrigger("curious_start");
    }
    void IDKCalled()
    {
        GetComponent<Animator>().SetTrigger("idk_start");
    }
    void LeaveCalled()
    {
        GetComponent<Animator>().SetTrigger("leave_start");
    }

    IEnumerator AppearFunction()
    {
        float i;
        for (i = 1;i<= max;i++)
        {
            AppearCalled();
            yield return new WaitForSeconds(waitSeconds);
        }
        isVisible = true;
        WaveCalled();

        if (!left_Thruster.isPlaying && !right_Thruster.isPlaying)
        {
            left_Thruster.Play();
            right_Thruster.Play();
        }
    }

    IEnumerator DisappearFunction()
    {
        if (left_Thruster.isPlaying && right_Thruster.isPlaying)
        {
            left_Thruster.Stop();
            right_Thruster.Stop();
        }

        WaveCalled();
        yield return new WaitForSeconds(4);
        float i;
        for (i = 1; i<= max; i++)
        {
            DisappearCalled();
            yield return new WaitForSeconds(waitSeconds);
        }
        isVisible = false;

    }

    void AppearCalled()
    {
        dissolve_value += 1;
        dissolveMat_Body.SetFloat("_Dissolve_Value", dissolve_value / max);
        dissolveMat_Face.SetFloat("_Dissolve_Value", dissolve_value / max);
    }

    void DisappearCalled()
    {
        dissolve_value -= 1;
        dissolveMat_Body.SetFloat("_Dissolve_Value", dissolve_value / max);
        dissolveMat_Face.SetFloat("_Dissolve_Value", dissolve_value / max);
    }
}
