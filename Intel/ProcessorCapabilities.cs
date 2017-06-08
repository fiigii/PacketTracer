using System;

namespace System.Runtime.CompilerServices
{
    public static class ProcessorCapabilities
    {
        public static bool IsSupported(InstructionSet instructionSet) { throw new NotImplementedException(); }
        public static InstructionSet GetSupportedInstructionSet() { throw new NotImplementedException(); }
    }

    public enum InstructionSet
    {
        AES,
        AVX,
        AVX2,
        BMI1,
        BMI2,
        FMA,
        LZCNT,
        PCLMULQDQ,
        POPCNT,
        SSE2,
        SSE3,
        SSE41,
        SSE42,
        SSSE3,
    }
}