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
        Vector2 positionplatformtop = new Vector2(1000, 200);
        Vector2 positionplatformmid = new Vector2(750, 350);
        Vector2 positionplatformbot = new Vector2(1200, 450);
        float widthplatform = 200;
        float heightplatform = 30;
        Vector2 velocityplatform;
        int speed1 = 200;
        int speed2 = 400;
        int speed3 = 150;

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
            bool isPassedScreenRight = positionplatformmid.X + widthplatform >= Window.Width + 1;
            if (isPassedScreenRight == true)
            {
                velocityplatform.X = velocityplatform.X * 5f;
                positionplatformmid.X = Window.Width - widthplatform;
            }

            // Prevents the middle platform from sinking through the bottom of the screen
            bool isAboveScreenBottom = positionplatformmid.Y + heightplatform >= Window.Height + 0;
            if (isAboveScreenBottom == true)
            {
                velocityplatform.Y = -velocityplatform.Y * 0f;
                positionplatformmid.Y = Window.Height - heightplatform;
            }

            // Velocity of the middle platform
            positionplatformmid.X -= speed1 * Time.DeltaTime;

            // Collision for the middle platform
            float leftEdge2 = positionplatformmid.X;
            float rightEdge2 = positionplatformmid.X + widthplatform;
            float topEdge2 = positionplatformmid.Y;
            float bottomEdge2 = positionplatformmid.Y + heightplatform;

            // Detects the cube in the middle platform
            bool doesOverlapLeft1 = leftEdge1 < rightEdge2;
            bool doesOverlapRight1 = rightEdge1 > leftEdge2;
            bool doesOverlapTop1 = topEdge1 < bottomEdge2;
            bool doesOverlapBottom1 = bottomEdge1 > topEdge2;\

            bool doesOverlap1 = doesOverlapLeft1 && doesOverlapRight1 && doesOverlapTop1 && doesOverlapBottom1;

            // Ends the game if collision detected
            if (doesOverlap2 == true)
            {
                bool isGameOver();
            }

            // Design of the middle platform
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.White;
            Draw.Rectangle(positionplatformmid.X, positionplatformmid.Y, widthplatform, heightplatform);

            // Prevents the top platform from sinking through the bottom of the screen
            if (isAboveScreenBottom == true)
            {
                velocityplatform.Y = -velocityplatform.Y * 0f;
                positionplatformtop.Y = Window.Height - heightplatform;
            }

            // Velocity of the top platform
            positionplatformtop.X -= speed2 * Time.DeltaTime;

            // Collision for the top platform
            float leftEdge3 = positionplatformtop.X;
            float rightEdge3 = positionplatformtop.X + widthplatform;
            float topEdge3 = positionplatformtop.Y;
            float bottomEdge3 = positionplatformtop.Y + heightplatform;

            // Detects the cube in the top platform
            bool doesOverlapLeft2 = leftEdge1 < rightEdge3;
            bool doesOverlapRight2 = rightEdge1 > leftEdge3;
            bool doesOverlapTop2 = topEdge1 < bottomEdge3;
            bool doesOverlapBottom2 = bottomEdge1 > topEdge3;

            bool doesOverlap2 = doesOverlapLeft2 && doesOverlapRight2 && doesOverlapTop2 && doesOverlapBottom2;

            // Ends the game if collision detected
            if (doesOverlap2 == true)
            {
                bool isGameOver();
            }

            // Design of the top platform
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.White;
            Draw.Rectangle(positionplatformtop.X, positionplatformtop.Y, widthplatform, heightplatform);

            // Prevents the bottom platform from sinking through the bottom of the screen
            if (isAboveScreenBottom == true)
            {
                velocityplatform.Y = -velocityplatform.Y * 0f;
                positionplatformbot.Y = Window.Height - heightplatform;
            }

            // Velocity of the bottom platform
            positionplatformbot.X -= speed3 * Time.DeltaTime;

            // Collision of the bottom platform
            float leftEdge4 = positionplatformbot.X;
            float rightEdge4 = positionplatformbot.X + widthplatform;
            float topEdge4 = positionplatformbot.Y;
            float bottomEdge4 = positionplatformbot.Y + heightplatform;

            // Detects the cube in the bottom platform
            bool doesOverlapLeft3 = leftEdge1 < rightEdge4;
            bool doesOverlapRight3 = rightEdge1 > leftEdge4;
            bool doesOverlapTop3 = topEdge1 < bottomEdge4;
            bool doesOverlapBottom3 = bottomEdge1 > topEdge4;

            bool doesOverlap3 = doesOverlapLeft3 && doesOverlapRight3 && doesOverlapTop3 && doesOverlapBottom3;

            // Ends the game if collision detected
            if (doesOverlap3 == true)
            {
                bool isGameOver();
            }    

            // Design of the bottom platform
            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.White;
            Draw.Rectangle(positionplatformbot.X, positionplatformbot.Y, widthplatform, heightplatform);

        }
    }
}
