using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace Recipes
{
    /// <summary>
    /// The Main calss that application is built around
    /// </summary>
    public class RecipeProgramMainWindow
    {
        public List<RecipeDataObject> recipeCatalog = new List<RecipeDataObject>();
        public List<FoodInventoryDataObject> foodInventory = new List<FoodInventoryDataObject>();
        ////////////////////////////////////////////////////////////////
        public void StartProgram()
        {
            //Switch statement to run to see what part of the program you are currently in
            while (MainWindow.currentProgramState != ProgramState.EXIT_APPLICATION)
            {
                switch (MainWindow.currentProgramState)
                {
                    case ProgramState.MAIN_MENU:
                        SelectMainMenuOption();
                        break;
                    case ProgramState.RECIPE_CATALOG_MENU:
                        SelectRecipeCatalogMenuOption();
                        break;
                    case ProgramState.FOOD_INVENTORY_MENU:
                        SelectFoodInventoryMenuOption();
                        break;
                    case ProgramState.ANALYZER_MENU:
                        SelectAnalyzerMenuOption();
                        break;
                    default:
                        break;
                }//end switch
            }//end while
            Console.WriteLine("Exiting Application: Press any key to exit");
            Console.ReadLine();
            System.Environment.Exit(1);
        }
        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// Fucntion to select an option in the main menu
        /// </summary>
        private void SelectMainMenuOption()
        {
            UIController.UpdateUI(MainWindow.currentProgramState);
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        MainWindow.currentProgramState = ProgramState.RECIPE_CATALOG_MENU;
                        break;
                    case 2:
                        MainWindow.currentProgramState = ProgramState.FOOD_INVENTORY_MENU;
                        break;
                    case 3:
                        MainWindow.currentProgramState = ProgramState.ANALYZER_MENU;
                        break;
                    case 4:
                        MainWindow.currentProgramState = ProgramState.EXIT_APPLICATION;
                        break;
                    default:
                        throw new Exception("Not a valid selection!");
                }//End Switch
            }//End Try block
            catch (Exception excep)
            {
                UIController.AddProgramMessage(RecipeExceptions.AnalyzeException(excep));
            }//End Catch Block
        }//SelectMainMenuFunction
        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// Fucntion to select an option in the Recipe Catalog menu
        /// </summary>
        private void SelectRecipeCatalogMenuOption()
        {
            UIController.UpdateUI(MainWindow.currentProgramState);
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        MainWindow.currentProgramState = ProgramState.RECIPE_CATALOG_ADD;
                        TryToAddRecipe();
                        MainWindow.currentProgramState = ProgramState.RECIPE_CATALOG_MENU;
                        break;
                    case 2:
                        MainWindow.currentProgramState = ProgramState.RECIPE_CATALOG_REMOVE;
                        TryToRemoveRecipe();
                        MainWindow.currentProgramState = ProgramState.RECIPE_CATALOG_MENU;
                        break;
                    case 3:
                        MainWindow.currentProgramState = ProgramState.RECIPE_CATALOG_EDIT;
                        UIController.AddProgramMessage("Edit recipe, not going to do this in colsole since the end program will be WPF and be much easier to implement this");
                        MainWindow.currentProgramState = ProgramState.RECIPE_CATALOG_MENU;
                        break;
                    case 4:
                        MainWindow.currentProgramState = ProgramState.RECIPE_CATALOG_DISPLAY;
                        if (recipeCatalog.Count == 0)
                        {
                            UIController.AddProgramMessage("Catalog is empty!");
                        }
                        else
                        {
                            OutputCatalogToConsole();
                        }
                        MainWindow.currentProgramState = ProgramState.RECIPE_CATALOG_MENU;
                        break;
                    case 5:
                        MainWindow.currentProgramState = ProgramState.MAIN_MENU;
                        break;
                    default:
                        throw new Exception("Not a valid selection!");
                }//End Switch
            }//End Try block
            catch (Exception excep)
            {
                UIController.AddProgramMessage(RecipeExceptions.AnalyzeException(excep));
            }//End Catch Block
        }//End SelectRecipeCatalogFunction
        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// This displays the menu for the Food Inventory
        /// </summary>
        private void SelectFoodInventoryMenuOption()
        {
            UIController.UpdateUI(MainWindow.currentProgramState);
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        MainWindow.currentProgramState = ProgramState.FOOD_INVENTORY_ADD;
                        TryToAddFoodItem();
                        MainWindow.currentProgramState = ProgramState.FOOD_INVENTORY_MENU;
                        break;
                    case 2:
                        MainWindow.currentProgramState = ProgramState.FOOD_INVENTORY_REMOVE;
                        TryToRemoveFoodItem();
                        MainWindow.currentProgramState = ProgramState.FOOD_INVENTORY_MENU;
                        break;
                    case 3:
                        MainWindow.currentProgramState = ProgramState.FOOD_INVENTORY_DISPLAY;
                        OutputFoodInventoryToConsole();
                        MainWindow.currentProgramState = ProgramState.FOOD_INVENTORY_MENU;
                        break;
                    case 4:
                        MainWindow.currentProgramState = ProgramState.MAIN_MENU;
                        break;
                    default:
                        throw new Exception("Not a valid selection!");
                }//End Switch
            }//End Try block
            catch (Exception excep)
            {
                UIController.AddProgramMessage(RecipeExceptions.AnalyzeException(excep));
            }//End Catch Block
        }//End SelectRecipeCatalogFunction
        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// This displays the menu for the Analyzer function
        /// </summary>
        private void SelectAnalyzerMenuOption()
        {
            UIController.UpdateUI(MainWindow.currentProgramState);
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Analyze Inventory and Recipes");
                        break;
                    case 2:
                        MainWindow.currentProgramState = ProgramState.MAIN_MENU;
                        break;
                    default:
                        throw new Exception("Not a valid selection!");
                }//End Switch
            }//End Try block
            catch (Exception excep)
            {
                UIController.AddProgramMessage(RecipeExceptions.AnalyzeException(excep));
            }//End Catch Block
        }//End SelectRecipeCatalogFunction
        ////////////////////////////////////////////////////////////////
        private bool DoesRecipeAlreadyExist(ref RecipeDataObject _recipe)
        {
            bool recipeAlreadyExistsInitialCondition = false;
            if (recipeCatalog.Count == 0)
            {
                recipeAlreadyExistsInitialCondition = false;
                UIController.AddProgramMessage("Recipe Catalog is blank! First Recipe Added");
                return recipeAlreadyExistsInitialCondition;
            }
            else
            {
                for (int i = 0; i < recipeCatalog.Count; i++)
                {
                    if (RecipeDataObject.CompareRecipes(recipeCatalog[i], _recipe))
                    {
                        recipeAlreadyExistsInitialCondition = true;
                        UIController.AddProgramMessage("already exists!");
                        break;
                    }
                    else
                    {
                        recipeAlreadyExistsInitialCondition = false;
                        UIController.AddProgramMessage("Recipe Added!");
                    }
                }
            }
            return recipeAlreadyExistsInitialCondition;
        }
        private void TryToAddRecipe()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            RecipeDataObject recipe = new RecipeDataObject(ofd.FileName);
            if (!DoesRecipeAlreadyExist(ref recipe))
            {
                recipeCatalog.Add(recipe);
            }
        }
        private void TryToRemoveRecipe()
        {
            UIController.AddProgramMessage("Please enter the name of the recipe you want removed");
            UIController.UpdateUI(MainWindow.currentProgramState);
            string recipeYouWantRemoved = Console.ReadLine();
            recipeYouWantRemoved = recipeYouWantRemoved.ToLower();
            try
            {
                foreach (RecipeDataObject _recipe in recipeCatalog)
                {
                    if (_recipe.Name.ToLower() == recipeYouWantRemoved)
                    {
                        recipeCatalog.Remove(_recipe);
                        UIController.AddProgramMessage("Recipe Sucessfully Removed");
                        break;
                    }
                    else
                    {
                        UIController.AddProgramMessage("Recipe does not exist or you typed the name in wrong");
                    }
                }
            }
            catch (Exception excep)
            {
                Console.WriteLine(RecipeExceptions.AnalyzeException(excep));
            }
        }
        private void OutputCatalogToConsole()
        {
            Console.Clear();

            foreach (RecipeDataObject rec in recipeCatalog)
            {
                Console.WriteLine("====================================================");
                Console.WriteLine("Name:{0}", rec.Name);
                Console.WriteLine("Cost:{0}", rec.Cost);
                Console.WriteLine("Serving Size:{0}", rec.ServingSize);
                Console.WriteLine("Ingredients:");
                for (int i = 0; i < rec.Ingredients.Count; i++)
                {
                    Console.WriteLine("\t" + rec.Ingredients[i]);
                }
                Console.WriteLine("Instructions:");
                for (int i = 0; i < rec.CookingInstructions.Count; i++)
                {
                    Console.WriteLine("\t" + rec.CookingInstructions[i]);
                }
                Console.WriteLine("Notes:");
                for (int i = 0; i < rec.Notes.Count; i++)
                {
                    Console.WriteLine("\t" + rec.Notes[i]);
                }
                Console.WriteLine("Resources:");
                for (int i = 0; i < rec.Resources.Count; i++)
                {
                    Console.WriteLine("\t" + rec.Resources[i]);
                }
                Console.WriteLine("\n====================================================");
            }
            Console.ReadLine();
        }//End OutputCatalogToConsole
        private void TryToAddFoodItem()
        {
            AddFoodItem addFoodItem = new AddFoodItem(this);
            addFoodItem.ShowDialog();
        }//End TryToAddFoodItem
        private void TryToRemoveFoodItem()
        {
            //RemoveFoodItem removeFoodItem = new RemoveFoodItem(this);
            //removeFoodItem.ShowDialog();
        }//End TryToREmoveFoodItem
        private void OutputFoodInventoryToConsole()
        {
            if (foodInventory.Count == 0)
            {
                UIController.AddProgramMessage("Food inventory is empty!");
            }
            else
            {
                Console.Clear();
                foreach (FoodInventoryDataObject _foodInventoryDataObject in foodInventory)
                {
                    Console.WriteLine("\n====================================================");
                    Console.WriteLine("Food: {0}", _foodInventoryDataObject.Name);
                    Console.WriteLine("Quantity: {0} {1}", _foodInventoryDataObject.Quantity, _foodInventoryDataObject.CurrentUnit);
                    Console.WriteLine("Price: {0}", _foodInventoryDataObject.Price);
                    Console.WriteLine("Expiration Date: {0}", _foodInventoryDataObject.ExpirationDate);
                    Console.WriteLine("\nSubstitutions:");
                    foreach (string substitutions in _foodInventoryDataObject.Substitutes)
                    {
                        Console.WriteLine("{0}", substitutions);
                    }
                    Console.WriteLine("====================================================");
                }
                Console.ReadLine();
            }
        }//End OutputFoodInventoryToConsole
    }//End Class RecipeProgramMainWindow
}//End Namespace Recipes
