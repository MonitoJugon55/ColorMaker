using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	bool isRandom = false;
	string hexValue;
	public MainPage()
	{
		InitializeComponent();
	}

	private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (!isRandom) 
		{
			//Get the values in the slides
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;
			//FromRgb transforms the three values into rgb code colors
            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }
		
	}

	private void SetColor(Color color)
	{
		btnRandom.Background = color;
        Container.Background = color;
		//Parse the rgb code color into hex
		hexValue = color.ToHex();
		lblHex.Text = hexValue;

    }

	private async void CopyHex_Clicked(object sender, EventArgs e)
	{
		//Copy the hex code color clicking in the image
		await Clipboard.SetTextAsync(hexValue);
		//Alerts saying the person copied the color
		var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
		await toast.Show();
	}

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		
		isRandom = true;
		Random random = new Random();
        //Generates a random color with values from 0 to 255 including 255
        var color = Color.FromRgb(
			random.Next(0,256),
            random.Next(0, 256),
            random.Next(0, 256));

		SetColor(color);

		//Assign the red, green and blue that generates the color to the three slides 
		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;
		isRandom = false;
	}
}

