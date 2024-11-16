// Include code libraries you need below (use the namespace).
using Microsoft.VisualBasic;
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        // Variables for the colours of the shapes
        Vector2 positioncube = new Vector2(200, 350);
        float radiuscube = 50;
        Vector2 velocitycube;
        Vector2 forceOfGravity = new Vector2(0, 10);
        Vector2 positionplatform = new Vector2(750, 350);
        float widthplatform = 200;
        float heightplatform = 30;
        Vector2 velocityplatform;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Window set size and title
            Window.SetTitle("Shape Bolt");
            Window.SetSize(800, 600);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // Change background colour to selected background colour
            Window.ClearBackground(Color.OffWhite);


            // Allows the player to control the cube's jump
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                velocitycube.Y = -5;
            }

            // Prevents the cube from sinking through the bottom of the screen
            bool isBelowScreenBottom = positioncube.Y + radiuscube >= Window.Height + 1;
            if (isBelowScreenBottom == true)
            {
                velocitycube.Y = -velocitycube.Y * 0f;
                positioncube.Y = Window.Height - radiuscube;
            }

            // Velocity of the cube
            velocitycube += forceOfGravity * Time.DeltaTime;
            positioncube += velocitycube;

            // Design of the cube
            Draw.FillColor = Color.Yellow;
            Draw.LineColor = Color.Black;
            Draw.Square(positioncube, radiuscube);


            bool isPassedScreenRight = positionplatform.X + widthplatform >= Window.Width + 1;
            if (isPassedScreenRight == true)
            {
                velocityplatform.X = -velocityplatform.X * -5f;
                positionplatform.X = Window.Width - widthplatform + heightplatform;
            }

            // Prevents the platform from sinking through the bottom of the screen
            bool isAboveScreenBottom = positionplatform.Y + heightplatform >= Window.Height + 0;
            if (isAboveScreenBottom == true)
            {
                velocityplatform.Y = -velocityplatform.Y * 0f;
                positionplatform.Y = Window.Height - heightplatform;
            }    

            // Velocity of the platform
            velocityplatform -= forceOfGravity * Time.DeltaTime;
            positionplatform -= velocityplatform;

            // Design of the platform
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.White;
            Draw.Rectangle(positionplatform.X, positionplatform.Y, widthplatform, heightplatform);
        }
    }
}
