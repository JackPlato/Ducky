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
    private int score = 0;
    public GameOverScreenScript gameOver;
    public VictoryScript victory;
    public HPBar hpBar;
    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        hitPoint = health;
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameOver.finalScore = score;
        victory.finalScore = score;
        hpBar.max = health;
        hpBar.current = hitPoint;
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

    void MoveUpdate()
    {
        float strafe = 0f;
        if (hitPoint > 0)
        {
            gameOver.gameObject.SetActive(false);
            if (leftPress && !rightPress)
            {
                strafe = velocityStrafe * -1;
                Vector3 newRot = new Vector3(0, 0, camTilt);
                Vector3 newerRot = AngleLerp(cam.transform.eulerAngles, newRot, 6f * Time.deltaTime);
                cam.transform.eulerAngles = newerRot;
            }
            else if (rightPress && !leftPress)
            {
                strafe = velocityStrafe;
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
            strafe = 0f;
            gameOver.gameObject.SetActive(true);
            Vector3 deathRot = AngleLerp(cam.transform.eulerAngles, new Vector3(-90f, 0, 0), 6f * Time.deltaTime);
            cam.transform.eulerAngles = deathRot;
        }


        //gravity and jumping!
        if (charCon.isGrounded)
        {
            vSpeed = 0f;
            if ((Input.GetButtonDown("Jump") || jumping) && (hitPoint > 0))
            {
                vSpeed = jump;
                Debug.Log("whee!" + vSpeed);
            }
            //Debug.Log("grounded");
        }
        else if (hitPoint > 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumping = true;
            }
            if (Input.GetButtonUp("Jump") || !Input.GetButton("Jump"))
            {
                jumping = false;
            }
        }
        vSpeed -= gravity * Time.deltaTime;
        Vector3 finalMovement = new Vector3(strafe, vSpeed, (hitPoint > 0) ? velocityFwd : 0f);
        charCon.Move(finalMovement * Time.deltaTime);

        
    }

    public void Activate()
    {
        go = true;
    }
    public void Hurt()
    {
        hitPoint--;
    }
    public void Pitfall()
    {
        hitPoint = 0;
    }

    public void GetCoin(int s)
    {
        score += s;
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
