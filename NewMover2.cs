using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMover2 : MonoBehaviour {

    static Animator anim;
    public float speedw = 3.0F,speedr = 5.0F, scalef,dist,x1,y1,div,xr,zr,xw,zw;
    public float ang1 = 0F,rot1;
    Vector2 coc, diff;
    Vector3 newV;
    private float Rad = Screen.height / 2;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
       // transform.Rotate(0, 90, 90);
    }
	
	// Update is called once per frame
	void Update () {
        

        Touch touch0 = Input.GetTouch(0);
        if(touch0.phase == TouchPhase.Began)
        {
            coc = touch0.position;
           // transform.Rotate(0, 45, 0);
        }
        else if (touch0.phase == TouchPhase.Moved)
        {
            x1 = touch0.position.x-coc.x;
            y1 = touch0.position.y-coc.y;
            dist = Vector2.Distance(touch0.position, coc);
            div = y1 / x1;
            
            
            if (div > 5.67 || div < -5.67)
            {
                if (y1 > 0 && dist > Rad)
                {
                    xr = (speedr / dist) * x1;
                    zr = (speedr / dist) * y1;
                    anim.SetBool("IsRunning", true);
                    newV.Set(xr, 0, zr);
                    transform.Translate(newV * Time.deltaTime);
                }
                else if(y1 < 0)
                {
                    xw = (speedw / dist) * x1;
                    zw = (speedw / dist) * y1;
                    anim.SetBool("IsWalkingDown", true);
                    newV.Set(xw, 0, zw);
                    transform.Translate(newV * Time.deltaTime);
                }
                else
                {
                    xw = (speedw / dist) * x1;
                    zw = (speedw / dist) * y1;
                    anim.SetBool("IsWalking", true);
                    newV.Set(xw, 0, zw);
                    transform.Translate(newV * Time.deltaTime);
                }
            }
            else if(x1 < 0)
            {
                if (y1 > 0 && div < -0.57 && dist > Rad)
                {
                    xr = (speedr / dist) * x1;
                    zr = (speedr / dist) * y1;
                   // anim.SetBool("IsLeft", false);
                    anim.SetBool("IsRunning", true);
                    anim.SetBool("IsLeft", false);
                    newV.Set(xr, 0, zr);
                    transform.Translate(newV * Time.deltaTime);
                    rot1 = Mathf.Atan2(x1, y1) * Mathf.Rad2Deg;
                    transform.Rotate(0, rot1 - ang1, 0);
                    ang1 = rot1;
                    //   transform.Rotate(0, Mathf.Atan2(x1, y1) * Mathf.Rad2Deg * Time.deltaTime, 0);
                }
                else
                {
                    xw = (speedw / dist) * x1;
                    zw = (speedw / dist) * y1;
                   // anim.SetBool("IsRunning", false);
                    anim.SetBool("IsLeft", true);
                    newV.Set(xw, 0, zw);
                   transform.Translate(newV * Time.deltaTime);
                }
            }
            else if (x1 > 0)
            {
                if (y1 > 0 && div > 0.57 && dist > Rad)
                {
                    xr = (speedr / dist) * x1;
                    zr = (speedr / dist) * y1;
                   // anim.SetBool("IsRight", false);
                    anim.SetBool("IsRunning", true);
                    anim.SetBool("IsRight", false);
                    newV.Set(xr, 0, zr);
                    transform.Translate(newV * Time.deltaTime);
                    rot1 = Mathf.Atan2(x1, y1) * Mathf.Rad2Deg;
                    Debug.Log("Hii" + rot1 + "This is rot");
                    transform.Rotate(0,rot1-ang1,0);
                    Debug.Log("Hii" + (rot1-ang1) + "This is angle");
                    ang1 = rot1;
                    
                }
                else
                {
                    xw = (speedw / dist) * x1;
                    zw = (speedw / dist) * y1;
                   // anim.SetBool("IsRunning", false);
                    anim.SetBool("IsRight", true);
                    newV.Set(xw, 0, zw);
                    transform.Translate(newV * Time.deltaTime);
                }
            }

        }
        else if(touch0.phase == TouchPhase.Stationary)
        {
            transform.Translate(newV * Time.deltaTime);
        }
        else if(touch0.phase == TouchPhase.Ended)
        {
            newV.Set(0, 0, 0);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsRight", false);
            anim.SetBool("IsLeft", false);
            anim.SetBool("IsWalkingDown", false);
            anim.Play("Idle");
            transform.Rotate(0,-ang1, 0);
            ang1 = 0F;
        }


    }
}
