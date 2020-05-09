using System;
using System.Runtime.InteropServices;

namespace OpenGLFW{
  static class GLFW{
#if WINDOWS
    private const string GLFW_DLL = "glfw3";
#else
    private const string GLFW_DLL = "glfw";
#endif

    [DllImport(GLFW_DLL, EntryPoint = "glfwInit")] public static extern bool Initialise();
    [DllImport(GLFW_DLL, EntryPoint = "glfwCreateWindow")] public static extern IntPtr CreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share);
    [DllImport(GLFW_DLL, EntryPoint = "glfwMakeContextCurrent")] public static extern void MakeContextCurrent(IntPtr window);
    [DllImport(GLFW_DLL, EntryPoint = "glfwSwapBuffers")] public static extern void SwapBuffers(IntPtr window);
    [DllImport(GLFW_DLL, EntryPoint = "glfwGetProcAddress")] public static extern IntPtr GetProcAddress(string procname);
    [DllImport(GLFW_DLL, EntryPoint = "glfwPollEvents")] public static extern void PollEvents();
    [DllImport(GLFW_DLL, EntryPoint = "glfwWindowShouldClose")] public static extern int WindowShouldClose(IntPtr window);
  }
}
