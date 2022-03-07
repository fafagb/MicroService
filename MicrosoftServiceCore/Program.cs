using System;
using System.Security.AccessControl;

namespace MicrosoftServiceCore {

    class Program {

        static int count;
        static void Main (string[] args) {

            count++;
            string hashId = string.Empty;
            if (count % 2 == 1) { //正面
               hashId = Guid.NewGuid ().ToString ();
            } else {
                //反面

            }
          
        }
    }
}