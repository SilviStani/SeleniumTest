using NUnit.Framework; //libreria q utilizamos
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace primertraining;

public class Tests
{

public IWebDriver driver;

By searchBox = By.Name("q");

By firstResult= By.CssSelector("#rso > div:nth-child(1) > div > div > div > div > div > div > div > div.yuRUbf > a > h3");

By title = By.TagName("title");
//
//  ********* heroku **********
By unLogged = By.Id("loginBTN");
By notLogged = By.Id("notLoggedTitleTXT");
By clickLoggin = By.Id("notLoggedScreen");
By link1= By.ClassName("navbar-brand");
By link2 = By.ClassName("navbar-brand");
By footer = By.ClassName("footerClass");
By emailBox = By.Name("username");
By password = By.Name("password");
By showPassword = By.XPath("/html/body/div/main/section/div/div[2]/div/form/div[1]/div/div[2]/div/button");
By logOut = By.Id("logoutBTN");
By avatar = By.XPath("//*[@id='profileTXT']");
By avatarImg = By.Id("profileIMG");
By header = By.XPath("//*[@id='root']/div/div[1]");
By lIpsum = By.ClassName("navbar-brand");
By notice = By.Id("news");
By hidden = By.CssSelector("div .jumbotron :nth-child(1)");
By loremIpsum = By.CssSelector("div #objaccordian :nth-child(1)");
By whyWeUseLI = By.CssSelector("div #objaccordian :nth-child(2)");
By whereComeLI = By.CssSelector("div #objaccordian :nth-child(3)");
By whereGetLI = By.CssSelector("div #objaccordian :nth-child(4)");
By  youTube = By.LinkText("Watch Videos");
By faceBook = By.LinkText("Post Something");
By selenium = By.LinkText("Automate It!");
By linkForm = By.LinkText("Testing Forms"); 

// ***** Manipulating the forms *****
By inputName = By.XPath("//*[@id='TXTUser']");


    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    
    [Test]
    public void SeleniumTest()
    {
        driver.Navigate().GoToUrl("https://www.google.com.ar");
        Assert.AreEqual("Google", driver.Title ); //verificaciones
        Assert.AreEqual(true, driver.FindElement(searchBox).Displayed); //verificaciones
        driver.FindElement(searchBox).SendKeys("Selenium");
        Thread.Sleep(3000);
        driver.FindElement(searchBox).SendKeys(Keys.Enter);
        driver.FindElement(firstResult).Click();
        Thread.Sleep(3000);
        Assert.AreEqual("Selenium" , driver.Title); 
    }

    [Test]
    public void HerokuTest(){
        driver.Navigate().GoToUrl("https://testappautomation.herokuapp.com");
        Assert.AreEqual("Home Page" , driver.Title); 
        Assert.AreEqual(true, driver.FindElement(unLogged).Displayed); 
        Assert.AreEqual("Welcome to my Automation Testing Site" , driver.FindElement(notLogged).Text);
        Assert.AreEqual("Please click Login button to log into the application or sign up!" , driver.FindElement(clickLoggin).Text);
        Assert.AreEqual(true , driver.FindElement(link1).Displayed);
        Assert.AreEqual(true , driver.FindElement(link2).Displayed);
        Assert.AreEqual(false, driver.FindElement(link1).Enabled);
        Assert.AreEqual(false, driver.FindElement(link2).Enabled);
        Thread.Sleep(3000);
    } 
    
    [Test]
    public void FooterinPlace() {
        driver.Navigate().GoToUrl("https://testappautomation.herokuapp.com");
        Assert.AreEqual("fixed", driver.FindElement(footer).GetCssValue("position"));
        Assert.AreEqual("Disclaimer: This project is a personal site meant to be used as a help test site to be able to perform some automation test on demand.", driver.FindElement(footer).Text);
        
    }

    [Test]
    public void HerokuSignIn() {
        driver.Navigate().GoToUrl("https://testappautomation.herokuapp.com");
        Thread.Sleep(1500);
        driver.FindElement(unLogged).Click();
        Assert.AreEqual(true, driver.FindElement(emailBox).Displayed);
        Assert.AreEqual(true, driver.FindElement(password).Displayed);
        driver.FindElement(password).SendKeys("password");
        Assert.AreEqual(true, driver.FindElement(By.Name("action")).Displayed);
        driver.FindElement(showPassword).Click();
        Thread.Sleep(1500);
        driver.FindElement(By.Name("action")).Click();
        Thread.Sleep(3000);
        driver.FindElement(By.Id("username")).SendKeys("Password");
        Thread.Sleep(1500);
        driver.FindElement(password).Clear();
        driver.FindElement(showPassword).Click();
        driver.FindElement(By.Name("action")).Click();
        Thread.Sleep(3000);
        driver.FindElement(emailBox).Clear();
        driver.FindElement(emailBox).SendKeys("silvina.stani@gmail.com");
        Thread.Sleep(1500);
        driver.FindElement(password).SendKeys("1234Pqow");
        Thread.Sleep(2000);
        driver.FindElement(By.Name("action")).Click();
        Thread.Sleep(5000);
        Assert.AreEqual(true , driver.FindElement(logOut).Displayed);
        Assert.AreEqual("Welcome silvina.stani !", driver.FindElement(avatar).Text);
        Assert.AreEqual(true, driver.FindElement(avatarImg).Displayed);
}

