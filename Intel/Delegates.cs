using System;
using System.Runtime.CompilerServices.Intrinsics;

namespace System.Runtime.CompilerServices.Intrinsics.Intel
{
    // Delegates for intrinsic functions that take an immediate value parameter which 
    // should be constants, but cannot be constrained to being constants in C#.
    // Use of delegates and partial function application used to constrain the immediate parameter

    public delegate Vector128<sbyte> AlignRightVector128Delegate(Vector128<sbyte> left, Vector128<sbyte> right);   
    public delegate Vector256<sbyte> AlignRightVector256Delegate(Vector256<sbyte> left, Vector256<sbyte> right); 

    public delegate Vector128<T> BlendVector128Delegate<T>(Vector128<T> left, Vector128<T> right) where T : struct;
    public delegate Vector256<T> BlendVector256Delegate<T>(Vector256<T> left, Vector256<T> right) where T : struct;

    public delegate Vector128<T> CarryLessMultiplyVector128Delegate<T>(Vector128<T> left, Vector128<T> right) where T : struct;

    public delegate bool CompareImplicitLengthVector128Delegate<T>(Vector128<T> left, Vector128<T> right) where T : struct;
    public delegate bool CompareExplicitLengthVector128Delegate<T>(Vector128<T> left, byte leftLength, Vector128<T> right, byte rightLength) where T : struct;
    public delegate byte CompareImplicitLengthIndexVector128Delegate<T>(Vector128<T> left, Vector128<T> right) where T : struct;
    public delegate byte CompareExplicitLengthIndexVector128Delegate<T>(Vector128<T> left, byte leftLength, Vector128<T> right, byte rightLength) where T : struct;

    public delegate Vector128<ushort> CompareImplicitLengthBitMaskVector128SbyteDelegate(Vector128<sbyte> left, Vector128<sbyte> right);
    public delegate Vector128<ushort> CompareImplicitLengthBitMaskVector128ByteDelegate(Vector128<byte> left, Vector128<byte> right);
    public delegate Vector128<byte> CompareImplicitLengthBitMaskVector128ShortDelegate(Vector128<short> left, Vector128<short> right);
    public delegate Vector128<byte> CompareImplicitLengthBitMaskVector128UshortDelegate(Vector128<short> left, Vector128<short> right);
    
    public delegate Vector128<byte> CompareImplicitLengthUnitMaskVector128SbyteDelegate(Vector128<sbyte> left, Vector128<sbyte> right);
    public delegate Vector128<byte> CompareImplicitLengthUnitMaskVector128ByteDelegate(Vector128<byte> left, Vector128<byte> right);
    public delegate Vector128<ushort> CompareImplicitLengthUnitMaskVector128ShortDelegate(Vector128<short> left, Vector128<short> right);
    public delegate Vector128<ushort> CompareImplicitLengthUnitMaskVector128UshortDelegate(Vector128<short> left, Vector128<short> right);
    
    public delegate Vector128<ushort> CompareExplicitLengthBitMaskVector128SbyteDelegate(Vector128<sbyte> left, byte leftLength, Vector128<sbyte> right, byte rightLength);
    public delegate Vector128<ushort> CompareExplicitLengthBitMaskVector128ByteDelegate(Vector128<byte> left, byte leftLength, Vector128<byte> right, byte rightLength);
    public delegate Vector128<byte> CompareExplicitLengthBitMaskVector128ShortDelegate(Vector128<short> left, byte leftLength, Vector128<short> right, byte rightLength);
    public delegate Vector128<byte> CompareExplicitLengthBitMaskVector128UshortDelegate(Vector128<short> left, byte leftLength, Vector128<short> right, byte rightLength);

    public delegate Vector128<byte> CompareExplicitLengthUnitMaskVector128SbyteDelegate(Vector128<sbyte> left, byte leftLength, Vector128<sbyte> right, byte rightLength);
    public delegate Vector128<byte> CompareExplicitLengthUnitMaskVector128ByteDelegate(Vector128<byte> left, byte leftLength, Vector128<byte> right, byte rightLength);
    public delegate Vector128<ushort> CompareExplicitLengthUnitMaskVector128ShortDelegate(Vector128<short> left, byte leftLength, Vector128<short> right, byte rightLength);
    public delegate Vector128<ushort> CompareExplicitLengthUnitMaskVector128UshortDelegate(Vector128<short> left, byte leftLength, Vector128<short> right, byte rightLength);

    public delegate Vector128<T> CompareVector128Delegate<T>(Vector128<T> left, Vector128<T> right) where T : struct;
    public delegate Vector256<T> CompareVector256Delegate<T>(Vector256<T> left, Vector256<T> right) where T : struct;

