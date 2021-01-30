using System;
using System.Collections;
using System.Collections.Generic;
using BodyNumber;
using CharacterState;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Rendering.PostProcessing;

public class PlayerController : MonoBehaviour
{
    //変更前のステート名
    private string _prevStateName;
    
    //ステート
    public StateProcessor StateProcessor { get; set; } = new StateProcessor();
    public CharacterStateIdle StateIdle { get; set; } = new CharacterStateIdle();
    public CharacterStateRun StateRun { get; set; } = new CharacterStateRun();
    public CharacterStateAir StateAir { get; set; } = new CharacterStateAir();
    public CharacterStateOver StateOver { get; set; } = new CharacterStateOver();

    public List<GameObject> bodyParts;
    
    [SerializeField] private PlayerParameter playerParameter;
    
    [SerializeField] private Rigidbody2D m_rigidbody2D;
    // [SerializeField] protected Animator m_animator;
    public bool m_isGround/* { get; set; }*/;
    [SerializeField] private ContactFilter2D _groundFilter2D;

    private bool moveableFlag;
    private bool  highMoveableFlag;
    private bool  openableDoorFlag;
    private bool  highOpenableDoorFlag;
    private bool  viewableFieldFlag;
    private bool highViewableFieldFlag;
    private bool  hearableFlag;
    private void Awake()
    {
        StateProcessor.State.Value = StateIdle;
        StateIdle.ExecAction = Idle;
        StateRun.ExecAction = Run;
        StateAir.ExecAction = Air;
        StateOver.ExecAction = Over;
        
        //パーツの集まり具合でフラグをオンにして、歩行や視界を広くする等の機能を増やしていく
        //この関数はパーツが集まったらできる機能を増やすためのフラグを動作させるもの
        inisActionFlag();
    }
    private void Start()
    {
        // var jumpableFlag = false;
        //ステートの値が変更されたら実行処理を行うようにする
        StateProcessor.State
            .Where(_ => StateProcessor.State.Value.GetStateName() != _prevStateName)
            .Subscribe(_ =>
            {
                Debug.Log("Now State:" + StateProcessor.State.Value.GetStateName());
                _prevStateName = StateProcessor.State.Value.GetStateName();
                StateProcessor.Execute();
            })
            .AddTo(this);
        
        // this.UpdateAsObservable()
        //     .Where(_ => (bodyParts[Define.RIGHTLEG].activeSelf || bodyParts[Define.LEFTLEG].activeSelf))
        //     .Subscribe(_ => jumpableFlag = true);

        foreach (var part in bodyParts)
        {
            part.SetActive(false);
        }
    }

    private void Update()
    {
        var _x = Input.GetAxis("Horizontal");
        var _jump = Input.GetButton("Jump");
        // m_animator.SetFloat("Horizontal", move);
        // m_animator.SetFloat("Vertical", m_rigidbody2D.velocity.y);
        // m_animator.SetBool("isGround", m_isGround);
        Move(_x, _jump);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var pickupable = other.gameObject.GetComponent<IPickupable>();
        if (pickupable != null)
        {
            pickupable.PickedUp(this);
            Debug.Log("Caught");
        }
        
        //なんでもぶつかったら
        // isJump = false;
        // animator.SetTrigger("idle");

        //片手で開けられるドア
        if (other.gameObject.tag == "doorOne")
        {
            if (openableDoorFlag)
            {
                //ドアが空く
                other.gameObject.GetComponentInParent<DoorController>().DoorOpen();
            }

        }

        //両手で開けるドア
        if (other.gameObject.tag == "doorTwo")
        {
            if (highOpenableDoorFlag)
            {
                //ドアが空く
                other.gameObject.GetComponentInParent<DoorController>().DoorOpen();
            }

        }
    }


