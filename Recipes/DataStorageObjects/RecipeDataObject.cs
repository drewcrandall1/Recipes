using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes
{
    public class RecipeDataObject
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public int ServingSize { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> CookingInstructions { get; set; }
        public List<string> Notes { get; set; }
        public List<string> Resources { get; set; }
        /// <summary>
        /// Constructor for the Recipe Class
        /// </summary>
        /// <param name="fileName"></param>
        public RecipeDataObject(string fileName)
        {
            Ingredients = new List<string>();
            CookingInstructions = new List<string>();
            Notes = new List<string>();
            Resources = new List<string>();

            XmlDocument XMLDOC = new XmlDocument();
            XMLDOC.Load(fileName);
            XmlNodeList xmllist = XMLDOC.DocumentElement.ChildNodes;

            foreach (XmlNode node in xmllist)
            {
                switch (node.Name)
                {
                    case "Name" :
                        Name = node.InnerText;
                        break;
                    case "Cost":
                        Cost = double.Parse(node.InnerText);
                        break;
                    case "ServingSize":
                        ServingSize = int.Parse(node.InnerText);
                        break;
                    case "Ingredients":
                        XmlNodeList ingredients = node.ChildNodes;
                        foreach (XmlNode inode in ingredients)
                        {
                            if (inode.Name == "Item")
                            {
                                Ingredients.Add(inode.InnerText);
                            }

                        }
                        break;
                    case "CookingInstructions":
                        XmlNodeList cookingInstructions = node.ChildNodes;
                        foreach (XmlNode cinode in cookingInstructions)
                        {
                            if (cinode.Name == "Item")
                            {
                                CookingInstructions.Add(cinode.InnerText);
                            }
                        }
                        break;
                    case "Notes":
                        XmlNodeList notes = node.ChildNodes;
                        foreach (XmlNode nnnode in notes)
                        {
                            if (nnnode.Name == "Item")
                            {
                                Notes.Add(nnnode.InnerText);
                            }
                        }
                        break;
                    case "Resources":
                        XmlNodeList resources = node.ChildNodes;
                        foreach (XmlNode rnode in resources)
                        {
                            if (rnode.Name == "Item")
                            {
                                Resources.Add(rnode.InnerText);
                            }
                        }
                        break;
                    default:
                        break;
                }//end switch
                 
            }//end foreach
        }//end Constructor
        public static bool CompareRecipes(RecipeDataObject r1, RecipeDataObject r2)
        {
            if (r1.Name == r2.Name && r1.Cost == r2.Cost && r1.ServingSize == r2.ServingSize)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }//end Class
}//end Namespace
