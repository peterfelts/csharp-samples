#include <cstdio>

// extern "C": 
// Specifies that the name of an exported function will not be 
// altered by the compiler (otherwise the export name may change)
//
// __attributes__((visibility("default"))): 
// Exports a function of a Shared Library (a.k.a. a Linux DLL) such
// that it can be called externally
extern "C" __attribute__((visibility("default"))) char* DoEncode(void* input, int nSize, void* PsKey, int nSizePsKey)
{
    return "Hello world (from shared library)!";
}