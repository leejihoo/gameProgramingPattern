using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Command buttonRight_ = new MoveRightCommand();
    private Command buttonUp_ = new MoveUpCommand();
    private Command buttonDown_ = new MoveDownCommand();
    private Command buttonLeft_ =  new MoveLeftCommand();
    private Command buttonSpace_ = new JumpCommand();
    private Command buttonX_ = new Attack();
    private Command nullValue = new NullCommand();


    public ref Command handlerInput()
    {
        
        if (Input.GetKey(KeyCode.RightArrow)) return ref buttonRight_; 
        if (Input.GetKey(KeyCode.UpArrow)) return ref buttonUp_;
        if (Input.GetKey(KeyCode.DownArrow)) return ref buttonDown_;
        if (Input.GetKey(KeyCode.LeftArrow)) return ref buttonLeft_;
        if (Input.GetKey(KeyCode.Space)) return ref buttonSpace_;
        if (Input.GetKey(KeyCode.X)) return ref buttonX_;
        return ref nullValue;
        
    }



}
