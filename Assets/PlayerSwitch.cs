using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class PlayerSwitch : MonoBehaviour
{
    //drag drop the Joystick child in the Inspector to animate
    // the joystick when moved
    public Transform Joystick;

    //this refers to the vive's touch pad or oculus's joystick
    //public SteamVR_Action_Vector2 moveAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("platformer", "Move");
    //this refers to a click event on the touch pad/joystick
    public SteamVR_Action_Boolean jumpAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("platformer", "Jump");
    public Text countText;
    public Text winText;

    //multiplier for ball movement
    //public float forceMult = 2.0f;
    
    //vertical force to add for jumping
    //public float upMult = 250.0f;

    //the original scene was on a different scale, so we've modified the multipler
    //public float joyMove = 0.01f;

    //Interactable script of this GameObject
    private Interactable interactable;

    //game ball's Rigidbody
    private Rigidbody ballRb;
    public GameObject BigPlayer;
    public GameObject LittlePlayer;
    //public int scoreCount = 0;

    
    //public MonoBehaviour playerScript;

    private void Start()
    {
        //get the Interactable script on this GameObject (the controller)
        interactable = GetComponent<Interactable>();
        
        //get the ball's Rigidbody so we can add force to it
        ballRb = GameObject.Find("/Ball").GetComponent<Rigidbody>();

        BigPlayer.SetActive(false);
        LittlePlayer.SetActive(true);
        
        //scoreCount = 0;
    }

    private void Update()
    {
        //Vector3 movement = Vector2.zero;
        bool jump = false;
        //if the controller is attached to the hand...
        if (interactable.attachedToHand)
        {
            //get the hand's type, LeftHand or RightHand so that the controller can be used in either hand
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            //get the touch pad/joystick x/y coordniates of that particular hand
            //Vector2 m = moveAction[hand].axis;
            //movement = new Vector3(m.x, 0, m.y);

            //if someone has "clicked" the touchpad/joystick, then they jump
            jump = jumpAction[hand].stateDown;
        }

        //Joystick.localPosition = movement * joyMove;

        // The movement of the ball is done relative to the controller.  
        // To do this, we get the angle with respect to the y-axis (vertical
        // in world space)
        //float rot = transform.eulerAngles.y;
        //movement = Quaternion.AngleAxis(rot, Vector3.up) * movement;

        if (jump)
        {
            BigPlayer.SetActive(!BigPlayer.activeInHierarchy);
            LittlePlayer.SetActive(!BigPlayer.activeInHierarchy);
        }
        //ballRb.AddForce(movement * this.forceMult);

    }
}
