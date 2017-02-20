package bda.Model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Currency;

public final class Money implements Serializable {

	/**
	 * Automatically generated
	 */
	private static final long serialVersionUID = 3775681192254267042L;

	private final Currency currency;
	private final BigDecimal value;
	
	public Money(Currency currency, BigDecimal value) {
		this.currency = currency;
		this.value = value;
	}	
	
	public String toString()	{
		return String.format("{0} {1}", this.value, this.currency.getCurrencyCode());
	}
	
	public boolean equals(Object other) {
		
		if (other == this) return true;
		
		if (!(other instanceof Money)) return false;
		
		Money otherMoney = (Money)other;
		return currency == otherMoney.currency &&
				value == otherMoney.value;
	}
	
}
