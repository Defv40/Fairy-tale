public class Flower : Item
{
    public override void Interact()
    {
       Player.Instance.PlaySound();
       base.Interact();
    }
}

