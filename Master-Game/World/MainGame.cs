using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace MasterGame.World
{
    class MainGame
    {
        /*
         Tutorial: 
         http://www.siltutorials.com/opentkbasicsindex
             */
        public GameWindow window;
        private int WidthLength;
        private int HeightLength;

        public MainGame(GameWindow userInput, int userWidthLength, int userHeightLength)
        {
            window = userInput;
            window.Load += Window_Load;
            window.UpdateFrame += Window_UpdateFrame;
            window.RenderFrame += Window_RenderFrame;
            HeightLength = userHeightLength;
            WidthLength = userWidthLength;
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.ClearColor(Color.CornflowerBlue); // Set the color of the backgorund
            GL.Clear(ClearBufferMask.ColorBufferBit);
            
            for (int rowNumber = 1; rowNumber <= HeightLength; rowNumber++)
            {
                for (int squareNumber = 1; squareNumber <= WidthLength; squareNumber++)
                {

                    // Make squre along the x axies
                    float centerLocation = (float)squareNumber * 0.2f - .95f;
                    float rowLocation = (float)rowNumber * 0.2f - 0.95f;

                    GL.Begin(PrimitiveType.Polygon);

                    GL.Vertex3(centerLocation - 0.05, -0.05 + rowLocation, 0);
                    GL.Vertex3(centerLocation - 0.05, 0.05 + rowLocation, 0);
                    GL.Vertex3(centerLocation + 0.05, 0.05 + rowLocation, 0);
                    GL.Vertex3(centerLocation + 0.05, -0.05 + rowLocation, 0);

                    GL.End();
                }
            }

            window.SwapBuffers(); //Swaps the screens to display what we drew
        }

        private void Window_UpdateFrame(object sender, FrameEventArgs e)
        {
            
        }

        private void Window_Load(object sender, EventArgs e)
        {
            
        }
    }
}