    public delegate Vector256<float> DotProductVectro256Delegate(Vector256<float> left, Vector256<float> right);

    public delegate sbyte ExtractSbyteVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate byte ExtractByteVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate short ExtractShortVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate ushort ExtractUShortVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate int ExtractIntVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate uint ExtractUIntVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate long ExtractLongVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate ulong ExtractUlongVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate int ExtractFloatVector128Delegate<T>(Vector128<T> value) where T : struct;

    public delegate sbyte ExtractSbyteVector256Delegate<T>(Vector256<T> value) where T : struct;
    public delegate byte ExtractByteVector256Delegate<T>(Vector256<T> value) where T : struct;
    public delegate short ExtractShortVector256Delegate<T>(Vector256<T> value) where T : struct;
    public delegate ushort ExtractUShortVector256Delegate<T>(Vector256<T> value) where T : struct;
    public delegate int ExtractIntVector256Delegate<T>(Vector256<T> value) where T : struct;
    public delegate uint ExtractUintVector256Delegate<T>(Vector256<T> value) where T : struct;
    public delegate long ExtractLongVector256Delegate<T>(Vector256<T> value) where T : struct;
    public delegate ulong ExtractUlongVector256Delegate<T>(Vector256<T> value) where T : struct;

    public delegate Vector128<T> Extract128Vector256Delegate<T>(Vector256<T> value) where T : struct;

    public unsafe delegate Vector128<int> GatherVector128IntIndexVector128IntDelegate(int* mem, Vector128<int> index);
    public unsafe delegate Vector128<uint> GatherVector128IntIndexVector128UintDelegate(uint* mem, Vector128<int> index);
    public unsafe delegate Vector128<long> GatherVector128IntIndexVector128LongDelegate(long* mem, Vector128<int> index);
    public unsafe delegate Vector128<ulong> GatherVector128IntIndexVector128UlongDelegate(ulong* mem, Vector128<int> index);
    public unsafe delegate Vector128<float> GatherVector128IntIndexVector128FloatDelegate(float* mem, Vector128<int> index);
    public unsafe delegate Vector128<double> GatherVector128IntIndexVector128DoubleDelegate(double* mem, Vector128<int> index);

    public unsafe delegate Vector256<long> GatherVector128IntIndexVector256LongDelegate(long* mem, Vector128<int> index);
    public unsafe delegate Vector256<ulong> GatherVector128IntIndexVector256UlongDelegate(ulong* mem, Vector128<int> index);
    public unsafe delegate Vector256<double> GatherVector128IntIndexVector256DoubleDelegate(double* mem, Vector128<int> index);

    public unsafe delegate Vector128<int> GatherVector128LongIndexVector128IntDelegate(int* mem, Vector128<long> index);
    public unsafe delegate Vector128<uint> GatherVector128LongIndexVector128UintDelegate(uint* mem, Vector128<long> index);
    public unsafe delegate Vector128<long> GatherVector128LongIndexVector128LongDelegate(long* mem, Vector128<long> index);
    public unsafe delegate Vector128<ulong> GatherVector128LongIndexVector128UlongDelegate(ulong* mem, Vector128<long> index);
    public unsafe delegate Vector128<float> GatherVector128LongIndexVector128FloatDelegate(float* mem, Vector128<long> index);
    public unsafe delegate Vector128<double> GatherVector128LongIndexVector128DoubleDelegate(double* mem, Vector128<long> index);

    public unsafe delegate Vector256<int> GatherVector256IntIndexVector256IntDelegate(int* mem, Vector256<int> index);
    public unsafe delegate Vector256<uint> GatherVector256IntIndexVector256UintDelegate(uint* mem, Vector256<int> index);
    public unsafe delegate Vector256<long> GatherVector256IntIndexVector256LongDelegate(long* mem, Vector256<int> index);
    public unsafe delegate Vector256<ulong> GatherVector256IntIndexVector256UlongDelegate(ulong* mem, Vector256<int> index);
    public unsafe delegate Vector256<float> GatherVector256IntIndexVector256FloatDelegate(float* mem, Vector256<int> index);
    public unsafe delegate Vector256<double> GatherVector256IntIndexVector256DoubleDelegate(double* mem, Vector256<int> index);

