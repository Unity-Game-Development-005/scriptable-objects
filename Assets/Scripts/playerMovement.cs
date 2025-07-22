
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public Vector2 inputDirection, lookDirection;
    Animator anim;


    // where the mouse moves from
    private Vector2 touchStart;

    // where the mouse moves to
    private Vector2 touchEnd;

    // the dpad control
    public GameObject dPad;

    // radius bounds of the dpad control
    public float dPadRadius = 15f;

    // touch phase and position
    private Touch theTouch;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //makes the character look down by default
        lookDirection = new Vector2(0, -1);
    }


    // Update is called once per frame
    void Update()
    {
        //getting input from keyboard controls
        calculateDesktopInputs();

        // get mouse input
        //calculateMobileInput();

        // get touch input
        //calculateTouchInput();

        //sets up the animator
        animationSetup();

        //moves the player
        transform.Translate(inputDirection * moveSpeed * Time.deltaTime);
    }


    void calculateDesktopInputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(x, y).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }

    }


    void animationSetup()
    {
        //checking if the player wants to move the character or not
        if (inputDirection.magnitude > 0.1f)
        {
            //changes look direction only when the player is moving, so that we remember the last direction the player was moving in
            lookDirection = inputDirection;

            //sets "isWalking" true. this triggers the walking blend tree
            anim.SetBool("isWalking", true);
        }
        else
        {
            // sets "isWalking" false. this triggers the idle blend tree
            anim.SetBool("isWalking", false);

        }

        //sets the values for input and lookdirection. this determines what animation to play in a blend tree
        anim.SetFloat("inputX", lookDirection.x);
        anim.SetFloat("inputY", lookDirection.y);
        anim.SetFloat("lookX", lookDirection.x);
        anim.SetFloat("lookY", lookDirection.y);
    }


    public void attack()
    {
        anim.SetTrigger("Attack");
    }


    void calculateMobileInput()
    {
        // if the left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            // show thw dpad control
            dPad.gameObject.SetActive(true);

            // when the left mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                // get the start position of the mouse
                touchStart = Input.mousePosition;
            }

            // while the left mouse button is pressed
            // get the end position of the mouse
            touchEnd = Input.mousePosition;

            // calculate the player's movement direction based on the position of the mouse
            float x = touchEnd.x - touchStart.x;

            float y = touchEnd.y - touchStart.y;

            // normalise the player's movement direction
            inputDirection = new Vector2(x, y).normalized;

            // if the movement of the mouse goes outside the radius bounds of the dpad control
            if ((touchEnd - touchStart).magnitude > dPadRadius)
            {
                // then set the position of the dpad control to the radius bounds
                dPad.transform.position = touchStart + (touchEnd - touchStart).normalized * dPadRadius;
            }

            // otherwise
            else
            {
                // simply move the dpad control to the new mouse position
                dPad.transform.position = touchEnd;
            }
        }

        // otherwise
        else
        {
            // stop the player moving
            inputDirection = Vector2.zero;

            // hide the dpad control
            dPad.gameObject.SetActive(false);
        }
    }


    private void calculateTouchInput()
    {
        // if at least one finger has touched the screen
        if (Input.touchCount > 0)
        {
            // get the first registered touch
            theTouch = Input.GetTouch(0);

            // show thw dpad control
            dPad.gameObject.SetActive(true);

            // if the touch phase is starting - equals 'began'
            if (theTouch.phase == TouchPhase.Began)
            {
                // get the start position of the touch
                touchStart = theTouch.position;
            }

            // otherwise
            // if the touch phase is equal to 'moved' or the touch phase equals 'ended'
            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                // get the end position of the touch
                touchEnd = theTouch.position;

                // calculate the player's movement direction based on the position of the touch
                float x = touchEnd.x - touchStart.x;

                float y = touchEnd.y - touchStart.y;

                // normalise the player's movement direction
                inputDirection = new Vector2(x, y).normalized;

                // if the movement of the mouse goes outside the radius bounds of the dpad control
                if ((touchEnd - touchStart).magnitude > dPadRadius)
                {
                    // then set the position of the dpad control to the radius bounds
                    dPad.transform.position = touchStart + (touchEnd - touchStart).normalized * dPadRadius;
                }

                // otherwise
                else
                {
                    // simply move the dpad control to the new mouse position
                    dPad.transform.position = touchEnd;
                }
            }
        }

        // otherwise
        else
        {
            // stop the player moving
            inputDirection = Vector2.zero;

            // hide the dpad control
            dPad.gameObject.SetActive(false);
        }
    }


} // end of class
