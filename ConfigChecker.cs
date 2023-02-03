//
// ${Melquiceded Balbi Villanueva}
//
// Author:
//       ${Melquiceded} <${melquiceded.balbi@gmail.com}>
//
// Copyright (c) ${2089} MIT
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.IO;
using QuickTools; 
namespace MCal
{

      /*
            static string[] Arguments { get; set; }
            static string dbVars = "Variables.db";
            static string dbName = "MCal.db";
            static bool IsWithParameters { get; set; }
            static double x;
      */
      public partial class MCalEntry
      {
            const string SettingsFile = "DefaultSettings.xml";
            public static bool LoadDefaultSettings = true; 
            public static void LoadSettings()
            {
                  using (MiniDB db = new MiniDB(SettingsFile, true))
                  {
                        if(db.Load() == false)
                        {
                              db.Create();
                              db.AddKey("LoadDefaultSettings", LoadDefaultSettings);
                              db.AddKey("VariableDBName", dbVars);
                              db.AddKey("HistoryDBName", dbName); 
                              return; 
                        }
                        if(db.SelectWhereKey("LoadDefaultSettings").Count == 0 )
                        {
                              return; 
                        }
                        if (db.SelectWhereKey("LoadDefaultSettings")[0].Value == "True")
                        {
                              return; 
                        }
                        MCalEntry.dbName = db.SelectWhereKey("HistoryDBName")[0].Value; 
                        MCalEntry.dbVars = db.SelectWhereKey("VariableDBName")[0].Value;
                  }
            }
      }
}
