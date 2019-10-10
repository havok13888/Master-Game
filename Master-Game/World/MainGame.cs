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

        public MainGame(GameWindow userInput)
        {
            window = userInput;
            window.Load += Window_Load;
            window.UpdateFrame += Window_UpdateFrame;
            window.RenderFrame += Window_RenderFrame;
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.ClearColor(Color.CornflowerBlue); // Set the color of the backgorund
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //GL.Begin(PrimitiveType.Triangles);

            //Triangle 1
            /*
            GL.Vertex2(0, 0);
            GL.Vertex2(1, 0);
            GL.Vertex2(0, 1);
            */
            //Triangle 2
            /*
            GL.Vertex2(0, 0);
            GL.Vertex2(-1, 0);
            GL.Vertex2(0, -1);
            */
            //GL.End();

            for(int squareNumber = 1; squareNumber <= 10; squareNumber++)
            {
                // Make squre along the x axies
                float centerLocation = (float)squareNumber * 0.2f - .95f;

                GL.Begin(PrimitiveType.Polygon);

                GL.Vertex3(centerLocation - 0.05, - 0.05, 0);
                GL.Vertex3(centerLocation - 0.05, 0.05, 0);
                GL.Vertex3(centerLocation + 0.05, 0.05, 0);
                GL.Vertex3(centerLocation + 0.05, - 0.05, 0);

                GL.End();
            }
            /*
            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0.5, 0, 0);
            GL.Vertex3(0.5, .75, 0);
            GL.Vertex3(0, .75, 0);
           
            GL.End();
            */
            //Drawings will go here

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
