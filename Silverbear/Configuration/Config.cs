using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Silverbear.Configuration
{
    public class Config
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public String readingXMLFile(String projectName, String ModuleName, String key, String fileName)
        {
            Log.Info("\n Control is inside method : readingXMLFile of Configuration" + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

            try
            {
                string configDir = @"C:\Project\KYC\Configuration\" + fileName;

                Log.Info("Config Directory:=" + configDir + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                String requiredData = null;

                // This is to load the config.xml file

                XmlTextReader reader = new XmlTextReader(configDir);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);

                // Move the control to 'Configuration' node.
                XmlNode node = doc.SelectSingleNode("Configuration");

                XmlNodeList projectNodeList = node.SelectNodes("Project");

                //Iterating through Project node
                foreach (XmlNode tempNode in projectNodeList)
                {
                    //get the value of 'name' attribute of current project node
                    String attribute = tempNode.Attributes["name"].Value;

                    //checking whether the current Project node is the required node
                    if (attribute.Equals(projectName))
                    {
                        Log.Info("Required project node is present" + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                        // get all the child node of Project
                        XmlNodeList moduleNodeList = tempNode.ChildNodes;

                        String eleAttribute = null;

                        //Iterating through Child node of project node
                        foreach (XmlNode tempModuleNode in moduleNodeList)
                        {
                            String attributeOfModuleNode = tempModuleNode.Attributes["name"].Value;

                            if (attributeOfModuleNode.Equals(ModuleName))
                            {
                                XmlNodeList elemnetNodeList = tempModuleNode.ChildNodes;

                                foreach (XmlNode tempElementNode in elemnetNodeList)
                                {
                                    if (fileName.Equals("Config.xml"))
                                    {
                                        eleAttribute = tempElementNode.Attributes["key"].Value;
                                    }
                                    else if (fileName.Equals("SysConfig.xml"))
                                    {
                                        eleAttribute = tempElementNode.Name;
                                    }

                                    if (eleAttribute.Equals(key))
                                    {
                                        requiredData = tempElementNode.InnerText;
                                        break;
                                    }
                                }

                            }

                        }

                    }

                }

                reader.Close();
                reader.Dispose();

                Log.Info("Require Data from config.cs " + requiredData + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());
                return requiredData;
            }
            catch (Exception e)
            {
                Log.Error(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());
                return null;
            }
        }

        // This function returns complete config information from SysConfig.XML
        public List<String> readSysConfigFile(String portal, String moduleName, String fileName)
        {
            Log.Info("\n Control is inside method : readSysConfigFile of Configuration" + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

            try
            {
                List<String> randomDataList = new List<String>();

                //Storing the file path

                //string sysConfigDir = AppDomain.CurrentDomain.BaseDirectory + @"\Configuration\" + fileName;

                string sysConfigDir = @"C:\Project\KYC\Configuration\" + fileName;

                Log.Info("Sys Config Directory:=" + sysConfigDir + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                XmlTextReader reader = new XmlTextReader(sysConfigDir);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);

                // move the control to 'Configuration' node.
                XmlNode node = doc.SelectSingleNode("Configuration");

                // get the all the node of 'Setting' node.
                XmlNodeList SettingeNodeList = node.SelectNodes("Project");

                // Iterating through Module node

                foreach (XmlNode tempSettingNode in SettingeNodeList)
                {
                    //get the value of 'Name' attribute of current Setting node.                    
                    String attribute = tempSettingNode.Attributes["name"].Value;

                    //checking whether the current Module node is the required node
                    if (attribute.Equals(portal))
                    {
                        //get all the child node of Setting node
                        XmlNodeList ModuleNodeList = tempSettingNode.ChildNodes;

                        foreach (XmlNode tempModuleNode in ModuleNodeList)
                        {
                            if ((tempModuleNode.Attributes["name"].Value).Equals(moduleName))
                            {
                                XmlNodeList dataListNodes = tempModuleNode.ChildNodes;   //Getting control of all nodes under our required module node.

                                foreach (XmlNode elementNode in dataListNodes)
                                {
                                    randomDataList.Add(elementNode.InnerText);
                                }
                                break;   //Break tempModuleNode for loop
                            }
                        }

                        break; //Break TempSettingNode for loop
                    }
                }

                reader.Close();
                reader.Dispose();

                return randomDataList;

            }
            catch (Exception e)
            {
                Log.Error(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());
                return null;
            }
        }
        public void writingIntoXML(String portal, String moduleName, string NodeName, string Value, String fileName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                string sysConfigFilePath = @"C:\Project\KYC\Configuration\" + fileName;  //Storing the file path

                xmlDoc.Load(sysConfigFilePath);

                XmlNode node = xmlDoc.SelectSingleNode("Configuration");

                // get the all the node of 'Configuration' node.
                XmlNodeList SettingeNodeList = node.SelectNodes("Project");

                Log.Info("No of Setting Node ::: " + SettingeNodeList.Count + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

                //Iterating through Module node
                foreach (XmlNode tempSettingNode in SettingeNodeList)
                {
                    String attribute = tempSettingNode.Attributes["name"].Value;   //get the value of 'Name' attribute of current Setting node.
                    Console.WriteLine("Name Attribute:: " + attribute);

                    //checking whether the current Module node is the required node
                    if (attribute.Equals(portal))
                    {
                        //get all the child node of Setting node
                        XmlNodeList ModuleNodeList = tempSettingNode.ChildNodes;

                        foreach (XmlNode tempModuleNode in ModuleNodeList)
                        {
                            if ((tempModuleNode.Attributes["name"].Value).Equals(moduleName))
                            {
                                XmlNode requiredNode = tempModuleNode.SelectSingleNode(NodeName);
                                requiredNode.InnerText = Value;
                                break; //Break TempSettingNode for loop
                            }
                        }
                    }

                }
                xmlDoc.Save(sysConfigFilePath);

            }
            catch (Exception e)
            {
                Log.Error(e.Message + "\n" + e.StackTrace + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());
            }

        }
    }
}
