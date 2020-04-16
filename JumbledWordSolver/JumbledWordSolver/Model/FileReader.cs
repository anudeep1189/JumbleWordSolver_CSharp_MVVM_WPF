using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace JumbledWordSolver.Model
{
    /// <summary>
    /// generic file reader class
    /// </summary>
    class FileReader
    {
        /// <summary>
        /// read the dictonary file and load it into the string array
        /// </summary>
        /// <param name="dictonaryLocation">location of the dictionary file</param>
        /// <returns>string array containing the content of file</returns>
        public string[] Read(string dictonaryLocation)
        {
            string[] fileContent;
            try
            {  
                    fileContent = File.ReadAllLines(dictonaryLocation);
                    return fileContent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
