using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public int vida;
    public float speed;
    public enum state { idle, run, shield, attack1, attack2, jump, hurt, die, finishJump, fall };
    public state MyState;


    private Animator myanimator;
    private Rigidbody2D myrigid;





    // Start is called before the first frame update
    void Start()
    {

        SetState(state.idle);

        myanimator = GetComponent<Animator>();
        myrigid = GetComponent<Rigidbody2D>();

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

                break;
            case state.hurt:

                break;
            case state.die:

                break;
            case state.fall:

                break;
            case state.finishJump:

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


        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            SetState(state.run);
            myrigid.gravityScale = 1;

        }
    }


    private void FunctionRun()
    {

        UpdateMuvment();

        ///////////////////////////////////////////

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            SetState(state.run);
        }
    }

    private void FunctionShield()
    {
        myanimator.Play("shield");
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