    private void inisActionFlag()
    {
        moveableFlag = false;
        highMoveableFlag = false;
        openableDoorFlag = false;
        viewableFieldFlag = false;
        highViewableFieldFlag = false;
        hearableFlag = false;
        
        this.UpdateAsObservable()
            .Where(_ => (bodyParts[Define.RIGHTLEG].activeSelf || bodyParts[Define.LEFTLEG].activeSelf))
            .Subscribe(_ => moveableFlag = true);
        
        this.UpdateAsObservable()
            .Where(_ => (bodyParts[Define.RIGHTLEG].activeSelf && bodyParts[Define.LEFTLEG].activeSelf))
            .Subscribe(_ => highMoveableFlag = true);
        
        this.UpdateAsObservable()
            .Where(_ => (bodyParts[Define.RIGHTHAND].activeSelf || bodyParts[Define.LEFTHAND].activeSelf))
            .Subscribe(_ => openableDoorFlag = true);
        
        this.UpdateAsObservable()
            .Where(_ => (bodyParts[Define.RIGHTHAND].activeSelf && bodyParts[Define.LEFTHAND].activeSelf))
            .Subscribe(_ => highOpenableDoorFlag = true);
        
        this.UpdateAsObservable()
            .Where(_ => (bodyParts[Define.RIGHTEYE].activeSelf || bodyParts[Define.LEFTEYE].activeSelf))
            .Subscribe(_ => viewableFieldFlag = true);
        
        this.UpdateAsObservable()
            .Where(_ => (bodyParts[Define.RIGHTEYE].activeSelf && bodyParts[Define.LEFTEYE].activeSelf))
            .Subscribe(_ => highViewableFieldFlag = true);
        
        this.UpdateAsObservable()
            .Where(_ => (bodyParts[Define.HEAD].activeSelf))
            .Subscribe(_ => hearableFlag = true);
    }

    private void Move(float x, bool jump)
    {
        m_isGround = m_rigidbody2D.IsTouching(_groundFilter2D);
        var _velosity = m_rigidbody2D.velocity;
        
        if (moveableFlag || highMoveableFlag)
        {

            m_rigidbody2D.velocity = highMoveableFlag
                ? new Vector2(x * playerParameter.HIGHRUN_SPEED, _velosity.y)
                : new Vector2(x * playerParameter.RUN_SPEED, _velosity.y);
            if (m_isGround)
            {
                if (jump)
                {
                    // m_animator.SetTrigger("Jump");
                    if (highMoveableFlag)
                    {
                        m_rigidbody2D.AddForce(Vector2.up * playerParameter.HIGHJUMP_POWER);
                    }
                    else
                    {
                        m_rigidbody2D.AddForce(Vector2.up * playerParameter.JUMP_POWER);
                    }

                    StateProcessor.State.Value = StateAir;
                }

                else if (Mathf.Abs(x) > 0)
                {
                    StateProcessor.State.Value = StateRun;
                    var rot = transform.rotation;
                    // transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(_playerInput.X) == 1 ? 0 : 180, rot.z);
                }
                else
                {
                    StateProcessor.State.Value = StateIdle;
                }
            }
        }
        else
        {
            m_rigidbody2D.velocity = new Vector2(x * playerParameter.LOWRUN_SPEED, _velosity.y);
            if (m_isGround)
            {
                if (jump)
                {
                    // m_animator.SetTrigger("Jump");
                    m_rigidbody2D.AddForce(Vector2.up * playerParameter.LOWJUMP_POWER);
                    StateProcessor.State.Value = StateAir;
                }

                else if (Mathf.Abs(x) > 0)
                {
                    StateProcessor.State.Value = StateRun;
                }
                else
                {
                    StateProcessor.State.Value = StateIdle;
                }
            }   
        }
    }
    
    public void Idle()
    {

    }
    public void Run()
    {
        
    }
    public void Air()
    {
        //_playerMover.Jump(m_animator, JUMP_POWER);
    }
    

    public void Over()
    {
        
    }
}