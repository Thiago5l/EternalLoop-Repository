using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;
using static UnityEngine.Rendering.DebugUI;

public class PlayerScript : MonoBehaviour
{

    public int vida;
    public float speed, jump_velocity_x, jump_velocity_y;

    public float shieldTime;
    public enum state { idle, run, shield, attack1, attack2, jump, hurt, die, finishJump, fall };
    public state MyState;


    private Animator myanimator;
    private Rigidbody2D myrigid;


    private GameObject escudo;



    // Start is called before the first frame update
    void Start()
    {

        SetState(state.idle);

        myanimator = GetComponent<Animator>();
        myrigid = GetComponent<Rigidbody2D>();
        escudo = GameObject.Find("shield");
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (MyState)
        {
            case state.idle:
                FunctionIdle();
                break;
            case state.run:
                FunctionRun();
                break;
            case state.shield:
                FunctionShield();
                break;
            case state.attack1:

                break;
            case state.attack2:

                break;
            case state.jump:
                FunctionJump();
                break;
            case state.hurt:

                break;
            case state.die:

                break;
            case state.fall:
                FunctiionFall();
                break;
            case state.finishJump:
                FunctionFinishJump();
                break;
            default:
                print("incorrect State");
                break;
        }

        
    }
    private void SetState(state newstate)
    {
        MyState = newstate;
    }

    private void FunctionIdle()
    {

        myanimator.Play("Player_Idle");

        ///////////////////////////////////////////

        //RUN
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            SetState(state.run);
            myrigid.gravityScale = 1;

        }

        //..............................................
        //SHIELD
        if (Input.GetButtonDown("Fire3")){
            SetState(state.shield);
            myrigid.gravityScale = 1;
        }

        //..............................................
        //JUMP

        if(Input.GetButtonDown("Jump") && GrouncCheckScript.tocosuelo )
        {
            SetState(state.jump);
            myrigid.gravityScale = 1;
        }

        if (myrigid.velocity.y < 0)
        {
            SetState(state.fall);
        }
    }


    private void FunctionRun()
    {
        myanimator.Play("Player_Run");
        UpdateMuvment();

        ///////////////////////////////////////////

        if (Input.GetKeyDown(KeyCode.E))
        {
            SetState(state.shield);
            myrigid.gravityScale = 1;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            SetState(state.idle);
        }

        if (Input.GetButtonDown("Jump") && GrouncCheckScript.tocosuelo)
        {
            SetState(state.jump);
            myrigid.gravityScale = 1;
        }
    }

    private void FunctionShield()
    {
        myanimator.Play("Player_Shield");
        ///////////////////////////////////////////
    }


    private void FunctionJump()
    {

        // myanimator.Play("Player_Jump");

        /*if (Input.GetAxisRaw("Horizontal") < 0)
        {
            myrigid.velocity = new Vector2(-jump_velocity_x, jump_velocity_y);

        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            myrigid.velocity = new Vector2(jump_velocity_x, jump_velocity_y);
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            myrigid.velocity = new Vector2(0, jump_velocity_y);
        }*/

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            myrigid.velocity = new Vector2(-jump_velocity_x, jump_velocity_y);
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            myrigid.velocity = new Vector3(0, jump_velocity_y);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            myrigid.velocity = new Vector3(jump_velocity_x, jump_velocity_y);
        }
        
        UpdateMuvment(); 

        ///////////////////////////////////////////


        SetState(state.finishJump);


    }

    private void FunctionFinishJump()
    {

        ///////////////////////////////////////////
        
        if (myrigid.velocity.y < 0)
        {
            SetState(state.fall);
        }
        UpdateMuvment();

    }

    private void FunctiionFall()
    {

        //myanimator.Play("Player_Falling");
        if (GrouncCheckScript.tocosuelo)
        {

            SetState(state.idle);

        }

        UpdateMuvment();
        ///////////////////////////////////////////

        if (myrigid.velocity.y == 0 && GrouncCheckScript.tocosuelo)
        {
            SetState(state.idle);
        }

    }


















    private void UpdateMuvment()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            myrigid.velocity = new Vector2(speed, myrigid.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            myrigid.velocity = new Vector2(-speed, myrigid.velocity.y);
        }
    }
}