    public unsafe delegate Vector128<int> GatherVector256LongIndexVector128IntDelegate(int* mem, Vector256<long> index);
    public unsafe delegate Vector128<uint> GatherVector256LongIndexVector128UintDelegate(uint* mem, Vector256<long> index);
    public unsafe delegate Vector256<long> GatherVector256LongIndexVector256LongDelegate(long* mem, Vector256<long> index);
    public unsafe delegate Vector256<ulong> GatherVector256LongIndexVector256UlongDelegate(ulong* mem, Vector256<long> index);
    public unsafe delegate Vector128<float> GatherVector256LongIndexVector128FloatDelegate(float* mem, Vector256<long> index);
    public unsafe delegate Vector256<double> GatherVector256LongIndexVector256DoubleDelegate(double* mem, Vector256<long> index);

    public unsafe delegate Vector128<int> GatherMaskVector128IntIndexVector128IntDelegate(Vector128<int> source, int* mem, Vector128<int> index, Vector128<byte> mask);
    public unsafe delegate Vector128<uint> GatherMaskVector128IntIndexVector128UintDelegate(Vector128<uint> source, uint* mem, Vector128<int> index, Vector128<byte> mask);
    public unsafe delegate Vector128<long> GatherMaskVector128IntIndexVector128LongDelegate(Vector128<long> source, long* mem, Vector128<int> index, Vector128<byte> mask);
    public unsafe delegate Vector128<ulong> GatherMaskVector128IntIndexVector128UlongDelegate(Vector128<ulong> source, ulong* mem, Vector128<int> index, Vector128<byte> mask);
    public unsafe delegate Vector128<float> GatherMaskVector128IntIndexVector128FloatDelegate(Vector128<float> source, float* mem, Vector128<int> index, Vector128<byte> mask);
    public unsafe delegate Vector128<double> GatherMaskVector128IntIndexVector128DoubleDelegate(Vector128<double> source, double* mem, Vector128<int> index, Vector128<byte> mask);

    public unsafe delegate Vector128<int> GatherMaskVector128LongIndexVector128IntDelegate(Vector128<int> source, int* mem, Vector128<long> index, Vector128<byte> mask);
    public unsafe delegate Vector128<uint> GatherMaskVector128LongIndexVector128UintDelegate(Vector128<uint> source, uint* mem, Vector128<long> index, Vector128<byte> mask);
    public unsafe delegate Vector128<long> GatherMaskVector128LongIndexVector128LongDelegate(Vector128<long> source, long* mem, Vector128<long> index, Vector128<byte> mask);
    public unsafe delegate Vector128<ulong> GatherMaskVector128LongIndexVector128UlongDelegate(Vector128<ulong> source, ulong* mem, Vector128<long> index, Vector128<byte> mask);
    public unsafe delegate Vector128<float> GatherMaskVector128LongIndexVector128FloatDelegate(Vector128<float> source, float* mem, Vector128<long> index, Vector128<byte> mask);
    public unsafe delegate Vector128<double> GatherMaskVector128LongIndexVector128DoubleDelegate(Vector128<double> source, double* mem, Vector128<long> index, Vector128<byte> mask);

    public unsafe delegate Vector256<long> GatherMaskVector128IntIndexVector256LongDelegate(Vector256<long> source, long* mem, Vector128<int> index, Vector256<byte> mask);
    public unsafe delegate Vector256<ulong> GatherMaskVector128IntIndexVector256UlongDelegate(Vector256<ulong> source, ulong* mem, Vector128<int> index, Vector256<byte> mask);
    public unsafe delegate Vector256<double> GatherMaskVector128IntIndexVector256DoubleDelegate(Vector256<double> source, double* mem, Vector128<int> index, Vector256<byte> mask);

    public unsafe delegate Vector256<int> GatherMaskVector256IntIndexVector256IntDelegate(Vector256<int> source, int* mem, Vector256<int> index, Vector256<byte> mask);
    public unsafe delegate Vector256<uint> GatherMaskVector256IntIndexVector256UintDelegate(Vector256<uint> source, uint* mem, Vector256<int> index, Vector256<byte> mask);
    public unsafe delegate Vector256<long> GatherMaskVector256IntIndexVector256LongDelegate(Vector256<long> source, long* mem, Vector256<int> index, Vector256<byte> mask);
    public unsafe delegate Vector256<ulong> GatherMaskVector256IntIndexVector256UlongDelegate(Vector256<ulong> source, ulong* mem, Vector256<int> index, Vector256<byte> mask);
    public unsafe delegate Vector256<float> GatherMaskVector256IntIndexVector256FloatDelegate(Vector256<float> source, float* mem, Vector256<int> index, Vector256<byte> mask);
    public unsafe delegate Vector256<double> GatherMaskVector256IntIndexVector256DoubleDelegate(Vector256<double> source, double* mem, Vector256<int> index, Vector256<byte> mask);

