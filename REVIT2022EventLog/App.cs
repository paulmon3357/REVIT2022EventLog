#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace REVIT2022EventLog
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            // register event
            a.ControlledApplication.DocumentOpened += new EventHandler<DocumentOpenedEventArgs>(DocOpened);
            a.ControlledApplication.DocumentClosing += new EventHandler<DocumentClosingEventArgs>(DocClosing);
            a.ControlledApplication.DocumentSynchronizedWithCentral += new EventHandler<DocumentSynchronizedWithCentralEventArgs>(DocSynchronized);
            a.ControlledApplication.DocumentChanged += new EventHandler<DocumentChangedEventArgs>(DocChanged);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        public void DocOpened(object sender, DocumentOpenedEventArgs args)
        {
            /*TaskDialog.Show("Test", "File opened");*/

            Document doc = args.Document;
            string filePath = doc.PathName;

            string logPath = @"M:\OneDrive - Mon & Associates Inc\Projects\Project Log\revitLog.csv";


            using (StreamWriter writer = File.AppendText(logPath))
            {
                if (File.Exists(logPath))
                {
                    writer.WriteLine("Open" + "," + filePath + "," + Environment.UserName + "," + DateTime.Now.ToString());
                }
                else
                {
                    TaskDialog.Show("Error", "Unable to locate data file " + logPath);
                }
            }
        }

        public void DocClosing(object sender, DocumentClosingEventArgs args)
        {
            /*TaskDialog.Show("Test", "File opened");*/

            Document doc = args.Document;
            string filePath = doc.PathName;

            string logPath = @"M:\OneDrive - Mon & Associates Inc\Projects\Project Log\revitLog.csv";
            using (StreamWriter writer = File.AppendText(logPath))
            {
                if(File.Exists(logPath))
                {
                    writer.WriteLine("Closed" + "," + filePath + "," + Environment.UserName + "," + DateTime.Now.ToString());
                }
                else
                {
                    TaskDialog.Show("Error", "Unable to locate data file " + logPath);
                }
            }
        }

        public void DocSynchronized(object sender, DocumentSynchronizedWithCentralEventArgs args)
        {
            /*TaskDialog.Show("Test", "File opened");*/

            Document doc = args.Document;
            string filePath = doc.PathName;

            string logPath = @"M:\OneDrive - Mon & Associates Inc\Projects\Project Log\revitLog.csv";
            using (StreamWriter writer = File.AppendText(logPath))
            {
                if (File.Exists(logPath))
                {
                    writer.WriteLine("Synchronized" + "," + filePath + "," + Environment.UserName + "," + DateTime.Now.ToString());
                }
                else
                {
                    TaskDialog.Show("Error", "Unable to locate data file " + logPath);
                }
            }
        }

        public void DocChanged(object sender, DocumentChangedEventArgs args)
        {
            /*TaskDialog.Show("Test", "File opened");*/

            Document doc = args.Document;
            string filePath = doc.PathName;

            string logPath = @"M:\OneDrive - Mon & Associates Inc\Projects\Project Log\revitLog.csv";
            using (StreamWriter writer = File.AppendText(logPath))
            {
                if (File.Exists(logPath))
                {
                    writer.WriteLine("Synchronized" + "," + filePath + "," + Environment.UserName + "," + DateTime.Now.ToString());
                }
                else
                {
                    TaskDialog.Show("Error", "Unable to locate data file " + logPath);
                }
            }
        }
    }
}
