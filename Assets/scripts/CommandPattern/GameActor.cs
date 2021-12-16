using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Events;

public class GameActor : MonoBehaviour
{
    
    float moveSpeed = 2f;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler inputHandler = new InputHandler();
        ref Command command = ref inputHandler.handlerInput();
        command.Execute(this.gameObject);
        if (command != nullCommand)
        {
            command.Execute(this.gameObject);
        }

        StaminaRecovery();
    }

    public void jump()
    {
         
    }

    public void MoveRight()
    {
        Vector3 dir = Vector3.right;
        animator.SetBool("isMove", true);
        //스프라이트 반전
        if(this.transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1f, this.transform.localScale.y, this.transform.localScale.z);
        }
        this.transform.Translate(dir * moveSpeed * Time.deltaTime);
        
    }
    public void MoveUp()
    {
        Vector3 dir = Vector3.up;
        animator.SetBool("isMove", true);
        this.transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    public void MoveLeft()
    {
        Vector3 dir = Vector3.left;
        animator.SetBool("isMove", true);
        // 스프라이트 반전
        if (this.transform.localScale.x > 0)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1f, this.transform.localScale.y, this.transform.localScale.z);
        }      
        this.transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    public void MoveDown()
    {
        Vector3 dir = Vector3.down;
        animator.SetBool("isMove", true);
        this.transform.Translate(dir * moveSpeed * Time.deltaTime);
        
    }

    public void Attack()
    {
        if (!aAttackDelay)
            StartCoroutine(AttackDelay());
    }

    public void Idle()
    {
        animator.SetBool("isMove", false);
        animator.SetBool("isAttack", false);
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
        Hurt();
        Debug.Log("공격딜레이");
        yield return new WaitForSeconds(1f);
        aAttackDelay = false;
    }
}