    public unsafe delegate Vector128<int> GatherMaskVector256LongIndexVector128IntDelegate(Vector128<int> source, int* mem, Vector256<long> index, Vector128<byte> mask);
    public unsafe delegate Vector128<uint> GatherMaskVector256LongIndexVector128UintDelegate(Vector128<uint> source, uint* mem, Vector256<long> index, Vector128<byte> mask);
    public unsafe delegate Vector256<long> GatherMaskVector256LongIndexVector256LongDelegate(Vector256<long> source, long* mem, Vector256<long> index, Vector256<byte> mask);
    public unsafe delegate Vector256<ulong> GatherMaskVector256LongIndexVector256UlongDelegate(Vector256<ulong> source, ulong* mem, Vector256<long> index, Vector256<byte> mask);
    public unsafe delegate Vector128<float> GatherMaskVector256LongIndexVector128FloatDelegate(Vector128<float> source, float* mem, Vector256<long> index, Vector128<byte> mask);
    public unsafe delegate Vector256<double> GatherMaskVector256LongIndexVector256DoubleDelegate(Vector256<double> source, double* mem, Vector256<long> index, Vector256<byte> mask);

    public delegate Vector128<T> InsertSbyteVector128Delegate<T>(Vector128<T> value, sbyte data) where T : struct;
    public delegate Vector128<T> InsertByteVector128Delegate<T>(Vector128<T> value, byte data) where T : struct;
    public delegate Vector128<T> InsertShortVector128Delegate<T>(Vector128<T> value, short data) where T : struct;
    public delegate Vector128<T> InsertUshortVector128Delegate<T>(Vector128<T> value, ushort data) where T : struct;
    public delegate Vector128<T> InsertIntVector128Delegate<T>(Vector128<T> value, int data) where T : struct;
    public delegate Vector128<T> InsertUintVector128Delegate<T>(Vector128<T> value, uint data) where T : struct;
    public delegate Vector128<T> InsertLongVector128Delegate<T>(Vector128<T> value, long data) where T : struct;
    public delegate Vector128<T> InsertUlongVector128Delegate<T>(Vector128<T> value, ulong data) where T : struct;
    public delegate Vector128<T> InsertFloatVector128Delegate<T>(Vector128<T> value, float data) where T : struct;
    
    public delegate Vector256<T> InsertSbyteVector256Delegate<T>(Vector256<T> value, sbyte data) where T : struct;
    public delegate Vector256<T> InsertByteVector256Delegate<T>(Vector256<T> value, byte data) where T : struct;
    public delegate Vector256<T> InsertShortVector256Delegate<T>(Vector256<T> value, short data) where T : struct;
    public delegate Vector256<T> InsertUshortVector256Delegate<T>(Vector256<T> value, ushort data) where T : struct;
    public delegate Vector256<T> InsertIntVector256Delegate<T>(Vector256<T> value, int data) where T : struct;
    public delegate Vector256<T> InsertUintVector256Delegate<T>(Vector256<T> value, uint data) where T : struct;
    public delegate Vector256<T> InsertLongVector256Delegate<T>(Vector256<T> value, long data) where T : struct;
    public delegate Vector256<T> InsertUlongVector256Delegate<T>(Vector256<T> value, ulong data) where T : struct;

    public delegate Vector256<T> Insert128Vector256Delegate<T>(Vector256<T> value, Vector128<T> data) where T : struct;

    public delegate Vector128<T> KeygenAssistVector128Delegate<T>(Vector128<T> value) where T : struct;
    
    public delegate Vector128<ushort> MultipleSumAbsoluteDifferenceVector128Delegate(Vector128<byte> left, Vector128<byte> right);
    public delegate Vector256<ushort> MultipleSumAbsoluteDifferenceVector256Delegate(Vector256<byte> left, Vector256<byte> right);

    public delegate Vector256<T> Permute2x128Delegate<T>(Vector256<T> left, Vector256<T> right) where T : struct;
    public delegate Vector256<T> Permute4x64Delegate<T>(Vector256<T> value) where T : struct;

    public delegate Vector128<T> PermuteVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate Vector256<T> PermuteVector256Delegate<T>(Vector256<T> value) where T : struct;

    public delegate Vector128<T> ShiftVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate Vector256<T> ShiftVector256Delegate<T>(Vector256<T> value) where T : struct;

    public delegate Vector128<T> ShuffleVector128Delegate<T>(Vector128<T> value) where T : struct;
    public delegate Vector128<T> ShuffleTwoVector128Delegate<T>(Vector128<T> left, Vector128<T> right) where T : struct;
    public delegate Vector256<T> ShuffleVector256Delegate<T>(Vector256<T> value) where T : struct;
    public delegate Vector256<T> ShuffleTwoVector256Delegate<T>(Vector256<T> left, Vector256<T> right) where T : struct;
}