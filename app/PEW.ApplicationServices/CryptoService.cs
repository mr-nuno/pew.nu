﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PEW.Core;
using PEW.Core.Interfaces.ApplicationServices;

namespace PEW.ApplicationServices
{
    public class CryptoService : ICryptoService
    {
        // Define default min and max password lengths.
        private const int DEFAULT_MIN_PASSWORD_LENGTH = 8;
        private const int DEFAULT_MAX_PASSWORD_LENGTH = 10;

        // Define supported password characters divided into groups.
        // You can add (or remove) characters to (from) these groups.
        private const string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        private const string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        private const string PASSWORD_CHARS_NUMERIC = "23456789";
        private const string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";

        // The Initialization Vector for the DES encryption routine
        private static readonly byte[] IV =
            new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        public string CreateHash(int input)
        {
            return CreateHash(input.ToString());
        }

        public string CreateHash(string input)
        {
            var h = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (var i = 0; i < h.Length; i++)
            {
                sBuilder.Append(h[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public bool CompareHash(string input, string hash)
        {
            return CreateHash(input).Equals(hash);
        }

        public bool CompareHash(int input, string hash)
        {
            return CreateHash(input).Equals(hash);
        }

        public string Encrypt(string input)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(input);

            var des = new TripleDESCryptoServiceProvider();
            var MD5 = new MD5CryptoServiceProvider();

            des.Key = MD5.ComputeHash(Encoding.UTF8.GetBytes(ProjectConstants.EncryptionKey));
            des.IV = IV;

            return Convert.ToBase64String(
                des.CreateEncryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length));

        }

        public string Encrypt(int input)
        {
            return Encrypt(input.ToString());
        }

        public string Decrypt(string input)
        {
            byte[] buffer = Convert.FromBase64String(input);

            var des = new TripleDESCryptoServiceProvider();
            var MD5 = new MD5CryptoServiceProvider();

            des.Key = MD5.ComputeHash(Encoding.UTF8.GetBytes(ProjectConstants.EncryptionKey));
            des.IV = IV;

            var encodedString = Encoding.UTF8.GetString(
                des.CreateDecryptor().TransformFinalBlock(
                buffer, 0, buffer.Length));

            return encodedString;

        }

        public string Decrypt(int input)
        {
            return Decrypt(input.ToString());
        }

        /// <summary>
        /// This class can generate random passwords, which do not include ambiguous 
        /// characters, such as I, l, and 1. The generated password will be made of
        /// 7-bit ASCII symbols. Every four characters will include one lower case
        /// character, one upper case character, one number, and one special symbol
        /// (such as '%') in a random order. The password will always start with an
        /// alpha-numeric character; it will not start with a special symbol (we do
        /// this because some back-end systems do not like certain special
        /// characters in the first position). <see cref="http://www.obviex.com/Samples/Password.aspx"/>
        /// </summary>

        /// <returns>A generated strong password</returns>
        public string GeneratePassword()
        {
            return GeneratePassword(DEFAULT_MIN_PASSWORD_LENGTH, DEFAULT_MAX_PASSWORD_LENGTH);
        }

        public string GeneratePassword(int minLength, int maxLength)
        {
            // Make sure that input parameters are valid.
            if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
                return null;

            // Create a local array containing supported password characters
            // grouped by types. You can remove character groups from thisKD
            // array, but doing so will weaken the password strength.
            char[][] charGroups = new char[][] 
            {
                PASSWORD_CHARS_LCASE.ToCharArray(),
                PASSWORD_CHARS_UCASE.ToCharArray(),
                PASSWORD_CHARS_NUMERIC.ToCharArray(),
                PASSWORD_CHARS_SPECIAL.ToCharArray()
            };

            // Use this array to track the number of unused characters in each
            // character group.
            int[] charsLeftInGroup = new int[charGroups.Length];

            // Initially, all characters in each group are not used.
            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;

            // Use this array to track (iterate through) unused character groups.
            int[] leftGroupsOrder = new int[charGroups.Length];

            // Initially, all character groups are not used.
            for (int i = 0; i < leftGroupsOrder.Length; i++)
                leftGroupsOrder[i] = i;

            // Because we cannot use the default randomizer, which is based on the
            // current time (it will produce the same "random" number within a
            // second), we will use a random number generator to seed the
            // randomizer.

            // Use a 4-byte array to fill it with random bytes and convert it then
            // to an integer value.
            byte[] randomBytes = new byte[4];

            // Generate 4 random bytes.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            // Convert 4 bytes into a 32-bit integer value.
            int seed = (randomBytes[0] & 0x7f) << 24 |
                        randomBytes[1] << 16 |
                        randomBytes[2] << 8 |
                        randomBytes[3];

            // Now, this is real randomization.
            Random random = new Random(seed);

            // This array will hold password characters.
            char[] password = null;

            // Allocate appropriate memory for the password.
            if (minLength < maxLength)
                password = new char[random.Next(minLength, maxLength + 1)];
            else
                password = new char[minLength];

            // Index of the next character to be added to password.
            int nextCharIdx;

            // Index of the next character group to be processed.
            int nextGroupIdx;

            // Index which will be used to track not processed character groups.
            int nextLeftGroupsOrderIdx;

            // Index of the last non-processed character in a group.
            int lastCharIdx;

            // Index of the last non-processed group.
            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            // Generate password characters one at a time.
            for (int i = 0; i < password.Length; i++)
            {
                // If only one character group remained unprocessed, process it;
                // otherwise, pick a random character group from the unprocessed
                // group list. To allow a special character to appear in the
                // first position, increment the second parameter of the Next
                // function call by one, i.e. lastLeftGroupsOrderIdx + 1.
                if (lastLeftGroupsOrderIdx == 0)
                    nextLeftGroupsOrderIdx = 0;
                else
                    nextLeftGroupsOrderIdx = random.Next(0,
                                                         lastLeftGroupsOrderIdx);

                // Get the actual index of the character group, from which we will
                // pick the next character.
                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];

                // Get the index of the last unprocessed characters in this group.
                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

                // If only one unprocessed character is left, pick it; otherwise,
                // get a random character from the unused character list.
                if (lastCharIdx == 0)
                    nextCharIdx = 0;
                else
                    nextCharIdx = random.Next(0, lastCharIdx + 1);

                // Add this character to the password.
                password[i] = charGroups[nextGroupIdx][nextCharIdx];

                // If we processed the last character in this group, start over.
                if (lastCharIdx == 0)
                    charsLeftInGroup[nextGroupIdx] =
                                              charGroups[nextGroupIdx].Length;
                // There are more unprocessed characters left.
                else
                {
                    // Swap processed character with the last unprocessed character
                    // so that we don't pick it until we process all characters in
                    // this group.
                    if (lastCharIdx != nextCharIdx)
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] =
                                    charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    // Decrement the number of unprocessed characters in
                    // this group.
                    charsLeftInGroup[nextGroupIdx]--;
                }

                // If we processed the last group, start all over.
                if (lastLeftGroupsOrderIdx == 0)
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                // There are more unprocessed groups left.
                else
                {
                    // Swap processed group with the last unprocessed group
                    // so that we don't pick it until we process all groups.
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] =
                                    leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    // Decrement the number of unprocessed groups.
                    lastLeftGroupsOrderIdx--;
                }
            }

            // Convert password characters into a string and return the result.
            return new string(password);

        }
    }
}
