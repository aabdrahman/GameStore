namespace GameStore.UI.Models;

public class GameDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string genre { get; set; }
    public string company { get; set; }
    public decimal price { get; set; }
    public DateOnly releasedDate { get; set; }
}