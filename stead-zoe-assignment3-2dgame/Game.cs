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
        Vector2 position;
        float radius = 35;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Window set size and title
            Window.SetTitle("Shape Bolt");
            Window.SetSize(800, 600);
        }

        void GetPlayerInput()
        {

            Vector2 input = Vector2.Zero;

            if (Input.IsKeyboardKeyDown(KeyboardInput.Up))
            {
                input.Y -= 1 + 1;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.Down))
            {
                input.Y += 1 + 1;
            }

            Input = input;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // Change background colour to selected background colour
            Window.ClearBackground(Color.OffWhite);

            position += Input * 100 * Time.DeltaTime;

            Draw.FillColor = Color.Yellow;
            Draw.LineColor = Color.Black;
            Draw.Square(105, 105, 75);
        }
    }
}
