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
using QuickTools;
namespace Ccal
{
      internal class Parser
      {

            public void Arguments(string[] args)
            {
                  string input = "";
                  string variableName = Get.IsNumber(args[0]) == false ? args[0] : null;
                  bool isFirstValue = true; 
                  int valA = 0;
                  int valB = 0; 


                  for(int a =0; a<args.Length; a++)
                  {
                        input += args[a]+" ";
                        
                        if(Get.IsNumber(args[a]) == true && isFirstValue == true)
                        {
                              valA = int.Parse(args[a]);
                              isFirstValue = false; 
                        }
                        if (Get.IsNumber(args[a]) == true && isFirstValue == false)
                        {
                              valB = int.Parse(args[a]);
                        }
                      

                  }
                  Get.Green($"Variable {variableName} {valA} {valB}");

            }
           
      }
}