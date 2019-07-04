# csharp-samples

## p-invoke-linux-shared-library
This sample shows how to call a C-based shared library (a.k.a. a Linux DLL) from a .Net Core app running on Linux via P/Invoke. The shared library returns a pointer to the managed (C#) code which is then marshaled in to a .Net string.