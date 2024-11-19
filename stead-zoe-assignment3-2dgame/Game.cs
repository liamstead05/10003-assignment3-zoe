// Include code libraries you need below (use the namespace).
using Microsoft.VisualBasic;
using stead_zoe_assignment3_2dgame;
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
        Vector2 uiPosition;
        int score = 0;
        bool isPlayerAlive = true;
        int spawnplatforms = 10;

        // Platform class calling
        platforms plat = new platforms();
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
            if (Input.IsMouseButtonPressed(MouseInput.Left) || Input.IsKeyboardKeyPressed(KeyboardInput.Space))
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

            bool isAboveScreenTop = positioncube.Y + radiuscube >= Window.Height + 1;
            if (isAboveScreenTop == true)
            {
                velocitycube.Y = -velocitycube.Y * 0f;
                positioncube.Y = Window.Height + radiuscube;
            }

            // Velocity of the cube
            velocitycube += forceOfGravity * Time.DeltaTime;
            positioncube += velocitycube;

            // Collision for the cube
            float leftEdge1 = positioncube.X;
            float rightEdge1 = positioncube.X + radiuscube;
            float topEdge1 = positioncube.Y;
            float bottomEdge1 = positioncube.Y + radiuscube;

            // Design of the cube
            Draw.FillColor = Color.Yellow;
            Draw.LineColor = Color.Black;
            Draw.Square(positioncube, radiuscube);

            Text.Draw("Score:" + plat.score, 50, 50);

            // Velocity of the top platform
            plat.positionplatformtophor.X -= plat.speed * Time.DeltaTime;

            // Collision for the top platform
            float leftEdge3 = plat.positionplatformtophor.X;
            float rightEdge3 = plat.positionplatformtophor.X + plat.widthplatform;
            float topEdge3 = plat.positionplatformtophor.Y;
            float bottomEdge3 = plat.positionplatformtophor.Y + plat.heightplatform;

            // Detects the cube in the top platform
            bool doesOverlapLeft2hor = leftEdge1 < rightEdge3;
            bool doesOverlapRight2hor = rightEdge1 > leftEdge3;
            bool doesOverlapTop2hor = topEdge1 < bottomEdge3;
            bool doesOverlapBottom2hor = bottomEdge1 > topEdge3;

            bool doesOverlap2hor = doesOverlapLeft2hor && doesOverlapRight2hor && doesOverlapTop2hor && doesOverlapBottom2hor;

            // Ends the game if collision detected
            if (doesOverlap2hor == true)
            {
                isPlayerAlive = false;
                positioncube.Y = topEdge3 - 50;
                positioncube.Y = bottomEdge3 - 50;
                positioncube.Y = leftEdge3 - 50;
                positioncube.Y = rightEdge3 - 50;
                velocitycube.Y = 0;
                plat.velocityplatform.X = 0;
                plat.speed = 0;
                forceOfGravity.Y = 0;
            }

            plat.DrawPlatform();

            plat.Detect();

            // Velocity of the bottom platform
            plat.positionplatformbothor.X -= plat.speed * Time.DeltaTime;

            // Collision of the bottom platform
            float leftEdge4 = plat.positionplatformbothor.X;
            float rightEdge4 = plat.positionplatformbothor.X + plat.widthplatform;
            float topEdge4 = plat.positionplatformbothor.Y;
            float bottomEdge4 = plat.positionplatformbothor.Y + plat.heightplatform;

            // Detects the cube in the bottom platform
            bool doesOverlapLeft3hor = leftEdge1 < rightEdge4;
            bool doesOverlapRight3hor = rightEdge1 > leftEdge4;
            bool doesOverlapTop3hor = topEdge1 < bottomEdge4;
            bool doesOverlapBottom3hor = bottomEdge1 > topEdge4;

            bool doesOverlap3hor = doesOverlapLeft3hor && doesOverlapRight3hor && doesOverlapTop3hor && doesOverlapBottom3hor;

            // Ends the game if collision detected
            if (doesOverlap3hor == true)
            {
                isPlayerAlive = false;
                positioncube.Y = topEdge4 - 50;
                positioncube.Y = bottomEdge4 - 50;
                positioncube.Y = leftEdge4 - 50;
                positioncube.Y = rightEdge4 - 50;
                velocitycube.Y = 0;
                plat.velocityplatform.X = 0;
                plat.speed = 0;
            }

            

        }
    }
}
