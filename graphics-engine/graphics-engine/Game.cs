using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Window {
    public class Game : GameWindow {

        float[] vertices = {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
             0.5f, -0.5f, 0.0f, //Bottom-right vertex
             0.0f,  0.5f, 0.0f  //Top vertex
        };
        Shader shader;
        int VertexBufferObject;
        int VertexArrayObject;

       public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        public static void Main() {
        Game game = new Game(800, 600, "LearnOpenTK");
        game.Run(60.0);
        while (true) {
                game.shader.Use();
                GL.BindVertexArray(game.VertexArrayObject);
                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            }
        }
            
        protected override void OnLoad(EventArgs e) {
            //decides the color of the window after it gets cleared between frames.
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            //Code goes here
            //This function runs one time, when the window first opens. Any initialization-related code should go here.
            VertexBufferObject = GL.GenBuffer();
            shader = new Shader("shader.vert", "shader.frag");

            base.OnLoad(e);

            VertexArrayObject = GL.GenVertexArray();

            // 1. bind Vertex Array Object
            GL.BindVertexArray(VertexArrayObject);
            // 2. copy our vertices array in a buffer for OpenGL to use
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            // 3. then set our vertex attributes pointers
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            shader.Use();
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
            shader.Dispose();
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            //clears the screen, using the color set in OnLoad
            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Code goes here.

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        //This function runs every time the window gets resized
        protected override void OnResize(EventArgs e) {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

    }
}   