    [Test]
public void Herokulogin () {
    driver.Navigate().GoToUrl("https://testappautomation.herokuapp.com");
    Thread.Sleep(1500);
    driver.FindElement(unLogged).Click();
    Thread.Sleep(1500);
    driver.FindElement(emailBox).SendKeys("silvina.stani@gmail.com");
    driver.FindElement(password).SendKeys("1234Pqow");
    driver.FindElement(By.Name("action")).Click();
    Thread.Sleep(3000);
    Assert.AreEqual("block", driver.FindElement(header).GetCssValue("display"));
    Assert.AreEqual("fixed", driver.FindElement(footer).GetCssValue("position"));
    Thread.Sleep(1500);
    Assert.AreEqual(true, driver.FindElement(lIpsum).Displayed);
    driver.FindElement(lIpsum).Click();
    Thread.Sleep(5000);
    Assert.AreEqual("Notice: This is a testing site meant to be used for automation test trainings", driver.FindElement(notice).Text);
    Assert.AreEqual( false , driver.FindElement(hidden).Displayed);
    Assert.AreEqual("Lorem Ipsum Page", driver.Title);
    Assert.AreEqual( true,  driver.FindElement(loremIpsum).Displayed);
    Assert.AreEqual( true , driver.FindElement(whyWeUseLI).Displayed);
    Assert.AreEqual( true , driver.FindElement(whereComeLI).Displayed);
    Assert.AreEqual( true , driver.FindElement(whereGetLI).Displayed);
    Assert.AreEqual(true, driver.FindElement(faceBook).Displayed);
    Assert.AreEqual("Watch Videos", driver.FindElement(youTube).Text);
    Assert.AreEqual(true, driver.FindElement(selenium).Displayed);
    Assert.AreEqual( driver.FindElement(hidden).Text , "");
    Assert.AreEqual("_self" , driver.FindElement(faceBook).GetAttribute("target"));
    Assert.AreEqual("_self" , driver.FindElement(selenium).GetAttribute("target"));
    Assert.AreEqual("_self" , driver.FindElement(youTube).GetAttribute("target"));
}

    
    [Test]

    public void FormsManipulate() {
            driver.Navigate().GoToUrl("https://testappautomation.herokuapp.com");
            Thread.Sleep(1500);
            driver.FindElement(unLogged).Click();
            Thread.Sleep(1500);
            driver.FindElement(emailBox).SendKeys("silvina.stani@gmail.com");
            driver.FindElement(password).SendKeys("1234Pqow");
            driver.FindElement(By.Name("action")).Click();
            Thread.Sleep(3000);
            driver.FindElement(linkForm).Click();
            Thread.Sleep(7000);
            Assert.AreEqual("block", driver.FindElement(header).GetCssValue("display"));
            Assert.AreEqual("fixed", driver.FindElement(footer).GetCssValue("position"));
            Assert.AreEqual("Forms Page" , driver.Title);
            Assert.AreEqual(true , driver.FindElement(inputName).Displayed);
            driver.FindElement(inputName).SendKeys("Luciano");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TXTPass")).SendKeys("Staniszewski");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TXTNick")).SendKeys("Sucio");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TXTEmail")).SendKeys("luciano.stani@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TXTUrl")).SendKeys("lucianostanisz.com.ar");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TXTMobile")).SendKeys("1133334455");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TXTAbout")).SendKeys("no imagination at all");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("SELTitle")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.XPath("//*[@id='SELTitle']/option[1]")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("RADButDevYes")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("BTNSubmit")).Click();
            Thread.Sleep(2500);
            Assert.AreEqual("Results Page", driver.Title);
            Thread.Sleep(1000);
            driver.FindElement(logOut).Click();
            Assert.AreEqual(true, driver.FindElement(unLogged).Displayed);

    }




    [TearDown]
    public void TearDown(){
      //driver.Close();
      //driver.Quit();
    }


}