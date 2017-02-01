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
using Microsoft.Win32;

namespace Recipes
{

    public enum ProgramState
    {
        MAIN_MENU,
        RECIPE_CATALOG_MENU,
        RECIPE_CATALOG_ADD,
        RECIPE_CATALOG_REMOVE,
        RECIPE_CATALOG_EDIT,
        RECIPE_CATALOG_DISPLAY,
        FOOD_INVENTORY_MENU,
        FOOD_INVENTORY_ADD,
        FOOD_INVENTORY_REMOVE,
        FOOD_INVENTORY_DISPLAY,
        ANALYZER_MENU,
        EXIT_APPLICATION
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static ProgramState currentProgramState;
        public static RecipeProgramMainWindow recipeProgramMainWindow = new RecipeProgramMainWindow();

        public MainWindow()
        {
            InitializeComponent();
            //Initialize the program by setting it to the main menu
            currentProgramState = ProgramState.MAIN_MENU;
            //recipeProgramMainWindow.StartProgram();
  
        }
    }
}
