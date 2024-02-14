using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MathEvalLogic;
using TableIOLogic;
namespace MathEvalUi
{
    class TableUi {
        public TextBox[,] Cells;
        public TableUi(string[,] table_start_data, IAddChild parent_elem) {
            Cells = new TextBox[table_start_data.GetLength(0), table_start_data.GetLength(1)];
            for (int i = 0; i < table_start_data.GetLength(0); i++) {
                for (int j = 0; j < table_start_data.GetLength(1); j++) {
                    TextBox cell = new TextBox();
                    cell.MinHeight = 30;
                    cell.MaxHeight = 30;
                    cell.MinWidth = 43;
                    cell.MaxWidth = 43;
                    cell.Focusable=false;
                    cell.Text = table_start_data[i, j];
                    Cells[i, j] = cell;
                }
            }
            TableToEllem(parent_elem);
        }
        private void TableToEllem(IAddChild parent_elem) {
            for (int i = 0; i < Cells.GetLength(0); i++) {
                for (int j = 0; j < Cells.GetLength(1); j++) {
                    parent_elem.AddChild(Cells[i, j]);
                }
            }
            
        }

    }
    /// <summary>
    /// MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        TableIO Table;
        TableUi table_ui;
        private void PrintTable(string[,] table) {
            for (int i = 0; i < table.GetLength(0); i++) {
                for (int j = 0; j < table.GetLength(1); j++) {
                    table_ui.Cells[i,j].Text=table[i, j];
                }
            }
        }
        public MainWindow() {
            InitializeComponent();
            Table = new TableIO();
            string[,] tb = Table.GetTable();
            table_ui = new TableUi(tb,wrap_panel);
            PrintTable(tb);
            
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
