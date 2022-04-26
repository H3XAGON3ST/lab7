using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IWebDriver driver = new ChromeDriver(); // инициализирую драйвер
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        // Вход в вк через selenium
        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            driver.Navigate().GoToUrl("https://vk.com/");
            driver.FindElement(By.XPath("//*[@id=\"index_email\"]")).SendKeys(Login.Text);
            driver.FindElement(By.XPath("//*[@id=\"index_pass\"]")).SendKeys(Password.Password);
            driver.FindElement(By.XPath("//*[@id=\"index_login_button\"]")).Click();

        }

        // закрытие окна и завершение работы драйвера
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            driver.Close();
            driver.Dispose();

        }

        // сохранение страницы в html
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();

            var stream = client.OpenRead(source.Text);

            var htmlText = "";
            
            using (StreamReader textReader = new StreamReader(stream, Encoding.UTF8, true))
            {
                htmlText = textReader.ReadToEnd();
            }
            File.WriteAllText("page.html", htmlText);
            
        }

        // переход на введенную страницу
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            webbros.Navigate(source.Text);
        }
    }
}
