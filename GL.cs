using System;
using System.Runtime.InteropServices;

namespace OpenGLFW{
  static class GL{
    public const int ARRAY_BUFFER = 0x8892;
    public const int STATIC_DRAW = 0x88E4;
    public const int FLOAT = 0x1406;
    public const int TRIANGLES = 0x0004;
    public const int COLOR_BUFFER_BIT = 0x4000;

#if WINDOWS
    private const string OPENGL_DLL = "opengl32";
#else
    private const string OPENGL_DLL = "libGL";
#endif

    [DllImport(OPENGL_DLL, EntryPoint = "glDrawArrays")] public static extern void DrawArrays(int mode, int first, int count);
    public delegate void glGenBuffers(int n, ref uint buffers);
    public delegate void glBindBuffer(uint target, uint buffer);
    public delegate void glBufferData(uint target, IntPtr size, float[] data, uint usage);
    public delegate void glEnableVertexAttribArray(uint index);
    public delegate void glVertexAttribPointer(uint indx, int size, uint type, bool normalized, int stride, IntPtr ptr);
    public delegate void glGenVertexArrays(int n, ref uint arrays);
    public delegate void glBindVertexArray(uint array);
    public delegate void glClearColor(float r, float g, float b, float a);
    public delegate void glClear(int mask);
    public static glGenBuffers GenBuffers;
    public static glBindBuffer BindBuffer;
    public static glBufferData BufferData;
    public static glEnableVertexAttribArray EnableVertexAttribArray;
    public static glVertexAttribPointer VertexAttribPointer;
    public static glGenVertexArrays GenVertexArrays;
    public static glBindVertexArray BindVertexArray;
    public static glClearColor ClearColor;
    public static glClear Clear;

    public static T GetMethod<T>(){
      IntPtr funcPtr = GLFW.GetProcAddress(typeof(T).Name);

      if(funcPtr == IntPtr.Zero){
        Console.WriteLine($"Unable to load Function Pointer: {typeof(T).Name}");
        return default(T);
      }

      return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
    }

    public static void LoadFunctionPointers(){
      GenBuffers = GetMethod<glGenBuffers>();
      BindBuffer = GetMethod<glBindBuffer>();
      BufferData = GetMethod<glBufferData>();
      EnableVertexAttribArray = GetMethod<glEnableVertexAttribArray>();
      VertexAttribPointer = GetMethod<glVertexAttribPointer>();
      GenVertexArrays = GetMethod<glGenVertexArrays>();
      BindVertexArray = GetMethod<glBindVertexArray>();
      ClearColor = GetMethod<glClearColor>();
      Clear = GetMethod<glClear>();
    }
  }
}
