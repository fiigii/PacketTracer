// =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
//
// SSE2.cs
//
// A class that implements intrinsic functions to provide access to Intel SSE/SSE2 instructions.
//
// =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+

using System;
using System.Runtime.CompilerServices.Intrinsics;
using System.Runtime.CompilerServices.Intrinsics.Intel;

namespace System.Runtime.CompilerServices.Intrinsics.Intel
{
    /// <summary>
    /// Provides access to Intel SSE2 hardware instructions via intrinsics
    /// </summary>
    /// <para>
    /// SSE2 class provides access to 128-bit SSE/SSE2 SIMD instructions
    /// </para>

    public static class SSE2
    {
        // __m128i _mm_add_epi8 (__m128i a,  __m128i b)
        // __m128i _mm_add_epi16 (__m128i a,  __m128i b)
        // __m128i _mm_add_epi32 (__m128i a,  __m128i b)
        // __m128i _mm_add_epi64 (__m128i a,  __m128i b)
        // __m128 _mm_add_ps (__m128 a,  __m128 b)
        // __m128d _mm_add_pd (__m128d a,  __m128d b)
        public static Vector128<T> Add<T>(Vector128<T> left,  Vector128<T> right) where T : struct { throw new NotImplementedException(); }

        // __m128i _mm_adds_epi8 (__m128i a,  __m128i b)
        public static Vector128<sbyte> AddSaturation(Vector128<sbyte> left,  Vector128<sbyte> right) { throw new NotImplementedException(); }
        // __m128i _mm_adds_epu8 (__m128i a,  __m128i b)
        public static Vector128<byte> AddSaturation(Vector128<byte> left,  Vector128<byte> right) { throw new NotImplementedException(); }
        // __m128i _mm_adds_epi16 (__m128i a,  __m128i b)
        public static Vector128<short> AddSaturation(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }
        // __m128i _mm_adds_epu16 (__m128i a,  __m128i b)
        public static Vector128<ushort> AddSaturation(Vector128<ushort> left,  Vector128<ushort> right) { throw new NotImplementedException(); }

        // __m128i _mm_and_si128 (__m128i a,  __m128i b)
        public static Vector128<T> And<T>(Vector128<T> left,  Vector128<T> right) where T : struct { throw new NotImplementedException(); }

        // __m128i _mm_andnot_si128 (__m128i a,  __m128i b)
        public static Vector128<T> AndNot<T>(Vector128<T> left,  Vector128<T> right) where T : struct { throw new NotImplementedException(); }

        // __m128i _mm_avg_epu8 (__m128i a,  __m128i b)
        public static Vector128<byte> Average(Vector128<byte> left,  Vector128<byte> right) { throw new NotImplementedException(); }
        // __m128i _mm_avg_epu16 (__m128i a,  __m128i b)
        public static Vector128<ushort> Average(Vector128<ushort> left,  Vector128<ushort> right) { throw new NotImplementedException(); }

