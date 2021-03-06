﻿using LittleSheep.Configuration;
using LittleSheep.Entities;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LittleSheep.Users
{
    public class UserRepository
    {
        public static bool loggedIn = false;
        public static XElement activeUser;

        public bool AddNewUser(User account)
        {
            try
            {
                if (File.Exists(Paths.PathToUsersXml()))
                {
                    var xDocument = XDocument.Load(Paths.PathToUsersXml());
                    var user = xDocument.Element("Users");

                    if (user != null)
                    {
                        user.Add(new XElement("User",
                            new XElement("FirstName", account.FirstName),
                            new XElement("LastName", account.LastName),
                            new XElement("Email", account.Email),
                            new XElement("Street", account.Street),
                            new XElement("ZipCode", account.ZipCode),
                            new XElement("Town", account.Town),
                            new XElement("Password", account.Password)));

                        xDocument.Save(Paths.PathToUsersXml());
                    }
                }
                else
                {
                    var user =
                        new XElement("Users",
                            new XElement("User",
                                new XElement("FirstName", account.FirstName),
                                new XElement("LastName", account.LastName),
                                new XElement("Email", account.Email),
                                new XElement("Street", account.Street),
                                new XElement("ZipCode", account.ZipCode),
                                new XElement("Town", account.Town),
                                new XElement("Password", account.Password)));

                    using (var streamWriter = new StreamWriter(Paths.PathToUsersXml(), true))
                    {
                        user.Save(streamWriter);
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                using (var streamWriter = new StreamWriter(Paths.PathToExceptionLog(), true))
                {
                    streamWriter.WriteLine(DateTime.Now + " " + exception.Message);
                }

                return false;
            }
        }

        public bool LogInToAccount(string email, string password)
        {
            try
            {
                if (File.Exists(Paths.PathToUsersXml()))
                {
                    var xDocument = XDocument.Load(Paths.PathToUsersXml());

                    foreach (var user in xDocument.Descendants("User").Where(aa => aa.Element("Email").Value == email))
                    {
                        if (user.Element("Password").Value == password)
                        {
                            activeUser = user;
                            loggedIn = true;
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception exception)
            {
                using (var streamWriter = new StreamWriter(Paths.PathToExceptionLog(), true))
                {
                    streamWriter.WriteLine(DateTime.Now + " " + exception.Message);
                }

                return false;
            }
        }
    }
}