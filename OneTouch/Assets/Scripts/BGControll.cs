using UnityEngine;
using System.Collections;

public class BGControll : MonoBehaviour
{

    //Move Speed;  
    private float mSpeed = 100.0F;
    void Start()
    {

    }

    void Update()
    {
        //Translate form right to left  
        transform.Translate(Vector2.left * Time.deltaTime * mSpeed);
        // If first background is out of camera view,then show sencond background  
        if (transform.position.x <= -2560.0F)
        {
            //We can chenge this value to reduce the wdith between 2 background  
            transform.position = new Vector2(2560.0F, transform.position.y);
        }
    }
}