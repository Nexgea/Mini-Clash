using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour
{

    Rigidbody2D body;
    Transform trans;
    public float flyPower;
    private float flyPower_P;
    public float rotatePowerUp, rotatePowerDown;
    private float rotatePowerUp_P, rotatePowerDown_P;
    public float rotateUpLimit, rotateDownLimit;
    public float speed;
    private float speed_P;
    public float maxSpeed;
    Vector3 euler;
    public float angular;
    bool pressed;
    public float lerpSpeed;
    public bool buttonPressed;
    public float direction;
    


    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        trans = transform;
        euler = trans.eulerAngles;
        resetVariables();
    }

    void resetVariables()
    {
        rotatePowerUp_P = rotatePowerUp;
        rotatePowerDown_P = rotatePowerDown;
        flyPower_P = flyPower;
        speed_P = speed;
    }
    
   /* void rotateDown()
    {
        float angle = 0;
        angle = euler.z;
        Debug.Log(angle.ToString()+" angle");
        Debug.Log(euler.z.ToString()+ "euler");
        if (direction == 1)
        {
          
        }

        if (direction == -1)
        {
            angle = 180 - euler.z;
        }
        if (angle > 120)
        {
            if (angle < 280)
            {
                if (angular > -rotateDownLimit)
                {
              

                    rotatePowerDown_P += 200 * Time.deltaTime;
                    angular += rotatePowerDown_P * Time.deltaTime;
                }

                body.angularVelocity = angular * direction;

            }
        }
        else if ((angle > 280 && angular > 20))
        {
            angular = 10;
       
        }
        else if ((angle < 120 ))
        {
            if (angular > -rotateDownLimit)
            {
                
                rotatePowerDown_P += 200 * Time.deltaTime ;
                angular -= rotatePowerDown_P * Time.deltaTime;
          }

            body.angularVelocity = angular*direction;

        }

       
    }*/
  /*  void rotateDown()
    {
        euler = trans.eulerAngles;
        float angle = 0;
        angle = euler.z;
        if (direction == 1)
        {

        }

        if (direction == -1)
        {
            angle = 180 - euler.z;
        }
  
        if (angle > 120 && angle < 280)
        {
            if (angular  > -rotateDownLimit)
            {
                rotatePowerDown_P += 200 * Time.deltaTime;
                angular += rotatePowerDown_P * Time.deltaTime;
            }
            body.angularVelocity = angular*direction ;
        }
        else if (angle > 280 && angular > 20)
        {
            angular = 10;
        }
        else if (angle < 120)
        {
            if (angular  > -rotateDownLimit)
            {
                Debug.Log((angular * direction).ToString()+"  "+(-rotateDownLimit).ToString() );

                rotatePowerDown_P += 200 * Time.deltaTime;
                angular -= rotatePowerDown_P * Time.deltaTime;
            }
            body.angularVelocity = angular * direction;
        }

    }*/
    void rotateDown()
    {
        euler = trans.eulerAngles;
        float angle = euler.z;
        if (direction == -1)
        {
            //angle = 360 - euler.z;
           
         
                if((angle + 360)>360)
                {
                    angle = 360 - angle;
                }
                 if((angle + 360)<360)
                {
                    angle = 360 - (angle + 360);
                }
          
        }
        if (angle > 280 && angular > 20)
        {
            angular = 10;
            Debug.Log("10");
        }
        else if (angle < 280)
        {
            if (angular  > -rotateDownLimit)
            {

                rotatePowerDown_P += 200 * Time.deltaTime;
                // the parenthesis below should return either -1 or 1.
                angular += (angle < 120 ? -1 : 1) * rotatePowerDown_P * Time.deltaTime ;
            }
            body.angularVelocity = angular*direction;
        }
        //Debug.Log(angle.ToString());
    }
    void rotateUp()
    {
        euler = trans.eulerAngles;

        if (angular < rotateUpLimit)
        {
            if (angular < 0)
            {
                rotatePowerUp_P += 1000 * Time.deltaTime;
            }
            else
            {
                rotatePowerUp_P += 150 * Time.deltaTime;
            }
            angular += rotatePowerUp_P * Time.deltaTime;
        }
        body.angularVelocity = angular *  direction;
    }

    void flyUp()
    {
        body.AddForce(new Vector2(0, flyPower_P));
        if (flyPower_P > 0)
        {
            if(!pressed)
            flyPower_P -= 1000 * Time.deltaTime;
        }
        else
        {
            flyPower_P = 0;
        }
    }

    void moveForward()
    {
        speed_P += 100 * Time.deltaTime;
      
        Vector2 dir = DegreeToVector2(transform.eulerAngles.z);


        body.velocity = Vector3.Lerp(body.velocity, dir * speed_P *direction, Time.deltaTime * lerpSpeed);
  //      body.velocity = dir * speed_P;
       body.AddRelativeForce((Vector2.right * speed_P ) *direction);
        if (body.velocity.magnitude > maxSpeed)
        {

            body.velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed ;
           
        }
    }
    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        euler = trans.eulerAngles;
        float angle = euler.z;
        if (direction == -1)
        {
            //angle = 360 - euler.z;


            if ((angle + 360) > 360)
            {
                angle = 360 - angle;
            }
            if ((angle + 360) < 360)
            {
                angle = 360 - (angle + 360);
            }

        }
       
        //    
        if (buttonPressed)
        {
            rotateUp();
            flyUp();
            moveForward();
        }
        else
        {
            if (pressed)
            {
                rotateDown();
            }
        }


     

    }
    public void OnButtonRealese()
    {
        pressed = true;
        resetVariables();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        angular = 0;
        body.angularVelocity = angular;
        pressed = false;
    }
}
