using System.Text;

namespace PasswordManager.Views;

public partial class GeneratorPage : ContentPage
{
	private double PasswordLength = 8;

	public GeneratorPage()
	{
		InitializeComponent();

        LowerCheckbox.IsChecked = true;
        UpperCheckbox.IsChecked = true;
        NumCheckbox.IsChecked = true;
        SpecialCheckbox.IsChecked = true;
    }

	public void UpdateLength(object? sender, EventArgs e)
	{
		PasswordLength = (int)Math.Round(LengthField.Value);
        LengthLabel.Text = $"Длина\n{PasswordLength}";

        GeneratePassword(sender, e);
    }


    public void GeneratePassword(object? sender, EventArgs e)
    {
        bool avoidAmbiguous = AvoidAmbiguousCheckbox.IsChecked;
        bool useLower = LowerCheckbox.IsChecked;
        bool useUpper = UpperCheckbox.IsChecked;
        bool useDigits = NumCheckbox.IsChecked;
        bool useSpecial = SpecialCheckbox.IsChecked;

        int minDigits = NumsCountInput.Value;
        int minSpecial = SpecialCountInput.Value;

        string lower = "abcdefghijklmnopqrstuvwxyz";
        string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string digits = "0123456789";
        string special = "!@#$%^&*()-_=+[]{};:,.<>?";

        // Символы, которых нужно избегать
        if (avoidAmbiguous)
        {
            lower = lower.Replace("l", "");
            upper = upper.Replace("I", "").Replace("O", "");
            digits = digits.Replace("0", "");
        }

        // Формируем набор допустимых символов
        var charPool = new StringBuilder();
        if (useLower) charPool.Append(lower);
        if (useUpper) charPool.Append(upper);
        if (useDigits) charPool.Append(digits);
        if (useSpecial) charPool.Append(special);

        if (charPool.Length == 0)
        {
            PasswordField.Text = "Выберите хотя бы один тип символов!";
            return;
        }

        Random rand = new Random();
        StringBuilder password = new StringBuilder();

        // Добавляем минимальные цифры
        for (int i = 0; i < minDigits && useDigits; i++)
            password.Append(digits[rand.Next(digits.Length)]);

        // Добавляем минимальные спецсимволы
        for (int i = 0; i < minSpecial && useSpecial; i++)
            password.Append(special[rand.Next(special.Length)]);

        // Заполняем оставшуюся длину случайными символами
        while (password.Length < PasswordLength)
            password.Append(charPool[rand.Next(charPool.Length)]);

        // Перемешиваем пароль
        PasswordField.Text = Shuffle(password.ToString());
    }

    private string Shuffle(string input)
    {
        Random rand = new Random();
        return new string(input.OrderBy(_ => rand.Next()).ToArray());
    }


}