using Microsoft.VisualBasic.ApplicationServices;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

class AutomationTesting
{
    static void addUser(string user)
    {
        string email = "a1@gmail.com";
        string password = "a1";

        string testName = "d1";
        string testEmail = "d1@gmail.com";
        string testPassword = "d1";

        // Initialize WebDriver
        IWebDriver driver = new ChromeDriver();

        try
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl("http://localhost:5173/login");

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Wait for the page to load
            Thread.Sleep(2000);

            // Locate the email input field and enter a test email
            IWebElement emailField = driver.FindElement(By.Id("email"));
            emailField.SendKeys(email);

            // Locate the password input field and enter a test password
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);

            // Locate the login button and click it
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            loginButton.Click();

            // Wait to observe the results after clicking login
            Thread.Sleep(3000);

            // Optional: Validate redirection or an error message (based on app's behavior)
            // Example: Check if URL changes or specific text appears
            if (driver.Url.Contains("Dashboard"))
            {
                Console.WriteLine("Login successful: Redirected to dashboard");

                Thread.Sleep(1000);

                driver.Navigate().Refresh();
                IWebElement userManagementButton = driver.FindElement(By.XPath($"//button[contains(@class, 'bg-gradient-to-r') and contains(text(), '{user}')]"));
                userManagementButton.Click();

                Thread.Sleep(1000);

                IWebElement addButton = driver.FindElement(By.CssSelector("button.bg-violet-700"));

                // Click the button
                addButton.Click();

                Thread.Sleep(1000);

                // Locate the Name field and enter data
                IWebElement nameFormField = driver.FindElement(By.Id("name"));
                nameFormField.SendKeys(testName);

                // Locate the Email field and enter data
                IWebElement emailFormField = driver.FindElement(By.Id("email"));
                emailFormField.SendKeys(testEmail);

                // Locate the Password field and enter data
                IWebElement passwordFormField = driver.FindElement(By.Id("password"));
                passwordFormField.SendKeys(testPassword);

                Thread.Sleep(1000);

                // Locate the Add User button and click it
                IWebElement addUserButton = driver.FindElement(By.CssSelector("button[type='submit']"));
                addUserButton.Click();

                Thread.Sleep(2000);

                // Locate all rows in the table body
                var rows = driver.FindElements(By.CssSelector("table tbody tr"));

                // Flag to check if the email exists
                bool emailExists = false;

                // Iterate through each row
                foreach (var row in rows)
                {
                    // Locate the Email column (second column in this case)
                    var emailColumn = row.FindElement(By.CssSelector("td:nth-child(2)"));

                    // Check if the email matches the target email
                    if (emailColumn.Text.Trim() == testEmail)
                    {
                        emailExists = true;
                        MessageBox.Show($"Test Passed: Seller with email {testEmail} exists in the table.");
                        break;
                    }
                }

                if (!emailExists)
                {
                    Console.WriteLine($"Test Failed: Seller with email {testEmail} does not exist in the table.");
                }
            }
            else
            {
                Console.WriteLine("Login failed or no redirection occurred.");
            }
            Console.ReadLine();
        }
        finally
        {
            // Close the browser
            driver.Quit();
        }
    }

    static void updateUser(string user)
    {
        string email = "a1@gmail.com";
        string password = "a1";

        string targetEmail = "d1@gmail.com";

        string usernameToUpdate = "Danish";
        string passwordToUpdate = "ddd";
        string[] selectedGenresToUpdate = { "Action", "Comedy" };

        // Initialize WebDriver
        IWebDriver driver = new ChromeDriver();

        try
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl("http://localhost:5173/login");

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Wait for the page to load
            Thread.Sleep(2000);

            // Locate the email input field and enter a test email
            IWebElement emailField = driver.FindElement(By.Id("email"));
            emailField.SendKeys(email);

            // Locate the password input field and enter a test password
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);

            // Locate the login button and click it
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            loginButton.Click();

            // Wait to observe the results after clicking login
            Thread.Sleep(3000);

            // Optional: Validate redirection or an error message (based on app's behavior)
            // Example: Check if URL changes or specific text appears
            if (driver.Url.Contains("Dashboard"))
            {
                Console.WriteLine("Login successful: Redirected to dashboard");

                Thread.Sleep(1000);

                driver.Navigate().Refresh();
                IWebElement userManagementButton = driver.FindElement(By.XPath($"//button[contains(@class, 'bg-gradient-to-r') and contains(text(), '{user}')]"));
                userManagementButton.Click();

                Thread.Sleep(1000);

                // Locate the table body
                var tableRows = driver.FindElements(By.XPath("//table/tbody/tr"));

                // Loop through rows to find the matching email
                foreach (var row in tableRows)
                {
                    var emailCell = row.FindElement(By.XPath("./td[2]")); // Email column is the second <td>
                    if (emailCell.Text.Equals(targetEmail, StringComparison.OrdinalIgnoreCase))
                    {
                        // If email matches, find and click the Update button
                        var updateButton = row.FindElement(By.XPath(".//button[contains(text(), 'Update')]"));
                        updateButton.Click();

                        Console.WriteLine($"Clicked the Update button for email: {targetEmail}");
                        break;
                    }
                }

                // Wait for the form to load
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                // Fill in the Name field
                var nameFieldToUpdate = wait.Until(e => e.FindElement(By.Id("name")));
                nameFieldToUpdate.Clear();
                nameFieldToUpdate.SendKeys(usernameToUpdate);

                // Fill in the Password field
                var passwordFieldToUpdate = driver.FindElement(By.Id("password"));
                passwordFieldToUpdate.Clear();
                passwordFieldToUpdate.SendKeys(passwordToUpdate);

                // Select genres from the dropdown
                var genreDropdown = driver.FindElement(By.Id("genre"));

                // Get all <option> elements within the dropdown
                var options = genreDropdown.FindElements(By.TagName("option"));

                // Deselect all options (if multiple selection is supported)
                foreach (var option in options)
                {
                    if (option.Selected)
                    {
                        option.Click(); // Deselect the option
                    }
                }

                // Select the desired genres
                foreach (string genre in selectedGenresToUpdate)
                {
                    foreach (var option in options)
                    {
                        if (option.GetDomAttribute("value") == genre) // Use GetDomAttribute instead of GetAttribute
                        {
                            option.Click(); // Select the option
                            break;
                        }
                    }
                }

                // Click the Update User button
                var submitButton = driver.FindElement(By.XPath("//button[contains(text(), 'Update User')]"));
                submitButton.Click();

                Thread.Sleep(2000);

                // Locate all rows in the table body
                var rows = driver.FindElements(By.CssSelector("table tbody tr"));

                // Flag to check if the email exists
                bool isUpdated = false;

                // Iterate through each row
                foreach (var row in rows)
                {
                    // Locate the Email column (second column in this case)
                    var emailColumn = row.FindElement(By.CssSelector("td:nth-child(2)"));

                    // Check if the email matches the target email
                    if (emailColumn.Text.Trim() == targetEmail)
                    {
                        var nameColumn = row.FindElement(By.CssSelector("td:nth-child(1)"));

                        if (nameColumn.Text == usernameToUpdate)
                        {
                            isUpdated = true;
                            MessageBox.Show($"Test Passed: Seller with email {targetEmail} updated.");
                            break;
                        }
                    }
                }

                if (!isUpdated)
                {
                    Console.WriteLine($"Test Failed: Seller with email {targetEmail} does not updated.");
                }
            }
            else
            {
                Console.WriteLine("Login failed or no redirection occurred.");
            }
            Console.ReadLine();
        }
        finally
        {
            // Close the browser
            driver.Quit();
        }
    }

    static void deleteUser(string user)
    {
        string email = "a1@gmail.com";
        string password = "a1";

        string targetEmail = "d1@gmail.com";

        // Initialize WebDriver
        IWebDriver driver = new ChromeDriver();

        try
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl("http://localhost:5173/login");

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Wait for the page to load
            Thread.Sleep(2000);

            // Locate the email input field and enter a test email
            IWebElement emailField = driver.FindElement(By.Id("email"));
            emailField.SendKeys(email);

            // Locate the password input field and enter a test password
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);

            // Locate the login button and click it
            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            loginButton.Click();

            // Wait to observe the results after clicking login
            Thread.Sleep(3000);

            // Optional: Validate redirection or an error message (based on app's behavior)
            // Example: Check if URL changes or specific text appears
            if (driver.Url.Contains("Dashboard"))
            {
                Console.WriteLine("Login successful: Redirected to dashboard");

                Thread.Sleep(1000);

                driver.Navigate().Refresh();
                IWebElement userManagementButton = driver.FindElement(By.XPath($"//button[contains(@class, 'bg-gradient-to-r') and contains(text(), '{user}')]"));
                userManagementButton.Click();

                Thread.Sleep(1000);

                // Locate the table body
                var tableRows = driver.FindElements(By.XPath("//table/tbody/tr"));

                // Loop through rows to find the matching email
                foreach (var row in tableRows)
                {
                    var emailCell = row.FindElement(By.XPath("./td[2]")); // Email column is the second <td>
                    if (emailCell.Text.Equals(targetEmail, StringComparison.OrdinalIgnoreCase))
                    {
                        // If email matches, find and click the Update button
                        var updateButton = row.FindElement(By.XPath(".//button[contains(text(), 'Delete')]"));
                        updateButton.Click();

                        Console.WriteLine($"Clicked the Delete button for email: {targetEmail}");
                        break;
                    }
                }

                Thread.Sleep(2000);

                // Locate all rows in the table body
                var rows = driver.FindElements(By.CssSelector("table tbody tr"));

                // Flag to check if the email exists
                bool isDeleted = true;

                // Iterate through each row
                foreach (var row in rows)
                {
                    // Locate the Email column (second column in this case)
                    var emailColumn = row.FindElement(By.CssSelector("td:nth-child(2)"));

                    // Check if the email matches the target email
                    if (emailColumn.Text.Trim() == targetEmail)
                    {
                        isDeleted = false;
                        Console.WriteLine($"Test Failed: Seller with email {targetEmail} does not deleted.");
                        break;
                    }
                }

                if (isDeleted)
                {
                    MessageBox.Show($"Test Passed: Seller with email {targetEmail} deleted.");
                }
            }
            else
            {
                Console.WriteLine("Login failed or no redirection occurred.");
            }
            Console.ReadLine();
        }
        finally
        {
            // Close the browser
            driver.Quit();
        }
    }


    static void Main(string[] args)
    {
        addUser("User Management");

        updateUser("User Management");

        deleteUser("User Management");
    }
}