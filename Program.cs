using System;

namespace OpenGLFW{
  class Program{
#if WINDOWS
    private const bool IS_WINDOWS = true;
#else
    private const bool IS_WINDOWS = false;
#endif

    private static float[] vertices = {
      -0.5f, -0.5f,
      0.5f, -0.5f,
      0.0f,  0.5f,
    };

    public static void Main(string[] args){
      // Console.WriteLine($"OpenGL version: {Gl.GetString(StringName.Version)}");
      // Console.WriteLine($"OpenGL shading version: {Gl.GetString(StringName.ShadingLanguageVersion)}");
      // Console.WriteLine($"OpenGL vendor: {Gl.GetString(StringName.Vendor)}");
      // Console.WriteLine($"OpenGL renderer: {Gl.GetString(StringName.Renderer)}");

      GLFW.Initialise();
      IntPtr window = GLFW.CreateWindow(800, 600, "test - " + (IS_WINDOWS ? "Windows" : "Not Windows"), IntPtr.Zero, IntPtr.Zero);
      GLFW.MakeContextCurrent(window);

      GL.LoadFunctionPointers();

      uint vao = 0;
      GL.GenVertexArrays(1, ref vao);
      GL.BindVertexArray(vao);

      uint vbo = 0;
      GL.GenBuffers(1, ref vbo);
      GL.BindBuffer(GL.ARRAY_BUFFER, vbo);
      GL.BufferData(GL.ARRAY_BUFFER, new IntPtr(sizeof(float) * vertices.Length), vertices, GL.STATIC_DRAW);

      GL.EnableVertexAttribArray(0);
      GL.VertexAttribPointer(0, 2, GL.FLOAT, false, 0, IntPtr.Zero);

      GL.ClearColor(0f, 0f, 0f, 1f);
      while(GLFW.WindowShouldClose(window) == 0){
        GL.Clear(GL.COLOR_BUFFER_BIT);

        GL.DrawArrays(GL.TRIANGLES, 0, 3);

        GLFW.SwapBuffers(window);
        GLFW.PollEvents();
      }
    }
  }
}
