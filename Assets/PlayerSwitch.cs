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

    
    public SteamVR_Action_Boolean jumpAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("platformer", "Jump");
    public Text countText;
    public Text winText;

    private Interactable interactable;

    //game ball's Rigidbody
    private Rigidbody ballRb;
    public GameObject LittlePlayer;
    public GameObject Controller;
    public bool isBig = false;
    //public int scoreCount = 0;

    
    //public MonoBehaviour playerScript;

    private void Start()
    {
        //get the Interactable script on this GameObject (the controller)
        interactable = GetComponent<Interactable>();
        
        //get the ball's Rigidbody so we can add force to it
        ballRb = GameObject.Find("/Ball").GetComponent<Rigidbody>();

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
            if (isBig == false)
            {
                LittlePlayer.transform.localScale = new Vector3(35, 35, 35);
                LittlePlayer.transform.localPosition = new Vector3(25, 0, -20);
                Controller.transform.localScale = new Vector3(35, 40, 35);
                //Controller.transform.localPosition = new Vector3(1, -10, -3);
                isBig = true;

            }
            else
            {
                LittlePlayer.transform.localScale = new Vector3(1, 1, 1);
                LittlePlayer.transform.localPosition = new Vector3(1, 53, 1);
                Destroy(Controller);
                //Controller.transform.localScale = new Vector3(1, 1, 1);
                //Controller.transform.localPosition = new Vector3(2, 55, -4);
                isBig = false;
            }
            //BigPlayer.SetActive(!BigPlayer.activeInHierarchy);
            //LittlePlayer.SetActive(!BigPlayer.activeInHierarchy);
        }
        //ballRb.AddForce(movement * this.forceMult);

    }
}
