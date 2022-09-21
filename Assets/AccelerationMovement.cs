using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationMovement : ProcessingLite.GP21
{
    float diameter = 2; // diameter of circle
    float posX; // x position of ball/circle
    float posY; // y position of ball/circle
    float v = 5; // constant velocity
    int a = 20; // constant acceleration


    void Start()
    {
        posX = Width / 2; //middle of the screen
        posY = Height / 2; //middle of the screen
    }   

    void Update()
    {
        Background(50, 166, 240);

        //add our new input to our x position
        posX += Input.GetAxis("Horizontal") * v * Time.deltaTime;
        posY += Input.GetAxis("Vertical") * v * Time.deltaTime;

        //detects input in all directions
        Vector2 m_input = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        //if any input then increase velocity until it reaches 10
        if(m_input.magnitude > 0)
        {
            v += a * Time.deltaTime;
            v = Mathf.Clamp(v, 0f, 10f);
        }
            
        //Teleports circle to other sice of screen if it exits from one side
        if(posX > Width)
            posX = 0;
        else if(posX < 0)
            posX = Width;

        if(posY > Height)
            posY = 0;
        else if(posY < 0)
            posY = Height;

        //Movable Circle
        Circle(posX, posY, diameter);

        //Extra Circles to make transition smoother
        Circle(posX+Width, posY+Height, diameter);
        Circle(posX+Width, posY, diameter);
        Circle(posX+Width, posY-Height, diameter);
        Circle(posX, posY+Height, diameter);
        Circle(posX, posY-Height, diameter);
        Circle(posX-Width, posY+Height, diameter);
        Circle(posX-Width, posY, diameter);
        Circle(posX-Width, posY-Height, diameter);
    }
}
