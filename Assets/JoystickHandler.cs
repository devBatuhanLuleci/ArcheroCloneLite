using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickHandler : MonoBehaviour
{


    public Joystick joystick;

    public Vector2 InitJoystickRectPos;
    public Vector2 CurrentJoystickRectPos;
    public enum SwipeType { None, Left, Right, Up, Down, UpRight, DownRight }
    public SwipeType swipeType;



    public float minSwipeTime = 0.2f;
    public float currentTime = 0f;


    public enum MoveType { Idle, Left, Right, Up, Down }
    public MoveType moveType;

    public Text swipeTypeText;
    public Text moveTypeText;




    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            currentTime = 0f;

            InitJoystickRectPos = new Vector2(joystick.GetComponent<RectTransform>().position.x, joystick.GetComponent<RectTransform>().position.y);
            Debug.Log(joystick.GetComponent<RectTransform>().position.x);
        }
        if (Input.GetMouseButton(0))
        {
            swipeTypeText.text = "Swipe Type: " + swipeType.ToString();
            moveTypeText.text = "Move Type: "+ moveType.ToString();
            currentTime += Time.deltaTime;
            CurrentJoystickRectPos = new Vector2(joystick.GetComponent<RectTransform>().position.x, joystick.GetComponent<RectTransform>().position.y);

            var dist = new Vector2(CurrentJoystickRectPos.x - InitJoystickRectPos.x, CurrentJoystickRectPos.y - InitJoystickRectPos.y);
        //    Debug.Log("Uzaklık  X: " + dist.x + "  Y: " + dist.y);


            //if (currentTime >= minSwipeTime && swipeType != SwipeType.None)
            //{
            // //   InitJoystickRectPos = CurrentJoystickRectPos;
            //    currentTime = 0f;
            //}

            //else if (currentTime >= minSwipeTime)
            //{
            //    return;
            //}


            if ((Mathf.Abs(dist.x) <= 10f && Mathf.Abs(dist.y) <= 10f))
            {

                //  Debug.Log("idle");
              //  swipeType = SwipeType.None;


            }
            //else
            //{

            InitJoystickRectPos = Vector2.MoveTowards(InitJoystickRectPos, CurrentJoystickRectPos, Time.deltaTime * 3000);
           // Debug.Log(Vector2.Distance(InitJoystickRectPos, CurrentJoystickRectPos));
            if (Vector2.Distance(InitJoystickRectPos, CurrentJoystickRectPos) < .2f)
            {
                //movement 
                if ((Mathf.Abs(joystick.xAxis.value) <= 0.9f && Mathf.Abs(joystick.yAxis.value) <= 0.9f) )
                {

                    Debug.Log("idle");
                    moveType = MoveType.Idle;

                }
                else
                {



                    if (Mathf.Abs(joystick.xAxis.value) > Mathf.Abs(joystick.yAxis.value))
                    {

                        if ((joystick.xAxis.value > 0) && moveType != MoveType.Right)
                        {
                            Debug.Log("right");
                            moveType = MoveType.Right;
                        }
                        else if ((joystick.xAxis.value < 0) && moveType != MoveType.Left)
                        {
                            Debug.Log("left");
                            moveType = MoveType.Left;
                        }

                    }
                    else if (Mathf.Abs(joystick.yAxis.value) > Mathf.Abs(joystick.xAxis.value))
                    {

                        if ((joystick.yAxis.value > 0) && moveType != MoveType.Up)
                        {
                            Debug.Log("up");
                            moveType = MoveType.Up;
                        }
                        else if ((joystick.yAxis.value < 0) && moveType != MoveType.Down)
                        {
                            Debug.Log("down");
                            moveType = MoveType.Down;

                        }

                    }
                }

                currentTime = 0f;
            }
            else
            {
                float angle = Mathf.Atan2(dist.y, dist.x) * Mathf.Rad2Deg;
                // Debug.Log("açı: " + angle);
                Debug.Log(dist.x);
                if (angle >= 20f && angle <= 70f )
                {
                    if(swipeType!=SwipeType.UpRight)
                    swipeType = SwipeType.UpRight;


                }
              else   if (angle <= -20f && angle >= -70f )
                {
                    if (swipeType != SwipeType.DownRight)

                    {
                        swipeType = SwipeType.DownRight;

                    }


                }
                //attack
              
                else if ((Mathf.Abs(dist.x) / (float)currentTime) >= .2f && Mathf.Abs(dist.x) > Mathf.Abs(dist.y))
                {
                   
                    if ((dist.x > 1) && swipeType != SwipeType.Right)
                    {
                        //      Debug.Log("right");
                        swipeType = SwipeType.Right;
                    }
                    else if ((dist.x < 1) && swipeType != SwipeType.Left)
                    {
                        //    Debug.Log("left");
                        swipeType = SwipeType.Left;
                    }

                }
                else if ((Mathf.Abs(dist.y) / (float)currentTime) >= .2f && Mathf.Abs(dist.y) > Mathf.Abs(dist.x))
                {

                    if ((dist.y > 1) && swipeType != SwipeType.Up)
                    {
                        //  Debug.Log("up");
                        swipeType = SwipeType.Up;
                    }
                    else if ((dist.y < 1) && swipeType != SwipeType.Down)
                    {
                        //  Debug.Log("down");
                        swipeType = SwipeType.Down;

                    }
                }
                //         }
            }
            //if ((Mathf.Abs(joystick.xAxis.value) <= 0.1f && Mathf.Abs(joystick.yAxis.value) <= 0.1f )&& moveType!=MoveType.Idle)
            //{

            //    Debug.Log("idle");
            //    moveType = MoveType.Idle;

            //}
            //else
            //{



            //    if (Mathf.Abs(joystick.xAxis.value) > Mathf.Abs(joystick.yAxis.value) )
            //    {

            //        if ((joystick.xAxis.value > 0)&& moveType != MoveType.Right)
            //        {
            //            Debug.Log("right");
            //            moveType = MoveType.Right;
            //        }
            //        else if ((joystick.xAxis.value < 0)&& moveType != MoveType.Left)
            //        {
            //            Debug.Log("left");
            //            moveType = MoveType.Left;
            //        }

            //    }
            //    else if (Mathf.Abs(joystick.yAxis.value) > Mathf.Abs(joystick.xAxis.value))
            //    {

            //        if ((joystick.yAxis.value > 0)&& moveType != MoveType.Up)
            //        {
            //            Debug.Log("up");
            //            moveType = MoveType.Up;
            //        }
            //        else if ((joystick.yAxis.value < 0) && moveType != MoveType.Down)
            //        {
            //            Debug.Log("down");
            //            moveType = MoveType.Down;

            //        }

            //    }
            //}



        }

        else
        {
            if ((Mathf.Abs(joystick.xAxis.value) <= 0.1f && Mathf.Abs(joystick.yAxis.value) <= 0.1f) && moveType != MoveType.Idle)
            {

                Debug.Log("idle");
                moveType = MoveType.Idle;

            }
        }
    }
}
