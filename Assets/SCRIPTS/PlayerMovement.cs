using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private CharacterController charCon;
    public float velocityFwd = 5f;
    public float velocityStrafe = 4f;
    public float camTilt = 0.4f;
    public float jump = 10.0f;
    public float gravity = 0.4f;
    private float vSpeed = 0f; //vertical speed. this is the only thing that i need to consistently update.
    private bool jumping = false; //allows us to queue jumps before landing
    bool leftPress;
    bool rightPress;
    public bool go = false;
    public int health = 3;
    private int hitPoint = 3;
    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        hitPoint = health;
    }

    // Update is called once per frame
    void Update()
    {
        leftPress = Input.GetKey(KeyCode.A);
        rightPress = Input.GetKey(KeyCode.D);
        if (go)
        {
            cam.enabled = true;
            MoveUpdate();

        }
        else
        {
            cam.enabled = false;
        }
    }
    void FixedUpdate()
    {
        
    }
    void MoveUpdate()
    {
        if (hitPoint > 0)
        {
            charCon.Move(velocityFwd * transform.forward * Time.deltaTime);
            if (leftPress && !rightPress)
            {
                charCon.Move(velocityStrafe * (transform.right * -1) * Time.deltaTime);
                Vector3 newRot = new Vector3(0, 0, camTilt);
                Vector3 newerRot = AngleLerp(cam.transform.eulerAngles, newRot, 6f * Time.deltaTime);
                cam.transform.eulerAngles = newerRot;
            }
            else if (rightPress && !leftPress)
            {
                charCon.Move(velocityStrafe * transform.right * Time.deltaTime);
                Vector3 newRot = new Vector3(0, 0, -camTilt);
                Vector3 newerRot = AngleLerp(cam.transform.eulerAngles, newRot, 6f * Time.deltaTime);
                cam.transform.eulerAngles = newerRot;
            }
            else
            {
                Vector3 newRot = AngleLerp(cam.transform.eulerAngles, Vector3.zero, 10f * Time.deltaTime);
                cam.transform.eulerAngles = newRot;
            }
        }
        else
        {
            Vector3 deathRot = AngleLerp(cam.transform.eulerAngles, new Vector3(0, 0, -90f), 6f * Time.deltaTime);
            cam.transform.eulerAngles = deathRot;
        }


        //gravity and jumping!
        if (charCon.isGrounded)
        {
            vSpeed = -1;
            if ((Input.GetKeyDown(KeyCode.Space) || jumping) && (hitPoint > 0))
            {
                vSpeed = jump;
                Debug.Log("whee!");
            }
            Debug.Log("grounded");
            jumping = false;
        }
        else if (hitPoint > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
            }
            if (Input.GetKeyUp(KeyCode.Space) || !Input.GetKey(KeyCode.Space))
            {
                jumping = false;
            }
        }
        vSpeed -= gravity * Time.deltaTime;
        charCon.Move(vSpeed * Vector3.up * Time.deltaTime);

        
    }

    public void Activate()
    {
        go = true;
    }
    public void Hurt()
    {
        hitPoint--;
    }

    //thanks, guy from answers.unity.com!
    Vector3 AngleLerp(Vector3 StartAngle, Vector3 FinishAngle, float t)
    {
        float xLerp = Mathf.LerpAngle(StartAngle.x, FinishAngle.x, t);
        float yLerp = Mathf.LerpAngle(StartAngle.y, FinishAngle.y, t);
        float zLerp = Mathf.LerpAngle(StartAngle.z, FinishAngle.z, t);
        Vector3 Lerped = new Vector3(xLerp, yLerp, zLerp);
        return Lerped;
    }
}
