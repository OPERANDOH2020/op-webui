using System;
using System.Diagnostics.CodeAnalysis;


namespace eu.operando.common.Entities
{

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Currencies are written this way")]
    public enum Currency
    {
        EUR,
        USD,
        CAD,
        GBP,
        AUD,
        JPJ
    }

    /// <summary>
    /// Contains an amount and the currency that it is in
    /// </summary>
    [Serializable]
    public sealed class Money
    {
        [SuppressMessage("ReSharper", "EmptyConstructor", Justification = "Default Ctor required for serialization")]
        public Money()
        {
        }

        public Currency Currency { get; set; }

        public decimal Value { get; set; }

        public override string ToString()
        {
            return $"{Value} ({Currency})";
        }
    }
}
