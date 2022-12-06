using System;
using System.DirectoryServices;

namespace SIDHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            // First, we need to establish a connection to Active Directory.
            // Replace "domain.com" with your domain name.
            string ldapPath = "LDAP://domain.com";
            DirectoryEntry directoryEntry = new DirectoryEntry(ldapPath);

            // Next, we need to create a search filter to find the user.
            // Replace "USERNAME" with the user's username.
            string searchFilter = "(&(objectClass=user)(sAMAccountName=USERNAME))";

            // Create a directory searcher using the filter and the directory entry.
            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry, searchFilter);

            // Set the search scope to include all subdirectories.
            directorySearcher.SearchScope = SearchScope.Subtree;

            // Execute the search and get the results.
            SearchResult result = directorySearcher.FindOne();

            // Get the directory entry for the user.
            DirectoryEntry userEntry = result.GetDirectoryEntry();

            // Get the SID history for the user.
            byte[] sidHistory = (byte[])userEntry.Properties["sidHistory"].Value;

            // Print the SID history.
            Console.WriteLine(sidHistory);
        }
    }
}
