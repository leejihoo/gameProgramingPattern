using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Events;

public class GameActorForStatePattern : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    NullCommand nullCommand = new NullCommand();
    // Start is called before the first frame update
    public int maxHp = 100;
    public int currentHp = 100;
    public int maxStamina = 5;
    public int currentStamina = 0;

    public UnityEvent playerHpChaged;
    public UnityEvent playerStaminaChaged;
    public bool staminaRecoveryDelay = false;
    public bool aAttackDelay = false;

    private GameActorState gameActorState;
    private AttackState attackState = new AttackState();
    private MoveDownState moveDownState = new MoveDownState();
    private MoveLeftState moveLeftState = new MoveLeftState();
    private MoveRightState moveRightState = new MoveRightState();
    private MoveUpState moveUpState = new MoveUpState();
    private IdleState idleState = new IdleState();
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        InputHandler inputHandler = new InputHandler();
        ref Command command = ref inputHandler.handlerInput();
        command.Execute(this.gameObject);
        gameActorState.updateState(this.gameObject);
        StaminaRecovery();
    }

    public void jump()
    {

    }

    public void MoveRight()
    {
        gameActorState = moveRightState;
    }
    public void MoveUp()
    {
        gameActorState = moveUpState;
    }
    public void MoveLeft()
    {
        gameActorState = moveLeftState;
    }
    public void MoveDown()
    {
        gameActorState = moveDownState;
    }

    public void Attack()
    {
        gameActorState = attackState;
    }

    public void Idle()
    {
        gameActorState = idleState;
    }

    public void Hurt()
    {
        currentHp -= 10;
        playerHpChaged.Invoke();
        Debug.Log("상처를 입었습니다.");
    }

    public void StaminaRecovery()
    {
        if (currentStamina == maxStamina)
            currentStamina = 0;

        if (!staminaRecoveryDelay)
            StartCoroutine(StaminaRecoveryDelay());
    }

    IEnumerator StaminaRecoveryDelay()
    {
        staminaRecoveryDelay = true;
        currentStamina += 1;
        Debug.Log("스태미나가 회복되었습니다.");
        playerStaminaChaged.Invoke();
        yield return new WaitForSeconds(1f);
        staminaRecoveryDelay = false;
    }

    IEnumerator AttackDelay()
    {
        aAttackDelay = true;
        animator.SetBool("isAttack", true);
        Debug.Log("공격딜레이");
        yield return new WaitForSeconds(1f);
        aAttackDelay = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");
        Destroy(this.gameObject);
    }
}
