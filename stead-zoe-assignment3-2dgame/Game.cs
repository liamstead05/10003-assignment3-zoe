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
        Vector2 position = new Vector2(200, 350);
        float radius = 50;
        Vector2 velocity;
        Vector2 forceOfGravity = new Vector2(0, 10);

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
                velocity.Y = -5;
            }

            // Prevents the cube from sinking through the bottom of the screen
            bool isBelowScreenBottom = position.Y + radius >= Window.Height + 1;
            if (isBelowScreenBottom == true)
            {
                velocity.Y = -velocity.Y * 0f;
                position.Y = Window.Height - radius;
            }

            // Velocity of the cube
            velocity += forceOfGravity * Time.DeltaTime;
            position += velocity;

            // Design of the cube
            Draw.FillColor = Color.Yellow;
            Draw.LineColor = Color.Black;
            Draw.Square(position, radius);

            
        }
    }
}
