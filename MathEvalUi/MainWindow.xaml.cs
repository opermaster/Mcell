using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
namespace MathEvalUi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
            //MathEval.Calculate("1+1");
            Cell_Grid.Columns.Add(new DataGridTextColumn());
            Cell_Grid.Items.Add(new Line("1"," "," "," "," "));
            Cell_Grid.Items.Add(new Line("2"," "," "," "," "));
            Cell_Grid.Items.Add(new Line("3"," "," "," "," "));
            Cell_Grid.Items.Add(new Line("4"," ", " ", " ", " "));
            Cell_Grid.Items.Add(new Line("5", " ", " ", " ", " "));

        }

    }
}
