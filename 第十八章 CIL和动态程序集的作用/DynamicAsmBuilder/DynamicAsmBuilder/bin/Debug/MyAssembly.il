
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0




// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly MyAssembly
{
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module MyAssembly
// MVID: {59C4CC4F-4F3C-4DB3-995B-CC06D44A2303}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x065D0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi MyAssembly.HelloWorld
       extends [mscorlib]System.Object
{
  .field private string theMessage
  .method public specialname rtspecialname 
          instance void  .ctor(string A_1) cil managed
  {
    // 代码大小       14 (0xe)
    .maxstack  4
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      string MyAssembly.HelloWorld::theMessage
    IL_000d:  ret
  } // end of method HelloWorld::.ctor

  .method public specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 代码大小       7 (0x7)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method HelloWorld::.ctor

  .method public instance string  GetMsg() cil managed
  {
    // 代码大小       7 (0x7)
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string MyAssembly.HelloWorld::theMessage
    IL_0006:  ret
  } // end of method HelloWorld::GetMsg

  .method public instance void  SayHello() cil managed
  {
    // 代码大小       11 (0xb)
    .maxstack  1
    IL_0000:  ldstr      "Hello from the hello class class!"
    IL_0005:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000a:  ret
  } // end of method HelloWorld::SayHello

} // end of class MyAssembly.HelloWorld


// =============================================================

// *********** 反汇编完成 ***********************
