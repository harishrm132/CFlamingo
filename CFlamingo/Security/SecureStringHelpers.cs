using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.InteropServices;

namespace CFlamingo
{
    /// <summary>
    /// Helpers for <see cref="SecureString"/> class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecure a <see cref="SecureString"/> to plain text
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString password)
        {
            //Validation
            if (password == null) return string.Empty;

            //Get the Pointer for an unsecure string
            var unmanagedString = IntPtr.Zero;

            try
            {
                //Unsecures the password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //claean up memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
