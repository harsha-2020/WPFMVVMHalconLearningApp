using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVMHalconLearning.DataService
{
    public class ReadRecipe
    {   
        public void GetRecipeValues(string recipeFilePath, dynamic procedureModel)
        {
            string jsonContent = File.ReadAllText(recipeFilePath);
            procedureModel = JsonConvert.DeserializeObject<dynamic>(jsonContent);
        }
    }
}
