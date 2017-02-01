using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Recipes
{
    static class UIController
    {
        //public Program program;
        //public ProgramState programState;
        private static string programMessage;


        public static void UpdateUI(ProgramState state)
        {
            switch (state)
            {
                case ProgramState.MAIN_MENU:
                    Console.Clear();
                    Headings.DisplayMainMenuHeading();
                    DisplayProgramMessage();
                    Menus.SelectMainMenuOption();
                    break;
                case ProgramState.RECIPE_CATALOG_MENU:
                    Console.Clear();
                    Headings.DisplayRecipeCatalogHeading();
                    DisplayProgramMessage();
                    Menus.SelectRecipeCatalogMenuOption();
                    break;
                case ProgramState.RECIPE_CATALOG_ADD:
                    Console.Clear();
                    Headings.DisplayRecipeCatalogHeading();
                    DisplayProgramMessage();
                    //Menus.SelectRecipeCatalogMenuOption();
                    break;
                case ProgramState.RECIPE_CATALOG_REMOVE:
                    Console.Clear();
                    Headings.DisplayRecipeCatalogHeading();
                    DisplayProgramMessage();
                    break;
                case ProgramState.FOOD_INVENTORY_MENU:
                    Console.Clear();
                    Headings.DisplayFoodInventoryHeading();
                    DisplayProgramMessage();
                    Menus.SelectFoodInventoryMenuOption();
                    break;
                case ProgramState.ANALYZER_MENU:
                    Console.Clear();
                    Headings.DisplayAnalyzerHeading();
                    DisplayProgramMessage();
                    Menus.SelectAnalyzerMenuOption();
                    break;
                default:
                    break;
            }//end switch
        }//end UpdateUI

        public static void AddProgramMessage(string _message)
        {
            programMessage = _message;
        }
        public static void DisplayProgramMessage()
        {
            //Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("--------------------------------");
            Console.WriteLine(programMessage);
            Console.WriteLine("--------------------------------");
            programMessage = "";
        }


    }
    class Menus
    {
        /// <summary>
        /// Fucntion to select an option in the main menu
        /// </summary>
        public static void SelectMainMenuOption()
        {
            Console.WriteLine("\nPlease choose an option from the following");
            Console.WriteLine("1:Recipe Catalog");
            Console.WriteLine("2:Food Inventory");
            Console.WriteLine("3:Analyzer");
            Console.WriteLine("4:Exit Program");
            Console.WriteLine("\nSelection: ");
        }//SelectMainMenuFunction
        /// <summary>
        /// Fucntion to select an option in the Recipe Catalog menu
        /// </summary>
        public static void SelectRecipeCatalogMenuOption()
        {
            Console.WriteLine("\nPlease choose an option from the following");
            Console.WriteLine("1:Add Recipe");
            Console.WriteLine("2:Remove Recipe");
            Console.WriteLine("3:Edit Recip");
            Console.WriteLine("4:Show All Recipes");
            Console.WriteLine("5:Back To Main Menu");
            Console.WriteLine("\nSelection: ");
        }//End SelectRecipeCatalogFunction

        /// <summary>
        /// This displays the menu for the Food Inventory
        /// </summary>
        public static void SelectFoodInventoryMenuOption()
        {
            Console.WriteLine("\nPlease choose an option from the following");
            Console.WriteLine("1:Add Food Item");
            Console.WriteLine("2:Remove Food Item");
            Console.WriteLine("3:Display Inventory");
            Console.WriteLine("4:Back To Main Menu");
            Console.WriteLine("\nSelection: ");
        }//End SelectRecipeCatalogFunction

        /// <summary>
        /// This displays the menu for the Analyzer function
        /// </summary>
        public static void SelectAnalyzerMenuOption()
        {
            Console.WriteLine("\nPlease choose an option from the following");
            Console.WriteLine("1:Analyze Inventory and Recipes");
            Console.WriteLine("2:Back To Main Menu");
            Console.WriteLine("\nSelection: ");
        }//End SelectRecipeCatalogFunction


    }
    class Headings
    {
        /// <summary>
        /// Display the intro to the program in the console
        /// </summary>
        public static void DisplayMainMenuHeading()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("Welcome to the beta version of the recipes app");
            Console.WriteLine("====================================================");

        }
        /// <summary>
        /// Display the menu for the recipe catalog state
        /// </summary>
        public static void DisplayRecipeCatalogHeading()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("Recipe Catalog:");
            Console.WriteLine("====================================================");

        }
        /// <summary>
        /// Display the menu for the food inventory state
        /// </summary>
        public static void DisplayFoodInventoryHeading()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("Food Inventory:");
            Console.WriteLine("====================================================");

        }
        /// <summary>
        /// Display the menu for the analyzer state
        /// </summary>
        public static void DisplayAnalyzerHeading()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("Analyzer:");
            Console.WriteLine("====================================================");

        }
    }
}
