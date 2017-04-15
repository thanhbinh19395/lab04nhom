using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab04_Nhom.CryptoExtension
{
    public static class StringExtension
    {
        public static bool IsValidXml(this string value)
        {
            try
            {
                // Check we actually have a value
                if (string.IsNullOrEmpty(value) == false)
                {
                    // Try to load the value into a document
                    XmlDocument xmlDoc = new XmlDocument();

                    xmlDoc.LoadXml(value);

                    // If we managed with no exception then this is valid XML!
                    return true;
                }
                else
                {
                    // A blank value is not valid xml
                    return false;
                }
            }
            catch (System.Xml.XmlException)
            {
                return false;
            }
        }
    }
}
