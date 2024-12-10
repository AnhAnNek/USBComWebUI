namespace USBComWebUI.Components.Pages
{
    public class DataPointProvider
    {
        public static List<DataPoint> ReturnPoints() {
        return new List<DataPoint>() {
            new DataPoint("USA", 4.21),
            new DataPoint("China", 3.33),
            new DataPoint("Turkey", 2.6),
            new DataPoint("Italy", 2.2),
            new DataPoint("India", 2.16),
        };
    }
    }
}
