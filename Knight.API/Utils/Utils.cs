namespace Knight.API.Helper
{
    public class Utils
    {
        public static int AgeCalculator(DateTime data)
        {
            return DateTime.Now.Year - data.Year;
        }

        public static int TableMod(int modValue)
        {
            if (Enumerable.Range(1, 8).Contains(modValue))
                return -2;
            if (Enumerable.Range(9, 10).Contains(modValue))
                return -1;
            if (Enumerable.Range(11, 12).Contains(modValue))
                return 0;
            if (Enumerable.Range(13, 15).Contains(modValue))
                return 1;
            if (Enumerable.Range(16, 18).Contains(modValue))
                return 2;
            if (Enumerable.Range(19, 20).Contains(modValue))
                return 3;
            return modValue;
        }
    }
}
