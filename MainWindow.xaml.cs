//
// 
//
//
//
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S1P2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			// Name   : MainWindow()
			// Purpose: Main entry to the program
			// Reuse  : None
			// Input  : None
			// Output : None
			InitializeComponent();
			cboCalcType.SelectedIndex = 0;
		}//MainWindow
		delegate float WattsLawDelegate(float firstparameter, float secondparameter);

		private void cboCalcType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Name   : cboCalcType_SelectionChanged(object sender, SelectionChangedEventArgs e)
			// Purpose: Select a calculation type
			// Reuse  : None
			// Input  : object sender; SelectionChangedEventArgs e
			// Output : None

			int selectedIndex = cboCalcType.SelectedIndex;
			switch (selectedIndex)
			{
				case 0:
					lblFirstValue.Content = "Current";
					lblSecondValue.Content = "Voltage";
					break;
				case 1:
					lblFirstValue.Content = "Power";
					lblSecondValue.Content = "Voltage";
					break;
				case 2:
					lblFirstValue.Content = "Power";
					lblSecondValue.Content = "Current";
					break;
			}// end switch
		}// end method

		private void btnClar_Click(object sender, RoutedEventArgs e)
		{
			//
			// Name   : btnClar_Click(object sender, RoutedEventArgs e)
			// Purpose: Clear all the text boxes and set a default index to the combo box
			// Reuse  : None
			// Input  : object sender; SelectionChangedEventArgs e
			// Output : None
			//

			cboCalcType.SelectedIndex = 0;
			txtFirstValue.Clear();
			txtResults.Clear();
			txtSecondValue.Clear();
			lblResult.Content = "Results";
		}// end method

		private void btnCalculate_Click(object sender, RoutedEventArgs e)
		{
			//
			// Name   : btnCalculate_Click(object sender, RoutedEventArgs e)
			// Purpose: Calculate and ouput the results
			// Reuse  : CalcPower(),CalcCurrent(),CalcVoltage()
			// Input  : object sender; SelectionChangedEventArgs e
			// Output : float results
			//

			float firstparameter = 0;
			float secondparameter = 0;
			string method = " ";
			WattsLawDelegate wattsLaw = null;
			bool calculate = false;
			string option = cboCalcType.SelectedIndex.ToString();

			try
			{
				switch (option)
				{
					case "0":
						firstparameter = float.Parse(txtFirstValue.Text.ToString());
						secondparameter = float.Parse(txtSecondValue.Text.ToString());
						wattsLaw = new WattsLawDelegate(CalcPower);
						method = "power";
						calculate = true;
						break;
					case "1":
						firstparameter = float.Parse(txtFirstValue.Text.ToString());
						secondparameter = float.Parse(txtSecondValue.Text.ToString());
						wattsLaw = new WattsLawDelegate(CalcCurrent);
						method = "Current";
						calculate = true;
						break;
					case "2":
						firstparameter = float.Parse(txtFirstValue.Text.ToString());
						secondparameter = float.Parse(txtSecondValue.Text.ToString());
						wattsLaw = new WattsLawDelegate(CalcVoltage);
						method = "Voltage";
						calculate = true;
						break;
				}//end switch
				if (calculate)
				{
					lblResult.Content = $"The  {method} is";
					txtResults.Text = wattsLaw(firstparameter, secondparameter).ToString();
				}//switch if
			}//end try
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "btnCalculate_Click", MessageBoxButton.OK, MessageBoxImage.Error);
			}//end catch
			
		}//end method
		private void Close_Click(object sender, RoutedEventArgs e)// end method
		{
		    //
		     // Name   : Close_Click(object sender, RoutedEventArgs e)
		     // Purpose: Stop the program
		     // Reuse  : none
		     // Input  : object sender, RoutedEventArgs e
		     // Output : none
		     //
			this.Close();
		}
		//Calculate Methods
		///////////////////////////////////////////////////////////////////////////
		public static float CalcPower(float current, float voltage)
		{
			// Name   : float CalcPower(float current, float voltage)
			// Purpose: Calculate power and return it
			// Reuse  : None
			// Input  : int current
			//           - current value 
			//          int voltage
			//           - voltage value
			// Output : float
			//          - power

			float resut = 0;
			try
			{
				resut = current * voltage;
			}// end try
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "CalcPower", MessageBoxButton.OK, MessageBoxImage.Error);
			}// end catch
			return resut;// return value
		}//end method
		public static float CalcVoltage(float power, float current)
		{
			//
			// Name   : float CalcVoltage(float power, float current)
			// Purpose: Calculate voltage and return it
			// Reuse  : None
			// Input  : int power; int current
			// Output : int
			//          - results
			// 
			float results = 0;
			try
			{
				results = power / current;
			}// end try
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "CalcVoltage", MessageBoxButton.OK, MessageBoxImage.Error);
			}// end-catch
			return results;// return value
		}//end method
		public static float CalcCurrent(float power, float voltage)
		{
			//
			// Name   : float CalcCurrent(float power, float voltage)
			// Purpose: Calculate Current and return it
			// Reuse  : None
			// Input  : int power; int voltage
			// Output : int
			//          - the results
			// 
			float results = 0;
			try
			{
				results = power / voltage;
			}//end try
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "CalcCurrent", MessageBoxButton.OK, MessageBoxImage.Error);
			}// end catch
			return results;// return value
		}//end method

        private void TxtFirstValue_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        ///////////////////////////////////////////////////////////////////////////
    }
}
