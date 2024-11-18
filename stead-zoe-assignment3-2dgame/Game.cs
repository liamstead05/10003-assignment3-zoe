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
        Vector2 positionplatformtophor = new Vector2(1000, 200);
        Vector2 positionplatformmidhor = new Vector2(750, 350);
        Vector2 positionplatformbothor = new Vector2(1200, 450);
        float widthplatform = 200;
        float heightplatform = 30;
        Vector2 velocityplatform;
        int speed1 = 200;
        int speed2 = 400;
        int speed3 = 150;
        Vector2 uiPosition;
        int score = 0;
        bool isPlayerAlive = true;

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

            // Collision for the cube
            float leftEdge1 = positioncube.X;
            float rightEdge1 = positioncube.X + radiuscube;
            float topEdge1 = positioncube.Y;
            float bottomEdge1 = positioncube.Y + radiuscube;

            // Design of the cube
            Draw.FillColor = Color.Yellow;
            Draw.LineColor = Color.Black;
            Draw.Square(positioncube, radiuscube);

            // Does something
            bool isPassedScreenRight = positionplatformmidhor.X + widthplatform >= Window.Width + 1;
            if (isPassedScreenRight == true)
            {
                velocityplatform.X = velocityplatform.X * 5f;
                positionplatformmidhor.X = Window.Width - widthplatform;
            }

            // Prevents the middle platform from sinking through the bottom of the screen
            bool isAboveScreenBottom = positionplatformmidhor.Y + heightplatform >= Window.Height + 0;
            if (isAboveScreenBottom == true)
            {
                velocityplatform.Y = -velocityplatform.Y * 0f;
                positionplatformmidhor.Y = Window.Height - heightplatform;
            }

            // Velocity of the middle platform
            positionplatformmidhor.X -= speed1 * Time.DeltaTime;

            // Collision for the middle platform
            float leftEdge2 = positionplatformmidhor.X;
            float rightEdge2 = positionplatformmidhor.X + widthplatform;
            float topEdge2 = positionplatformmidhor.Y;
            float bottomEdge2 = positionplatformmidhor.Y + heightplatform;

            // Detects the cube in the middle platform
            bool doesOverlapLeft1hor = leftEdge1 < rightEdge2;
            bool doesOverlapRight1hor = rightEdge1 > leftEdge2;
            bool doesOverlapTop1hor = topEdge1 < bottomEdge2;
            bool doesOverlapBottom1hor = bottomEdge1 > topEdge2;

            bool doesOverlap1hor = doesOverlapLeft1hor && doesOverlapRight1hor && doesOverlapTop1hor && doesOverlapBottom1hor;

            // Ends the game if collision detected
            if (doesOverlap1hor == true)
            {
                isPlayerAlive = false;
                positioncube.Y = topEdge2 - 50;
                positioncube.Y = bottomEdge2 - 50;
                positioncube.Y = leftEdge2 - 50;
                positioncube.Y = rightEdge2 - 50;
                velocitycube.Y = 0;
                velocityplatform.X = 0;
                speed1 = 0;
                speed2 = 0;
                speed3 = 0;
            }

            Text.Color = Color.Gray;
            Text.Draw("Score:" + score, uiPosition);

            // Design of the middle platform
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.White;
            Draw.Rectangle(positionplatformmidhor.X, positionplatformmidhor.Y, widthplatform, heightplatform);

            // Prevents the top platform from sinking through the bottom of the screen
            if (isAboveScreenBottom == true)
            {
                velocityplatform.Y = -velocityplatform.Y * 0f;
                positionplatformtophor.Y = Window.Height - heightplatform;
            }

            // Velocity of the top platform
            positionplatformtophor.X -= speed2 * Time.DeltaTime;

            // Collision for the top platform
            float leftEdge3 = positionplatformtophor.X;
            float rightEdge3 = positionplatformtophor.X + widthplatform;
            float topEdge3 = positionplatformtophor.Y;
            float bottomEdge3 = positionplatformtophor.Y + heightplatform;

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
                velocityplatform.X = 0;
                speed1 = 0;
                speed2 = 0;
                speed3 = 0;
            }

            // Design of the top platform
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.White;
            Draw.Rectangle(positionplatformtophor.X, positionplatformtophor.Y, widthplatform, heightplatform);

            // Prevents the bottom platform from sinking through the bottom of the screen
            if (isAboveScreenBottom == true)
            {
                velocityplatform.Y = -velocityplatform.Y * 0f;
                positionplatformbothor.Y = Window.Height - heightplatform;
            }

            // Velocity of the bottom platform
            positionplatformbothor.X -= speed3 * Time.DeltaTime;

            // Collision of the bottom platform
            float leftEdge4 = positionplatformbothor.X;
            float rightEdge4 = positionplatformbothor.X + widthplatform;
            float topEdge4 = positionplatformbothor.Y;
            float bottomEdge4 = positionplatformbothor.Y + heightplatform;

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
                velocityplatform.X = 0;
                speed1 = 0;
                speed2 = 0;
                speed3 = 0;
            }

            // Design of the bottom platform
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.White;
            Draw.Rectangle(positionplatformbothor.X, positionplatformbothor.Y, widthplatform, heightplatform);

        }
    }
}
