namespace XSerializeSample;

[XmlSerializable]
public class Product
{
    public string Title { get; set; }
    public decimal Price { get; set; }
}