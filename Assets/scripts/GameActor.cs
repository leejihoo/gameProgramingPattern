using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
public class GameActor : MonoBehaviour
{
    
    float moveSpeed = 2f;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    NullCommand nullCommand = new NullCommand();
    // Start is called before the first frame update
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
        this.transform.localScale = new Vector3(this.transform.localScale.x * -1f, this.transform.localScale.y, this.transform.localScale.z);
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
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1f, this.transform.localScale.y, this.transform.localScale.z);
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
        animator.SetBool("isAttack", true);
    }

    public void Idle()
    {
        animator.SetBool("isMove", false);
        animator.SetBool("isAttack", false);
    }
}
