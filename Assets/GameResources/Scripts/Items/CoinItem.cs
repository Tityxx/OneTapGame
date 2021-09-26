/// <summary>
/// Подбор монет
/// </summary>
public class CoinItem : AbstractPlayerCollision
{
    protected override void DoAction(PlayerController player)
    {
        Currency.Coins++;
        Destroy(gameObject);
    }
}
