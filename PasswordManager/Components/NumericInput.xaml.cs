using Microsoft.UI.Xaml.Controls;

namespace PasswordManager.Components;

public partial class NumericInput : ContentView
{
    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(
            nameof(Value),
            typeof(int),
            typeof(NumericInput),
            0,
            BindingMode.TwoWay);

    public static readonly BindableProperty MinValueProperty =
        BindableProperty.Create(
            nameof(MinValue),
            typeof(int),
            typeof(NumericInput),
            0);

    public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create(
            nameof(MaxValue),
            typeof(int),
            typeof(NumericInput),
            100);

    public event EventHandler<int>? ValueChanged;

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public int MinValue
    {
        get => (int)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public int MaxValue
    {
        get => (int)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public NumericInput()
    {
        InitializeComponent();
    }
    private static void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
    {
    }

    private void OnMinusClicked(object sender, EventArgs e)
    {
        if (Value > MinValue)
        {
            Value--;
            ValueChanged?.Invoke(sender, Value);
        }
    }

    private void OnPlusClicked(object sender, EventArgs e)
    {
        if (Value < MaxValue)
        {
            Value++;
            ValueChanged?.Invoke(sender, Value);
        }
    }
}