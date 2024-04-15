namespace BlazorWebAppEFCore.Data
{
    internal class Seed
    {
        protected string RandomOne(string[] list)
        {
            var idx = new Random().Next(list.Length);
            return list[idx];
        }

        protected DateOnly RandomDate()
        {
            var random = new Random();
            var start = new DateTime(2000, 1, 1);
            var range = (DateTime.Today - start).Days;
            return DateOnly.FromDateTime(start.AddDays(random.Next(range)));
        }

        protected TEnum RandomEnumValue<TEnum>(params TEnum[] notAllowedEnums) where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
            var allowedValues = enumValues.Except(notAllowedEnums).ToList();

            if (!allowedValues.Any())
            {
                throw new InvalidOperationException("No hay valores permitidos para seleccionar.");
            }

            var random = new Random();
            var randomIndex = random.Next(allowedValues.Count);

            return allowedValues[randomIndex];
        }
    }
}
