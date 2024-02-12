using System;
using System.Collections.Generic;
using System.Windows;
using MathEvalLogic;
using TableIOLogic;
namespace MathEvalUi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TableIO Table;
        private void PrintTable(string[,] table) {
            Table_view.Text="";
            for (int i = 0; i < table.GetLength(0); i++) {
                for (int j = 0; j < table.GetLength(1); j++) {
                    Table_view.Text+=table[i, j]+"   ";
                }
                Table_view.Text +='\n';
            }
        }
        public MainWindow() {
            InitializeComponent();
            Table = new TableIO();
            PrintTable(Table.GetTable());
        }

        private void Calculate_button_Click(object sender, RoutedEventArgs e) {
            string command_text = Input_commands.Text.Replace(" ", "");

            if (!(command_text == "")) {
                string[] commands = command_text.Split('\n');
                PrintTable(TableIO.Main(commands));
            }
            else MessageBox.Show("Wrong input!!");
        }

        private void Clear_button_Click(object sender, RoutedEventArgs e) {
            Table.ClearTable();
            PrintTable(Table.GetTable());
        }
    }
}
