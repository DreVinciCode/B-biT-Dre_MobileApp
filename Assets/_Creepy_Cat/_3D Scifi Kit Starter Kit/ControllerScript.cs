using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;


namespace DitzeGames.MobileJoystick.play
{
    public class ControllerScript : MonoBehaviour
    {
        protected Joystick Joystick;
        protected FixedButton Button;
        protected TouchField TouchField;

        void Awake()
        {
            Joystick = FindObjectOfType<Joystick>();
            Button = FindObjectOfType<FixedButton>();
            TouchField = FindObjectOfType<TouchField>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(transform.position.x + Joystick.AxisNormalized.x * Time.deltaTime * 3f, Button.Pressed ? 2 : 1, transform.position.z + Joystick.AxisNormalized.y * Time.deltaTime * 3f);

            transform.Rotate(Vector3.up, TouchField.TouchDist.x);
            transform.Rotate(Vector3.left, TouchField.TouchDist.y);

        }
    }
}