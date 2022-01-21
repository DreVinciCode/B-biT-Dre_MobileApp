using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour
{
    //public Transform target;
    public ParticleSystemRenderer left_Thruster;
    public ParticleSystemRenderer right_Thruster;
    public ParticleSystem l_thruster;
    public ParticleSystem r_thruster;
    public ParticleSystem dummy;
    public Joystick Joystick;
    public FixedButton Button;
    public FixedTouchField TouchField;
    public Vector3 CameraOffset;
    public float CameraAngle;

    public LayerMask groundLayers;
    public float jumpForce = 1.0f;
    public SphereCollider col;

    protected Actions Actions;
    protected Rigidbody Rigidbody;

    protected float CameraAngleY;
    protected float CameraAngleSpeed = 0.1f;
    protected float CameraPosY;
    protected float CameraPosSpeed = 0.1f;

    Color blue = new Color(0, 228, 255, 1.0f);
    Color red = new Color(255, 0, 0, 1.0f);


    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {

        Actions = GameObject.FindObjectOfType<Actions>();
        mainCamera = GameObject.FindObjectOfType<Camera>();
        Rigidbody = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var left_thrust = l_thruster.main;
        var right_thrust = r_thruster.main;

        var input = new Vector3(-Joystick.inputVector.x, 0, -Joystick.inputVector.y);
        var vel = Quaternion.AngleAxis(CameraAngleY + 180, Vector3.up) * input * 5f;

   
        Rigidbody.velocity = new Vector3(vel.x, Rigidbody.velocity.y , vel.z);

        //if zero on joystick value, then dont face that start direction and stay in the last known place direction. 
        if (input.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.AngleAxis(CameraAngleY + 180 + Vector3.SignedAngle(Vector3.forward, input.normalized + (Vector3.forward * 0.001f), Vector3.up), Vector3.up);
        }
        CameraAngleY += TouchField.TouchDist.x * CameraAngleSpeed;

        mainCamera.transform.position = transform.position + (Quaternion.AngleAxis(CameraAngleY, Vector3.up) * CameraOffset);
        mainCamera.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * CameraAngle - mainCamera.transform.position, Vector3.up);

        if (Button.Pressed)
        {
            Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Rigidbody.velocity.magnitude > 3f)
        {
            Actions.Flying();

            //right_thrust.startColor = red;
            //left_thrust.startColor = red;
            left_Thruster.lengthScale = 2.7f;
            right_Thruster.lengthScale = 2.7f;
            dummy.Play();
            // Unknown reason leaving this .Play() on l_thruster when not being assigned allows the ParticleSystemRenderer to work for the different cases. 

        }
        else if (Rigidbody.velocity.magnitude > 0.5f)
        {
            Actions.Lean();
            //right_thrust.startColor = blue;
            //left_thrust.startColor = blue;
            left_Thruster.lengthScale = 2.3f;
            right_Thruster.lengthScale = 2.3f;
            dummy.Play();
        }
        else
            Actions.Idle();
            //right_thrust.startColor = blue;
            //left_thrust.startColor = blue;
            left_Thruster.lengthScale = 2.0f;
            right_Thruster.lengthScale = 2.0f;
            dummy.Play();
    }
}


