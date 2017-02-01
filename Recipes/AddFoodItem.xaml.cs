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
using System.Windows.Shapes;

namespace Recipes
{
    /// <summary>
    /// Interaction logic for AddFoodItem.xaml
    /// </summary>
    public partial class AddFoodItem : Window
    {
        
            RecipeProgramMainWindow mainWindow;
        public AddFoodItem(RecipeProgramMainWindow _mainWindow)
        {
           
            mainWindow = _mainWindow as RecipeProgramMainWindow;
            //ComboBox_Units.DataSource = Enum.GetValues(typeof(Units));
        }
        
    }
}