        // __m128i _mm_cmpeq_epi8 (__m128i a,  __m128i b)
        public static Vector128<sbyte> CompareEqual(Vector128<sbyte> left,  Vector128<sbyte> right) { throw new NotImplementedException(); }
        // __m128i _mm_cmpeq_epi8 (__m128i a,  __m128i b)
        public static Vector128<byte> CompareEqual(Vector128<byte> left,  Vector128<byte> right) { throw new NotImplementedException(); }
        // __m128i _mm_cmpeq_epi16 (__m128i a,  __m128i b)
        public static Vector128<short> CompareEqual(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }
        // __m128i _mm_cmpeq_epi16 (__m128i a,  __m128i b)
        public static Vector128<ushort> CompareEqual(Vector128<ushort> left,  Vector128<ushort> right) { throw new NotImplementedException(); }
        // __m128i _mm_cmpeq_epi32 (__m128i a,  __m128i b)
        public static Vector128<int> CompareEqual(Vector128<int> left,  Vector128<int> right) { throw new NotImplementedException(); }
        // __m128i _mm_cmpeq_epi32 (__m128i a,  __m128i b)
        public static Vector128<uint> CompareEqual(Vector128<uint> left,  Vector128<uint> right) { throw new NotImplementedException(); }
        // __m128 _mm_cmpeq_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareEqual(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpeq_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareEqual(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128i _mm_cmpgt_epi8 (__m128i a,  __m128i b)
        public static Vector128<sbyte> CompareGreaterThan(Vector128<sbyte> left,  Vector128<sbyte> right) { throw new NotImplementedException(); }
        // __m128i _mm_cmpgt_epi16 (__m128i a,  __m128i b)
        public static Vector128<short> CompareGreaterThan(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }
        // __m128i _mm_cmpgt_epi32 (__m128i a,  __m128i b)
        public static Vector128<int> CompareGreaterThan(Vector128<int> left,  Vector128<int> right) { throw new NotImplementedException(); }
        // __m128 _mm_cmpgt_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareGreaterThan(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpgt_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareGreaterThan(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_cmpge_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareGreaterThanOrEqual(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpge_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareGreaterThanOrEqual(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128i _mm_cmplt_epi8 (__m128i a,  __m128i b)
        public static Vector128<sbyte> CompareLessThan(Vector128<sbyte> left,  Vector128<sbyte> right) { throw new NotImplementedException(); }
        // __m128i _mm_cmplt_epi16 (__m128i a,  __m128i b)
        public static Vector128<short> CompareLessThan(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }
        // __m128i _mm_cmplt_epi32 (__m128i a,  __m128i b)
        public static Vector128<int> CompareLessThan(Vector128<int> left,  Vector128<int> right) { throw new NotImplementedException(); }
        // __m128 _mm_cmplt_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareLessThan(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmplt_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareLessThan(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_cmple_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareLessThanOrEqual(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmple_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareLessThanOrEqual(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_cmpneq_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareNotEqual(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpneq_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareNotEqual(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_cmpngt_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareNotGreaterThan(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpngt_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareNotGreaterThan(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_cmpnge_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareNotGreaterThanOrEqual(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpnge_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareNotGreaterThanOrEqual(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_cmpnlt_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareNotLessThan(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpnlt_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareNotLessThan(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_cmpnle_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareNotLessThanOrEqual(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpnle_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareNotLessThanOrEqual(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_cmpord_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareOrdered(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpord_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareOrdered(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_cmpunord_ps (__m128 a,  __m128 b)
        public static Vector128<float> CompareUnordered(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_cmpunord_pd (__m128d a,  __m128d b)
        public static Vector128<double> CompareUnordered(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128i _mm_cvtps_epi32 (__m128 a)
        public static Vector128<int> ConvertToInt(Vector128<float> value) { throw new NotImplementedException(); }
        // __m128i _mm_cvtpd_epi32 (__m128d a)
        public static Vector128<int> ConvertToInt(Vector128<double> value) { throw new NotImplementedException(); }
        // __m128 _mm_cvtepi32_ps (__m128i a)
        public static Vector128<float> ConvertToFloat(Vector128<int> value) { throw new NotImplementedException(); }
        // __m128 _mm_cvtpd_ps (__m128d a)
        public static Vector128<float> ConvertToFloat(Vector128<double> value) { throw new NotImplementedException(); }
        // __m128d _mm_cvtepi32_pd (__m128i a)
        public static Vector128<double> ConvertToDouble(Vector128<int> value) { throw new NotImplementedException(); }
        // __m128d _mm_cvtps_pd (__m128 a)
        public static Vector128<double> ConvertToDouble(Vector128<float> value) { throw new NotImplementedException(); }

        // __m128i _mm_cvttps_epi32 (__m128 a)
        public static Vector128<int> ConvertToIntWithTruncation(Vector128<float> value) { throw new NotImplementedException(); }
        // __m128i _mm_cvttpd_epi32 (__m128d a)
        public static Vector128<int> ConvertToIntWithTruncation(Vector128<double> value) { throw new NotImplementedException(); }

        // __m128 _mm_div_ps (__m128 a,  __m128 b)
        public static Vector128<float> Divide(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_div_pd (__m128d a,  __m128d b)
        public static Vector128<double> Divide(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // int _mm_extract_epi16 (__m128i a,  int immediate)
        private static short ExtractShort<T>(Vector128<T> value,  byte index) where T : struct { throw new NotImplementedException(); }
        public static ExtractShortVector128Delegate<T> GetExtractVector128Short<T>(byte index) where T : struct
        {
            return (value) => ExtractShort(value, index);
        }
        // int _mm_extract_epi16 (__m128i a,  int immediate)
        private static ushort ExtractUshort<T>(Vector128<T> value,  byte index) where T : struct { throw new NotImplementedException(); }
        public static ExtractUShortVector128Delegate<T> GetExtractVector128Ushort<T>(byte index) where T : struct
        {
            return (value) => ExtractUshort(value, index);
        }

        // __m128i _mm_insert_epi16 (__m128i a,  int i, int immediate)
        private static Vector128<T> InsertShort<T>(Vector128<T> value,  short data, byte index) where T : struct { throw new NotImplementedException(); }
        public static InsertShortVector128Delegate<T> GetInsertVector128Short<T>(byte index) where T : struct
        {
            return (value, data) => InsertShort(value, data, index);
        }
        // __m128i _mm_insert_epi16 (__m128i a,  int i, int immediate)
        private static Vector128<T> InsertUshort<T>(Vector128<T> value,  ushort data, byte index) where T : struct { throw new NotImplementedException(); }
        public static InsertUshortVector128Delegate<T> GetInsertVector128Ushort<T>(byte index) where T : struct
        {
            return (value, data) => InsertUshort(value, data, index);
        }

        // __m128i _mm_loadu_si128 (__m128i const* mem_address)
        public static unsafe Vector128<sbyte> Load(sbyte* mem) { throw new NotImplementedException(); }
        // __m128i _mm_loadu_si128 (__m128i const* mem_address)
        public static unsafe Vector128<byte> Load(byte* mem) { throw new NotImplementedException(); }
        // __m128i _mm_loadu_si128 (__m128i const* mem_address)
        public static unsafe Vector128<short> Load(short* mem) { throw new NotImplementedException(); }
        // __m128i _mm_loadu_si128 (__m128i const* mem_address)
        public static unsafe Vector128<ushort> Load(ushort* mem) { throw new NotImplementedException(); }
        // __m128i _mm_loadu_si128 (__m128i const* mem_address)
        public static unsafe Vector128<int> Load(int* mem) { throw new NotImplementedException(); }
        // __m128i _mm_loadu_si128 (__m128i const* mem_address)
        public static unsafe Vector128<uint> Load(uint* mem) { throw new NotImplementedException(); }
        // __m128i _mm_loadu_si128 (__m128i const* mem_address)
        public static unsafe Vector128<long> Load(long* mem) { throw new NotImplementedException(); }
        // __m128i _mm_loadu_si128 (__m128i const* mem_address)
        public static unsafe Vector128<ulong> Load(ulong* mem) { throw new NotImplementedException(); }
        // __m128 _mm_loadu_ps (float const* mem_address)
        public static unsafe Vector128<float> Load(float* mem) { throw new NotImplementedException(); }
        // __m128d _mm_loadu_pd (double const* mem_address)
        public static unsafe Vector128<double> Load(double* mem) { throw new NotImplementedException(); }

        // __m128i _mm_load_si128 (__m128i const* mem_address)
        public static unsafe Vector128<sbyte> LoadAligned(sbyte* mem) { throw new NotImplementedException(); }
        // __m128i _mm_load_si128 (__m128i const* mem_address)
        public static unsafe Vector128<byte> LoadAligned(byte* mem) { throw new NotImplementedException(); }
        // __m128i _mm_load_si128 (__m128i const* mem_address)
        public static unsafe Vector128<short> LoadAligned(short* mem) { throw new NotImplementedException(); }
        // __m128i _mm_load_si128 (__m128i const* mem_address)
        public static unsafe Vector128<ushort> LoadAligned(ushort* mem) { throw new NotImplementedException(); }
        // __m128i _mm_load_si128 (__m128i const* mem_address)
        public static unsafe Vector128<int> LoadAligned(int* mem) { throw new NotImplementedException(); }
        // __m128i _mm_load_si128 (__m128i const* mem_address)
        public static unsafe Vector128<uint> LoadAligned(uint* mem) { throw new NotImplementedException(); }
        // __m128i _mm_load_si128 (__m128i const* mem_address)
        public static unsafe Vector128<long> LoadAligned(long* mem) { throw new NotImplementedException(); }
        // __m128i _mm_load_si128 (__m128i const* mem_address)
        public static unsafe Vector128<ulong> LoadAligned(ulong* mem) { throw new NotImplementedException(); }
        // __m128 _mm_load_ps (float const* mem_address)
        public static unsafe Vector128<float> LoadAligned(float* mem) { throw new NotImplementedException(); }
        // __m128d _mm_load_pd (double const* mem_address)
        public static unsafe Vector128<double> LoadAligned(double* mem) { throw new NotImplementedException(); }

        // void _mm_maskmoveu_si128 (__m128i a,  __m128i mask, char* mem_address)
        public static unsafe void MaskMoveAlignedOrUnaligned(Vector128<sbyte> source,  Vector128<byte> mask, sbyte* mem) { throw new NotImplementedException(); }
        public static unsafe void MaskMoveAlignedOrUnaligned(Vector128<byte> source,  Vector128<byte> mask, byte* mem) { throw new NotImplementedException(); }

        // __m128i _mm_max_epu8 (__m128i a,  __m128i b)
        public static Vector128<byte> Max(Vector128<byte> left,  Vector128<byte> right) { throw new NotImplementedException(); }
        // __m128i _mm_max_epi16 (__m128i a,  __m128i b)
        public static Vector128<short> Max(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }
        // __m128 _mm_max_ps (__m128 a,  __m128 b)
        public static Vector128<float> Max(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_max_pd (__m128d a,  __m128d b)
        public static Vector128<double> Max(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128i _mm_min_epu8 (__m128i a,  __m128i b)
        public static Vector128<byte> Min(Vector128<byte> left,  Vector128<byte> right) { throw new NotImplementedException(); }
        // __m128i _mm_min_epi16 (__m128i a,  __m128i b)
        public static Vector128<short> Min(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }
        // __m128 _mm_min_ps (__m128 a,  __m128 b)
        public static Vector128<float> Min(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_min_pd (__m128d a,  __m128d b)
        public static Vector128<double> Min(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128 _mm_movehl_ps (__m128 a,  __m128 b)
        public static Vector128<float> MoveHighToLow(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128 _mm_movelh_ps (__m128 a,  __m128 b)
        public static Vector128<float> MoveLowToHigh(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }

        // int _mm_movemask_epi8 (__m128i a)
        public static int MoveMask(Vector128<sbyte> value) { throw new NotImplementedException(); }
        // int _mm_movemask_pd (__m128d a)
        public static int MoveMask(Vector128<double> value) { throw new NotImplementedException(); }

        // __m128i _mm_mul_epu32 (__m128i a,  __m128i b)
        public static Vector128<ulong> Multiply(Vector128<uint> left,  Vector128<uint> right) { throw new NotImplementedException(); }
        // __m128 _mm_mul_ps (__m128 a, __m128 b)
        public static Vector128<float> Multiply(Vector128<float> left,  Vector128<float> right) { throw new NotImplementedException(); }
        // __m128d _mm_mul_pd (__m128d a,  __m128d b)
        public static Vector128<double> Multiply(Vector128<double> left,  Vector128<double> right) { throw new NotImplementedException(); }

        // __m128i _mm_mulhi_epi16 (__m128i a,  __m128i b)
        public static Vector128<short> MultiplyHi(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }
        // __m128i _mm_mulhi_epu16 (__m128i a,  __m128i b)
        public static Vector128<ushort> MultiplyHi(Vector128<ushort> left,  Vector128<ushort> right) { throw new NotImplementedException(); }

        // __m128i _mm_madd_epi16 (__m128i a,  __m128i b)
        public static Vector128<int> MultiplyHorizontalAdd(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }

        // __m128i _mm_mullo_epi16 (__m128i a,  __m128i b)
        public static Vector128<short> MultiplyLow(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }

        // __m128i _mm_or_si128 (__m128i a,  __m128i b)
        // __m128 _mm_or_ps (__m128 a,  __m128 b)
        // __m128d _mm_or_pd (__m128d a,  __m128d b)
        public static Vector128<T> Or<T>(Vector128<T> left,  Vector128<T> right) where T : struct { throw new NotImplementedException(); }

        // __m128i _mm_packs_epi16 (__m128i a,  __m128i b)
        public static Vector128<sbyte> PackSignedSaturation(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }
        // __m128i _mm_packs_epi32 (__m128i a,  __m128i b)
        public static Vector128<short> PackSignedSaturation(Vector128<int> left,  Vector128<int> right) { throw new NotImplementedException(); }

        // __m128i _mm_packus_epi16 (__m128i a,  __m128i b)
        public static Vector128<byte> PackUnsignedSaturation(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }

        // __m128 _mm_rcp_ps (__m128 a)
        public static Vector128<float> Reciprocal(Vector128<float> value) { throw new NotImplementedException(); }

        // __m128 _mm_rsqrt_ps (__m128 a)
        public static Vector128<float> ReciprocalSquareRoot(Vector128<float> value) { throw new NotImplementedException(); }

        // ___m128i _mm_set_epi8 (char e15, char e14, char e13, char e12, char e11, char e10, char e9, char e8, char e7, char e6, char e5, char e4, char e3, char e2, char e1, char e0)
        public static Vector128<sbyte> Set(sbyte e15, sbyte e14, sbyte e13, sbyte e12, sbyte e11, sbyte e10, sbyte e9, sbyte e8, sbyte e7, sbyte e6, sbyte e5, sbyte e4, sbyte e3, sbyte e2, sbyte e1, sbyte e0)
        {
            throw new NotImplementedException();
        }
        // ___m128i _mm_set_epi8 (char e15, char e14, char e13, char e12, char e11, char e10, char e9, char e8, char e7, char e6, char e5, char e4, char e3, char e2, char e1, char e0)
        public static Vector128<byte> Set(byte e15, byte e14, byte e13, byte e12, byte e11, byte e10, byte e9, byte e8, byte e7, byte e6, byte e5, byte e4, byte e3, byte e2, byte e1, byte e0)
        {
            throw new NotImplementedException();
        }
        // __m128i _mm_set_epi16 (short e7, short e6, short e5, short e4, short e3, short e2, short e1, short e0)
        public static Vector128<short> Set(short e7, short e6, short e5, short e4, short e3, short e2, short e1, short e0)
        {
            throw new NotImplementedException();
        }
        // __m128i _mm_set_epi16 (short e7, short e6, short e5, short e4, short e3, short e2, short e1, short e0)
        public static Vector128<ushort> Set(ushort e7, ushort e6, ushort e5, ushort e4, ushort e3, ushort e2, ushort e1, ushort e0)
        {
            throw new NotImplementedException();
        }
        // __m128i _mm_set_epi32 (int e3, int e2, int e1, int e0)
        public static Vector128<int> Set(int e3, int e2, int e1, int e0) { throw new NotImplementedException(); }
        // __m128i _mm_set_epi32 (int e3, int e2, int e1, int e0)
        public static Vector128<uint> Set(uint e3, uint e2, uint e1, uint e0) { throw new NotImplementedException(); }
        // __m128i _mm_set_epi64x (__int64 e1, __int64 e0)
        public static Vector128<long> Set(long e1, long e0) { throw new NotImplementedException(); }
        // __m128i _mm_set_epi64x (__int64 e1, __int64 e0)
        public static Vector128<ulong> Set(ulong e1, ulong e0) { throw new NotImplementedException(); }
        // __m256 _mm256_set_ps (float e7, float e6, float e5, float e4, float e3, float e2, float e1, float e0)
        public static Vector128<float> Set(float e7, float e6, float e5, float e4, float e3, float e2, float e1, float e0)
        {
            throw new NotImplementedException();
        }
        // __m128d _mm_set_pd (double e1, double e0)
        public static Vector128<double> Set(double e1, double e0) { throw new NotImplementedException(); }
        
        // __m128i _mm_set1_epi8 (char a)
        // __m128i _mm_set1_epi16 (short a)
        // __m128i _mm_set1_epi32 (int a)
        // __m128i _mm_set1_epi64x (long long a)
        // __m128 _mm_set1_ps (float a)
        // __m128d _mm_set1_pd (double a)
        public static Vector128<T> Set1<T>(T value) where T : struct { throw new NotImplementedException(); }

        // __m128i _mm_setzero_si128 ()
        // __m128d _mm_setzero_pd (void)
        public static Vector128<T> SetZero<T>() where T : struct { throw new NotImplementedException(); }

        // __m128i _mm_sad_epu8 (__m128i a,  __m128i b)
        public static Vector128<long> SumAbsoluteDifference(Vector128<byte> left,  Vector128<byte> right) { throw new NotImplementedException(); }

        // __m128i _mm_shuffle_epi32 (__m128i a,  int immediate)
        private static Vector128<int> Shuffle(Vector128<int> value,  byte control) { throw new NotImplementedException(); }
        public static ShuffleVector128Delegate<int> GetShuffleVector128Int(byte control)
        {
            return (value) => Shuffle(value, control);
        }
        // __m128i _mm_shuffle_epi32 (__m128i a,  int immediate)
        private static Vector128<uint> Shuffle(Vector128<uint> value,  byte control) { throw new NotImplementedException(); }
        public static ShuffleVector128Delegate<uint> GetShuffleVector128Uint(byte control)
        {
            return (value) => Shuffle(value, control);
        }
        // __m128 _mm_shuffle_ps (__m128 a,  __m128 b, unsigned int control)
        private static Vector128<float> Shuffle(Vector128<float> left,  Vector128<float> right, byte control) { throw new NotImplementedException(); }
        public static ShuffleTwoVector128Delegate<float> GetShuffleVector128Float(byte control)
        {
            return (left, right) => Shuffle(left, right, control);
        }
        // __m128d _mm_shuffle_pd (__m128d a,  __m128d b, int immediate)
        private static Vector128<double> Shuffle(Vector128<double> left,  Vector128<double> right, byte control) { throw new NotImplementedException(); }
        public static ShuffleTwoVector128Delegate<double> GetShuffleVector128Double(byte control)
        {
            return (left, right) => Shuffle(left, right, control);
        }

        // __m128i _mm_shufflehi_epi16 (__m128i a,  int immediate)
        private static Vector128<short> ShuffleHigh(Vector128<short> value,  byte control) { throw new NotImplementedException(); }
        public static ShuffleVector128Delegate<short> GetShuffleHighVector128Short(byte control)
        {
            return (value) => ShuffleHigh(value, control);
        }
        // __m128i _mm_shufflehi_epi16 (__m128i a,  int control)
        private static Vector128<ushort> ShuffleHigh(Vector128<ushort> value,  byte control) { throw new NotImplementedException(); }
        public static ShuffleVector128Delegate<ushort> GetShuffleHighVector128Ushort(byte control)
        {
            return (value) => ShuffleHigh(value, control);
        }

        // __m128i _mm_shufflelo_epi16 (__m128i a,  int control)
        private static Vector128<short> ShuffleLow(Vector128<short> value,  byte control) { throw new NotImplementedException(); }
        public static ShuffleVector128Delegate<short> GetShuffleLowVector128Short(byte control)
        {
            return (value) => ShuffleLow(value, control);
        }
        // __m128i _mm_shufflelo_epi16 (__m128i a,  int control)
        private static Vector128<ushort> ShuffleLow(Vector128<ushort> value,  byte control) { throw new NotImplementedException(); }
        public static ShuffleVector128Delegate<ushort> GetShuffleLowVector128Ushort(byte control)
        {
            return (value) => ShuffleLow(value, control);
        }

        // __m128i _mm_slli_epi16 (__m128i a,  int immediate)
        private static Vector128<short> ShiftLeftLogical(Vector128<short> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<short> GetShiftLeftLogicalVector128Short(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m128i _mm_slli_epi16 (__m128i a,  int immediate)
        private static Vector128<ushort> ShiftLeftLogical(Vector128<ushort> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<ushort> GetShiftLeftLogicalVector128Ushort(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m128i _mm_slli_epi32 (__m128i a,  int immediate)
        private static Vector128<int> ShiftLeftLogical(Vector128<int> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<int> GetShiftLeftLogicalVector128Int(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m128i _mm_slli_epi32 (__m128i a,  int immediate)
        private static Vector128<uint> ShiftLeftLogical(Vector128<uint> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<uint> GetShiftLeftLogicalVector128Uint(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m128i _mm_slli_epi64 (__m128i a,  int immediate)
        private static Vector128<long> ShiftLeftLogical(Vector128<long> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<long> GetShiftLeftLogicalVector128Long(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }
        // __m128i _mm_slli_epi64 (__m128i a,  int immediate)
        private static Vector128<ulong> ShiftLeftLogical(Vector128<ulong> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<ulong> GetShiftLeftLogicalVector128Ulong(byte count)
        {
            return (value) => ShiftLeftLogical(value, count);
        }

        // __m128i _mm_bslli_si128 (__m128i a, int imm8)
        private static Vector128<sbyte> ShiftLeftLogical128BitLane(Vector128<sbyte> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<sbyte> GetShiftLeftLogical128BitLaneVector128Sbyte(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bslli_si128 (__m128i a, int imm8)
        private static Vector128<byte> ShiftLeftLogical128BitLane(Vector128<byte> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<byte> GetShiftLeftLogical128BitLaneVector128Byte(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bslli_si128 (__m128i a, int imm8)
        private static Vector128<short> ShiftLeftLogical128BitLane(Vector128<short> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<short> GetShiftLeftLogical128BitLaneVector128Short(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bslli_si128 (__m128i a, int imm8)
        private static Vector128<ushort> ShiftLeftLogical128BitLane(Vector128<ushort> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<ushort> GetShiftLeftLogical128BitLaneVector128Ushort(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bslli_si128 (__m128i a, int imm8)
        private static Vector128<int> ShiftLeftLogical128BitLane(Vector128<int> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<int> GetShiftLeftLogical128BitLaneVector128Int(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bslli_si128 (__m128i a, int imm8)
        private static Vector128<uint> ShiftLeftLogical128BitLane(Vector128<uint> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<uint> GetShiftLeftLogical128BitLaneVector128Uint(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bslli_si128 (__m128i a, int imm8)
        private static Vector128<long> ShiftLeftLogical128BitLane(Vector128<long> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<long> GetShiftLeftLogical128BitLaneVector128Long(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bslli_si128 (__m128i a, int imm8)
        private static Vector128<ulong> ShiftLeftLogical128BitLane(Vector128<ulong> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<ulong> GetShiftLeftLogical128BitLaneVector128Ulong(byte numBytes)
        {
            return (value) => ShiftLeftLogical128BitLane(value, numBytes);
        }

        // __m128i _mm_srai_epi16 (__m128i a,  int immediate)
        private static Vector128<short> ShiftRightArithmetic(Vector128<short> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<short> GetShiftRightArithmeticVector128Short(byte count)
        {
            return (value) => ShiftRightArithmetic(value, count);
        }
        // __m128i _mm_srai_epi32 (__m128i a,  int immediate)
        private static Vector128<int> ShiftRightArithmetic(Vector128<int> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<int> GetShiftRightArithmeticVector128Int(byte count)
        {
            return (value) => ShiftRightArithmetic(value, count);
        }

        // __m128i _mm_srli_epi16 (__m128i a,  int immediate)
        private static Vector128<short> ShiftRightLogical(Vector128<short> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<short> GetShiftRightLogicalVector128Short(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m128i _mm_srli_epi16 (__m128i a,  int immediate)
        private static Vector128<ushort> ShiftRightLogical(Vector128<ushort> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<ushort> GetShiftRightLogicalVector128Ushort(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m128i _mm_srli_epi32 (__m128i a,  int immediate)
        private static Vector128<int> ShiftRightLogical(Vector128<int> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<int> GetShiftRightLogicalVector128Int(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m128i _mm_srli_epi32 (__m128i a,  int immediate)
        private static Vector128<uint> ShiftRightLogical(Vector128<uint> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<uint> GetShiftRightLogicalVector128Uint(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m128i _mm_srli_epi64 (__m128i a,  int immediate)
        private static Vector128<long> ShiftRightLogical(Vector128<long> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<long> GetShiftRightLogicalVector128Long(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }
        // __m128i _mm_srli_epi64 (__m128i a,  int immediate)
        private static Vector128<ulong> ShiftRightLogical(Vector128<ulong> value,  byte count) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<ushort> GetShiftRightLogicalVector128Ulong(byte count)
        {
            return (value) => ShiftRightLogical(value, count);
        }

        // __m128i _mm_bsrli_si128 (__m128i a, int imm8)
        private static Vector128<sbyte> ShiftRightLogical128BitLane(Vector128<sbyte> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<sbyte> GetShiftRightLogical128BitLaneVector128Sbyte(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bsrli_si128 (__m128i a, int imm8)
        private static Vector128<byte> ShiftRightLogical128BitLane(Vector128<byte> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<byte> GetShiftRightLogical128BitLaneVector128Byte(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bsrli_si128 (__m128i a, int imm8)
        private static Vector128<short> ShiftRightLogical128BitLane(Vector128<short> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<short> GetShiftRightLogical128BitLaneVector128Short(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bsrli_si128 (__m128i a, int imm8)
        private static Vector128<ushort> ShiftRightLogical128BitLane(Vector128<ushort> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<ushort> GetShiftRightLogical128BitLaneVector128Ushort(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bsrli_si128 (__m128i a, int imm8)
        private static Vector128<int> ShiftRightLogical128BitLane(Vector128<int> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<int> GetShiftRightLogical128BitLaneVector128Int(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bsrli_si128 (__m128i a, int imm8)
        private static Vector128<uint> ShiftRightLogical128BitLane(Vector128<uint> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<uint> GetShiftRightLogical128BitLaneVector128Uint(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bsrli_si128 (__m128i a, int imm8)
        private static Vector128<long> ShiftRightLogical128BitLane(Vector128<long> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<long> GetShiftRightLogical128BitLaneVector128Long(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }
        // __m128i _mm_bsrli_si128 (__m128i a, int imm8)
        private static Vector128<ulong> ShiftRightLogical128BitLane(Vector128<ulong> value, byte numBytes) { throw new NotImplementedException(); }
        public static ShiftVector128Delegate<ulong> GetShiftRightLogical128BitLaneVector128Ulong(byte numBytes)
        {
            return (value) => ShiftRightLogical128BitLane(value, numBytes);
        }

        // __m128 _mm_sqrt_ps (__m128 a)
        public static Vector128<float> Sqrt(Vector128<float> value) { throw new NotImplementedException(); }
        // __m128d _mm_sqrt_pd (__m128d a)
        public static Vector128<double> Sqrt(Vector128<double> value) { throw new NotImplementedException(); }

        // void _mm_store_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAligned(sbyte* mem, Vector128<sbyte> source) { throw new NotImplementedException(); }
        // void _mm_store_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAligned(byte* mem, Vector128<byte> source) { throw new NotImplementedException(); }
        // void _mm_store_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAligned(short* mem, Vector128<short> source) { throw new NotImplementedException(); }
        // void _mm_store_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAligned(ushort* mem, Vector128<ushort> source) { throw new NotImplementedException(); }
        // void _mm_store_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAligned(int* mem, Vector128<int> source) { throw new NotImplementedException(); }
        // void _mm_store_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAligned(uint* mem, Vector128<uint> source) { throw new NotImplementedException(); }
        // void _mm_store_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAligned(long* mem, Vector128<long> source) { throw new NotImplementedException(); }
        // void _mm_store_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAligned(ulong* mem, Vector128<ulong> source) { throw new NotImplementedException(); }
        // void _mm_store_ps (float* mem_addr, __m128 a)
        public static unsafe void StoreAligned(float* mem, Vector128<float> source) { throw new NotImplementedException(); }
        // void _mm_store_pd (double* mem_addr, __m128d a)
        public static unsafe void StoreAligned(double* mem, Vector128<double> source) { throw new NotImplementedException(); }

        // void _mm_stream_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAlignedNonTemporal(sbyte* mem, Vector128<sbyte> source) { throw new NotImplementedException(); }
        // void _mm_stream_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAlignedNonTemporal(byte* mem, Vector128<byte> source) { throw new NotImplementedException(); }
        // void _mm_stream_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAlignedNonTemporal(short* mem, Vector128<short> source) { throw new NotImplementedException(); }
        // void _mm_stream_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAlignedNonTemporal(ushort* mem, Vector128<ushort> source) { throw new NotImplementedException(); }
        // void _mm_stream_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAlignedNonTemporal(int* mem, Vector128<int> source) { throw new NotImplementedException(); }
        // void _mm_stream_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAlignedNonTemporal(uint* mem, Vector128<uint> source) { throw new NotImplementedException(); }
        // void _mm_stream_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAlignedNonTemporal(long* mem, Vector128<long> source) { throw new NotImplementedException(); }
        // void _mm_stream_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreAlignedNonTemporal(ulong* mem, Vector128<ulong> source) { throw new NotImplementedException(); }
        // void _mm_stream_ps (float* mem_addr, __m128 a)
        public static unsafe void StoreAlignedNonTemporal(float* mem, Vector128<float> source) { throw new NotImplementedException(); }
        // void _mm_stream_pd (double* mem_addr, __m128d a)
        public static unsafe void StoreAlignedNonTemporal(double* mem, Vector128<double> source) { throw new NotImplementedException(); }

        // void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void Store(sbyte* mem, Vector128<sbyte> source) { throw new NotImplementedException(); }
        // void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void Store(byte* mem, Vector128<byte> source) { throw new NotImplementedException(); }
        // void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void Store(short* mem, Vector128<short> source) { throw new NotImplementedException(); }
        // void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void Store(ushort* mem, Vector128<ushort> source) { throw new NotImplementedException(); }
        // void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void Store(int* mem, Vector128<int> source) { throw new NotImplementedException(); }
        // void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void Store(uint* mem, Vector128<uint> source) { throw new NotImplementedException(); }
        // void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void Store(long* mem, Vector128<long> source) { throw new NotImplementedException(); }
        // void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)
        public static unsafe void Store(ulong* mem, Vector128<ulong> source) { throw new NotImplementedException(); }
        // void _mm_storeu_ps (float* mem_addr, __m128 a)
        public static unsafe void Store(float* mem, Vector128<float> source) { throw new NotImplementedException(); }
        // void _mm_storeu_pd (double* mem_addr, __m128d a)
        public static unsafe void Store(double* mem, Vector128<double> source) { throw new NotImplementedException(); }

        // void _mm_storeh_pd (double* mem_addr, __m128d a)
        public static unsafe void StoreHigh(double* mem, Vector128<double> source) { throw new NotImplementedException(); }

        // void _mm_storel_epi64 (__m128i* mem_addr, __m128i a)
        public static unsafe void StoreLow(long* mem, Vector128<long> source) { throw new NotImplementedException(); }
        public static unsafe void StoreLow(ulong* mem, Vector128<ulong> source) { throw new NotImplementedException(); }
        // void _mm_storel_pd (double* mem_addr, __m128d a)
        public static unsafe void StoreLow(double* mem, Vector128<double> source) { throw new NotImplementedException(); }

        // __m128i _mm_sub_epi8 (__m128i a,  __m128i b)
        // __m128i _mm_sub_epi16 (__m128i a,  __m128i b)
        // __m128i _mm_sub_epi16 (__m128i a,  __m128i b)
        // __m128i _mm_sub_epi32 (__m128i a,  __m128i b)
        // __m128i _mm_sub_epi32 (__m128i a,  __m128i b)
        // __m128i _mm_sub_epi64 (__m128i a,  __m128i b)
        // __m128i _mm_sub_epi64 (__m128i a,  __m128i b)
        public static Vector128<T> Subtract<T>(Vector128<T> left,  Vector128<T> right) where T : struct { throw new NotImplementedException(); }

        // __m128i _mm_subs_epi8 (__m128i a,  __m128i b)
        public static Vector128<sbyte> SubtractSaturation(Vector128<sbyte> left,  Vector128<sbyte> right) { throw new NotImplementedException(); }
        // __m128i _mm_subs_epi16 (__m128i a,  __m128i b)
        public static Vector128<short> SubtractSaturation(Vector128<short> left,  Vector128<short> right) { throw new NotImplementedException(); }
        // __m128i _mm_subs_epu8 (__m128i a,  __m128i b)
        public static Vector128<byte> SubtractSaturation(Vector128<byte> left,  Vector128<byte> right) { throw new NotImplementedException(); }
        // __m128i _mm_subs_epu16 (__m128i a,  __m128i b)
        public static Vector128<ushort> SubtractSaturation(Vector128<ushort> left,  Vector128<ushort> right) { throw new NotImplementedException(); }

        // __m128i _mm_unpackhi_epi8 (__m128i a,  __m128i b)
        // __m128i _mm_unpackhi_epi16 (__m128i a,  __m128i b)
        // __m128i _mm_unpackhi_epi32 (__m128i a,  __m128i b)
        // __m128i _mm_unpackhi_epi64 (__m128i a,  __m128i b)
        // __m128 _mm_unpackhi_ps (__m128 a,  __m128 b)
        // __m128d _mm_unpackhi_pd (__m128d a,  __m128d b)
        public static Vector128<T> UnpackHigh<T>(Vector128<T> left,  Vector128<T> right) where T : struct { throw new NotImplementedException(); }
        
        // __m128i _mm_unpacklo_epi8 (__m128i a,  __m128i b)
        // __m128i _mm_unpacklo_epi16 (__m128i a,  __m128i b)
        // __m128i _mm_unpacklo_epi32 (__m128i a,  __m128i b)
        // __m128i _mm_unpacklo_epi64 (__m128i a,  __m128i b)
        // __m128 _mm_unpacklo_ps (__m128 a,  __m128 b)
        // __m128d _mm_unpacklo_pd (__m128d a,  __m128d b)
        public static Vector128<T> UnpackLow<T>(Vector128<T> left,  Vector128<T> right) where T : struct { throw new NotImplementedException(); }
        
        // __m128i _mm_xor_si128 (__m128i a,  __m128i b)
        // __m128 _mm_xor_ps (__m128 a,  __m128 b)
        // __m128d _mm_xor_pd (__m128d a,  __m128d b)
        public static Vector128<T> Xor<T>(Vector128<T> left,  Vector128<T> right) where T : struct { throw new NotImplementedException(); }
    }
}