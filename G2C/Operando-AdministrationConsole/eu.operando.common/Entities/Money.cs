using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


namespace eu.operando.common.Entities
{

    

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

        public CurrencyCode Currency { get; set; }

        public decimal Value { get; set; }

        public override string ToString()
        {
            return $"{Value} ({Currency})";
        }

        /// <summary>
        /// All currency codes
        /// </summary>
        public static CurrencyCode[] AvailableCurrencyCodes { get; } = Enum.GetValues(typeof(CurrencyCode)).Cast<CurrencyCode>().ToArray();

        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Currencies are written this way")]
        public enum CurrencyCode
        {
            EUR,
            USD,
            CAD,
            GBP,
            AUD,
            JPY
        }
    }
}
