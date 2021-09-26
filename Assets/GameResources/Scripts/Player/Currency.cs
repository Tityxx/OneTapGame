using System;
/// <summary>
/// Валюта игрока
/// </summary>
public static class Currency
{
    public static event Action<int> OnChangeCoins = delegate { };

    public static int Coins
    {
        get
        {
            return PrefsHelper.GetInt(COIN, 0);
        }
        set
        {
            PrefsHelper.SetInt(COIN, value);
            OnChangeCoins(value);
        }
    }


    private const string COIN = "COIN";
}
