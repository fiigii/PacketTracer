namespace System.Runtime.CompilerServices.Intrinsics.Intel
{
    public enum StringComparisonMode : byte {
        CompareEqualAny = 0x00,
        CompareRanges = 0x04,
        CompareEqualEach = 0x08,
        CompareEqualOrdered = 0x0c,
        NegativePolarity = 0x10,
        MaskedNegativePolarity = 0x30,
        LeastSignificant = 0x00,
        MostSignificant = 0x40,
    }

    public enum FloatComparisonMode : byte
    {
        CompareEqualOrderedNonSignaling,
        CompareLessThanOrderedSignaling,
        CompareLessThanOrEqualOrderedSignaling,
        CompareUnorderedNonSignaling,
        CompareNotEqualUnorderedNonSignaling,
        CompareNotLessThanUnorderedSignaling,
        CompareNotLessThanOrEqualUnorderedSignaling,
        CompareOrderedNonSignaling,
        CompareEqualUnorderedNonSignaling,
        CompareNotGreaterThanOrEqualUnorderedSignaling,
        CompareNotGreaterThanUnorderedSignaling,
        CompareFalseOrderedNonSignaling,
        CompareNotEqualOrderedNonSignaling,
        CompareGreaterThanOrEqualOrderedSignaling,
        CompareGreaterThanOrderedSignaling,
        CompareTrueUnorderedNonSignaling,
        CompareEqualOrderedSignaling,
        CompareLessThanOrderedNonSignaling,
        CompareLessThanOrEqualOrderedNonSignaling,
        CompareUnorderedSignaling,
        CompareNotEqualUnorderedSignaling,
        CompareNotLessThanUnorderedNonSignaling,
        CompareNotLessThanOrEqualUnorderedNonSignaling,
        CompareOrderedSignaling,
        CompareEqualUnorderedSignaling,
        CompareNotGreaterThanOrEqualUnorderedNonSignaling,
        CompareNotGreaterThanUnorderedNonSignaling,
        CompareFalseOrderedSignaling,
        CompareNotEqualOrderedSignaling,
        CompareGreaterThanOrEqualOrderedNonSignaling,
        CompareGreaterThanOrderedNonSignaling,
        CompareTrueUnorderedSignaling,
    }

    public enum ResultsFlag : byte {
        CFlag,
        NotCFlagAndNotZFlag,
        OFlag,
        SFlag,
        ZFlag,
    }
}